using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App_Code;
using System.Data;

public partial class MasterCountry : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    SqlPavanCourier cn = new SqlPavanCourier();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["loginid"].Value == "" || Request.Cookies["branchid"].Value == null)
        {
            Response.Redirect("login.aspx");
        }
        txtcountrycode.Focus();
        if (Session["Msg"] != null)
        {
            lblsucess.Text = Session["Msg"].ToString();
            divsucess.Visible = true;
            Session["Msg"] = null;
        }

        try
        {
            if (IsPostBack == false)
            {

                ds = cn.RunSql("sp_usermanagement '" + Request.Cookies["branchid"].Value + "','" + Request.Cookies["loginid"].Value + "'", "select");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["cCountry"].ToString().Substring(0, 1) != "1")
                    {
                        Response.Redirect("home.aspx");
                    }
                    if (ds.Tables[0].Rows[0]["cCountry"].ToString().Substring(1, 1) != "1" && ds.Tables[0].Rows[0]["cCountry"].ToString().Substring(2, 1) != "1" && ds.Tables[0].Rows[0]["cCountry"].ToString().Substring(3, 1) != "1")
                    {
                        btnlist.Visible = false;
                    }
                }


                ds = cn.RunSql("sp_getsrno 'c','" + Request.Cookies["branchid"].Value + "'", "select");
                txtsrno.Text = ds.Tables[0].Rows[0]["nsrno"] != DBNull.Value ? ds.Tables[0].Rows[0]["nsrno"].ToString() : "";

                if (Request.QueryString["id"] != null)
                {
                    ds = cn.RunSql("sp_listcountry 's','" + Request.Cookies["compid"].Value + "','" + Request.QueryString["id"] + "'", "search");
                    txtsrno.Text = ds.Tables[0].Rows[0]["nsrno"] != DBNull.Value ? ds.Tables[0].Rows[0]["nsrno"].ToString() : "";
                    txtcountrycode.Text = ds.Tables[0].Rows[0]["cCountryCode"].ToString();
                    txtcountryname.Text = ds.Tables[0].Rows[0]["cCountryName"].ToString();

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
                    ds = cn.RunSql("sp_addcountrymaster 'U','" + txtsrno.Text + "','" + txtcountrycode.Text + "','" + txtcountryname.Text + "','" + Request.Cookies["compid"].Value + "','" + Request.Cookies["loginid"].Value + "','" + Request.QueryString["id"] + "','" + Request.Cookies["branchid"].Value + "'", "insert");
                    Session["Msg"] = "You have sucessfully Update Country !!";
                    Response.Redirect("ListCountry.aspx");
                }
                if (Request.QueryString["D"] == "1")
                {
                    if (ddldelete.SelectedValue == "Yes")
                    {
                        ds = cn.RunSql("sp_addcountrymaster 'D','" + txtsrno.Text + "','" + txtcountrycode.Text + "','" + txtcountryname.Text + "','" + Request.Cookies["compid"].Value + "','" + Request.Cookies["loginid"].Value + "','" + Request.QueryString["id"] + "','" + Request.Cookies["branchid"].Value + "'", "insert");
                        Session["Msg"] = "You have sucessfully Delete Country !!";
                        Response.Redirect("ListCountry.aspx");
                    }
                }
            }
            else
            {
                ds = cn.RunSql("sp_addcountrymaster 'I','" + txtsrno.Text + "','" + txtcountrycode.Text + "','" + txtcountryname.Text + "','" + Request.Cookies["compid"].Value + "','" + Request.Cookies["loginid"].Value + "','','" + Request.Cookies["branchid"].Value + "'", "insert");
                Session["Msg"] = "You have sucessfully insert Country !!";
                Response.Redirect("MasterCountry.aspx");
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
        Response.Redirect("ListCountry.aspx");
    }
    protected void btnreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("MasterCountry.aspx");
    }
}