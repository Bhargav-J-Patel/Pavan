using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using App_Code;

public partial class ListCashBooking : System.Web.UI.Page
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

        ds = cn.RunSql("sp_usermanagement '" + Request.Cookies["branchid"].Value + "','" + Request.Cookies["loginid"].Value + "'", "select");
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0]["cCashBooking"].ToString().Substring(0, 1) != "1")
            {
                Button1.Visible = false;
            }
            if (ds.Tables[0].Rows[0]["cCashBooking"].ToString().Substring(1, 1) != "1" && ds.Tables[0].Rows[0]["cCashBooking"].ToString().Substring(2, 1) != "1" && ds.Tables[0].Rows[0]["cCashBooking"].ToString().Substring(3, 1) != "1")
            {
                Response.Redirect("home.aspx");
            }

        }


    }
    protected void btnaddnew_Click(object sender, EventArgs e)
    {
        Response.Redirect("TranCashBooking.aspx");
    }
}