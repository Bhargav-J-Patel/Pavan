using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App_Code;
using System.Data;

public partial class ConsigneeDetail : System.Web.UI.Page
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
            ds = cn.RunSql("sp_usermanagement '" + Request.Cookies["branchid"].Value + "','" + Request.Cookies["loginid"].Value + "'", "select");
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["cConsignee"].ToString().Substring(0, 1) != "1")
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
            ds = cn.RunSql("sp_getdrsmanifestconsignee '" + txtawbno.Text + "','" + Request.Cookies["branchid"].Value + "'", "select");
            if (ds.Tables[0].Rows.Count > 0)
            {
                HIFDRSID.Value = ds.Tables[0].Rows[0]["nid"] != DBNull.Value ? ds.Tables[0].Rows[0]["nid"].ToString() : "";
                HIFDrsCus.Value = ds.Tables[0].Rows[0]["cBoy"] != DBNull.Value ? ds.Tables[0].Rows[0]["cBoy"].ToString() : "";
                txtdrsno.Text = ds.Tables[0].Rows[0]["nDRSNo"] != DBNull.Value ? ds.Tables[0].Rows[0]["nDRSNo"].ToString() : "";
                txtlocation.Text = ds.Tables[0].Rows[0]["Location"] != DBNull.Value ? ds.Tables[0].Rows[0]["Location"].ToString() : "";
                txtdrsdate.Text = ds.Tables[0].Rows[0]["dDate"] != DBNull.Value ? ds.Tables[0].Rows[0]["dDate"].ToString() : "";
                txtdrsweight.Text = ds.Tables[0].Rows[0]["cweight"] != DBNull.Value ? ds.Tables[0].Rows[0]["cweight"].ToString() : "";
                txtdrspcs.Text = ds.Tables[0].Rows[0]["cpcs"] != DBNull.Value ? ds.Tables[0].Rows[0]["cpcs"].ToString() : "";
                txtdrsrate.Text = ds.Tables[0].Rows[0]["nrate"] != DBNull.Value ? ds.Tables[0].Rows[0]["nrate"].ToString() : "";
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                HIFManifestID.Value = ds.Tables[1].Rows[0]["nid"] != DBNull.Value ? ds.Tables[1].Rows[0]["nid"].ToString() : "";
                HIFManifestCus.Value = ds.Tables[1].Rows[0]["cCustomer"] != DBNull.Value ? ds.Tables[1].Rows[0]["cCustomer"].ToString() : "";
                txtmanifestno.Text = ds.Tables[1].Rows[0]["nManifestNo"] != DBNull.Value ? ds.Tables[1].Rows[0]["nManifestNo"].ToString() : "";
                txtdestination.Text = ds.Tables[1].Rows[0]["Destination"] != DBNull.Value ? ds.Tables[1].Rows[0]["Destination"].ToString() : "";
                txtmanifestdt.Text = ds.Tables[1].Rows[0]["dDate"] != DBNull.Value ? ds.Tables[1].Rows[0]["dDate"].ToString() : "";
                txtmanifestweight.Text = ds.Tables[1].Rows[0]["nWeight"] != DBNull.Value ? ds.Tables[1].Rows[0]["nWeight"].ToString() : "";
                txtmanifestpcs.Text = ds.Tables[1].Rows[0]["nPcs"] != DBNull.Value ? ds.Tables[1].Rows[0]["nPcs"].ToString() : "";
                txtmanifestrate.Text = ds.Tables[1].Rows[0]["nrate"] != DBNull.Value ? ds.Tables[1].Rows[0]["nrate"].ToString() : "";
            }
            if (ds.Tables[2].Rows.Count > 0)
            {
                TxtCustAgent.Text = ds.Tables[2].Rows[0]["cCustomerName"] != DBNull.Value ? ds.Tables[2].Rows[0]["cCustomerName"].ToString() : "";
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
            ds = cn.RunSql("sp_updatedrsmanifest '" + HIFDRSID.Value + "','" + HIFManifestID.Value + "','" + txtdrsweight.Text + "','" + txtdrspcs.Text + "','" + HIFDrsCus.Value + "','" + txtmanifestweight.Text + "','" + txtmanifestpcs.Text + "','" + HIFManifestCus.Value + "'", "update");
            Session["Msg"] = "You have Sucessfully Update!!";
            Response.Redirect("ConsigneeDetail.aspx");
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
    protected void txtdrsweight_TextChanged(object sender, EventArgs e)
    {
        try
        {
            ds = cn.RunSql("sp_getrate '" + txtdrsweight.Text + "','" + HIFDrsCus.Value + "'", "rate");
            txtdrsrate.Text = ds.Tables[0].Rows[0][0] != DBNull.Value ? ds.Tables[0].Rows[0][0].ToString() : "";

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
    protected void txtmanifestweight_TextChanged(object sender, EventArgs e)
    {
        try
        {
            ds = cn.RunSql("sp_getrate '"+ txtmanifestweight.Text +"','"+ HIFManifestCus.Value +"'","rate");
            txtmanifestrate.Text = ds.Tables[0].Rows[0][0] != DBNull.Value ? ds.Tables[0].Rows[0][0].ToString() : "";
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