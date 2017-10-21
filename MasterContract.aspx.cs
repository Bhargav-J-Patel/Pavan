using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App_Code;
using System.Data;

public partial class MasterContract : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    SqlPavanCourier cn = new SqlPavanCourier();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Msg"] != null)
        {
            lblsucess.Text = Session["Msg"].ToString();
            divsucess.Visible = true;
            Session["Msg"] = null;
        }
        txtcontractname.Focus();
        if (IsPostBack == false)
        {
            try
            {

                ds = cn.RunSql("sp_usermanagement '" + Request.Cookies["branchid"].Value + "','" + Request.Cookies["loginid"].Value + "'", "select");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["cContract"].ToString().Substring(0, 1) != "1")
                    {
                        Response.Redirect("home.aspx");
                    }
                    if (ds.Tables[0].Rows[0]["cContract"].ToString().Substring(1, 1) != "1" && ds.Tables[0].Rows[0]["cContract"].ToString().Substring(2, 1) != "1" && ds.Tables[0].Rows[0]["cContract"].ToString().Substring(3, 1) != "1")
                    {
                        btnlist.Visible = false;
                    }
                }

                if (Request.QueryString["id"] != null)
                {
                    ds = cn.RunSql("sp_listcontract 's','" + Request.Cookies["compid"].Value + "','" + Request.QueryString["id"] + "',''", "select");
                    txtcontractcode.Text = ds.Tables[0].Rows[0]["cContractCode"] != DBNull.Value ? ds.Tables[0].Rows[0]["cContractCode"].ToString() : "";
                    txtcontractname.Text = ds.Tables[0].Rows[0]["cContractName"] != DBNull.Value ? ds.Tables[0].Rows[0]["cContractName"].ToString() : "";
                    txtproduct.Text = ds.Tables[0].Rows[0]["cProductName"] != DBNull.Value ? ds.Tables[0].Rows[0]["cProductName"].ToString() : "";

                    DDLCType.SelectedValue = ds.Tables[0].Rows[0]["cctype"] != DBNull.Value ? ds.Tables[0].Rows[0]["cctype"].ToString() : "";
                    HifProduct.Value = ds.Tables[0].Rows[0]["cProductID"] != DBNull.Value ? ds.Tables[0].Rows[0]["cProductID"].ToString() : "";

                    GvRateList.DataSource = ds.Tables[1];
                    GvRateList.DataBind();

                    if (ds.Tables.Count > 2)
                    {
                        txtzone.Text = ds.Tables[2].Rows[0]["cZoneName"] != DBNull.Value ? ds.Tables[2].Rows[0]["cZoneName"].ToString() : "";
                        HifZone.Value = ds.Tables[2].Rows[0]["ZoneID"] != DBNull.Value ? ds.Tables[2].Rows[0]["ZoneID"].ToString() : "";
                    }

                    if (Request.QueryString["cid"] != null)
                    {
                        ds = cn.RunSql("sp_listcontract 'c','" + Request.Cookies["branchid"].Value + "','" + Request.QueryString["id"] + "','" + Request.QueryString["cid"] + "'", "select");
                        txtfromweight.Text = ds.Tables[0].Rows[0]["nFromWeight"] != DBNull.Value ? ds.Tables[0].Rows[0]["nFromWeight"].ToString() : "";
                        txttoweight.Text = ds.Tables[0].Rows[0]["nToWeight"] != DBNull.Value ? ds.Tables[0].Rows[0]["nToWeight"].ToString() : "";
                        txtrate.Text = ds.Tables[0].Rows[0]["nRate"] != DBNull.Value ? ds.Tables[0].Rows[0]["nRate"].ToString() : "";
                        DDLType.SelectedValue = ds.Tables[0].Rows[0]["cType"] != DBNull.Value ? ds.Tables[0].Rows[0]["cType"].ToString() : "";
                        txtzone.Text = ds.Tables[0].Rows[0]["cZoneName"] != DBNull.Value ? ds.Tables[0].Rows[0]["cZoneName"].ToString() : "";
                        HifZone.Value = ds.Tables[0].Rows[0]["ZoneID"] != DBNull.Value ? ds.Tables[0].Rows[0]["ZoneID"].ToString() : "";
                    }
                    txtzone.Focus();
                    if (Request.QueryString["D"] != null)
                    {
                        ddldelete.Visible = true;
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
    public static List<string> SearchProduct(string prefixText, int count)
    {
        DataSet ds = new DataSet();
        SqlPavanCourier cn = new SqlPavanCourier();
        List<string> product = new List<string>();
        string cnm = "";
        ds = cn.RunSql("sp_Searchforautocomplete 'PB','" + prefixText + "','" + HttpContext.Current.Request.Cookies["compid"].Value + "','" + HttpContext.Current.Request.Cookies["branchid"].Value + "'", "select");
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cnm = AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(ds.Tables[0].Rows[i]["cProductName"].ToString(), ds.Tables[0].Rows[i]["nid"].ToString());
                product.Add(cnm);
            }
        }

        return product;
    }
    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static List<string> SearchZone(string prefixText, int count)
    {
        DataSet ds = new DataSet();
        SqlPavanCourier cn = new SqlPavanCourier();
        List<string> zone = new List<string>();
        string cnm = "";
        ds = cn.RunSql("sp_Searchforautocomplete 'ZB','" + prefixText + "','" + HttpContext.Current.Request.Cookies["compid"].Value + "','" + HttpContext.Current.Request.Cookies["branchid"].Value + "'", "select");
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cnm = AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(ds.Tables[0].Rows[i]["cZoneName"].ToString(), ds.Tables[0].Rows[i]["nid"].ToString());
                zone.Add(cnm);
            }
        }

        return zone;
    }
    protected void ImgBtnAdd_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (Request.QueryString["id"] != null)
            {
                if (Request.QueryString["cid"] != null)
                {
                    ds = cn.RunSql("sp_addcontractmaster 'PUCU','" + txtcontractcode.Text + "','" + txtcontractname.Text + "','" + HifProduct.Value + "','" + HifZone.Value + "','" + DDLCType.SelectedValue + "','" + txtfromweight.Text + "','" + txttoweight.Text + "','" + txtrate.Text + "','" + DDLType.SelectedValue + "','" + Request.Cookies["compid"].Value + "','" + Request.Cookies["loginid"].Value + "','" + Request.QueryString["id"] + "','" + Request.QueryString["cid"] + "','" + Request.Cookies["branchid"].Value + "'", "puci");
                    Response.Redirect("MasterContract.aspx?id=" + ds.Tables[0].Rows[0][0] + "");
                }
                else
                {
                    ds = cn.RunSql("sp_addcontractmaster 'PUCI','" + txtcontractcode.Text + "','" + txtcontractname.Text + "','" + HifProduct.Value + "','" + HifZone.Value + "','" + DDLCType.SelectedValue + "','" + txtfromweight.Text + "','" + txttoweight.Text + "','" + txtrate.Text + "','" + DDLType.SelectedValue + "','" + Request.Cookies["compid"].Value + "','" + Request.Cookies["loginid"].Value + "','" + Request.QueryString["id"] + "','','" + Request.Cookies["branchid"].Value + "'", "puci");
                    Response.Redirect("MasterContract.aspx?id=" + ds.Tables[0].Rows[0][0] + "");
                }
            }
            else
            {
                ds = cn.RunSql("sp_addcontractmaster 'I','" + txtcontractcode.Text + "','" + txtcontractname.Text + "','" + HifProduct.Value + "','" + HifZone.Value + "','" + DDLCType.SelectedValue + "','" + txtfromweight.Text + "','" + txttoweight.Text + "','" + txtrate.Text + "','" + DDLType.SelectedValue + "','" + Request.Cookies["compid"].Value + "','" + Request.Cookies["loginid"].Value + "','','','" + Request.Cookies["branchid"].Value + "'", "puci");
                Response.Redirect("MasterContract.aspx?id=" + ds.Tables[0].Rows[0][0] + "");
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
        Response.Redirect("ListContract.aspx");
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
                cnid = GvRateList.Rows[row.RowIndex].Cells[0].Text;
                ds = cn.RunSql("sp_addcontractmaster 'PUCD','" + txtcontractcode.Text + "','" + txtcontractname.Text + "','" + HifProduct.Value + "','" + HifZone.Value + "','" + DDLCType.SelectedValue + "','" + txtfromweight.Text + "','" + txttoweight.Text + "','" + txtrate.Text + "','" + DDLType.SelectedValue + "','" + Request.Cookies["compid"].Value + "','" + Request.Cookies["loginid"].Value + "','" + Request.QueryString["id"] + "','" + cnid + "','" + Request.Cookies["branchid"].Value + "'", "puci");
                Response.Redirect("MasterContract.aspx?id=" + ds.Tables[0].Rows[0][0] + "");
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
                if (Request.QueryString["D"] == "1")
                {
                    if (ddldelete.SelectedValue == "Yes")
                    {
                        ds = cn.RunSql("sp_addcontractmaster 'D','" + txtcontractcode.Text + "','" + txtcontractname.Text + "','" + HifProduct.Value + "','" + HifZone.Value + "','" + DDLCType.SelectedValue + "','" + txtfromweight.Text + "','" + txttoweight.Text + "','" + txtrate.Text + "','" + DDLType.SelectedValue + "','" + Request.Cookies["compid"].Value + "','" + Request.Cookies["loginid"].Value + "','" + Request.QueryString["id"] + "','" + Request.QueryString["cid"] + "','" + Request.Cookies["branchid"].Value + "'", "puci");
                        Session["Msg"] = "You have Sucessfully Delete Contract!!";
                        Response.Redirect("ListContract.aspx");
                    }
                }
                else
                {
                    ds = cn.RunSql("sp_addcontractmaster 'PU','" + txtcontractcode.Text + "','" + txtcontractname.Text + "','" + HifProduct.Value + "','" + HifZone.Value + "','" + DDLCType.SelectedValue + "','" + txtfromweight.Text + "','" + txttoweight.Text + "','" + txtrate.Text + "','" + DDLType.SelectedValue + "','" + Request.Cookies["compid"].Value + "','" + Request.Cookies["loginid"].Value + "','" + Request.QueryString["id"] + "','" + Request.QueryString["cid"] + "','" + Request.Cookies["branchid"].Value + "'", "puci");
                    Session["Msg"] = "You have Sucessfully Update Contract!!";
                    Response.Redirect("ListContract.aspx");
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
    protected void btnreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("MasterContract.aspx");
    }
}