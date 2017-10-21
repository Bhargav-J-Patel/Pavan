using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App_Code;
using System.Data;

public partial class MasterBranch : System.Web.UI.Page
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
        if (IsPostBack == false)
        {
            try
            {
                txtcompname.Text = Request.Cookies["compname"].Value;
                ds = cn.RunSql("sp_listbranch 's','" + Request.Cookies["branchid"].Value + "'", "select");
                txtbranchcode.Text = ds.Tables[0].Rows[0]["cCode"] != DBNull.Value ? ds.Tables[0].Rows[0]["cCode"].ToString() : "";
                txtbranchname.Text = ds.Tables[0].Rows[0]["cName"] != DBNull.Value ? ds.Tables[0].Rows[0]["cName"].ToString() : "";
                txtaddress.Text = ds.Tables[0].Rows[0]["cAddress"] != DBNull.Value ? ds.Tables[0].Rows[0]["cAddress"].ToString() : "";
                txtpincodeno.Text = ds.Tables[0].Rows[0]["cPinCodeno"] != DBNull.Value ? ds.Tables[0].Rows[0]["cPinCodeno"].ToString() : "";
                txtcontactno.Text = ds.Tables[0].Rows[0]["cContactNo"] != DBNull.Value ? ds.Tables[0].Rows[0]["cContactNo"].ToString() : "";
                txtpanno.Text = ds.Tables[0].Rows[0]["cPAN"] != DBNull.Value ? ds.Tables[0].Rows[0]["cPAN"].ToString() : "";
                TxtServiceTaxNo.Text = ds.Tables[0].Rows[0]["cServTax"] != DBNull.Value ? ds.Tables[0].Rows[0]["cServTax"].ToString() : "";
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
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            ds = cn.RunSql("sp_addbranchmaster 'U','" + txtbranchcode.Text + "','" + txtbranchname.Text + "','" + txtaddress.Text + "','" + txtpincodeno.Text + "','" + txtcontactno.Text + "','" + txtpanno.Text + "','" + TxtServiceTaxNo.Text + "','" + Request.Cookies["branchid"].Value + "','" + Request.Cookies["compid"].Value + "'", "insert");
            Session["msg"] = "Branch Update Sucessfully !!";
            Response.Redirect("MasterBranch.aspx");
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