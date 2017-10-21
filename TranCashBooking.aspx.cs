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
using System.Globalization;

public partial class TranCashBooking : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    DataSet ds1 = new DataSet();
    SqlPavanCourier cn = new SqlPavanCourier();
    Control ctrl = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["branchid"] == null)
        {
            Response.Redirect("login.aspx");
        }

        if (Session["Msg"] != null)
        {
            lblsucess.Text = Session["Msg"].ToString();
            divsucess.Visible = true;
            Session["Msg"] = null;
        }

        if (Request.Params["__EVENTTARGET"] != null)
        {
            string eTarget = Request.Params["__EVENTTARGET"].ToString();
            if (!String.IsNullOrEmpty(eTarget))
                ctrl = Page.FindControl(eTarget);
            if (ctrl.ID == "TxtWeight")
            {
                TxtAmt.Focus();
            }
            else if (ctrl.ID == "txtdestination")
            {
                TxtShippedTo.Focus();
            }
        }

        if (IsPostBack == false)
        {
            try
            {
                TxtCustomer.Focus();
                TxtDate.Text = DateTime.Now.ToString("dd/MM/yyyy");

                ds = cn.RunSql("sp_getsrno 'Cash','" + Request.Cookies["branchid"].Value + "'", "select");
                TxtBookingNo.Text = ds.Tables[0].Rows[0]["nBookingNo"].ToString();


                ds1 = cn.RunSql("sp_getbookingno '" + Request.Cookies["cAgentID"].Value + "','" + Request.Cookies["branchid"].Value + "','" + Request.Cookies["loginid"].Value + "'", "select");
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    TxtAWBNo.Text = ds1.Tables[0].Rows[0]["nFromAMWNo"] != DBNull.Value ? ds1.Tables[0].Rows[0]["nFromAMWNo"].ToString() : "";
                }

                if (ds1.Tables[1].Rows.Count > 0)
                {
                    LblLastEntry.Text = ds1.Tables[1].Rows[0]["bookno"] != DBNull.Value ? ds1.Tables[1].Rows[0]["bookno"].ToString() : "";
                    TxtAWBNo.Text = ds1.Tables[2].Rows[0]["bookno"] != DBNull.Value ? ds1.Tables[2].Rows[0]["bookno"].ToString() : "";
                }

                ds = cn.RunSql("sp_selectsystemsetting '" + Request.Cookies["branchid"].Value + "'", "select");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    TxtWeight.Text = ds.Tables[0].Rows[0]["nCashWeight"] != DBNull.Value ? ds.Tables[0].Rows[0]["nCashWeight"].ToString() : "";
                }

                ds = cn.RunSql("sp_usermanagement '" + Request.Cookies["branchid"].Value + "','" + Request.Cookies["loginid"].Value + "'", "select");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["cCashBooking"].ToString().Substring(0, 1) != "1")
                    {
                        Response.Redirect("home.aspx");
                    }
                    if (ds.Tables[0].Rows[0]["cCashBooking"].ToString().Substring(1, 1) != "1" && ds.Tables[0].Rows[0]["cCashBooking"].ToString().Substring(2, 1) != "1" && ds.Tables[0].Rows[0]["cCashBooking"].ToString().Substring(3, 1) != "1")
                    {
                        btnlist.Visible = false;
                    }
                }

                if (Request.QueryString["id"] != null)
                {
                    ds = cn.RunSql("sp_listCash 's','" + Request.Cookies["branchid"].Value + "','" + Request.QueryString["id"] + "'", "select");
                    TxtBookingNo.Text = ds.Tables[0].Rows[0]["nBookingNo"] != DBNull.Value ? ds.Tables[0].Rows[0]["nBookingNo"].ToString() : "";
                    TxtDate.Text = ds.Tables[0].Rows[0]["dBookingDt"] != DBNull.Value ? ds.Tables[0].Rows[0]["dBookingDt"].ToString() : "";
                    HifDestination.Value = ds.Tables[0].Rows[0]["cDestination"] != DBNull.Value ? ds.Tables[0].Rows[0]["cDestination"].ToString() : "";
                    TxtCustomer.Text = ds.Tables[0].Rows[0]["cCustomer"] != DBNull.Value ? ds.Tables[0].Rows[0]["cCustomer"].ToString() : "";
                    txtdestination.Text = ds.Tables[0].Rows[0]["dest"] != DBNull.Value ? ds.Tables[0].Rows[0]["dest"].ToString() : "";
                    TxtShippedTo.Text = ds.Tables[0].Rows[0]["cShippedTo"] != DBNull.Value ? ds.Tables[0].Rows[0]["cShippedTo"].ToString() : "";
                    DDlContent.SelectedValue = ds.Tables[0].Rows[0]["cContenet"] != DBNull.Value ? ds.Tables[0].Rows[0]["cContenet"].ToString() : "";
                    TxtNoOfPkg.Text = ds.Tables[0].Rows[0]["nNoofPkt"] != DBNull.Value ? ds.Tables[0].Rows[0]["nNoofPkt"].ToString() : "";
                    TxtWeight.Text = ds.Tables[0].Rows[0]["cWeight"] != DBNull.Value ? ds.Tables[0].Rows[0]["cWeight"].ToString() : "";
                    TxtAmt.Text = ds.Tables[0].Rows[0]["nAmt"] != DBNull.Value ? ds.Tables[0].Rows[0]["nAmt"].ToString() : "";
                    TxtAWBNo.Text = ds.Tables[0].Rows[0]["nAWBNo"] != DBNull.Value ? ds.Tables[0].Rows[0]["nAWBNo"].ToString() : "";
                    TxtValue.Text = ds.Tables[0].Rows[0]["cvalue"] != DBNull.Value ? ds.Tables[0].Rows[0]["cvalue"].ToString() : "";
                    ChkPaymentRecvd.Checked = ds.Tables[0].Rows[0]["cPaymentRecvd"] != DBNull.Value ? ds.Tables[0].Rows[0]["cPaymentRecvd"].ToString() == "true" ? true : false : false;
                    ChkDestination.Checked = ds.Tables[0].Rows[0]["cchkDestination"] != DBNull.Value ? ds.Tables[0].Rows[0]["cchkDestination"].ToString() == "1" ? true : false : false;
                    ChkAWBNo.Checked = ds.Tables[0].Rows[0]["nchkAWBNo"] != DBNull.Value ? ds.Tables[0].Rows[0]["nchkAWBNo"].ToString() == "1" ? true : false : false;
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
    protected void btnlist_Click(object sender, EventArgs e)
    {
        Response.Redirect("ListCashBooking.aspx");
    }

    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static List<string> SearchCus(string prefixText, int count)
    {
        DataSet ds = new DataSet();
        SqlPavanCourier cn = new SqlPavanCourier();
        List<string> cus = new List<string>();
        string cnm = "";
        ds = cn.RunSql("sp_Searchforautocomplete 'shipper','" + prefixText + "','" + HttpContext.Current.Request.Cookies["compid"].Value + "','" + HttpContext.Current.Request.Cookies["branchid"].Value + "'", "select");
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cnm = AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(ds.Tables[0].Rows[i]["cCustomer"].ToString(), ds.Tables[0].Rows[i]["cCustomer"].ToString());
                cus.Add(cnm);
            }
        }
        return cus;
    }

    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static List<string> Searchrecv(string prefixText, int count)
    {
        DataSet ds = new DataSet();
        SqlPavanCourier cn = new SqlPavanCourier();
        List<string> cus = new List<string>();
        string cnm = "";
        ds = cn.RunSql("sp_Searchforautocomplete 'shippedto','" + prefixText + "','" + HttpContext.Current.Request.Cookies["compid"].Value + "','" + HttpContext.Current.Request.Cookies["branchid"].Value + "'", "select");
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

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        try
        {
            string strChkPaymentRecvd = ChkPaymentRecvd.Checked == true ? "true" : "false";
            if (Request.QueryString["id"] != null)
            {
                if (Request.QueryString["E"] == "1")
                {
                    ds = cn.RunSql("sp_addCashBookingTran 'U','" + TxtBookingNo.Text + "','" + TxtDate.Text + "','" + TxtCustomer.Text + "','" + HifDestination.Value + "','" + HifProduct.Value + "','" + TxtShippedTo.Text + "','" + DDlContent.SelectedValue + "','" + TxtNoOfPkg.Text + "','" + TxtWeight.Text + "','" + TxtAmt.Text + "','" + Request.Cookies["compid"].Value + "','" + Request.Cookies["branchid"].Value + "','" + Request.QueryString["id"] + "','" + TxtAWBNo.Text + "','" + TxtValue.Text + "','" + strChkPaymentRecvd + "','" + Request.Cookies["loginid"].Value + "','" + Request.Cookies["cAgentID"].Value + "','" + txtdestination.Text + "','" + (ChkDestination.Checked == true ? "1" : "0").ToString() + "','" + (ChkAWBNo.Checked == true ? "1" : "0").ToString() + "'", "update");
                    Session["Msg"] = "You have sucessfully Update Cash Transaction !!";
                    Response.Redirect("ListCashBooking.aspx");
                }
                if (Request.QueryString["D"] == "1")
                {
                    if (ddldelete.SelectedValue == "Yes")
                    {
                        ds = cn.RunSql("sp_addCashBookingTran 'D','" + TxtBookingNo.Text + "','" + TxtDate.Text + "','" + TxtCustomer.Text + "','" + HifDestination.Value + "','" + HifProduct.Value + "','" + TxtShippedTo.Text + "','" + DDlContent.SelectedValue + "','" + TxtNoOfPkg.Text + "','" + TxtWeight.Text + "','" + TxtAmt.Text + "','" + Request.Cookies["compid"].Value + "','" + Request.Cookies["branchid"].Value + "','" + Request.QueryString["id"] + "','" + TxtAWBNo.Text + "','" + TxtValue.Text + "','" + strChkPaymentRecvd + "','" + Request.Cookies["loginid"].Value + "','" + Request.Cookies["cAgentID"].Value + "','" + txtdestination.Text + "','" + (ChkDestination.Checked == true ? "1" : "0").ToString() + "','" + (ChkAWBNo.Checked == true ? "1" : "0").ToString() + "'", "delete");
                        Session["Msg"] = "You have sucessfully Delete Cash Transaction !!";
                        Response.Redirect("ListCashBooking.aspx");
                    }
                }
            }
            else
            {
                ds = cn.RunSql("sp_addCashBookingTran 'I','" + TxtBookingNo.Text + "','" + TxtDate.Text + "','" + TxtCustomer.Text + "','" + HifDestination.Value + "','" + HifProduct.Value + "','" + TxtShippedTo.Text + "','" + DDlContent.SelectedValue + "','" + TxtNoOfPkg.Text + "','" + TxtWeight.Text + "','" + TxtAmt.Text + "','" + Request.Cookies["compid"].Value + "','" + Request.Cookies["branchid"].Value + "','','" + TxtAWBNo.Text + "','" + TxtValue.Text + "','" + strChkPaymentRecvd + "','" + Request.Cookies["loginid"].Value + "','" + Request.Cookies["cAgentID"].Value + "','" + txtdestination.Text + "','" + (ChkDestination.Checked == true ? "1" : "0").ToString() + "','" + (ChkAWBNo.Checked == true ? "1" : "0").ToString() + "'", "insert");
                Session["Msg"] = "You have sucessfully insert Cash Transaction !!";
                Response.Redirect("TranCashbooking.aspx");
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
    }
    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static List<string> SearchDestination(string prefixText, int count, string contextKey)
    {
        DataSet ds = new DataSet();
        SqlPavanCourier cn = new SqlPavanCourier();
        List<string> cus = new List<string>();
        string cnm = "";
        ds = cn.RunSql("sp_Searchforautocomplete 'DestUser','" + prefixText + "','" + HttpContext.Current.Request.Cookies["compid"].Value + "','" + HttpContext.Current.Request.Cookies["branchid"].Value + "','" + HttpContext.Current.Request.Cookies["loginid"].Value + "','" + contextKey + "'", "select");
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cnm = AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(ds.Tables[0].Rows[i]["Destination"].ToString(), ds.Tables[0].Rows[i]["nid"].ToString());
                cus.Add(cnm);
            }
        }
        return cus;
    }
    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static List<string> SearchProduct(string prefixText, int count)
    {
        DataSet ds = new DataSet();
        SqlPavanCourier cn = new SqlPavanCourier();
        List<string> cus = new List<string>();
        string cnm = "";
        ds = cn.RunSql("sp_Searchforautocomplete 'P','" + prefixText + "','" + HttpContext.Current.Request.Cookies["compid"].Value + "'", "select");
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cnm = AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(ds.Tables[0].Rows[i]["cProductName"].ToString(), ds.Tables[0].Rows[i]["nid"].ToString());
                cus.Add(cnm);
            }
        }
        return cus;
    }
    protected void TxtWeight_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (ChkDestination.Checked == true)
            {
                TxtAmt.Text = "";
                TxtAmt.Focus();
            }
            else
            {
                ds = cn.RunSql("sp_getcashrate '" + TxtWeight.Text + "','" + HifDestination.Value + "','" + Request.Cookies["loginid"].Value + "'", "rate");
                TxtAmt.Text = ds.Tables[0].Rows[0][0] != DBNull.Value ? ds.Tables[0].Rows[0][0].ToString() : "";
                TxtAmt.Focus();
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
                    Session["Msg"] = "You have sucessfully Upload Cash Transaction !!";
                    Response.Redirect("TranCashbooking.aspx");

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
        for (int i = 0; i <= ds1.Tables[0].Rows.Count - 1; i++)
        {

            if (ds1.Tables[0].Rows[i]["A"].ToString() != "")
            {
                string strawbno = ds1.Tables[0].Rows[i]["A"].ToString();
                string strDate = ds1.Tables[0].Rows[i]["B"].ToString();
                string strShipperName = ds1.Tables[0].Rows[i]["C"].ToString();
                string strDestinationCode = ds1.Tables[0].Rows[i]["D"].ToString();
                string strDestination = ds1.Tables[0].Rows[i]["E"].ToString();
                string strShippedto = ds1.Tables[0].Rows[i]["F"].ToString();
                string strContents = ds1.Tables[0].Rows[i]["G"].ToString();
                string strNoofPkg = ds1.Tables[0].Rows[i]["H"].ToString();
                string strWeight = ds1.Tables[0].Rows[i]["I"].ToString();

                ds = cn.RunSql("sp_addCashBookingCSV 'I','" + strawbno + "','" + strDate + "','" + strShipperName + "','" + strDestinationCode + "','" + strDestination + "','" + strShippedto + "','" + strContents + "','" + strNoofPkg + "','" + strWeight + "','" + Request.Cookies["branchid"].Value + "','" + Request.Cookies["compid"].Value + "'", "Data");

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
                writer.WriteLine("Col3=C Text");
                writer.WriteLine("Col4=D Text");
                writer.WriteLine("Col5=E Text");
                writer.WriteLine("Col6=F Text");
                writer.WriteLine("Col7=G Text");
                writer.WriteLine("Col8=H Double");
                writer.WriteLine("Col9=I Double");
                writer.Close();
                writer.Dispose();
            }
            FileStr.Close();
            FileStr.Dispose();

        }

    }

    protected void DDlContent_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (DDlContent.SelectedValue == "1")
            {
                TxtValue.Text = "0";
            }
            else
            {
                TxtValue.Text = "100";
            }
            TxtNoOfPkg.Focus();
        }
        catch (Exception ex)
        {
            lblerror.Text = ex.Message;
            diverror.Visible = true;
        }
    }
    //protected void TxtValue_TextChanged(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        if (Convert.ToInt64(TxtValue.Text) > 5000)
    //        {
    //            LblWarning.Text = "Value Not More than 5000";
    //            DivWarning.Visible = true;
    //            TxtValue.Text = "5000";
    //            TxtValue.Focus();
    //        }
    //    }
    //    catch (Exception ex)
    //    {

    //    }
    //}
    protected void txtdestination_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (ChkDestination.Checked == true)
            {
                TxtAmt.Text = "";
                TxtShippedTo.Focus();
            }
            else
            {
                ds = cn.RunSql("sp_getcashrate '" + TxtWeight.Text + "','" + HifDestination.Value + "','" + Request.Cookies["loginid"].Value + "'", "rate");
                TxtAmt.Text = ds.Tables[0].Rows[0][0] != DBNull.Value ? ds.Tables[0].Rows[0][0].ToString() : "";
                TxtShippedTo.Focus();
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