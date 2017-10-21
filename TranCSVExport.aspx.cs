using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App_Code;
using System.Data;

public partial class TranCSVExport : System.Web.UI.Page
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
                 if (Request.QueryString["type"] == "1")
                 {
                     Lbltxt.Text = "DRS Export";
                 }
                 if (Request.QueryString["type"] == "2")
                 {
                     Lbltxt.Text = "Manifest Export";
                     //trdestination.Visible = true;
                 }
                 if (Request.QueryString["type"] == "3")
                 {
                     Lbltxt.Text = "Cash Booking Export";
                 }
                 if (Request.QueryString["type"] == "4")
                 {
                     Lbltxt.Text = "Credit Booking Export";
                     //trdestination.Visible = true;
                 }
             }
             catch (Exception ex)
             {
                 lblerror.Text = ex.Message;
                 diverror.Visible = true;
             }
         }
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString["type"] == "1")
            {
                ds = cn.RunSql("sp_exportdata '" + Request.QueryString["type"] + "','" + txtfromdate.Text + "','" + txttodate.Text + "','','" + Request.Cookies["compid"].Value + "','" + Request.Cookies["branchid"].Value + "'", "select");
            }
            if (Request.QueryString["type"] == "2")
            {
                ds = cn.RunSql("sp_exportdata '" + Request.QueryString["type"] + "','" + txtfromdate.Text + "','" + txttodate.Text + "','','" + Request.Cookies["compid"].Value + "','" + Request.Cookies["branchid"].Value + "'", "select");
            }
            if (Request.QueryString["type"] == "3")
            {
                ds = cn.RunSql("sp_exportdata '" + Request.QueryString["type"] + "','" + txtfromdate.Text + "','" + txttodate.Text + "','','" + Request.Cookies["compid"].Value + "','" + Request.Cookies["branchid"].Value + "'", "select");
            }
            if (Request.QueryString["type"] == "4")
            {
                ds = cn.RunSql("sp_exportdata '" + Request.QueryString["type"] + "','" + txtfromdate.Text + "','" + txttodate.Text + "','','" + Request.Cookies["compid"].Value + "','" + Request.Cookies["branchid"].Value + "'", "select");
            }
        }
        catch (Exception ex)
        {
            lblerror.Text = ex.Message;
            diverror.Visible = true;
        }
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

}