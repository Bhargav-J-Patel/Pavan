using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App_Code;
using System.Data;

public partial class MasterDeliveryRoute : System.Web.UI.Page
{

    DataSet ds = new DataSet();
    SqlPavanCourier cn = new SqlPavanCourier();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["loginid"].Value == "" || Request.Cookies["branchid"].Value == null)
        {
            Response.Redirect("login.aspx");
        }
        txtdeliveryroutecode.Focus();
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
                    if (ds.Tables[0].Rows[0]["cDeliveryRoute"].ToString().Substring(0, 1) != "1")
                    {
                        Response.Redirect("home.aspx");
                    }
                    if (ds.Tables[0].Rows[0]["cDeliveryRoute"].ToString().Substring(1, 1) != "1" && ds.Tables[0].Rows[0]["cDeliveryRoute"].ToString().Substring(2, 1) != "1" && ds.Tables[0].Rows[0]["cDeliveryRoute"].ToString().Substring(3, 1) != "1")
                    {
                        btnlist.Visible = false;
                    }
                }


                ds = cn.RunSql("sp_getsrno 'devroute','" + Request.Cookies["branchid"].Value + "','" + Request.Cookies["loginid"].Value + "'", "select");
                txtsrno.Text = ds.Tables[0].Rows[0]["nsrno"] != DBNull.Value ? ds.Tables[0].Rows[0]["nsrno"].ToString() : "";

                if (Request.QueryString["id"] != null)
                {
                    ds = cn.RunSql("sp_listdeliveryroute 's','" + Request.Cookies["compid"].Value + "','" + Request.QueryString["id"] + "'", "search");
                    txtsrno.Text = ds.Tables[0].Rows[0]["nsrno"] != DBNull.Value ? ds.Tables[0].Rows[0]["nsrno"].ToString() : "";
                    txtdeliveryroutecode.Text = ds.Tables[0].Rows[0]["cDeliveryCode"] != DBNull.Value ? ds.Tables[0].Rows[0]["cDeliveryCode"].ToString() : "";
                    txtdeliveryroutename.Text = ds.Tables[0].Rows[0]["cDeliveryName"] != DBNull.Value ? ds.Tables[0].Rows[0]["cDeliveryName"].ToString() : "";
                    txtlocation.Text = ds.Tables[0].Rows[0]["cLocationName"] != DBNull.Value ? ds.Tables[0].Rows[0]["cLocationName"].ToString() : "";
                    HifLocation.Value = ds.Tables[0].Rows[0]["cLocationID"] != DBNull.Value ? ds.Tables[0].Rows[0]["cLocationID"].ToString() : "";

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
                    ds = cn.RunSql("sp_adddeliveryroutemaster 'U','" + txtsrno.Text + "','" + txtdeliveryroutecode.Text + "','" + txtdeliveryroutename.Text + "','" + HifLocation.Value + "','" + Request.Cookies["compid"].Value + "','" + Request.Cookies["loginid"].Value + "','" + Request.QueryString["id"] + "','" + Request.Cookies["branchid"].Value + "'", "insert");
                    Session["Msg"] = "You have sucessfully Update Delivery Route !!";
                    Response.Redirect("ListDeliveryRoute.aspx");
                }
                if (Request.QueryString["D"] == "1")
                {
                    if (ddldelete.SelectedValue == "Yes")
                    {
                        ds = cn.RunSql("sp_adddeliveryroutemaster 'D','" + txtsrno.Text + "','" + txtdeliveryroutecode.Text + "','" + txtdeliveryroutename.Text + "','" + HifLocation.Value + "','" + Request.Cookies["compid"].Value + "','" + Request.Cookies["loginid"].Value + "','" + Request.QueryString["id"] + "','" + Request.Cookies["branchid"].Value + "'", "insert");
                        Session["Msg"] = "You have sucessfully Delete Delivery Route !!";
                        Response.Redirect("ListDeliveryRoute.aspx");
                    }
                }
            }
            else
            {
                ds = cn.RunSql("sp_adddeliveryroutemaster 'I','" + txtsrno.Text + "','" + txtdeliveryroutecode.Text + "','" + txtdeliveryroutename.Text + "','" + HifLocation.Value + "','" + Request.Cookies["compid"].Value + "','" + Request.Cookies["loginid"].Value + "','','" + Request.Cookies["branchid"].Value + "'", "insert");
                Session["Msg"] = "You have sucessfully insert Delivery Route !!";
                Response.Redirect("MasterDeliveryRoute.aspx");
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
    protected void btnreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("MasterDeliveryRoute.aspx");
    }
    protected void btnlist_Click(object sender, EventArgs e)
    {
        Response.Redirect("ListDeliveryRoute.aspx");
    }
    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static List<string> SearchLocation(string prefixText, int count)
    {
        DataSet ds = new DataSet();
        SqlPavanCourier cn = new SqlPavanCourier();
        List<string> loc = new List<string>();
        string cnm = "";
        ds = cn.RunSql("sp_Searchforautocomplete 'LOC','" + prefixText + "','" + HttpContext.Current.Request.Cookies["compid"].Value + "','" + HttpContext.Current.Request.Cookies["branchid"].Value + "'", "select");
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cnm = AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(ds.Tables[0].Rows[i]["cLocationName"].ToString(), ds.Tables[0].Rows[i]["nid"].ToString());
                loc.Add(cnm);
            }
        }

        return loc;
    }
}