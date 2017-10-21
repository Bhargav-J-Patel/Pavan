using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App_Code;
using System.Data;
using System.IO;
using System.Data.OleDb;

public partial class TranCashCreditBill : System.Web.UI.Page
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
    }

    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static List<string> SearchCus(string prefixText, int count)
    {
        DataSet ds = new DataSet();
        SqlPavanCourier cn = new SqlPavanCourier();
        List<string> cus = new List<string>();
        string cnm = "";
        ds = cn.RunSql("sp_Searchforautocomplete 'Cus','" + prefixText + "','" + HttpContext.Current.Request.Cookies["compid"].Value + "'", "select");
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
    public static List<string> SearchDestination(string prefixText, int count)
    {
        DataSet ds = new DataSet();
        SqlPavanCourier cn = new SqlPavanCourier();
        List<string> cus = new List<string>();
        string cnm = "";
        ds = cn.RunSql("sp_Searchforautocomplete 'Dest','" + prefixText + "','" + HttpContext.Current.Request.Cookies["compid"].Value + "'", "select");
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cnm = AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(ds.Tables[0].Rows[i]["Destination"].ToString(), ds.Tables[0].Rows[i]["nid"].ToString());
                cus.Add(cnm);
            }
        }
        return cus;
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("creditbill.aspx?fromdt=" + TxtFromDt.Text + "&todt=" + TxtToDt.Text + "&customer=" + HifBoy.Value + "&destination=" + HifDestination.Value + "");
        }
        catch (Exception ex)
        {
            lblerror.Text = ex.Message;
            diverror.Visible = false;
        }
    }

}