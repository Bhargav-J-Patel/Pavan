using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App_Code;
using System.Data;

public partial class ManifestRpt : System.Web.UI.Page
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
                   if (Request.QueryString["summary"] == "1")
                   {
                       ds = cn.RunSql("sp_manifestrptsummary '" + Request.QueryString["fromdt"] + "','" + Request.QueryString["todt"] + "','" + Request.QueryString["vendor"] + "','" + Request.QueryString["dest"] + "','" + Request.Cookies["branchid"].Value + "'", "summary");
                       lblreport.Text = ds.Tables[0].Rows[0][0] != DBNull.Value ? ds.Tables[0].Rows[0][0].ToString() : "";
                   }
                   if (Request.QueryString["summary"] == "0")
                   {
                       ds = cn.RunSql("sp_manifestrptdetail '" + Request.QueryString["fromdt"] + "','" + Request.QueryString["todt"] + "','" + Request.QueryString["vendor"] + "','" + Request.QueryString["dest"] + "','" + Request.Cookies["branchid"].Value + "'", "detail");
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