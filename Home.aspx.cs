using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App_Code;
using System.Data;

public partial class Home : System.Web.UI.Page
{

    DataSet ds = new DataSet();
    SqlPavanCourier cn = new SqlPavanCourier();

    protected void Page_Load(object sender, EventArgs e)
    {

        ////ds = cn.RunSql("sp_gettotalcashcredit '" + Request.Cookies["branchid"].Value + "'", "select");
        ////LblCashBooking.Text = ds.Tables[0].Rows[0][0] != DBNull.Value ? ds.Tables[0].Rows[0][0].ToString() : "";
        ////LblCreditBooking.Text = ds.Tables[1].Rows[0][0] != DBNull.Value ? ds.Tables[1].Rows[0][0].ToString() : "";


    }
}