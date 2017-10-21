using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App_Code;
using System.Data;
using System.IO;
using System.Data.OleDb;

public partial class TranLoadReceived : System.Web.UI.Page
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
            if (Request.QueryString["id"] != null)
            {
                HIDPFID.Value = Request.QueryString["id"].ToString();
                ds = cn.RunSql("sp_listloadrecvd 's','" + Request.Cookies["branchid"].Value + "','" + HIDPFID.Value + "',''", "select");
                txtdate.Text = ds.Tables[1].Rows[0]["dDate"] != DBNull.Value ? ds.Tables[1].Rows[0]["dDate"].ToString() : "";
                bindGrid(); 
            }
        }
    }
    protected void btnreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("TranLoadReceived.aspx");
    }
    protected void btnlist_Click(object sender, EventArgs e)
    {
        Response.Redirect("ListLoadReceived.aspx");
    }
    protected void txtawbno_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (HIDPFID.Value != "0")
            {
                if (Request.QueryString["cid"] != null)
                {

                    ds = cn.RunSql("sp_addloadrecvd 'PUCU','" + txtdate.Text + "','" + txtawbno.Text + "','" + Request.Cookies["branchid"].Value + "','" + HIDPFID.Value + "','" + Request.QueryString["cid"] + "','"+ Request.Cookies["loginid"].Value +"'", "insert");
                    //Response.Redirect("TranManifest.aspx?id=" + ds.Tables[0].Rows[0][0] + "");
                    HIDPFID.Value = ds.Tables[0].Rows[0][0].ToString();
                    ClearChild();
                    bindGrid();

                }
                else
                {

                    ds = cn.RunSql("sp_addloadrecvd 'PUCI','" + txtdate.Text + "','" + txtawbno.Text + "','" + Request.Cookies["branchid"].Value + "','" + HIDPFID.Value + "','','" + Request.Cookies["loginid"].Value + "'", "insert");
                    //Response.Redirect("TranManifest.aspx?id=" + ds.Tables[0].Rows[0][0] + "");
                    HIDPFID.Value = ds.Tables[0].Rows[0][0].ToString();
                    ClearChild();
                    bindGrid();

                }
            }
            else
            {
                ds = cn.RunSql("sp_addloadrecvd 'I','" + txtdate.Text + "','" + txtawbno.Text + "','" + Request.Cookies["branchid"].Value + "','','','"+ Request.Cookies["loginid"].Value +"'", "insert");
                //Response.Redirect("TranManifest.aspx?id=" + ds.Tables[0].Rows[0][0] + "");
                HIDPFID.Value = ds.Tables[0].Rows[0][0].ToString();
                ClearChild();
                bindGrid();

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
    private void ClearChild()
    {
        try
        {
            txtawbno.Text = "";
            txtawbno.Focus();
        }
        catch (Exception ex)
        {
            lblerror.Text = ex.Message;
            diverror.Visible = true;
        }
    }
    protected void bindGrid()
    {
        try
        {
            if (HIDPFID.Value != "0")
            {
                ds = cn.RunSql("sp_listloadrecvd 's','" + Request.Cookies["branchid"].Value + "','" + HIDPFID.Value + "',''", "insert");
                GVLoadRecvd.DataSource = ds.Tables[0];
                GVLoadRecvd.DataBind();
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
            if (HIDPFID.Value != "0")
            {
                if (Request.QueryString["D"] == "1")
                {
                    if (ddldelete.SelectedValue == "Yes")
                    {
                        ds = cn.RunSql("sp_addloadrecvd 'D','" + txtdate.Text + "','0','" + Request.Cookies["branchid"].Value + "','" + HIDPFID.Value + "','','" + Request.Cookies["loginid"].Value + "'", "insert");
                        Session["Msg"] = "You have Sucessfully Delete Load Received!!";
                        Response.Redirect("ListLoadReceived.aspx");
                    }
                }
                else
                {
                    ds = cn.RunSql("sp_addloadrecvd 'PU','" + txtdate.Text + "','0','" + Request.Cookies["branchid"].Value + "','" + HIDPFID.Value + "','','" + Request.Cookies["loginid"].Value + "'", "insert");
                    Session["Msg"] = "You have Sucessfully Update Load Received!!";
                    Response.Redirect("ListLoadReceived.aspx");
                }
            }

        }
        catch (Exception ex)
        {
            lblerror.Text = ex.Message;
            diverror.Visible = true;
        }
    }
    protected void ImgDelete1_Click(object sender, EventArgs e)
    {
        try
        {
            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

            string cnid = "";
            string confirmval = "";
            confirmval = Request.Form["confirm_value"];
            if (confirmval == "Yes")
            {
                cnid = GVLoadRecvd.Rows[row.RowIndex].Cells[0].Text;
                ds = cn.RunSql("sp_addloadrecvd 'PUCD','" + txtdate.Text + "','0','" + Request.Cookies["branchid"].Value + "','" + HIDPFID.Value + "','" + cnid + "','" + Request.Cookies["loginid"].Value + "'", "insert");
                Response.Redirect("TranLoadReceived.aspx?id=" + ds.Tables[0].Rows[0][0] + "");
            }
        }
        catch (Exception ex)
        {
            lblerror.Text = ex.Message;
            diverror.Visible = true;
        }

    }
}