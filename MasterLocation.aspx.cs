using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App_Code;
using System.Data;

public partial class MasterLocation : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    SqlPavanCourier cn = new SqlPavanCourier();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["loginid"].Value == "" || Request.Cookies["branchid"].Value == null)
        {
            Response.Redirect("login.aspx");
        }
        txtlocationcode.Focus();
        if (Session["Msg"] != null)
        {
            lblsucess.Text = Session["Msg"].ToString();
            divsucess.Visible = true;
            Session["Msg"] = null;
        }

        try
        {
            if (IsPostBack == false)
            {

                ds = cn.RunSql("sp_usermanagement '" + Request.Cookies["branchid"].Value + "','" + Request.Cookies["loginid"].Value + "'", "select");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["cLocation"].ToString().Substring(0, 1) != "1")
                    {
                        Response.Redirect("home.aspx");
                    }
                    if (ds.Tables[0].Rows[0]["cLocation"].ToString().Substring(1, 1) != "1" && ds.Tables[0].Rows[0]["cLocation"].ToString().Substring(2, 1) != "1" && ds.Tables[0].Rows[0]["cLocation"].ToString().Substring(3, 1) != "1")
                    {
                        btnlist.Visible = false;
                    }
                }


                ds = cn.RunSql("sp_getsrno 'loc','" + Request.Cookies["branchid"].Value + "'", "select");
                txtsrno.Text = ds.Tables[0].Rows[0]["nsrno"] != DBNull.Value ? ds.Tables[0].Rows[0]["nsrno"].ToString() : "";

                if (Request.QueryString["id"] != null)
                {
                    ds = cn.RunSql("sp_listlocation 's','" + Request.Cookies["compid"].Value + "','" + Request.QueryString["id"] + "'", "search");
                    txtsrno.Text = ds.Tables[0].Rows[0]["nsrno"] != DBNull.Value ? ds.Tables[0].Rows[0]["nsrno"].ToString() : "";
                    txtlocationcode.Text = ds.Tables[0].Rows[0]["cLocationCode"] != DBNull.Value ? ds.Tables[0].Rows[0]["cLocationCode"].ToString() : "";
                    txtlocationname.Text = ds.Tables[0].Rows[0]["cLocationName"] != DBNull.Value ? ds.Tables[0].Rows[0]["cLocationName"].ToString() : "";
                    txtzone.Text = ds.Tables[0].Rows[0]["zonename"] != DBNull.Value ? ds.Tables[0].Rows[0]["zonename"].ToString() : "";
                    HifZone.Value = ds.Tables[0].Rows[0]["cZone"] != DBNull.Value ? ds.Tables[0].Rows[0]["cZone"].ToString() : "";  

                    if (Request.QueryString["D"] == "1")
                    {
                        ddldelete.Visible = true;
                        btnsubmit.Text = "Delete";
                    }
                }
            }
        }
        catch (Exception ex)
        {
            lblerror.Text = ex.Message;
            diverror.Visible = true;
        }
        finally
        {
            ds.Dispose();
        }

    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString["id"] != null)
            {
                if (Request.QueryString["E"] == "1")
                {
                    ds = cn.RunSql("sp_addlocationmaster 'U','" + txtsrno.Text + "','" + txtlocationcode.Text + "','" + txtlocationname.Text + "','" + HifZone.Value + "','" + Request.Cookies["compid"].Value + "','" + Request.Cookies["loginid"].Value + "','" + Request.QueryString["id"] + "','" + Request.Cookies["branchid"].Value + "'", "insert");
                    Session["Msg"] = "You have sucessfully Update Location !!";
                    Response.Redirect("ListLocation.aspx");
                }
                if (Request.QueryString["D"] == "1")
                {
                    if (ddldelete.SelectedValue == "Yes")
                    {
                        ds = cn.RunSql("sp_addlocationmaster 'D','" + txtsrno.Text + "','" + txtlocationcode.Text + "','" + txtlocationname.Text + "','" + HifZone.Value + "','" + Request.Cookies["compid"].Value + "','" + Request.Cookies["loginid"].Value + "','" + Request.QueryString["id"] + "','" + Request.Cookies["branchid"].Value + "'", "insert");
                        Session["Msg"] = "You have sucessfully Delete Location !!";
                        Response.Redirect("ListLocation.aspx");
                    }
                }
            }
            else
            {
                ds = cn.RunSql("sp_addlocationmaster 'I','" + txtsrno.Text + "','" + txtlocationcode.Text + "','" + txtlocationname.Text + "','" + HifZone.Value + "','" + Request.Cookies["compid"].Value + "','" + Request.Cookies["loginid"].Value + "','','"+ Request.Cookies["branchid"].Value +"'", "insert");
                Session["Msg"] = "You have sucessfully insert Location !!";
                Response.Redirect("MasterLocation.aspx");
            }
        }
        catch (Exception ex)
        {
            lblerror.Text = ex.Message;
            diverror.Visible = true;
        }

        finally
        {
            ds.Dispose();
        }
    }
    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static List<string> SearchZone(string prefixText, int count)
    {
        DataSet ds = new DataSet();
        SqlPavanCourier cn = new SqlPavanCourier();
        List<string> zone = new List<string>();
        string cnm = "";
        ds = cn.RunSql("sp_Searchforautocomplete 'ZB','" + prefixText + "','" + HttpContext.Current.Request.Cookies["compid"].Value + "','" + HttpContext.Current.Request.Cookies["branchid"].Value + "'", "select");
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cnm = AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(ds.Tables[0].Rows[i]["cZoneName"].ToString(), ds.Tables[0].Rows[i]["nid"].ToString());
                zone.Add(cnm);
            }
        }

        return zone;
    }
    protected void btnlist_Click(object sender, EventArgs e)
    {
        Response.Redirect("ListLocation.aspx");
    }
    protected void btnreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("MasterLocation.aspx");
    }
}