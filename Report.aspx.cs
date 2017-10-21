using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App_Code;
using System.Data;

public partial class Report : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    DataSet ds1 = new DataSet();
    SqlPavanCourier cn = new SqlPavanCourier();

    protected void Page_Load(object sender, EventArgs e)
    {
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
                if (Request.QueryString["rpt"] == "1")
                {
                    ds = cn.RunSql("sp_stockissuedatewiserpt '" + Request.QueryString["rpt"] + "','" + Request.QueryString["fromdt"] + "','" + Request.QueryString["todt"] + "','" + Request.Cookies["branchid"].Value + "'", "stockissue");
                    lblreport.Text = ds.Tables[0].Rows[0][0] != DBNull.Value ? ds.Tables[0].Rows[0][0].ToString() : "";
                }
                if (Request.QueryString["rpt"] == "2")
                {
                    ds = cn.RunSql("sp_stockinwarddatewiserpt '" + Request.QueryString["rpt"] + "','" + Request.QueryString["fromdt"] + "','" + Request.QueryString["todt"] + "','" + Request.Cookies["branchid"].Value + "'", "stockissue");
                    lblreport.Text = ds.Tables[0].Rows[0][0] != DBNull.Value ? ds.Tables[0].Rows[0][0].ToString() : "";
                }
                if (Request.QueryString["rpt"] == "3")
                {
                    ds = cn.RunSql("sp_stockissuecuswiserpt '" + Request.QueryString["rpt"] + "','" + Request.QueryString["cus"] + "','" + Request.Cookies["branchid"].Value + "'", "stockissue");
                    lblreport.Text = ds.Tables[0].Rows[0][0] != DBNull.Value ? ds.Tables[0].Rows[0][0].ToString() : "";
                }
                if (Request.QueryString["rpt"] == "4")
                {
                    ds = cn.RunSql("sp_deliveryrunsheetrpt '" + Request.QueryString["rpt"] + "','" + Request.QueryString["ID"] + "','" + Request.QueryString["drsno"] + "','" + Request.Cookies["branchid"].Value + "','" + Request.Cookies["loginid"].Value + "'", "stockissue");
                    lblreport.Text = ds.Tables[0].Rows[0][0] != DBNull.Value ? ds.Tables[0].Rows[0][0].ToString() : "";
                }
                if (Request.QueryString["rpt"] == "5")
                {

                    ds1 = cn.RunSql("sp_selectsystemsetting '" + Request.Cookies["branchid"].Value + "'", "select");
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        if (ds1.Tables[0].Rows[0]["cManifestWeightPrint"].ToString() == "Yes")
                        {
                            ds = cn.RunSql("sp_manifestrpt '" + Request.QueryString["rpt"] + "','" + Request.QueryString["manifest"] + "','" + Request.Cookies["branchid"].Value + "'", "stockissue");
                        }
                        else
                        {
                            ds = cn.RunSql("sp_manifestrptwithoutweight '" + Request.QueryString["rpt"] + "','" + Request.QueryString["manifest"] + "','" + Request.Cookies["branchid"].Value + "'", "stockissue");
                        }
                    }
                    
                    lblreport.Text = ds.Tables[0].Rows[0][0] != DBNull.Value ? ds.Tables[0].Rows[0][0].ToString() : "";
                }
                if (Request.QueryString["rpt"] == "6")
                {
                    if (Request.QueryString["summary"] == "0")
                    {
                        ds = cn.RunSql("sp_DailyDetailrpt '" + Request.QueryString["fromdt"] + "','" + Request.QueryString["todt"] + "','" + Request.QueryString["cus"] + "','" + Request.Cookies["branchid"].Value + "','" + Request.Cookies["compid"].Value + "'", "stockissue");
                    }
                    else
                    {
                        ds = cn.RunSql("sp_DailySummaryrpt '" + Request.QueryString["fromdt"] + "','" + Request.QueryString["todt"] + "','" + Request.QueryString["cus"] + "','" + Request.Cookies["branchid"].Value + "','" + Request.Cookies["compid"].Value + "'", "stockissue");
                    }
                    lblreport.Text = ds.Tables[0].Rows[0][0] != DBNull.Value ? ds.Tables[0].Rows[0][0].ToString() : "";
                }
                if (Request.QueryString["rpt"] == "7")
                {
                    ds = cn.RunSql("sp_printcashbooking '" + Request.QueryString["ID"] + "','" + Request.Cookies["branchid"].Value + "'", "print");
                    lblreport.Text = ds.Tables[0].Rows[0][0] != DBNull.Value ? ds.Tables[0].Rows[0][0].ToString() : "";
                }
                if (Request.QueryString["rpt"] == "8")
                {
                    ds = cn.RunSql("sp_cashcreditrpt '" + Request.QueryString["dest"] + "','" + Request.Cookies["branchid"].Value + "'", "print");
                    lblreport.Text = ds.Tables[0].Rows[0][0] != DBNull.Value ? ds.Tables[0].Rows[0][0].ToString() : "";
                }
                if (Request.QueryString["rpt"] == "9")
                {
                    ds = cn.RunSql("sp_billprintrpt '" + Request.QueryString["cus"] + "'", "print");
                    lblreport.Text = ds.Tables[0].Rows[0][0] != DBNull.Value ? ds.Tables[0].Rows[0][0].ToString() : "";
                }
                if (Request.QueryString["rpt"] == "10")
                {
                    ds = cn.RunSql("sp_deliveryboyrpt '" + Request.QueryString["boy"] + "','" + Request.Cookies["branchid"].Value + "'", "print");
                    lblreport.Text = ds.Tables[0].Rows[0][0] != DBNull.Value ? ds.Tables[0].Rows[0][0].ToString() : "";
                }
                if (Request.QueryString["rpt"] == "16")
                {
                    ds = cn.RunSql("sp_creditbookingrpt '" + Request.QueryString["fromdt"] + "','" + Request.QueryString["todt"] + "','" + Request.Cookies["branchid"].Value + "','" + Request.Cookies["compid"].Value + "'", "stockissue");
                    lblreport.Text = ds.Tables[0].Rows[0][0] != DBNull.Value ? ds.Tables[0].Rows[0][0].ToString() : "";
                }
                if (Request.QueryString["rpt"] == "17")
                {
                    ds = cn.RunSql("sp_creditbookingrptcus '" + Request.QueryString["fromdt"] + "','" + Request.QueryString["todt"] + "','" + Request.Cookies["branchid"].Value + "','" + Request.Cookies["compid"].Value + "','" + Request.QueryString["cus"] + "'", "stockissue");
                    lblreport.Text = ds.Tables[0].Rows[0][0] != DBNull.Value ? ds.Tables[0].Rows[0][0].ToString() : "";
                }
               

            }
            catch (Exception ex)
            {
                lblerror.Text = ex.Message;
                diverror.Visible = false;
            }
            finally
            {
                ds.Dispose();
            }

        }
    }
}