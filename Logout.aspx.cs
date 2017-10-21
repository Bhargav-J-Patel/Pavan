using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cookies["compid"].Value = null;
        Response.Cookies["compname"].Value = null;
        Response.Cookies["branchid"].Value = null;
        Response.Cookies["loginid"].Value = null;
        Response.Cookies["cname"].Value = null;
        Response.Cookies["cType"].Value = null;
        Response.Redirect("Login.aspx");
    }
}