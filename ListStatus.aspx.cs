using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App_Code;
using System.Data;

public partial class ListStatus : System.Web.UI.Page
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
        if (IsPostBack == false)
        {
            try
            {

                ds = cn.RunSql("sp_usermanagement '" + Request.Cookies["branchid"].Value + "','" + Request.Cookies["loginid"].Value + "'", "select");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["cDeliveryException"].ToString().Substring(0, 1) != "1")
                    {
                        btnaddnew.Visible = false;
                    }
                    if (ds.Tables[0].Rows[0]["cDeliveryException"].ToString().Substring(1, 1) != "1" && ds.Tables[0].Rows[0]["cDeliveryException"].ToString().Substring(2, 1) != "1" && ds.Tables[0].Rows[0]["cDeliveryException"].ToString().Substring(3, 1) != "1")
                    {
                        Response.Redirect("home.aspx");
                    }

                }


                //ds = cn.RunSql("sp_liststatus 'L','" + Request.Cookies["compid"].Value + "',''", "select");
                //GvStatusList.DataSource = ds;
                //GvStatusList.DataBind();
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
    }

    protected void btnaddnew_Click(object sender, EventArgs e)
    {
        Response.Redirect("MasterStatus.aspx");
    }

    //protected void GvStatusList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    try
    //    {
    //        GvStatusList.PageIndex = e.NewPageIndex;
    //        ds = cn.RunSql("sp_liststatus 'L','" + Request.Cookies["compid"].Value + "',''", "select");
    //        GvStatusList.DataSource = ds;
    //        GvStatusList.DataBind();
    //    }
    //    catch (Exception ex)
    //    {
    //        lblerror.Text = ex.Message;
    //        diverror.Visible = true;
    //    }
    //}
}