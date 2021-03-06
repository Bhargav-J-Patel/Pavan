﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App_Code;
using System.Data;
using System.IO;
using System.Data.OleDb;

public partial class TranDRS : System.Web.UI.Page
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
                txtdate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                ds = cn.RunSql("sp_getsrno 'DRS','" + Request.Cookies["branchid"].Value + "','" + Request.Cookies["loginid"].Value + "'", "select");
                txtdrsno.Text = ds.Tables[0].Rows[0]["nDRSNo"].ToString();

                ds = cn.RunSql("sp_getprevdate", "select");
                txtbookdate.Text = ds.Tables[0].Rows[0][0] != DBNull.Value ? ds.Tables[0].Rows[0][0].ToString() : "";

                txtroute.Focus();

                ds = cn.RunSql("sp_usermanagement '" + Request.Cookies["branchid"].Value + "','" + Request.Cookies["loginid"].Value + "'", "select");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["cDRS"].ToString().Substring(0, 1) != "1")
                    {
                        Response.Redirect("home.aspx");
                    }
                    if (ds.Tables[0].Rows[0]["cDRS"].ToString().Substring(1, 1) != "1" && ds.Tables[0].Rows[0]["cDRS"].ToString().Substring(2, 1) != "1" && ds.Tables[0].Rows[0]["cDRS"].ToString().Substring(3, 1) != "1")
                    {
                        btnlist.Visible = false;
                    }
                }

                if (Request.QueryString["id"] != null)
                {
                    HIDPFID.Value = Request.QueryString["id"].ToString();
                    ds = cn.RunSql("sp_listDRS 's','" + Request.Cookies["branchid"].Value + "','" + Request.QueryString["id"] + "',''", "select");
                    txtdrsno.Text = ds.Tables[0].Rows[0]["nDRSNo"] != DBNull.Value ? ds.Tables[0].Rows[0]["nDRSNo"].ToString() : "";
                    txtdate.Text = ds.Tables[0].Rows[0]["dDate"] != DBNull.Value ? ds.Tables[0].Rows[0]["dDate"].ToString() : "";
                    txtorigin.Text = ds.Tables[0].Rows[0]["cOrigin"] != DBNull.Value ? ds.Tables[0].Rows[0]["cOrigin"].ToString() : "";
                    txtbookdate.Text = ds.Tables[0].Rows[0]["dBookDate"] != DBNull.Value ? ds.Tables[0].Rows[0]["dBookDate"].ToString() : "";
                    HifRoute.Value = ds.Tables[0].Rows[0]["cRoute"] != DBNull.Value ? ds.Tables[0].Rows[0]["cRoute"].ToString() : "";
                    HifBoy.Value = ds.Tables[0].Rows[0]["cBoy"] != DBNull.Value ? ds.Tables[0].Rows[0]["cBoy"].ToString() : "";
                    HifLoc.Value = ds.Tables[0].Rows[0]["cLocation"] != DBNull.Value ? ds.Tables[0].Rows[0]["cLocation"].ToString() : "";
                    txtlocation.Text = ds.Tables[0].Rows[0]["cLocationName"] != DBNull.Value ? ds.Tables[0].Rows[0]["cLocationName"].ToString() : "";
                    txtroute.Text = ds.Tables[0].Rows[0]["cDeliveryName"] != DBNull.Value ? ds.Tables[0].Rows[0]["cDeliveryName"].ToString() : "";
                    txtboy.Text = ds.Tables[0].Rows[0]["cCustomerName"] != DBNull.Value ? ds.Tables[0].Rows[0]["cCustomerName"].ToString() : "";

                    //txtweight.Text = ds.Tables[2].Rows[0]["cweight"] != DBNull.Value ? ds.Tables[2].Rows[0]["cweight"].ToString() : "";
                    //txtpcs.Text = ds.Tables[2].Rows[0]["cpcs"] != DBNull.Value ? ds.Tables[2].Rows[0]["cpcs"].ToString() : "";
                    txtawbno.Focus();

                    GvAWBList.DataSource = ds.Tables[1];
                    GvAWBList.DataBind();

                    LblTotalRate.Text = ds.Tables[3].Rows[0]["rate"] != DBNull.Value ? ds.Tables[3].Rows[0]["rate"].ToString() : "";

                    //if (Request.Cookies["cType"].Value == "0")
                    //{
                    //    GvAWBList.Columns[4].Visible = false;
                    //}

                    if (Request.QueryString["cid"] != null)
                    {
                        thpcs.Visible = true;
                        thweight.Visible = true;
                        threcv.Visible = true;


                        tdweight.Attributes.Remove("style");
                        tdpcs.Attributes.Remove("style");
                        tdrecv.Attributes.Remove("style");
                        tdbtnad.Attributes.Remove("style");
                        
                        //tdweight.Visible = true;
                        //tdpcs.Visible = true;
                        //tdrecv.Visible = true;
                        //tdbtnad.Visible = true;

                        ds = cn.RunSql("sp_listDRS 'c','" + Request.Cookies["branchid"].Value + "','" + Request.QueryString["id"] + "','" + Request.QueryString["cid"] + "'", "select");
                        txtweight.Text = ds.Tables[0].Rows[0]["cweight"] != DBNull.Value ? ds.Tables[0].Rows[0]["cweight"].ToString() : "";
                        txtawbno.Text = ds.Tables[0].Rows[0]["nAWBNo"] != DBNull.Value ? ds.Tables[0].Rows[0]["nAWBNo"].ToString() : "";
                        TxtRecvrNm.Text = ds.Tables[0].Rows[0]["cReceiverName"] != DBNull.Value ? ds.Tables[0].Rows[0]["cReceiverName"].ToString() : "";
                        txtpcs.Text = ds.Tables[0].Rows[0]["cpcs"] != DBNull.Value ? ds.Tables[0].Rows[0]["cpcs"].ToString() : "";
                    }
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
        }
    }
    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static List<string> Searchrecv(string prefixText, int count)
    {
        DataSet ds = new DataSet();
        SqlPavanCourier cn = new SqlPavanCourier();
        List<string> cus = new List<string>();
        string cnm = "";
        ds = cn.RunSql("sp_Searchforautocomplete 'shippedto','" + prefixText + "','" + HttpContext.Current.Request.Cookies["compid"].Value + "'", "select");
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cnm = AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(ds.Tables[0].Rows[i]["cShippedTo"].ToString(), ds.Tables[0].Rows[i]["cShippedTo"].ToString());
                cus.Add(cnm);
            }
        }
        return cus;
    }

    protected void btnlist_Click(object sender, EventArgs e)
    {
        Response.Redirect("ListDRS.aspx");
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
                        ds = cn.RunSql("sp_addDRSTran 'D','" + txtdrsno.Text + "','" + txtdate.Text + "','" + HifRoute.Value + "','" + HifBoy.Value + "','" + HifLoc.Value + "','" + txtorigin.Text + "','" + txtbookdate.Text + "','" + txtweight.Text + "','" + txtpcs.Text + "','" + txtawbno.Text + "','" + Request.Cookies["branchid"].Value + "','" + HIDPFID.Value + "','" + Request.QueryString["cid"] + "','0','" + TxtRecvrNm.Text + "','" + Request.Cookies["loginid"].Value + "'", "puci");
                        Session["Msg"] = "You have Sucessfully Delete DRS!!";
                        Response.Redirect("ListDRS.aspx");
                    }
                }
                else
                {
                    ds = cn.RunSql("sp_addDRSTran 'PU','" + txtdrsno.Text + "','" + txtdate.Text + "','" + HifRoute.Value + "','" + HifBoy.Value + "','" + HifLoc.Value + "','" + txtorigin.Text + "','" + txtbookdate.Text + "','" + txtweight.Text + "','" + txtpcs.Text + "','" + txtawbno.Text + "','" + Request.Cookies["branchid"].Value + "','" + HIDPFID.Value + "','" + Request.QueryString["cid"] + "','0','" + TxtRecvrNm.Text + "','" + Request.Cookies["loginid"].Value + "'", "puci");
                    Session["Msg"] = "You have Sucessfully Update DRS!!";
                    Response.Redirect("ListDRS.aspx");
                }
            }
        }
        catch (Exception ex)
        {
            lblerror.Text = ex.Message;
            diverror.Visible = true;
        }
    }
    protected void btnreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("TranDRS.aspx");
    }

    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static List<string> SearchCus(string prefixText, int count)
    {
        DataSet ds = new DataSet();
        SqlPavanCourier cn = new SqlPavanCourier();
        List<string> cus = new List<string>();
        string cnm = "";
        ds = cn.RunSql("sp_Searchforautocomplete 'DCouRoute','" + prefixText + "','" + HttpContext.Current.Request.Cookies["compid"].Value + "','" + HttpContext.Current.Request.Cookies["branchid"].Value + "','" + HttpContext.Current.Request.Cookies["loginid"].Value + "'", "select");
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
    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static List<string> SearchRoute(string prefixText, int count)
    {
        DataSet ds = new DataSet();
        SqlPavanCourier cn = new SqlPavanCourier();
        List<string> cus = new List<string>();
        string cnm = "";
        ds = cn.RunSql("sp_Searchforautocomplete 'DRouteUser','" + prefixText + "','" + HttpContext.Current.Request.Cookies["compid"].Value + "','" + HttpContext.Current.Request.Cookies["branchid"].Value + "','" + HttpContext.Current.Request.Cookies["loginid"].Value + "'", "select");
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cnm = AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(ds.Tables[0].Rows[i]["cDeliveryRouteName"].ToString(), ds.Tables[0].Rows[i]["nid"].ToString());
                cus.Add(cnm);
            }
        }
        return cus;
    }
    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static List<string> SearchLoc(string prefixText, int count)
    {
        DataSet ds = new DataSet();
        SqlPavanCourier cn = new SqlPavanCourier();
        List<string> cus = new List<string>();
        string cnm = "";
        ds = cn.RunSql("sp_Searchforautocomplete 'DL','" + prefixText + "','" + HttpContext.Current.Request.Cookies["compid"].Value + "','" + HttpContext.Current.Request.Cookies["branchid"].Value + "'", "select");
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cnm = AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(ds.Tables[0].Rows[i]["cLocationName"].ToString(), ds.Tables[0].Rows[i]["nid"].ToString());
                cus.Add(cnm);
            }
        }
        return cus;
    }
    protected void ImgBtnAdd_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (Request.QueryString["id"] != null)
            {
                if (Request.QueryString["cid"] != null)
                {
                    //                    ds = cn.RunSql("sp_addDRSTran 'PUCU','" + txtdrsno.Text + "','" + txtdate.Text + "','" + HifRoute.Value + "','" + HifBoy.Value + "','" + HifLoc.Value + "','" + txtorigin.Text + "','" + txtbookdate.Text + "','" + txtweight.Text + "','" + txtawbno.Text + "','" + Request.Cookies["branchid"].Value + "','" + Request.QueryString["id"] + "','" + Request.QueryString["cid"] + "'", "pucu");
                    ds = cn.RunSql("sp_addDRSTran 'PUCU','" + txtdrsno.Text + "','" + txtdate.Text + "','" + HifRoute.Value + "','" + HifBoy.Value + "','" + HifLoc.Value + "','" + txtorigin.Text + "','" + txtbookdate.Text + "','" + txtweight.Text + "','" + txtpcs.Text + "','" + txtawbno.Text + "','" + Request.Cookies["branchid"].Value + "','" + HIDPFID.Value + "','" + Request.QueryString["cid"] + "','0','" + TxtRecvrNm.Text + "','" + Request.Cookies["loginid"].Value + "'", "pucu");
                    Response.Redirect("TranDRS.aspx?id=" + ds.Tables[0].Rows[0][0] + "");
                }
                //else
                //{
                //    ds = cn.RunSql("sp_addDRSTran 'PUCI','" + txtdrsno.Text + "','" + txtdate.Text + "','" + HifRoute.Value + "','" + HifBoy.Value + "','" + HifLoc.Value + "','" + txtorigin.Text + "','" + txtbookdate.Text + "','" + txtweight.Text + "','" + txtawbno.Text + "','" + Request.Cookies["branchid"].Value + "','" + Request.QueryString["id"] + "',''", "puci");
                //    Response.Redirect("TranDRS.aspx?id=" + ds.Tables[0].Rows[0][0] + "");
                //}
            }
            //else
            //{
            //    ds = cn.RunSql("sp_addDRSTran 'I','" + txtdrsno.Text + "','" + txtdate.Text + "','" + HifRoute.Value + "','" + HifBoy.Value + "','" + HifLoc.Value + "','" + txtorigin.Text + "','" + txtbookdate.Text + "','" + txtweight.Text + "','" + txtawbno.Text + "','" + Request.Cookies["branchid"].Value + "','',''", "insert");
            //    Response.Redirect("TranDRS.aspx?id=" + ds.Tables[0].Rows[0][0] + "");
            //}
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
                cnid = GvAWBList.Rows[row.RowIndex].Cells[0].Text;
                ds = cn.RunSql("sp_addDRSTran 'PUCD','" + txtdrsno.Text + "','" + txtdate.Text + "','" + HifRoute.Value + "','" + HifBoy.Value + "','" + HifLoc.Value + "','" + txtorigin.Text + "','" + txtbookdate.Text + "','" + txtweight.Text + "','" + txtpcs.Text + "','" + txtawbno.Text + "','" + Request.Cookies["branchid"].Value + "','" + HIDPFID.Value + "','" + cnid + "','0','" + TxtRecvrNm.Text + "','" + Request.Cookies["loginid"].Value + "'", "pucu");
                Response.Redirect("TranDRS.aspx?id=" + ds.Tables[0].Rows[0][0] + "");
            }
        }
        catch (Exception ex)
        {
            lblerror.Text = ex.Message;
            diverror.Visible = true;
        }

    }
    protected void btnprint_Click(object sender, EventArgs e)
    {
        Response.Redirect("Report.aspx?ID=" + HIDPFID.Value + "&rpt=4&drsno=" + txtdrsno.Text + "");
    }
    protected void txtawbno_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (HIDPFID.Value != "0")
            {
                if (Request.QueryString["cid"] != null)
                {
                    ds = cn.RunSql("sp_addDRSTran 'PUCU','" + txtdrsno.Text + "','" + txtdate.Text + "','" + HifRoute.Value + "','" + HifBoy.Value + "','" + HifLoc.Value + "','" + txtorigin.Text + "','" + txtbookdate.Text + "','" + txtweight.Text + "','" + txtpcs.Text + "','" + txtawbno.Text + "','" + Request.Cookies["branchid"].Value + "','" + HIDPFID.Value + "','" + Request.QueryString["cid"] + "','0','" + TxtRecvrNm.Text + "','" + Request.Cookies["loginid"].Value + "'", "pucu");
                    if (ds.Tables[0].Rows[0][0].ToString() == "Enter Weight and Pcs")
                    {
                        TxtRecvrNm.Focus();
                        //txtpcs.Text = "1";
                    }
                    else
                    {
                        //Response.Redirect("TranDRS.aspx?id=" + ds.Tables[0].Rows[0][0] + "");
                        HIDPFID.Value = ds.Tables[0].Rows[0][0].ToString();
                        ClearChild();
                        bindGrid();
                        txtawbno.Focus();
                    }
                }
                else
                {
                    ds = cn.RunSql("sp_addDRSTran 'PUCI','" + txtdrsno.Text + "','" + txtdate.Text + "','" + HifRoute.Value + "','" + HifBoy.Value + "','" + HifLoc.Value + "','" + txtorigin.Text + "','" + txtbookdate.Text + "','" + txtweight.Text + "','" + txtpcs.Text + "','" + txtawbno.Text + "','" + Request.Cookies["branchid"].Value + "','" + HIDPFID.Value + "','','0','" + TxtRecvrNm.Text + "','" + Request.Cookies["loginid"].Value + "'", "puci");
                    if (ds.Tables[0].Rows[0][0].ToString() == "Enter Weight and Pcs")
                    {
                        TxtRecvrNm.Focus();
                        //txtweight.Focus();
                        //txtpcs.Text = "1";
                    }
                    else
                    {
                        //Response.Redirect("TranDRS.aspx?id=" + ds.Tables[0].Rows[0][0] + "");
                        HIDPFID.Value = ds.Tables[0].Rows[0][0].ToString();
                        ClearChild();
                        bindGrid();
                        txtawbno.Focus();

                    }
                }
            }
            else
            {
                ds = cn.RunSql("sp_addDRSTran 'I','" + txtdrsno.Text + "','" + txtdate.Text + "','" + HifRoute.Value + "','" + HifBoy.Value + "','" + HifLoc.Value + "','" + txtorigin.Text + "','" + txtbookdate.Text + "','" + txtweight.Text + "','" + txtpcs.Text + "','" + txtawbno.Text + "','" + Request.Cookies["branchid"].Value + "','','','0','" + TxtRecvrNm.Text + "','" + Request.Cookies["loginid"].Value + "'", "insert");
                if (ds.Tables[0].Rows[0][0].ToString() == "Enter Weight and Pcs")
                {
                    TxtRecvrNm.Focus();
                    //txtpcs.Text = "1";
                }
                else
                {
                    //Response.Redirect("TranDRS.aspx?id=" + ds.Tables[0].Rows[0][0] + "");
                    HIDPFID.Value = ds.Tables[0].Rows[0][0].ToString();
                    ClearChild();
                    bindGrid();
                    txtawbno.Focus();
                }
                //Response.Redirect("TranDRS.aspx?id=" + ds.Tables[0].Rows[0][0] + "");
                //HIDPFID.Value = ds.Tables[0].Rows[0][0].ToString();
                //ClearChild();
                //bindGrid();

            }
        }
        catch (Exception ex)
        {
            txtawbno.Focus();
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
            TxtRecvrNm.Text = "";
            txtweight.Text = "";
            txtpcs.Text = "";
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
                ds = cn.RunSql("sp_listDRS 's','" + Request.Cookies["branchid"].Value + "','" + HIDPFID.Value + "',''", "select");
                GvAWBList.DataSource = ds.Tables[1];
                GvAWBList.DataBind();
                LblTotalRate.Text = ds.Tables[3].Rows[0]["rate"] != DBNull.Value ? ds.Tables[3].Rows[0]["rate"].ToString() : "";
                txtawbno.Focus();
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
    protected void BtnUpload_Click(object sender, EventArgs e)
    {
        try
        {
            string FilePath = "";
            string Extention = "";
            string Filename = FileUpload1.FileName;
            //DataTable = new DataTable();
            if (FileUpload1.HasFile == true)
            {
                Extention = Path.GetExtension(FileUpload1.FileName);
                if (Extention.ToString().ToUpper() == ".CSV")
                {
                    FilePath = Server.MapPath("~/");
                    FilePath += @"csv\";

                    FileUpload1.SaveAs(FilePath + Filename);

                    string sql = @"SELECT * FROM [" + Filename + "]";

                    using (OleDbConnection connection = new OleDbConnection(
                              @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + FilePath +
                              ";Extended Properties=\"Text;HDR=Yes\""))
                    using (OleDbCommand command = new OleDbCommand(sql, connection))
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter(command))
                    {
                        WriteSchema(FilePath, Filename);
                        adapter.Fill(ds);
                    }
                    //string XMLData = ds.GetXml();
                    ReadFunction(ds);
                    Session["Msg"] = "You have sucessfully Upload Manifest Transaction !!";
                    Response.Redirect("TranManifest.aspx");

                }
                else
                {
                    LblWarning.Text = "Please Upload CSV File! !";
                    DivWarning.Visible = true;
                }
            }
            else
            {
                LblWarning.Text = "Please Upload Proper File! !";
                DivWarning.Visible = true;
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
    public void ReadFunction(DataSet ds1)
    {
        string pid = "";
        for (int i = 0; i <= ds1.Tables[0].Rows.Count - 1; i++)
        {

            if (ds1.Tables[0].Rows[i]["A"].ToString() != "")
            {
                string weight = ds1.Tables[0].Rows[i]["A"].ToString();
                string pcs = ds1.Tables[0].Rows[i]["B"].ToString();
                string awbno = ds1.Tables[0].Rows[i]["C"].ToString();

                if (i == 0)
                {
                    ds = cn.RunSql("sp_addDRSCSV 'I','','" + txtdate.Text + "','" + HifRoute.Value + "','" + HifBoy.Value + "','" + HifLoc.Value + "','" + txtorigin.Text + "','" + txtbookdate.Text + "','" + weight + "','" + pcs + "','" + awbno + "','" + Request.Cookies["branchid"].Value + "','" + Request.Cookies["compid"].Value + "'", "Data");
                    pid = ds.Tables[0].Rows[0][0].ToString();
                }
                else
                {
                    ds = cn.RunSql("sp_addDRSCSV 'C','" + pid + "','" + txtdate.Text + "','" + HifRoute.Value + "','" + HifBoy.Value + "','" + HifLoc.Value + "','" + txtorigin.Text + "','" + txtbookdate.Text + "','" + weight + "','" + pcs + "','" + awbno + "','" + Request.Cookies["branchid"].Value + "','" + Request.Cookies["compid"].Value + "'", "Data");
                }

            }
            else
            {
                break;
            }

        }
    }
    public void WriteSchema(string FilePath, string Filename)
    {

        using (FileStream FileStr = new FileStream(FilePath + "\\schema.ini", FileMode.Create, FileAccess.Write))
        {
            using (StreamWriter writer = new StreamWriter(FileStr))
            {
                writer.WriteLine("[" + Filename + "]");
                writer.WriteLine("ColNameHeader=True");
                writer.WriteLine("Format=CSVDelimited");
                writer.WriteLine("Col1=A Double");
                writer.WriteLine("Col2=B Text");
                writer.WriteLine("Col3=C Double");
                writer.Close();
                writer.Dispose();
            }
            FileStr.Close();
            FileStr.Dispose();

        }

    }
    protected void txtpcs_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (HIDPFID.Value != "0")
            {
                if (Request.QueryString["cid"] != null)
                {
                    ds = cn.RunSql("sp_addDRSTran 'PUCU','" + txtdrsno.Text + "','" + txtdate.Text + "','" + HifRoute.Value + "','" + HifBoy.Value + "','" + HifLoc.Value + "','" + txtorigin.Text + "','" + txtbookdate.Text + "','" + txtweight.Text + "','" + txtpcs.Text + "','" + txtawbno.Text + "','" + Request.Cookies["branchid"].Value + "','" + HIDPFID.Value + "','" + Request.QueryString["cid"] + "','1','" + TxtRecvrNm.Text + "','" + Request.Cookies["loginid"].Value + "'", "pucu");
                    if (ds.Tables[0].Rows[0][0].ToString() == "Enter Weight and Pcs")
                    {
                        TxtRecvrNm.Focus();
                        //txtpcs.Text = "1";
                    }
                    else
                    {
                        //Response.Redirect("TranDRS.aspx?id=" + ds.Tables[0].Rows[0][0] + "");
                        HIDPFID.Value = ds.Tables[0].Rows[0][0].ToString();
                        ClearChild();
                        bindGrid();
                        txtawbno.Focus();
                    }
                }
                else
                {
                    ds = cn.RunSql("sp_addDRSTran 'PUCI','" + txtdrsno.Text + "','" + txtdate.Text + "','" + HifRoute.Value + "','" + HifBoy.Value + "','" + HifLoc.Value + "','" + txtorigin.Text + "','" + txtbookdate.Text + "','" + txtweight.Text + "','" + txtpcs.Text + "','" + txtawbno.Text + "','" + Request.Cookies["branchid"].Value + "','" + HIDPFID.Value + "','','1','" + TxtRecvrNm.Text + "','" + Request.Cookies["loginid"].Value + "'", "puci");
                    if (ds.Tables[0].Rows[0][0].ToString() == "Enter Weight and Pcs")
                    {
                        TxtRecvrNm.Focus();
                        //txtpcs.Text = "1";
                    }
                    else
                    {
                        //Response.Redirect("TranDRS.aspx?id=" + ds.Tables[0].Rows[0][0] + "");
                        HIDPFID.Value = ds.Tables[0].Rows[0][0].ToString();
                        ClearChild();
                        bindGrid();
                        txtawbno.Focus();

                    }
                }
            }
            else
            {
                ds = cn.RunSql("sp_addDRSTran 'I','" + txtdrsno.Text + "','" + txtdate.Text + "','" + HifRoute.Value + "','" + HifBoy.Value + "','" + HifLoc.Value + "','" + txtorigin.Text + "','" + txtbookdate.Text + "','" + txtweight.Text + "','" + txtpcs.Text + "','" + txtawbno.Text + "','" + Request.Cookies["branchid"].Value + "','','','1','" + TxtRecvrNm.Text + "','" + Request.Cookies["loginid"].Value + "'", "insert");
                if (ds.Tables[0].Rows[0][0].ToString() == "Enter Weight and Pcs")
                {
                    TxtRecvrNm.Focus();
                    txtpcs.Text = "1";
                }
                else
                {
                    //Response.Redirect("TranDRS.aspx?id=" + ds.Tables[0].Rows[0][0] + "");
                    HIDPFID.Value = ds.Tables[0].Rows[0][0].ToString();
                    ClearChild();
                    bindGrid();
                }
                //Response.Redirect("TranDRS.aspx?id=" + ds.Tables[0].Rows[0][0] + "");
                //HIDPFID.Value = ds.Tables[0].Rows[0][0].ToString();
                //ClearChild();
                //bindGrid();

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

    protected void TxtRecvrNm_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (HIDPFID.Value != "0")
            {
                if (Request.QueryString["cid"] != null)
                {
                    ds = cn.RunSql("sp_addDRSTran 'PUCU','" + txtdrsno.Text + "','" + txtdate.Text + "','" + HifRoute.Value + "','" + HifBoy.Value + "','" + HifLoc.Value + "','" + txtorigin.Text + "','" + txtbookdate.Text + "','" + txtweight.Text + "','" + txtpcs.Text + "','" + txtawbno.Text + "','" + Request.Cookies["branchid"].Value + "','" + HIDPFID.Value + "','" + Request.QueryString["cid"] + "','1','" + TxtRecvrNm.Text + "','" + Request.Cookies["loginid"].Value + "'", "pucu");
                    if (ds.Tables[0].Rows[0][0].ToString() == "Enter Weight and Pcs")
                    {
                        //TxtRecvrNm.Focus();
                        //txtpcs.Text = "1";
                    }
                    else
                    {
                        //Response.Redirect("TranDRS.aspx?id=" + ds.Tables[0].Rows[0][0] + "");
                        HIDPFID.Value = ds.Tables[0].Rows[0][0].ToString();
                        ClearChild();
                        bindGrid();
                    }
                }
                else
                {
                    ds = cn.RunSql("sp_addDRSTran 'PUCI','" + txtdrsno.Text + "','" + txtdate.Text + "','" + HifRoute.Value + "','" + HifBoy.Value + "','" + HifLoc.Value + "','" + txtorigin.Text + "','" + txtbookdate.Text + "','" + txtweight.Text + "','" + txtpcs.Text + "','" + txtawbno.Text + "','" + Request.Cookies["branchid"].Value + "','" + HIDPFID.Value + "','','1','" + TxtRecvrNm.Text + "','" + Request.Cookies["loginid"].Value + "'", "puci");
                    if (ds.Tables[0].Rows[0][0].ToString() == "Enter Weight and Pcs")
                    {
                        //TxtRecvrNm.Focus();
                        //txtpcs.Text = "1";
                    }
                    else
                    {
                        //Response.Redirect("TranDRS.aspx?id=" + ds.Tables[0].Rows[0][0] + "");
                        HIDPFID.Value = ds.Tables[0].Rows[0][0].ToString();
                        ClearChild();
                        bindGrid();

                    }
                }
            }
            else
            {
                ds = cn.RunSql("sp_addDRSTran 'I','" + txtdrsno.Text + "','" + txtdate.Text + "','" + HifRoute.Value + "','" + HifBoy.Value + "','" + HifLoc.Value + "','" + txtorigin.Text + "','" + txtbookdate.Text + "','" + txtweight.Text + "','" + txtpcs.Text + "','" + txtawbno.Text + "','" + Request.Cookies["branchid"].Value + "','','','1','" + TxtRecvrNm.Text + "','" + Request.Cookies["loginid"].Value + "'", "insert");
                if (ds.Tables[0].Rows[0][0].ToString() == "Enter Weight and Pcs")
                {
                    //TxtRecvrNm.Focus();
                    // txtpcs.Text = "1";
                }
                else
                {
                    //Response.Redirect("TranDRS.aspx?id=" + ds.Tables[0].Rows[0][0] + "");
                    HIDPFID.Value = ds.Tables[0].Rows[0][0].ToString();
                    ClearChild();
                    bindGrid();
                }
                //Response.Redirect("TranDRS.aspx?id=" + ds.Tables[0].Rows[0][0] + "");
                //HIDPFID.Value = ds.Tables[0].Rows[0][0].ToString();
                //ClearChild();
                //bindGrid();

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
