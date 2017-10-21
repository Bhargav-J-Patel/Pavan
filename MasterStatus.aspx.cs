using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App_Code;
using System.Data;

public partial class MasterStatus : System.Web.UI.Page
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
        txtstatuscode.Focus();
        try
        {
            if (IsPostBack == false)
            {

                ds = cn.RunSql("sp_usermanagement '" + Request.Cookies["branchid"].Value + "','" + Request.Cookies["loginid"].Value + "'", "select");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["cDeliveryException"].ToString().Substring(0, 1) != "1")
                    {
                        Response.Redirect("home.aspx");
                    }
                    if (ds.Tables[0].Rows[0]["cDeliveryException"].ToString().Substring(1, 1) != "1" && ds.Tables[0].Rows[0]["cDeliveryException"].ToString().Substring(2, 1) != "1" && ds.Tables[0].Rows[0]["cDeliveryException"].ToString().Substring(3, 1) != "1")
                    {
                        btnlist.Visible = false;
                    }
                }


                ds = cn.RunSql("sp_getsrno 'status','" + Request.Cookies["branchid"].Value + "'", "select");
                txtsrno.Text = ds.Tables[0].Rows[0]["nsrno"] != DBNull.Value ? ds.Tables[0].Rows[0]["nsrno"].ToString() : "";

                if (Request.QueryString["id"] != null)
                {
                    ds = cn.RunSql("sp_liststatus 's','" + Request.Cookies["compid"].Value + "','" + Request.QueryString["id"] + "'", "search");
                    txtsrno.Text = ds.Tables[0].Rows[0]["nsrno"] != DBNull.Value ? ds.Tables[0].Rows[0]["nsrno"].ToString() : "";
                    txtstatuscode.Text = ds.Tables[0].Rows[0]["cStatusCode"] != DBNull.Value ? ds.Tables[0].Rows[0]["cStatusCode"].ToString() : "";
                    txtstatusdetail.Text = ds.Tables[0].Rows[0]["cStatusDetail"] != DBNull.Value ? ds.Tables[0].Rows[0]["cStatusDetail"].ToString() : "";
                    ChkDefaultStatus.Checked = ds.Tables[0].Rows[0]["cDefault"] != DBNull.Value ? ds.Tables[0].Rows[0]["cDefault"].ToString() == "1" ? true : false : false;

                    if (Request.QueryString["D"] == "1")
                    {
                        ddldelete.Visible = true;
                        btnsubmit.Text = "Delete";
                    }
                }
            }
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

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString["id"] != null)
            {
                if (Request.QueryString["E"] == "1")
                {
                    ds = cn.RunSql("sp_addstatusmaster 'U','" + txtsrno.Text + "','" + txtstatuscode.Text + "','" + txtstatusdetail.Text + "','" + Request.Cookies["compid"].Value + "','" + Request.Cookies["loginid"].Value + "','" + Request.QueryString["id"] + "','" + Request.Cookies["branchid"].Value + "','" + (ChkDefaultStatus.Checked == true ? "1" : "0").ToString() + "'", "update");
                    Session["Msg"] = "You have sucessfully Update Status !!";
                    Response.Redirect("ListStatus.aspx");
                }
                if (Request.QueryString["D"] == "1")
                {
                    if (ddldelete.SelectedValue == "Yes")
                    {
                        ds = cn.RunSql("sp_addstatusmaster 'D','" + txtsrno.Text + "','" + txtstatuscode.Text + "','" + txtstatusdetail.Text + "','" + Request.Cookies["compid"].Value + "','" + Request.Cookies["loginid"].Value + "','" + Request.QueryString["id"] + "','" + Request.Cookies["branchid"].Value + "','" + (ChkDefaultStatus.Checked == true ? "1" : "0").ToString() + "'", "delete");
                        Session["Msg"] = "You have sucessfully Delete Status !!";
                        Response.Redirect("ListStatus.aspx");
                    }
                }
            }
            else
            {
                ds = cn.RunSql("sp_addstatusmaster 'I','" + txtsrno.Text + "','" + txtstatuscode.Text + "','" + txtstatusdetail.Text + "','" + Request.Cookies["compid"].Value + "','" + Request.Cookies["loginid"].Value + "','','" + Request.Cookies["branchid"].Value + "','" + (ChkDefaultStatus.Checked == true ? "1" : "0").ToString() + "'", "insert");
                Session["Msg"] = "You have sucessfully insert Status !!";
                Response.Redirect("MasterStatus.aspx");
            }
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
    protected void btnlist_Click(object sender, EventArgs e)
    {
        Response.Redirect("ListStatus.aspx");
    }
    protected void btnreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("MasterStatus.aspx");
    }
}