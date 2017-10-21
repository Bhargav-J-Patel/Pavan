using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App_Code;
using System.Data;



public partial class MasterCharge : System.Web.UI.Page
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
        try
        {
            if (IsPostBack == false)
            {

                ds = cn.RunSql("sp_usermanagement '" + Request.Cookies["branchid"].Value + "','" + Request.Cookies["loginid"].Value + "'", "select");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["cCharge"].ToString().Substring(0, 1) != "1")
                    {
                        Response.Redirect("home.aspx");
                    }
                    if (ds.Tables[0].Rows[0]["cCharge"].ToString().Substring(1, 1) != "1" && ds.Tables[0].Rows[0]["cCharge"].ToString().Substring(2, 1) != "1" && ds.Tables[0].Rows[0]["cCharge"].ToString().Substring(3, 1) != "1")
                    {
                        btnlist.Visible = false;
                    }
                }


                ds = cn.RunSql("sp_getsrno 'charge','" + Request.Cookies["branchid"].Value + "'", "select");
                txtsrno.Text = ds.Tables[0].Rows[0]["nsrno"] != DBNull.Value ? ds.Tables[0].Rows[0]["nsrno"].ToString() : "";

                if (Request.QueryString["id"] != null)
                {
                    ds = cn.RunSql("sp_listcharge 's','" + Request.Cookies["compid"].Value + "','" + Request.QueryString["id"] + "'", "search");
                    txtsrno.Text = ds.Tables[0].Rows[0]["nsrno"] != DBNull.Value ? ds.Tables[0].Rows[0]["nsrno"].ToString() : "";
                    txtchargename.Text = ds.Tables[0].Rows[0]["cChargeName"] != DBNull.Value ? ds.Tables[0].Rows[0]["cChargeName"].ToString() : "";
                    txtchargeper.Text = ds.Tables[0].Rows[0]["cChargePer"] != DBNull.Value ? ds.Tables[0].Rows[0]["cChargePer"].ToString() : "";

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
                    ds = cn.RunSql("sp_addchargemaster 'U','" + txtsrno.Text + "','" + txtchargename.Text + "','" + txtchargeper.Text + "','" + Request.Cookies["compid"].Value + "','" + Request.QueryString["id"] + "','" + Request.Cookies["branchid"].Value + "'", "insert");
                    Session["Msg"] = "You have sucessfully Update Charge !!";
                    Response.Redirect("ListCharge.aspx");
                }
                if (Request.QueryString["D"] == "1")
                {
                    if (ddldelete.SelectedValue == "Yes")
                    {
                        ds = cn.RunSql("sp_addchargemaster 'D','" + txtsrno.Text + "','" + txtchargename.Text + "','" + txtchargeper.Text + "','" + Request.Cookies["compid"].Value + "','" + Request.QueryString["id"] + "','" + Request.Cookies["branchid"].Value + "'", "insert");
                        Session["Msg"] = "You have sucessfully Delete Charge !!";
                        Response.Redirect("ListCharge.aspx");
                    }
                }
            }
            else
            {
                ds = cn.RunSql("sp_addchargemaster 'I','" + txtsrno.Text + "','" + txtchargename.Text + "','" + txtchargeper.Text + "','" + Request.Cookies["compid"].Value + "','','" + Request.Cookies["branchid"].Value + "'", "insert");
                Session["Msg"] = "You have sucessfully insert Charge !!";
                Response.Redirect("MasterCharge.aspx");
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
        Response.Redirect("ListCharge.aspx");
    }
    protected void btnreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("MasterCharge.aspx");
    }
}