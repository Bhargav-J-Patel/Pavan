    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App_Code;
using System.Data;

public partial class Trace : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    SqlPavanCourier cn = new SqlPavanCourier();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["loginid"].Value == "" || Request.Cookies["branchid"].Value == null)
        {
            Response.Redirect("login.aspx");
        }

        try
        {
            ds = cn.RunSql("sp_usermanagement '" + Request.Cookies["branchid"].Value + "','" + Request.Cookies["loginid"].Value + "'", "select");
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["cTrace"].ToString().Substring(0, 1) != "1")
                {
                    Response.Redirect("home.aspx");
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
                TxtRoute.Text = ds.Tables[0].Rows[0]["cDeliveryName"] != DBNull.Value ? ds.Tables[0].Rows[0]["cDeliveryName"].ToString() : "";
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                txtmanifestno.Text = ds.Tables[1].Rows[0]["nManifestNo"] != DBNull.Value ? ds.Tables[1].Rows[0]["nManifestNo"].ToString() : "";
                //txtproduct.Text = ds.Tables[1].Rows[0]["cProductName"] != DBNull.Value ? ds.Tables[1].Rows[0]["cProductName"].ToString() : "";
            }
            if (ds.Tables[2].Rows.Count > 0)
            {
                txtstatus.Text = ds.Tables[2].Rows[0]["cStatus"] != DBNull.Value ? ds.Tables[2].Rows[0]["cStatus"].ToString() : "";
                txtdeldate.Text = ds.Tables[2].Rows[0]["dDelDate"] != DBNull.Value ? ds.Tables[2].Rows[0]["dDelDate"].ToString() : "";
                txtrecname.Text = ds.Tables[2].Rows[0]["cRecName"] != DBNull.Value ? ds.Tables[2].Rows[0]["cRecName"].ToString() : "";
                txtremark.Text = ds.Tables[2].Rows[0]["cRemark"] != DBNull.Value ? ds.Tables[2].Rows[0]["cRemark"].ToString() : "";
                txtphoneno.Text = ds.Tables[2].Rows[0]["cphoneno"] != DBNull.Value ? ds.Tables[2].Rows[0]["cphoneno"].ToString() : "";
                txtvendor1.Text = ds.Tables[2].Rows[0]["cvendor1"] != DBNull.Value ? ds.Tables[2].Rows[0]["cvendor1"].ToString() : "";
                txtvendor2.Text = ds.Tables[2].Rows[0]["cvendor2"] != DBNull.Value ? ds.Tables[2].Rows[0]["cvendor2"].ToString() : "";
            }
            if (ds.Tables[7].Rows.Count > 0)
            {
                txtcustomer.Text = ds.Tables[7].Rows[0]["cCustomerName"] != DBNull.Value ? ds.Tables[7].Rows[0]["cCustomerName"].ToString() : "";
            }
            GvPODList.DataSource = ds.Tables[3];
            GvPODList.DataBind();

            GvDRSList.DataSource = ds.Tables[4];
            GvDRSList.DataBind();

            GvManifest.DataSource = ds.Tables[5];
            GvManifest.DataBind();

            if (Request.Cookies["cType"].Value == "0")
            {
                GvPODList.Columns[7].Visible = false;
                GvPODList.Columns[8].Visible = false;

                GvDRSList.Columns[6].Visible = false;
                GvDRSList.Columns[7].Visible = false;

                GvManifest.Columns[5].Visible = false;
                GvManifest.Columns[6].Visible = false;

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
   
}