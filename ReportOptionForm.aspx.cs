using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App_Code;
using System.Data;

public partial class ReportOptionForm : System.Web.UI.Page
{
    DataSet ds = new DataSet();
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
                ds = cn.RunSql("sp_usermanagement '" + Request.Cookies["branchid"].Value + "','" + Request.Cookies["loginid"].Value + "'", "select");

                if (Request.QueryString["id"] == "1")
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0]["cStockIssueDt"].ToString() != "1")
                        {
                            Response.Redirect("home.aspx");
                        }
                    }

                    Lbltxt.Text = "Stock Issue Date wise";
                    trdate.Visible = true;
                }
                if (Request.QueryString["id"] == "2")
                {
                      
                      if (ds.Tables[0].Rows.Count > 0)
                      {
                          if (ds.Tables[0].Rows[0]["cStockInwardDt"].ToString() != "1")
                          {
                              Response.Redirect("home.aspx");
                          }
                      }
                    Lbltxt.Text = "Stock Inward Date wise";
                    trdate.Visible = true;
                }
                if (Request.QueryString["id"] == "3")
                {

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0]["cStockIssueCus"].ToString() != "1")
                        {
                            Response.Redirect("home.aspx");
                        }
                    }

                    Lbltxt.Text = "Stock Issue Customer wise";
                    trcus.Visible = true;
                }
                if (Request.QueryString["id"] == "4")
                {
                    Lbltxt.Text = "DRS Delivery RunSheet";
                    lbldrsmanifest.Text = "DRS No";
                    trdrsmanifest.Visible = true;
                }
                if (Request.QueryString["id"] == "5")
                {
                    Lbltxt.Text = "Manifest";
                    lbldrsmanifest.Text = "Manifest No";
                    trdrsmanifest.Visible = true;
                }
                if (Request.QueryString["id"] == "6")
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0]["cDailyRpt"].ToString() != "1")
                        {
                            Response.Redirect("home.aspx");
                        }
                    }

                    txtfromdate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    txttodate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    Lbltxt.Text = "Daily Reports";
                    trdate.Visible = true;
                    trcus.Visible = true;
                    trsummary.Visible = true;
                }
                if (Request.QueryString["id"] == "7")
                {

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0]["cStockIssueCus"].ToString() != "1")
                        {
                            Response.Redirect("home.aspx");
                        }
                    }

                    Lbltxt.Text = "Agent / Customer Bill";
                    tragent.Visible = true;
                }
                if (Request.QueryString["id"] == "8")
                {
                    Lbltxt.Text = "Deleivery Boy";
                    trdeliveryboy.Visible = true;
                }
                if (Request.QueryString["id"] == "8")
                {
                    Lbltxt.Text = "Deleivery Boy";
                    trdeliveryboy.Visible = true;
                }
                if (Request.QueryString["id"] == "16")
                {
                    Lbltxt.Text = "Credit Booking";
                    trdate.Visible = true;
                }
                if (Request.QueryString["id"] == "17")
                {
                    Lbltxt.Text = "Credit Booking";
                    trdate.Visible = true;
                    tr1.Visible = true;
                }
            }
            catch (Exception ex)
            {
                lblerror.Text = ex.Message;
                diverror.Visible = false;
            }

        }
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        try
        {
            string summaryval = chksummary.Checked == true ? "1" : "0";

            if (Request.QueryString["id"] == "1")
            {
                Response.Redirect("Report.aspx?rpt=1&fromdt=" + txtfromdate.Text + "&todt=" + txttodate.Text + "");
            }
            if (Request.QueryString["id"] == "2")
            {
                Response.Redirect("Report.aspx?rpt=2&fromdt=" + txtfromdate.Text + "&todt=" + txttodate.Text + "");
            }
            if (Request.QueryString["id"] == "3")
            {
                Response.Redirect("Report.aspx?rpt=3&cus=" + HifCus.Value + "");
            }
            if (Request.QueryString["id"] == "4")
            {
                Response.Redirect("Report.aspx?rpt=4&drsno=" + txtdrsno.Text + "");
            }
            if (Request.QueryString["id"] == "5")
            {
                Response.Redirect("Report.aspx?rpt=5&manifest=" + txtdrsno.Text + "");
            }
            if (Request.QueryString["id"] == "6")
            {
                Response.Redirect("Report.aspx?rpt=6&fromdt=" + txtfromdate.Text + "&todt=" + txttodate.Text + "&cus=" + HifCus.Value + "&summary="+ summaryval +"");

            }
            if (Request.QueryString["id"] == "7")
            {
                Response.Redirect("Report.aspx?rpt=9&cus=" + HifAgent.Value + "");

            }
            if (Request.QueryString["id"] == "8")
            {
                Response.Redirect("Report.aspx?rpt=10&boy=" + HFCourier.Value + "");
            }
            if (Request.QueryString["id"] == "16")
            {
                Response.Redirect("Report.aspx?rpt=16&fromdt=" + txtfromdate.Text + "&todt=" + txttodate.Text + "");
            }
            if (Request.QueryString["id"] == "17")
            {
                Response.Redirect("Report.aspx?rpt=17&fromdt=" + txtfromdate.Text + "&todt=" + txttodate.Text + "&cus=" + HifCus1.Value + "");
            }
        }
        catch (Exception ex)
        {
            lblerror.Text = ex.Message;
            diverror.Visible = false;
        }
    }
    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static List<string> SearchCus(string prefixText, int count)
    {
        DataSet ds = new DataSet();
        SqlPavanCourier cn = new SqlPavanCourier();
        List<string> cus = new List<string>();
        string cnm = "";
        ds = cn.RunSql("sp_Searchforautocomplete 'Custrpt','" + prefixText + "','" + HttpContext.Current.Request.Cookies["compid"].Value + "','" + HttpContext.Current.Request.Cookies["branchid"].Value + "'", "select");
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cnm = AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(ds.Tables[0].Rows[i]["cCustomerName"].ToString(), ds.Tables[0].Rows[i]["nid"].ToString());
                cus.Add(cnm);
            }
        }

        return cus;
    }
    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static List<string> SearchCustmer(string prefixText, int count)
    {
        DataSet ds = new DataSet();
        SqlPavanCourier cn = new SqlPavanCourier();
        List<string> cus = new List<string>();
        string cnm = "";
        ds = cn.RunSql("sp_Searchforautocomplete 'custmer','" + prefixText + "','" + HttpContext.Current.Request.Cookies["compid"].Value + "','" + HttpContext.Current.Request.Cookies["branchid"].Value + "'", "select");
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cnm = AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(ds.Tables[0].Rows[i]["cCustomerName"].ToString(), ds.Tables[0].Rows[i]["nid"].ToString());
                cus.Add(cnm);
            }
        }

        return cus;
    }
    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static List<string> SearchAgent(string prefixText, int count)
    {
        DataSet ds = new DataSet();
        SqlPavanCourier cn = new SqlPavanCourier();
        List<string> cus = new List<string>();
        string cnm = "";
        ds = cn.RunSql("sp_Searchforautocomplete 'AgentCus','" + prefixText + "','" + HttpContext.Current.Request.Cookies["compid"].Value + "','" + HttpContext.Current.Request.Cookies["branchid"].Value + "'", "select");
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cnm = AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(ds.Tables[0].Rows[i]["cCustomerName"].ToString(), ds.Tables[0].Rows[i]["nid"].ToString());
                cus.Add(cnm);
            }
        }

        return cus;
    }
    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static List<string> SearchCourier(string prefixText, int count)
    {
        DataSet ds = new DataSet();
        SqlPavanCourier cn = new SqlPavanCourier();
        List<string> cus = new List<string>();
        string cnm = "";
        ds = cn.RunSql("sp_Searchforautocomplete 'DRSRpt','" + prefixText + "','" + HttpContext.Current.Request.Cookies["compid"].Value + "','" + HttpContext.Current.Request.Cookies["branchid"].Value + "'", "select");
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cnm = AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(ds.Tables[0].Rows[i]["cCustomerName"].ToString(), ds.Tables[0].Rows[i]["nid"].ToString());
                cus.Add(cnm);
            }
        }

        return cus;
    }
}