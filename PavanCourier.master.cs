using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App_Code;
using System.Data;

public partial class PavanCourier : System.Web.UI.MasterPage
{
    SqlPavanCourier cn = new SqlPavanCourier();
    DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           if (Request.Cookies["loginid"].Value == "" || Request.Cookies["branchid"].Value == null)
            {
                Response.Redirect("login.aspx");
            }

            lblusername.Text = Request.Cookies["cname"].Value;
            lblcompname.Text = Request.Cookies["compname"].Value;

            ds = cn.RunSql("sp_menu '" + Request.Cookies["branchid"].Value + "','" + Request.Cookies["loginid"].Value + "'", "select");
            lblmenu.Text = ds.Tables[0].Rows[0][0] != DBNull.Value ? ds.Tables[0].Rows[0][0].ToString() : "";

        }
    }
}
