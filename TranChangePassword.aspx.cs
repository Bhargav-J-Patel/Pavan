using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App_Code;
using System.Data;

public partial class TranChangePassword : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    SqlPavanCourier cn = new SqlPavanCourier();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["loginid"].Value == "" || Request.Cookies["compid"].Value == null)
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
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        try
        {
            ds = cn.RunSql("updatepassword '1','" + TxtCurrentPswd.Text + "','" + Request.Cookies["loginid"].Value + "'", "update");

            ds = cn.RunSql("updatepassword '2','" + TxtNewPswd.Text + "','" + Request.Cookies["loginid"].Value + "'", "update");
            Session["Msg"] = "You have sucessfully Update Password !!";
            Response.Redirect("TranChangePassword.aspx");
        }
        catch (Exception ex)
        {
            lblerror.Text = ex.Message;
            diverror.Visible = true;
        }
        finally
        {
            ds.Dispose();
        }
    }
    protected void Btncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("TranChangePassword.aspx");
    }
    //protected void TxtCurrentPswd_TextChanged(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        ds = cn.RunSql("updatepassword '1','" + TxtCurrentPswd.Text + "','" + Request.Cookies["loginid"].Value + "'", "update");
    //        TxtNewPswd.Focus();
    //    }
    //    catch (Exception ex)
    //    {
    //        lblerror.Text = ex.Message;
    //        diverror.Visible = true;
    //    }
    //    finally
    //    {
    //        ds.Dispose();
    //    }
    //}
}