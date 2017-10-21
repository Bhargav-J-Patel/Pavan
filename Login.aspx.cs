using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App_Code;
using System.Data;

public partial class Login : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    SqlPavanCourier cn = new SqlPavanCourier();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            try
            {

                ds = cn.RunSql("sp_listbranch 'L',''", "select");
                ddlbranch.DataSource = ds;
                ddlbranch.DataBind();
            }
            catch (Exception ex)
            {

            }
        }
    }
    protected void btnlogin_Click(object sender, EventArgs e)
    {
        try
        {
            ds = cn.RunSql("sp_login '1','" + txtusername.Text + "','" + txtpassword.Text + "','" + ddlbranch.SelectedValue + "'", "select");
            if (ds.Tables[0].Rows.Count > 0)
            {
                Response.Cookies["compid"].Value = ds.Tables[0].Rows[0]["cCompID"].ToString();
                Response.Cookies["compname"].Value = ds.Tables[0].Rows[0]["cCompName"].ToString();
                Response.Cookies["branchid"].Value = ds.Tables[0].Rows[0]["cBranchID"].ToString();
                Response.Cookies["loginid"].Value = ds.Tables[0].Rows[0]["nid"].ToString();
                Response.Cookies["cname"].Value = ds.Tables[0].Rows[0]["cname"].ToString();
                Response.Cookies["cType"].Value = ds.Tables[0].Rows[0]["cType"].ToString();
                Response.Cookies["cAgent"].Value = ds.Tables[0].Rows[0]["cAgent"].ToString();
                Response.Cookies["cAgentID"].Value = ds.Tables[0].Rows[0]["cAgentId"].ToString();
                Response.Redirect("Home.aspx");
            }
        }
        catch (Exception ex)
        {

        }
    }
}