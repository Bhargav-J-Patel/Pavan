using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App_Code;
using System.Data;

public partial class TranStockIssue : System.Web.UI.Page
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

                txtissuedate.Text = DateTime.Now.ToString("dd/MM/yyyy");

                ds = cn.RunSql("sp_usermanagement '" + Request.Cookies["branchid"].Value + "','" + Request.Cookies["loginid"].Value + "'", "select");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["cStockIssue"].ToString().Substring(0, 1) != "1")
                    {
                        Response.Redirect("home.aspx");
                    }
                    if (ds.Tables[0].Rows[0]["cStockIssue"].ToString().Substring(1, 1) != "1" && ds.Tables[0].Rows[0]["cStockIssue"].ToString().Substring(2, 1) != "1" && ds.Tables[0].Rows[0]["cStockIssue"].ToString().Substring(3, 1) != "1")
                    {
                        btnlist.Visible = false;
                    }
                }


                if (Request.QueryString["id"] != null)
                {

                    ds = cn.RunSql("sp_liststockissue 's','" + Request.Cookies["branchid"].Value + "','" + Request.QueryString["id"] + "'", "search");
                    ddlIssueTo.SelectedValue = ds.Tables[0].Rows[0]["cIssueTo"] != DBNull.Value ? ds.Tables[0].Rows[0]["cIssueTo"].ToString() : "";
                    txtissuedate.Text = ds.Tables[0].Rows[0]["cIssueDate"] != DBNull.Value ? ds.Tables[0].Rows[0]["cIssueDate"].ToString() : "";
                    txtcusname.Text = ds.Tables[0].Rows[0]["cCustomerName"] != DBNull.Value ? ds.Tables[0].Rows[0]["cCustomerName"].ToString() : "";
                    txtfromamwno.Text = ds.Tables[0].Rows[0]["nFromAMWNo"] != DBNull.Value ? ds.Tables[0].Rows[0]["nFromAMWNo"].ToString() : "";
                    txttoamwno.Text = ds.Tables[0].Rows[0]["nToAMWNo"] != DBNull.Value ? ds.Tables[0].Rows[0]["nToAMWNo"].ToString() : "";
                    txttotal.Text = ds.Tables[0].Rows[0]["nTotal"] != DBNull.Value ? ds.Tables[0].Rows[0]["nTotal"].ToString() : "";
                    HifCus.Value = ds.Tables[0].Rows[0]["cCustomerID"] != DBNull.Value ? ds.Tables[0].Rows[0]["cCustomerID"].ToString() : "";


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
    protected void btnlist_Click(object sender, EventArgs e)
    {
        Response.Redirect("ListStockIssue.aspx");
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        try
        {

            if (Request.QueryString["id"] != null)
            {
                if (Request.QueryString["E"] == "1")
                {
                    ds = cn.RunSql("sp_addstockissue 'U','" + ddlIssueTo.SelectedValue + "','" + txtissuedate.Text + "','" + HifCus.Value + "','" + txtfromamwno.Text + "','" + txttoamwno.Text + "','" + txttotal.Text + "','" + Request.Cookies["branchid"].Value + "','" + Request.QueryString["id"] + "','" + Request.Cookies["loginid"].Value + "'", "update");
                    Session["Msg"] = "You have sucessfully Upadte Stock Issue !!";
                    Response.Redirect("ListStockIssue.aspx");
                }
                if (Request.QueryString["D"] == "1")
                {
                    if (ddldelete.SelectedValue == "Yes")
                    {
                        ds = cn.RunSql("sp_addstockissue 'D','" + ddlIssueTo.SelectedValue + "','" + txtissuedate.Text + "','" + HifCus.Value + "','" + txtfromamwno.Text + "','" + txttoamwno.Text + "','" + txttotal.Text + "','" + Request.Cookies["branchid"].Value + "','" + Request.QueryString["id"] + "','" + Request.Cookies["loginid"].Value + "'", "insert");
                        Session["Msg"] = "You have sucessfully Delete Stock Issue !!";
                        Response.Redirect("ListStockIssue.aspx");
                    }
                }
            }
            else
            {
                ds = cn.RunSql("sp_addstockissue 'I','" + ddlIssueTo.SelectedValue + "','" + txtissuedate.Text + "','" + HifCus.Value + "','" + txtfromamwno.Text + "','" + txttoamwno.Text + "','" + txttotal.Text + "','" + Request.Cookies["branchid"].Value + "','','" + Request.Cookies["loginid"].Value + "'", "insert");
                Session["Msg"] = "You have sucessfully Insert Stock Issue !!";
                Response.Redirect("TranStockIssue.aspx");
            }
        }
        catch (Exception ex)
        {
            lblerror.Text = ex.Message;
            diverror.Visible = true;
        }
    }

    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static List<string> SearchCus(string prefixText, int count)
    {
        DataSet ds = new DataSet();
        SqlPavanCourier cn = new SqlPavanCourier();
        List<string> cus = new List<string>();
        string cnm = "";
        ds = cn.RunSql("sp_Searchforautocomplete 'CustStock','" + prefixText + "','" + HttpContext.Current.Request.Cookies["compid"].Value + "','" + HttpContext.Current.Request.Cookies["branchid"].Value + "','" + HttpContext.Current.Request.Cookies["loginid"].Value + "'", "select");
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cnm = AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(ds.Tables[0].Rows[i]["cCustomerName"].ToString(), ds.Tables[0].Rows[i]["nid"].ToString());
                cus.Add(cnm);
            }
        }

        return cus;
    }


    protected void txttoamwno_TextChanged(object sender, EventArgs e)
    {
        try
        {
            
            txttotal.Text = Convert.ToDecimal(Convert.ToDecimal(Convert.ToDouble(txttoamwno.Text) - Convert.ToDouble(txtfromamwno.Text) + 1)).ToString("0");
            btnsubmit.Focus();
        }
        catch (Exception ex)
        {
            lblerror.Text = ex.Message;
            diverror.Visible = true;
        }
    }
    protected void btnreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("TranStockIssue.aspx");
    }
}