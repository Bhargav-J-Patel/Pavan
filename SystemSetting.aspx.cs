using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using App_Code;

public partial class SystemSetting : System.Web.UI.Page
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
                ds = cn.RunSql("sp_selectsystemsetting '" + Request.Cookies["branchid"].Value + "'", "select");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    TxtCashWeight.Text = ds.Tables[0].Rows[0]["nCashWeight"] != DBNull.Value ? ds.Tables[0].Rows[0]["nCashWeight"].ToString() : "";
                    TxtCreditWeight.Text = ds.Tables[0].Rows[0]["nCreditWeight"] != DBNull.Value ? ds.Tables[0].Rows[0]["nCreditWeight"].ToString() : "";
                    DDLServTaxNo.SelectedValue = ds.Tables[0].Rows[0]["cServTaxNoCash"] != DBNull.Value ? ds.Tables[0].Rows[0]["cServTaxNoCash"].ToString() : "";
                    DDLManifestPrint.SelectedValue = ds.Tables[0].Rows[0]["cManifestWeightPrint"] != DBNull.Value ? ds.Tables[0].Rows[0]["cManifestWeightPrint"].ToString() : "";
                }
            }
        }
        catch (Exception ex)
        {
            lblerror.Text = ex.Message;
            diverror.Visible = true;
        }
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        try
        {
            ds = cn.RunSql("sp_addsystemsetting '" + TxtCashWeight.Text + "','" + TxtCreditWeight.Text + "','" + DDLServTaxNo.SelectedValue + "','" + DDLManifestPrint.SelectedValue + "','" + Request.Cookies["branchid"].Value + "'", "select");
            Session["msg"] = "You have sucessfully update System setting";
            Response.Redirect("SystemSetting.aspx");
        }
        catch (Exception ex)
        {
            lblerror.Text = ex.Message;
            diverror.Visible = true;
        }
    }
}