using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App_Code;
using System.Data;

public partial class MasterVendor : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    SqlPavanCourier cn = new SqlPavanCourier();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["loginid"].Value == "" || Request.Cookies["branchid"].Value == null)
        {
            Response.Redirect("login.aspx");
        }
        txtcuscode.Focus();
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

                //ds = cn.RunSql("sp_usermanagement '" + Request.Cookies["branchid"].Value + "','" + Request.Cookies["loginid"].Value + "'", "select");
                //if (ds.Tables[0].Rows.Count > 0)
                //{
                //    if (ds.Tables[0].Rows[0]["cCustomer"].ToString().Substring(0, 1) != "1")
                //    {
                //        Response.Redirect("home.aspx");
                //    }
                //    if (ds.Tables[0].Rows[0]["cCustomer"].ToString().Substring(1, 1) != "1" && ds.Tables[0].Rows[0]["cCustomer"].ToString().Substring(2, 1) != "1" && ds.Tables[0].Rows[0]["cCustomer"].ToString().Substring(3, 1) != "1")
                //    {
                //        btnlist.Visible = false;
                //    }
                //}



                ds = cn.RunSql("sp_selectcharge '" + Request.Cookies["compid"].Value + "','"+ Request.Cookies["branchid"].Value +"'", "select");
                ChkCharge.DataSource = ds;
                ChkCharge.DataBind();


                if (Request.QueryString["id"] != null)
                {
                    ds = cn.RunSql("sp_listvendor 's','" + Request.Cookies["compid"].Value + "','" + Request.QueryString["id"] + "'", "search");
                    txtcuscode.Text = ds.Tables[0].Rows[0]["cCustomerCode"] != DBNull.Value ? ds.Tables[0].Rows[0]["cCustomerCode"].ToString() : "";
                    txtcusname.Text = ds.Tables[0].Rows[0]["cCustomerName"] != DBNull.Value ? ds.Tables[0].Rows[0]["cCustomerName"].ToString() : "";
                    txtaddress.Text = ds.Tables[0].Rows[0]["cAddress"] != DBNull.Value ? ds.Tables[0].Rows[0]["cAddress"].ToString() : "";
                    txtmobile.Text = ds.Tables[0].Rows[0]["cMobNo"] != DBNull.Value ? ds.Tables[0].Rows[0]["cMobNo"].ToString() : "";
                    TxPhNo.Text = ds.Tables[0].Rows[0]["cPhoneNo"] != DBNull.Value ? ds.Tables[0].Rows[0]["cPhoneNo"].ToString() : "";
                    txtemailid.Text = ds.Tables[0].Rows[0]["cEmailID"] != DBNull.Value ? ds.Tables[0].Rows[0]["cEmailID"].ToString() : "";
                    txtdob.Text = ds.Tables[0].Rows[0]["cDOB"] != DBNull.Value ? ds.Tables[0].Rows[0]["cDOB"].ToString() : "";
                    txtcontract.Text = ds.Tables[0].Rows[0]["cContractName"] != DBNull.Value ? ds.Tables[0].Rows[0]["cContractName"].ToString() : "";
                    txtlocation.Text = ds.Tables[0].Rows[0]["cLocationName"] != DBNull.Value ? ds.Tables[0].Rows[0]["cLocationName"].ToString() : "";
                    ddlpaymenttype.SelectedValue = ds.Tables[0].Rows[0]["cPaymentType"] != DBNull.Value ? ds.Tables[0].Rows[0]["cPaymentType"].ToString() : "";
                   // DdlType.SelectedValue = ds.Tables[0].Rows[0]["cType"] != DBNull.Value ? ds.Tables[0].Rows[0]["cType"].ToString() : "";
                    HifContract.Value = ds.Tables[0].Rows[0]["cContract"] != DBNull.Value ? ds.Tables[0].Rows[0]["cContract"].ToString() : "";
                    HifLocation.Value = ds.Tables[0].Rows[0]["cLocationID"] != DBNull.Value ? ds.Tables[0].Rows[0]["cLocationID"].ToString() : "";
                    TxtPanCardNo.Text = ds.Tables[0].Rows[0]["cPancardNo"] != DBNull.Value ? ds.Tables[0].Rows[0]["cPancardNo"].ToString() : "";
                    TxtServiceTaxNo.Text = ds.Tables[0].Rows[0]["cSeviceTaxNo"] != DBNull.Value ? ds.Tables[0].Rows[0]["cSeviceTaxNo"].ToString() : "";
                    //chkservicetzx.Checked = ds.Tables[0].Rows[0]["cServiceTax"].ToString() == "1" ? true : false;
                    //chkfuelcharge.Checked = ds.Tables[0].Rows[0]["cFuelCharge"].ToString() == "1" ? true : false;


                    if (ds.Tables.Count > 1)
                    {
                        if (ds.Tables[1].Rows.Count > 0)
                        {

                            for (int i = 0; i <= ds.Tables[1].Rows.Count - 1; i++)
                            {
                                foreach (ListItem item in ChkCharge.Items)
                                {
                                    if (item.Value == ds.Tables[1].Rows[i]["value"].ToString())
                                    {
                                        item.Selected = true;
                                        break;
                                    }
                                }
                            }
                        }
                    }



                    if (Request.QueryString["D"] == "1")
                    {
                        ddldelete.Visible = true;
                        Button1.Text = "Delete";
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

    }
    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static List<string> SearchLocation(string prefixText, int count)
    {
        DataSet ds = new DataSet();
        SqlPavanCourier cn = new SqlPavanCourier();
        List<string> loc = new List<string>();
        string cnm = "";
        ds = cn.RunSql("sp_Searchforautocomplete 'LOC','" + prefixText + "','" + HttpContext.Current.Request.Cookies["compid"].Value + "','" + HttpContext.Current.Request.Cookies["branchid"].Value + "'", "select");
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cnm = AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(ds.Tables[0].Rows[i]["cLocationName"].ToString(), ds.Tables[0].Rows[i]["nid"].ToString());
                loc.Add(cnm);
            }
        }
        return loc;
    }
    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static List<string> SearchContract(string prefixText, int count)
    {
        DataSet ds = new DataSet();
        SqlPavanCourier cn = new SqlPavanCourier();
        List<string> co = new List<string>();
        string cnm = "";
        ds = cn.RunSql("sp_Searchforautocomplete 'COBU','" + prefixText + "','" + HttpContext.Current.Request.Cookies["compid"].Value + "','" + HttpContext.Current.Request.Cookies["branchid"].Value + "','" + HttpContext.Current.Request.Cookies["loginid"].Value + "'", "select");
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cnm = AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(ds.Tables[0].Rows[i]["cContractName"].ToString(), ds.Tables[0].Rows[i]["nid"].ToString());
                co.Add(cnm);
            }
        }
        return co;
    }
    protected void btnlist_Click(object sender, EventArgs e)
    {
        Response.Redirect("ListVendor.aspx");
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {

            //string servicetax =chkservicetzx.Checked == true ? "1":"0";
            //string fuelcharge = chkfuelcharge.Checked == true ? "1" : "0";

            string charge = "";

            foreach (ListItem item in ChkCharge.Items)
            {
                if (item.Selected)
                {
                    charge = charge + item.Value + '¶';
                }
            }


            if (Request.QueryString["id"] != null)
            {
                if (Request.QueryString["E"] == "1")
                {
                    ds = cn.RunSql("sp_addvendor 'U','" + txtcuscode.Text + "','" + txtcusname.Text + "','" + txtaddress.Text + "','" + HifLocation.Value + "','" + TxPhNo.Text + "','" + txtmobile.Text + "','" + TxtPanCardNo.Text + "','" + TxtServiceTaxNo.Text + "','" + txtemailid.Text + "','" + txtdob.Text + "','" + ddlpaymenttype.SelectedValue + "','" + charge + "','" + HifContract.Value + "','" + Request.Cookies["compid"].Value + "','" + Request.Cookies["loginid"].Value + "','" + Request.Cookies["branchid"].Value + "','" + Request.QueryString["id"] + "'", "insert");
                    Session["Msg"] = "You have sucessfully Update Vendor !!";
                    Response.Redirect("ListVendor.aspx");
                }
                if (Request.QueryString["D"] == "1")
                {
                    if (ddldelete.SelectedValue == "Yes")
                    {
                        ds = cn.RunSql("sp_addvendor 'D','" + txtcuscode.Text + "','" + txtcusname.Text + "','" + txtaddress.Text + "','" + HifLocation.Value + "','" + TxPhNo.Text + "','" + txtmobile.Text + "','" + TxtPanCardNo.Text + "','" + TxtServiceTaxNo.Text + "','" + txtemailid.Text + "','" + txtdob.Text + "','" + ddlpaymenttype.SelectedValue + "','" + charge + "','" + HifContract.Value + "','" + Request.Cookies["compid"].Value + "','" + Request.Cookies["loginid"].Value + "','" + Request.Cookies["branchid"].Value + "','" + Request.QueryString["id"] + "'", "insert");
                        Session["Msg"] = "You have sucessfully Delete Vendor !!";
                        Response.Redirect("ListVendor.aspx");
                    }
                }
            }
            else
            {
                ds = cn.RunSql("sp_addvendor 'I','" + txtcuscode.Text + "','" + txtcusname.Text + "','" + txtaddress.Text + "','" + HifLocation.Value + "','" + TxPhNo.Text + "','" + txtmobile.Text + "','"+ TxtPanCardNo.Text +"','"+ TxtServiceTaxNo.Text +"','" + txtemailid.Text + "','" + txtdob.Text + "','" + ddlpaymenttype.SelectedValue + "','" + charge + "','" + HifContract.Value + "','" + Request.Cookies["compid"].Value + "','" + Request.Cookies["loginid"].Value + "','" + Request.Cookies["branchid"].Value + "',''", "insert");
                Session["Msg"] = "You have sucessfully insert Vendor !!";
                Response.Redirect("MasterVendor.aspx");
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
    protected void Btnreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("MasterVendor.aspx");
    }

}