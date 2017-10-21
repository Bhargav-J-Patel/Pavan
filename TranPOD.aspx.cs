using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App_Code;
using System.Data;


public partial class TranPOD : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    SqlPavanCourier cn = new SqlPavanCourier();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["loginid"].Value == "" || Request.Cookies["branchid"].Value == null)
        {
            Response.Redirect("login.aspx");
        }

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
                    if (ds.Tables[0].Rows[0]["cPOD"].ToString().Substring(0, 1) != "1")
                    {
                        Response.Redirect("home.aspx");
                    }
                    if (ds.Tables[0].Rows[0]["cPOD"].ToString().Substring(1, 1) != "1" && ds.Tables[0].Rows[0]["cPOD"].ToString().Substring(2, 1) != "1" && ds.Tables[0].Rows[0]["cPOD"].ToString().Substring(3, 1) != "1")
                    {
                        btnlist.Visible = false;
                    }
                }

                if (Request.QueryString["id"] != null)
                {
                    ds = cn.RunSql("sp_listpod 's','" + Request.Cookies["compid"].Value + "','" + Request.QueryString["id"] + "'", "search");
                    txtawbno.Text = ds.Tables[0].Rows[0]["cAwbno"] != DBNull.Value ? ds.Tables[0].Rows[0]["cAwbno"].ToString() : "";
                    txtorigin.Text = ds.Tables[0].Rows[0]["cOrigin"] != DBNull.Value ? ds.Tables[0].Rows[0]["cOrigin"].ToString() : "";
                    txtlocation.Text = ds.Tables[0].Rows[0]["cLocation"] != DBNull.Value ? ds.Tables[0].Rows[0]["cLocation"].ToString() : "";
                    txtbookdatetime.Text = ds.Tables[0].Rows[0]["bkdt"] != DBNull.Value ? ds.Tables[0].Rows[0]["bkdt"].ToString() : "";
                    txtcustomer.Text = ds.Tables[0].Rows[0]["cCusName"] != DBNull.Value ? ds.Tables[0].Rows[0]["cCusName"].ToString() : "";
                    txtproduct.Text = ds.Tables[0].Rows[0]["cProduct"] != DBNull.Value ? ds.Tables[0].Rows[0]["cProduct"].ToString() : "";
                    txtdrsno.Text = ds.Tables[0].Rows[0]["cDRSNo"] != DBNull.Value ? ds.Tables[0].Rows[0]["cDRSNo"].ToString() : "";
                    txtmanifestno.Text = ds.Tables[0].Rows[0]["cManifestNo"] != DBNull.Value ? ds.Tables[0].Rows[0]["cManifestNo"].ToString() : "";
                    txtstatus.Text = ds.Tables[0].Rows[0]["statusnm"] != DBNull.Value ? ds.Tables[0].Rows[0]["statusnm"].ToString() : "";
                    txtdeldate.Text = ds.Tables[0].Rows[0]["deldt"] != DBNull.Value ? ds.Tables[0].Rows[0]["deldt"].ToString() : "";
                    txtrecname.Text = ds.Tables[0].Rows[0]["cRecName"] != DBNull.Value ? ds.Tables[0].Rows[0]["cRecName"].ToString() : "";
                    txtremark.Text = ds.Tables[0].Rows[0]["cRemark"] != DBNull.Value ? ds.Tables[0].Rows[0]["cRemark"].ToString() : "";
                    txtphoneno.Text = ds.Tables[0].Rows[0]["cphoneno"] != DBNull.Value ? ds.Tables[0].Rows[0]["cphoneno"].ToString() : "";
                    txtvendor1.Text = ds.Tables[0].Rows[0]["cvendor1"] != DBNull.Value ? ds.Tables[0].Rows[0]["cvendor1"].ToString() : "";
                    txtvendor2.Text = ds.Tables[0].Rows[0]["cvendor2"] != DBNull.Value ? ds.Tables[0].Rows[0]["cvendor2"].ToString() : "";
                    HifStatus.Value = ds.Tables[0].Rows[0]["cStatus"] != DBNull.Value ? ds.Tables[0].Rows[0]["cStatus"].ToString() : "";

                    if (Request.QueryString["D"] != null)
                    {
                        ddldelete.Visible = true;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            lblerror.Text = ex.Message;
            diverror.Visible = true;
        }
    }
    protected void btnlist_Click(object sender, EventArgs e)
    {
        Response.Redirect("ListPOD.aspx");
    }

    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static List<string> SearchStatus(string prefixText, int count)
    {
        DataSet ds = new DataSet();
        SqlPavanCourier cn = new SqlPavanCourier();
        List<string> loc = new List<string>();
        string cnm = "";
        ds = cn.RunSql("sp_Searchforautocomplete 'statusUser','" + prefixText + "','" + HttpContext.Current.Request.Cookies["compid"].Value + "','" + HttpContext.Current.Request.Cookies["branchid"].Value + "','" + HttpContext.Current.Request.Cookies["loginid"].Value + "'", "select");
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cnm = AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(ds.Tables[0].Rows[i]["statusnm"].ToString(), ds.Tables[0].Rows[i]["nid"].ToString());
                loc.Add(cnm);
            }
        }
        return loc;
    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString["id"] != null)
            {
                if (Request.QueryString["E"] == "1")
                {
                    ds = cn.RunSql("sp_addPODTran 'U','" + txtawbno.Text + "','" + txtorigin.Text + "','" + txtlocation.Text + "','" + txtbookdatetime.Text + "','" + txtcustomer.Text + "','" + txtproduct.Text + "','" + txtdrsno.Text + "','" + txtmanifestno.Text + "','" + HifStatus.Value + "','" + txtdeldate.Text + "','" + txtrecname.Text + "','" + txtremark.Text + "','" + txtphoneno.Text + "','" + txtvendor1.Text + "','" + txtvendor2.Text + "','" + Request.Cookies["branchid"].Value + "','" + Request.Cookies["compid"].Value + "','" + Request.QueryString["id"] + "','" + Request.Cookies["loginid"].Value + "'", "insert");
                    Session["Msg"] = "You have sucessfully Update POD !!";
                    Response.Redirect("ListPOD.aspx");
                }
                if (Request.QueryString["D"] == "1")
                {
                    if (ddldelete.SelectedValue == "Yes")
                    {
                        ds = cn.RunSql("sp_addPODTran 'D','" + txtawbno.Text + "','" + txtorigin.Text + "','" + txtlocation.Text + "','" + txtbookdatetime.Text + "','" + txtcustomer.Text + "','" + txtproduct.Text + "','" + txtdrsno.Text + "','" + txtmanifestno.Text + "','" + HifStatus.Value + "','" + txtdeldate.Text + "','" + txtrecname.Text + "','" + txtremark.Text + "','" + txtphoneno.Text + "','" + txtvendor1.Text + "','" + txtvendor2.Text + "','" + Request.Cookies["branchid"].Value + "','" + Request.Cookies["compid"].Value + "','" + Request.QueryString["id"] + "','" + Request.Cookies["loginid"].Value + "'", "insert");
                        Session["Msg"] = "You have sucessfully Delete POD !!";
                        Response.Redirect("ListPOD.aspx");
                    }
                }
            }
            else
            {
                ds = cn.RunSql("sp_addPODTran 'I','" + txtawbno.Text + "','" + txtorigin.Text + "','" + txtlocation.Text + "','" + txtbookdatetime.Text + "','" + txtcustomer.Text + "','" + txtproduct.Text + "','" + txtdrsno.Text + "','" + txtmanifestno.Text + "','" + HifStatus.Value + "','" + txtdeldate.Text + "','" + txtrecname.Text + "','" + txtremark.Text + "','" + txtphoneno.Text + "','" + txtvendor1.Text + "','" + txtvendor2.Text + "','" + Request.Cookies["branchid"].Value + "','" + Request.Cookies["compid"].Value + "','','" + Request.Cookies["loginid"].Value + "'", "insert");
                Session["Msg"] = "You have sucessfully insert POD !!";
                Response.Redirect("TranPOD.aspx");
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
        Response.Redirect("TranPOD.aspx");
    }
    protected void txtawbno_TextChanged(object sender, EventArgs e)
    {
        try
        {
            ds = cn.RunSql("sp_getdrsmanifest '" + txtawbno.Text + "','" + Request.Cookies["branchid"].Value + "'", "select");

            if (ds.Tables[0].Rows.Count > 0)
            {
                txtorigin.Text = ds.Tables[0].Rows[0]["cOrigin"] != DBNull.Value ? ds.Tables[0].Rows[0]["cOrigin"].ToString() : "";
                txtlocation.Text = ds.Tables[0].Rows[0]["cLocationName"] != DBNull.Value ? ds.Tables[0].Rows[0]["cLocationName"].ToString() : "";
                txtbookdatetime.Text = ds.Tables[0].Rows[0]["bookdt"] != DBNull.Value ? ds.Tables[0].Rows[0]["bookdt"].ToString() : "";
                txtdrsno.Text = ds.Tables[0].Rows[0]["nDRSNo"] != DBNull.Value ? ds.Tables[0].Rows[0]["nDRSNo"].ToString() : "";
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                txtmanifestno.Text = ds.Tables[1].Rows[0]["nManifestNo"] != DBNull.Value ? ds.Tables[1].Rows[0]["nManifestNo"].ToString() : "";
                //txtproduct.Text = ds.Tables[1].Rows[0]["cProductName"] != DBNull.Value ? ds.Tables[1].Rows[0]["cProductName"].ToString() : "";
            }
            //if (ds.Tables[6].Rows.Count > 0)
            //{
            //    HifStatus.Value = ds.Tables[6].Rows[0]["cStatus"] != DBNull.Value ? ds.Tables[6].Rows[0]["cStatus"].ToString() : "";
            //    txtdeldate.Text = ds.Tables[6].Rows[0]["dDelDate"] != DBNull.Value ? ds.Tables[6].Rows[0]["dDelDate"].ToString() : "";
            //    txtrecname.Text = ds.Tables[6].Rows[0]["cRecName"] != DBNull.Value ? ds.Tables[6].Rows[0]["cRecName"].ToString() : "";
            //    txtstatus.Text = ds.Tables[6].Rows[0]["StatusDetail"] != DBNull.Value ? ds.Tables[6].Rows[0]["StatusDetail"].ToString() : "";
            //}
            if (ds.Tables[7].Rows.Count > 0)
            {
                txtcustomer.Text = ds.Tables[7].Rows[0]["cCustomerName"] != DBNull.Value ? ds.Tables[7].Rows[0]["cCustomerName"].ToString() : "";
            }
            txtstatus.Focus();

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
}