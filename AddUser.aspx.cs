using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App_Code;
using System.Data;
public partial class AddUser : System.Web.UI.Page
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

                ds = cn.RunSql("sp_listbranch 'L',''", "select");
                ddlbranch.DataSource = ds;
                ddlbranch.DataBind();

                    if (Request.QueryString["id"] != null)
                    {
                        ds = cn.RunSql("sp_listbranch 's','" + Request.QueryString["id"] + "'", "search");
                        txtname.Text = ds.Tables[0].Rows[0]["nSrno"].ToString();
                        txtcontactno.Text = ds.Tables[0].Rows[0]["cCode"].ToString();
                        txtusername.Text = ds.Tables[0].Rows[0]["cName"].ToString();
                        txtpassword.Text = ds.Tables[0].Rows[0]["cAddress"].ToString();
                        ddlbranch.SelectedValue = ds.Tables[0].Rows[0]["cPinCodeno"].ToString();
                       
                        if (Request.QueryString["D"] == "1")
                        {
                            ddldelete.Visible = true;
                            btnsubmit.Text = "Delete";
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
            string usertype = chkadmin.Checked == true ? "1" : "0";

            if (Request.QueryString["id"] != null)
            {
                if (Request.QueryString["E"] == "1")
                {
                    ds = cn.RunSql("sp_addusers 'U','" + txtname.Text + "','" + txtcontactno.Text + "','" + txtusername.Text + "','" + txtpassword.Text + "','" + usertype + "','" + ddlbranch.SelectedValue + "','" + Request.Cookies["compid"].Value + "','" + Request.QueryString["id"] + "'", "insert");
                    Session["msg"] = "Branch Update Sucessfully !!";
                    Response.Redirect("ListBranch.aspx");
                }
                if (Request.QueryString["D"] == "1")
                {
                    if (ddldelete.SelectedValue == "Yes")
                    {
                        ds = cn.RunSql("sp_addusers 'D','" + txtname.Text + "','" + txtcontactno.Text + "','" + txtusername.Text + "','" + txtpassword.Text + "','" + usertype + "','" + ddlbranch.SelectedValue + "','" + Request.Cookies["compid"].Value + "','" + Request.QueryString["id"] + "'", "insert");
                        Session["msg"] = "Branch Delete Sucessfully !!";
                        Response.Redirect("ListBranch.aspx");
                    }
                }
            }
            else
            {
                ds = cn.RunSql("sp_addusers 'I','" + txtname.Text + "','" + txtcontactno.Text + "','" + txtusername.Text + "','" + txtpassword.Text + "','" + usertype + "','" + ddlbranch.SelectedValue + "','" + Request.Cookies["compid"].Value + "',''", "insert");
                Session["msg"] = "User Added Sucessfully !!";
                Response.Redirect("AddUser.aspx");
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
    //protected void btnlist_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("ListBranch.aspx");
    //}
    protected void btnreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddUSer.aspx");
    }
}