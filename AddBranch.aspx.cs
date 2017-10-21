using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App_Code;
using System.Data;

public partial class AddBranch : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    SqlPavanCourier cn = new SqlPavanCourier();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            if (Session["Msg"] != null)
            {
                lblsucess.Text = Session["Msg"].ToString();
                divsucess.Visible = true;
            }

            try
            {
                if (IsPostBack == false)
                {
                    if (Request.QueryString["id"] != null)
                    {
                        ds = cn.RunSql("sp_listbranch 's','" + Request.QueryString["id"] + "'", "search");
                        txtsrno.Text = ds.Tables[0].Rows[0]["nSrno"].ToString();
                        txtbranchcode.Text = ds.Tables[0].Rows[0]["cCode"].ToString();
                        txtbranchname.Text = ds.Tables[0].Rows[0]["cName"].ToString();
                        txtaddress.Text = ds.Tables[0].Rows[0]["cAddress"].ToString();
                        txtpincodeno.Text = ds.Tables[0].Rows[0]["cPinCodeno"].ToString();
                        txtcontactno.Text = ds.Tables[0].Rows[0]["cContactNo"].ToString();
                        txtpanno.Text = ds.Tables[0].Rows[0]["cPAN"].ToString();

                        if (Request.QueryString["D"] == "1")
                        {
                            ddldelete.Visible = true;
                            btnsubmit.Text = "Delete";
                        }
                    }
                    else
                    {
                        ds = cn.RunSql("sp_getsrno 'B'", "select");
                        txtsrno.Text = ds.Tables[0].Rows[0]["nsrno"] != DBNull.Value ? ds.Tables[0].Rows[0]["nsrno"].ToString() : "";
                    }

                }
            }
            catch (Exception ex)
            {
                lblerror.Text = ex.Message;
                diverror.Visible = true;
            }
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
                    ds = cn.RunSql("sp_addbranchmaster 'U','" + txtbranchcode.Text + "','" + txtbranchname.Text + "','" + txtaddress.Text + "','" + txtpincodeno.Text + "','" + txtcontactno.Text + "','" + txtpanno.Text + "','" + Request.QueryString["id"] + "','" + Request.Cookies["compid"].Value + "'", "insert");
                    Session["msg"] = "Branch Update Sucessfully !!";
                    Response.Redirect("ListBranch.aspx");
                }
                if (Request.QueryString["D"] == "1")
                {
                    if (ddldelete.SelectedValue == "Yes")
                    {
                        ds = cn.RunSql("sp_addbranchmaster 'D','" + txtbranchcode.Text + "','" + txtbranchname.Text + "','" + txtaddress.Text + "','" + txtpincodeno.Text + "','" + txtcontactno.Text + "','" + txtpanno.Text + "','" + Request.QueryString["id"] + "','" + Request.Cookies["compid"].Value + "'", "insert");
                        Session["msg"] = "Branch Delete Sucessfully !!";
                        Response.Redirect("ListBranch.aspx");
                    }
                }
            }
            else
            {
                ds = cn.RunSql("sp_addbranchmaster 'I','" + txtbranchcode.Text + "','" + txtbranchname.Text + "','" + txtaddress.Text + "','" + txtpincodeno.Text + "','" + txtcontactno.Text + "','" + txtpanno.Text + "','','" + Request.Cookies["compid"].Value + "'", "insert");
                Session["msg"] = "Branch Added Sucessfully !!";
                Response.Redirect("AddBranch.aspx");
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
        Response.Redirect("ListBranch.aspx");
    }
}