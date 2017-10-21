using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App_Code;
using System.Data;

public partial class MasterCourier : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    SqlPavanCourier cn = new SqlPavanCourier();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["loginid"].Value == "" || Request.Cookies["branchid"].Value == null)
        {
            Response.Redirect("login.aspx");
        }
        txtcouriercode.Focus();
        if (Session["Msg"] != null)
        {
            lblsucess.Text = Session["Msg"].ToString();
            divsucess.Visible = true;
            Session["Msg"] = null;
        }
        if (IsPostBack == false)
        {

            ds = cn.RunSql("sp_usermanagement '" + Request.Cookies["branchid"].Value + "','" + Request.Cookies["loginid"].Value + "'", "select");
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["cCourier"].ToString().Substring(0, 1) != "1")
                {
                    Response.Redirect("home.aspx");
                }
                if (ds.Tables[0].Rows[0]["cCourier"].ToString().Substring(1, 1) != "1" && ds.Tables[0].Rows[0]["cCourier"].ToString().Substring(2, 1) != "1" && ds.Tables[0].Rows[0]["cCourier"].ToString().Substring(3, 1) != "1")
                {
                    btnlist.Visible = false;
                }
            }


            ds = cn.RunSql("sp_getsrno 'cou','" + Request.Cookies["branchid"].Value + "','" + Request.Cookies["loginid"].Value + "'", "select");
            txtsrno.Text = ds.Tables[0].Rows[0]["nsrno"] != DBNull.Value ? ds.Tables[0].Rows[0]["nsrno"].ToString() : "";
            if (Request.QueryString["id"] != null)
            {

                try
                {
                    ds = cn.RunSql("sp_listcourier 's','" + Request.Cookies["compid"].Value + "','" + Request.QueryString["id"] + "'", "search");
                    txtsrno.Text = ds.Tables[0].Rows[0]["nsrno"] != DBNull.Value ? ds.Tables[0].Rows[0]["nsrno"].ToString() : "";
                    txtcouriercode.Text = ds.Tables[0].Rows[0]["cCode"] != DBNull.Value ? ds.Tables[0].Rows[0]["cCode"].ToString() : "";
                    txtcouriername.Text = ds.Tables[0].Rows[0]["cname"] != DBNull.Value ? ds.Tables[0].Rows[0]["cname"].ToString() : "";
                    txtcommission.Text = ds.Tables[0].Rows[0]["cCommision"] != DBNull.Value ? ds.Tables[0].Rows[0]["cCommision"].ToString() : "0";
                    txtmobno.Text = ds.Tables[0].Rows[0]["cMobNo"] != DBNull.Value ? ds.Tables[0].Rows[0]["cMobNo"].ToString() : "";
                    HifCname.Value = ds.Tables[0].Rows[0]["cCusID"] != DBNull.Value ? ds.Tables[0].Rows[0]["cCusID"].ToString() : "";
                    TxtExtraRate.Text = ds.Tables[0].Rows[0]["nExtraRate"] != DBNull.Value ? ds.Tables[0].Rows[0]["nExtraRate"].ToString() : "0";

                    if (Request.QueryString["D"] == "1")
                    {
                        ddldelete.Visible = true;
                        btnsubmit.Text = "Delete";
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
        }
    }
    //[System.Web.Script.Services.ScriptMethod()]
    //[System.Web.Services.WebMethod]
    //public static List<string> SearchCName(string prefixText, int count)
    //{
    //    DataSet ds = new DataSet();
    //    SqlPavanCourier cn = new SqlPavanCourier();
    //    List<string> cus = new List<string>();
    //    string cnm = "";
    //    ds = cn.RunSql("sp_Searchforautocomplete 'Cus','" + prefixText + "','" + HttpContext.Current.Request.Cookies["compid"].Value + "'", "select");
    //    if (ds.Tables[0].Rows.Count > 0)
    //    {
    //        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
    //        {
    //            cnm = AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(ds.Tables[0].Rows[i]["cCustomerName"].ToString(), ds.Tables[0].Rows[i]["nid"].ToString());
    //            cus.Add(cnm);
    //        }
    //    }
    //    return cus;
    //}

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        try
        {
            TxtExtraRate.Text = TxtExtraRate.Text == "" ? "0" : TxtExtraRate.Text;
            if (Request.QueryString["id"] != null)
            {
                if (Request.QueryString["E"] == "1")
                {
                    ds = cn.RunSql("sp_addcouriermaster 'U','" + txtsrno.Text + "','" + txtcouriercode.Text + "','" + HifCname.Value + "','" + txtcouriername.Text + "','" + txtcommission.Text + "','" + txtmobno.Text + "','" + Request.Cookies["compid"].Value + "','" + Request.Cookies["loginid"].Value + "','" + Request.QueryString["id"] + "','" + TxtExtraRate.Text + "','" + Request.Cookies["branchid"].Value + "'", "select");
                    Session["Msg"] = "You have sucessfully Update Courier !!";
                    HifCname.Value = "";
                    Response.Redirect("ListCourier.aspx");
                }
                if (Request.QueryString["D"] == "1")
                {
                    if (ddldelete.SelectedValue == "Yes")
                    {
                        ds = cn.RunSql("sp_addcouriermaster 'D','" + txtsrno.Text + "','" + txtcouriercode.Text + "','" + HifCname.Value + "','" + txtcouriername.Text + "','" + txtcommission.Text + "','" + txtmobno.Text + "','" + Request.Cookies["compid"].Value + "','" + Request.Cookies["loginid"].Value + "','" + Request.QueryString["id"] + "','" + TxtExtraRate.Text + "','" + Request.Cookies["branchid"].Value + "'", "select");
                        Session["Msg"] = "You have sucessfully Delete Courier !!";
                        HifCname.Value = "";
                        Response.Redirect("ListCourier.aspx");
                    }
                }
            }
            else
            {
                ds = cn.RunSql("sp_addcouriermaster 'I','" + txtsrno.Text + "','" + txtcouriercode.Text + "','" + HifCname.Value + "','" + txtcouriername.Text + "','" + txtcommission.Text + "','" + txtmobno.Text + "','" + Request.Cookies["compid"].Value + "','" + Request.Cookies["loginid"].Value + "','','" + TxtExtraRate.Text + "','" + Request.Cookies["branchid"].Value + "'", "select");
                Session["Msg"] = "You have sucessfully insert Courier !!";
                HifCname.Value = "";
                Response.Redirect("MasterCourier.aspx");
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
        Response.Redirect("ListCourier.aspx");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("MasterCourier.aspx");
    }
}