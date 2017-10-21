using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App_Code;
using System.Data;

public partial class TranDRSRunsheetUpload : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    SqlPavanCourier cn = new SqlPavanCourier();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (IsPostBack == false)
            {

                ds = cn.RunSql("sp_getsrno 'DR','" + Request.Cookies["branchid"].Value + "','" + Request.Cookies["loginid"].Value + "'", "select");
                txtsrno.Text = ds.Tables[0].Rows[0]["nsrno"] != DBNull.Value ? ds.Tables[0].Rows[0]["nsrno"].ToString() : "";

                if (Request.QueryString["id"] != null)
                {
                    ds = cn.RunSql("sp_getdrsimage '" + Request.QueryString["id"] + "'", "search");
                    txtsrno.Text = ds.Tables[0].Rows[0]["nsrno"] != DBNull.Value ? ds.Tables[0].Rows[0]["nsrno"].ToString() : "";
                    txtdate.Text = ds.Tables[0].Rows[0]["dDate"] != DBNull.Value ? ds.Tables[0].Rows[0]["dDate"].ToString() : "";
                    TxtImgNo.Text = ds.Tables[0].Rows[0]["cimage"] != DBNull.Value ? ds.Tables[0].Rows[0]["cimage"].ToString() : "";

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
                    ds = cn.RunSql("sp_adddrsrunsheetimage 'U','" + txtsrno.Text + "','" + txtdate.Text + "','" + TxtImgNo.Text + "','" + Request.Cookies["branchid"].Value + "','" + Request.Cookies["compid"].Value + "','" + Request.QueryString["id"] + "','" + Request.Cookies["loginid"].Value + "'", "insert");
                    if (FileUpload1.HasFile)
                    {

                        string path = Server.MapPath("~/DRSImage/");
                        path += ds.Tables[0].Rows[0][0] + ".jpg";
                        FileUpload1.PostedFile.SaveAs(path);
                    }  
                    Session["Msg"] = "You have sucessfully Update Delivery Runsheet !!";
                    Response.Redirect("ListDrsRunsheetImage.aspx");
                }
                if (Request.QueryString["D"] == "1")
                {
                    if (ddldelete.SelectedValue == "Yes")
                    {
                        ds = cn.RunSql("sp_adddrsrunsheetimage 'D','" + txtsrno.Text + "','" + txtdate.Text + "','" + TxtImgNo.Text + "','" + Request.Cookies["branchid"].Value + "','" + Request.Cookies["compid"].Value + "','" + Request.QueryString["id"] + "','" + Request.Cookies["loginid"].Value + "'", "insert");
                        Session["Msg"] = "You have sucessfully Delete Delivery Runsheet !!";
                        Response.Redirect("ListDrsRunsheetImage.aspx");
                    }
                }
            }
            else
            {
                ds = cn.RunSql("sp_adddrsrunsheetimage 'I','" + txtsrno.Text + "','" + txtdate.Text + "','" + TxtImgNo.Text + "','" + Request.Cookies["branchid"].Value + "','" + Request.Cookies["compid"].Value + "','','" + Request.Cookies["loginid"].Value + "'", "insert");
                if (FileUpload1.HasFile)
                {
                   
                    string path = Server.MapPath("~/DRSImage/");
                    path += ds.Tables[0].Rows[0][0] + ".jpg";
                    FileUpload1.PostedFile.SaveAs(path);
                }  
                Session["Msg"] = "You have sucessfully insert Delivery Runsheet !!";
                Response.Redirect("TranDRSRunsheetUpload.aspx");
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
        Response.Redirect("ListDrsRunsheetImage.aspx");
    }
    protected void btnreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("TranDRSRunsheetUpload.aspx");
    }
}