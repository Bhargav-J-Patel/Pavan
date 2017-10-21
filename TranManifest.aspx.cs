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

public partial class TranManifest : System.Web.UI.Page
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

                ds = cn.RunSql("sp_usermanagement '" + Request.Cookies["branchid"].Value + "','" + Request.Cookies["loginid"].Value + "'", "select");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["cManifest"].ToString().Substring(0, 1) != "1")
                    {
                        Response.Redirect("home.aspx");
                    }
                    if (ds.Tables[0].Rows[0]["cManifest"].ToString().Substring(1, 1) != "1" && ds.Tables[0].Rows[0]["cManifest"].ToString().Substring(2, 1) != "1" && ds.Tables[0].Rows[0]["cManifest"].ToString().Substring(3, 1) != "1")
                    {
                        btnlist.Visible = false;
                    }
                }


                ds = cn.RunSql("sp_listbranch 's','" + Request.Cookies["branchid"].Value + "'", "select");
                txtvendor.Text = ds.Tables[0].Rows[0]["cName"] != DBNull.Value ? ds.Tables[0].Rows[0]["cName"].ToString() : "";

                txtdate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                ds = cn.RunSql("sp_getsrno 'Manifest','" + Request.Cookies["branchid"].Value + "','" + Request.Cookies["loginid"].Value + "'", "select");
                txtmanifest.Text = ds.Tables[0].Rows[0]["nManifestNo"] != DBNull.Value ? ds.Tables[0].Rows[0]["nManifestNo"].ToString() : "";

                if (Request.QueryString["id"] != null)
                {
                    HIDPFID.Value = Request.QueryString["id"].ToString();
                    ds = cn.RunSql("sp_listManifest 's','" + Request.Cookies["branchid"].Value + "','" + Request.QueryString["id"] + "',''", "select");
                    txtmanifest.Text = ds.Tables[0].Rows[0]["nManifestNo"] != DBNull.Value ? ds.Tables[0].Rows[0]["nManifestNo"].ToString() : "";
                    txtdate.Text = ds.Tables[0].Rows[0]["dDate"] != DBNull.Value ? ds.Tables[0].Rows[0]["dDate"].ToString() : "";
                    txtdestination.Text = ds.Tables[0].Rows[0]["Destination"] != DBNull.Value ? ds.Tables[0].Rows[0]["Destination"].ToString() : "";
                    HifDestination.Value = ds.Tables[0].Rows[0]["cDestination"] != DBNull.Value ? ds.Tables[0].Rows[0]["cDestination"].ToString() : "";


                    //if (ds.Tables[2].Rows.Count > 0)
                    //{
                    //    txtweight.Text = ds.Tables[2].Rows[0]["nWeight"] != DBNull.Value ? ds.Tables[2].Rows[0]["nWeight"].ToString() : "";
                    //    txtproduct.Text = ds.Tables[2].Rows[0]["product"] != DBNull.Value ? ds.Tables[2].Rows[0]["product"].ToString() : "";
                    //    HifProduct.Value = ds.Tables[2].Rows[0]["cProduct"] != DBNull.Value ? ds.Tables[2].Rows[0]["cProduct"].ToString() : "";
                    //    txtpcs.Text = ds.Tables[2].Rows[0]["nPcs"] != DBNull.Value ? ds.Tables[2].Rows[0]["nPcs"].ToString() : "";
                    //}
                    txtawbno.Focus();


                    GvManifestList.DataSource = ds.Tables[1];
                    GvManifestList.DataBind();


                    if (Request.Cookies["cType"].Value == "0")
                    {
                        GvManifestList.Columns[8].Visible = false;
                        //GvManifestList.Columns[7].Visible = false;
                    }


                    if (Request.QueryString["cid"] != null)
                    {
                        ds = cn.RunSql("sp_listManifest 'c','" + Request.Cookies["branchid"].Value + "','" + Request.QueryString["id"] + "','" + Request.QueryString["cid"] + "'", "select");
                        txtweight.Text = ds.Tables[0].Rows[0]["nWeight"] != DBNull.Value ? ds.Tables[0].Rows[0]["nWeight"].ToString() : "";
                        txtproduct.Text = ds.Tables[0].Rows[0]["product"] != DBNull.Value ? ds.Tables[0].Rows[0]["product"].ToString() : "";
                        HifProduct.Value = ds.Tables[0].Rows[0]["cProduct"] != DBNull.Value ? ds.Tables[0].Rows[0]["cProduct"].ToString() : "";
                        txtpcs.Text = ds.Tables[0].Rows[0]["nPcs"] != DBNull.Value ? ds.Tables[0].Rows[0]["nPcs"].ToString() : "";
                        txtawbno.Text = ds.Tables[0].Rows[0]["nAWBNo"] != DBNull.Value ? ds.Tables[0].Rows[0]["nAWBNo"].ToString() : "";
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
    public static List<string> SearchDestination(string prefixText, int count)
    {
        DataSet ds = new DataSet();
        SqlPavanCourier cn = new SqlPavanCourier();
        List<string> cus = new List<string>();
        string cnm = "";
        ds = cn.RunSql("sp_Searchforautocomplete 'DestUser','" + prefixText + "','" + HttpContext.Current.Request.Cookies["compid"].Value + "','" + HttpContext.Current.Request.Cookies["branchid"].Value + "','" + HttpContext.Current.Request.Cookies["loginid"].Value + "','0'", "select");
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
    protected void btnlist_Click(object sender, EventArgs e)
    {
        Response.Redirect("ListManifest.aspx");
    }
    protected void btnreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("TranManifest.aspx");
    }

    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static List<string> SearchCus(string prefixText, int count)
    {
        DataSet ds = new DataSet();
        SqlPavanCourier cn = new SqlPavanCourier();
        List<string> cus = new List<string>();
        string cnm = "";
        ds = cn.RunSql("sp_Searchforautocomplete 'Cus','" + prefixText + "','" + HttpContext.Current.Request.Cookies["compid"].Value + "'", "select");
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
                cnid = GvManifestList.Rows[row.RowIndex].Cells[0].Text;
                ds = cn.RunSql("sp_addManifestTran 'PUCD','" + txtmanifest.Text + "','" + txtdate.Text + "','" + HifDestination.Value + "','" + txtweight.Text + "','" + HifProduct.Value + "','" + txtpcs.Text + "','0','" + Request.Cookies["branchid"].Value + "','" + Request.QueryString["id"] + "','" + cnid + "','0','" + Request.Cookies["loginid"].Value + "'", "insert");
                Response.Redirect("TranManifest.aspx?id=" + ds.Tables[0].Rows[0][0] + "");
            }
        }
        catch (Exception ex)
        {
            lblerror.Text = ex.Message;
            diverror.Visible = true;
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
                        ds = cn.RunSql("sp_addManifestTran 'D','" + txtmanifest.Text + "','" + txtdate.Text + "','" + HifDestination.Value + "','" + txtweight.Text + "','" + HifProduct.Value + "','" + txtpcs.Text + "','0','" + Request.Cookies["branchid"].Value + "','" + HIDPFID.Value + "','','0','" + Request.Cookies["loginid"].Value + "'", "insert");
                        Session["Msg"] = "You have Sucessfully Delete Manifest!!";
                        Response.Redirect("ListManifest.aspx");
                    }
                }
                else
                {
                    ds = cn.RunSql("sp_addManifestTran 'PU','" + txtmanifest.Text + "','" + txtdate.Text + "','" + HifDestination.Value + "','" + txtweight.Text + "','" + HifProduct.Value + "','" + txtpcs.Text + "','0','" + Request.Cookies["branchid"].Value + "','" + HIDPFID.Value + "','','0','" + Request.Cookies["loginid"].Value + "'", "insert");
                    Session["Msg"] = "You have Sucessfully Update Manifest!!";
                    Response.Redirect("ListManifest.aspx");
                }
            }

        }
        catch (Exception ex)
        {
            lblerror.Text = ex.Message;
            diverror.Visible = true;
        }
    }
    //protected void ImgBtnAdd_Click(object sender, ImageClickEventArgs e)
    //{
    //    try
    //    {
    //        if (Request.QueryString["id"] != null)
    //        {
    //            if (Request.QueryString["cid"] != null)
    //            {

    //                ds = cn.RunSql("sp_addManifestTran 'PUCU','" + txtmanifest.Text + "','" + txtdate.Text + "','" + HifDestination.Value + "','" + txtweight.Text + "','" + HifProduct.Value + "','" + txtpcs.Text + "','" + txtawbno.Text + "','" + Request.Cookies["branchid"].Value + "','" + Request.QueryString["id"] + "','" + Request.QueryString["cid"] + "'", "insert");
    //                Response.Redirect("TranManifest.aspx?id=" + ds.Tables[0].Rows[0][0] + "");
    //            }
    //            else
    //            {

    //                ds = cn.RunSql("sp_addManifestTran 'PUCI','" + txtmanifest.Text + "','" + txtdate.Text + "','" + HifDestination.Value + "','" + txtweight.Text + "','" + HifProduct.Value + "','" + txtpcs.Text + "','" + txtawbno.Text + "','" + Request.Cookies["branchid"].Value + "','" + Request.QueryString["id"] + "',''", "insert");
    //                Response.Redirect("TranManifest.aspx?id=" + ds.Tables[0].Rows[0][0] + "");
    //            }
    //        }
    //        else
    //        {
    //            ds = cn.RunSql("sp_addManifestTran 'I','" + txtmanifest.Text + "','" + txtdate.Text + "','" + HifDestination.Value + "','" + txtweight.Text + "','" + HifProduct.Value + "','" + txtpcs.Text + "','" + txtawbno.Text + "','" + Request.Cookies["branchid"].Value + "','',''", "insert");
    //            Response.Redirect("TranManifest.aspx?id=" + ds.Tables[0].Rows[0][0] + "");
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        lblerror.Text = ex.Message;
    //        diverror.Visible = true;
    //    }
    //}
    protected void btnprint_Click(object sender, EventArgs e)
    {
        Response.Redirect("Report.aspx?rpt=5&manifest=" + txtmanifest.Text + "");
    }
    protected void txtawbno_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (HIDPFID.Value != "0")
            {
                if (Request.QueryString["cid"] != null)
                {

                    ds = cn.RunSql("sp_addManifestTran 'PUCU','" + txtmanifest.Text + "','" + txtdate.Text + "','" + HifDestination.Value + "','" + txtweight.Text + "','" + HifProduct.Value + "','" + txtpcs.Text + "','" + txtawbno.Text + "','" + Request.Cookies["branchid"].Value + "','" + HIDPFID.Value + "','" + Request.QueryString["cid"] + "','0','" + Request.Cookies["loginid"].Value + "'", "insert");
                    if (ds.Tables[0].Rows[0][0].ToString() == "Enter Weight and Pcs")
                    {
                        txtweight.Focus();
                        txtpcs.Text = "0";
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

                    ds = cn.RunSql("sp_addManifestTran 'PUCI','" + txtmanifest.Text + "','" + txtdate.Text + "','" + HifDestination.Value + "','" + txtweight.Text + "','" + HifProduct.Value + "','" + txtpcs.Text + "','" + txtawbno.Text + "','" + Request.Cookies["branchid"].Value + "','" + HIDPFID.Value + "','','0','" + Request.Cookies["loginid"].Value + "'", "insert");
                    if (ds.Tables[0].Rows[0][0].ToString() == "Enter Weight and Pcs")
                    {
                        txtweight.Focus();
                        txtpcs.Text = "0";
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
                ds = cn.RunSql("sp_addManifestTran 'I','" + txtmanifest.Text + "','" + txtdate.Text + "','" + HifDestination.Value + "','" + txtweight.Text + "','" + HifProduct.Value + "','" + txtpcs.Text + "','" + txtawbno.Text + "','" + Request.Cookies["branchid"].Value + "','','','0','" + Request.Cookies["loginid"].Value + "'", "insert");
                if (ds.Tables[0].Rows[0][0].ToString() == "Enter Weight and Pcs")
                {
                    txtweight.Focus();
                    txtpcs.Text = "0";
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
                ds = cn.RunSql("sp_listManifest 's','" + Request.Cookies["branchid"].Value + "','" + HIDPFID.Value + "',''", "select");
                GvManifestList.DataSource = ds.Tables[1];
                GvManifestList.DataBind();
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
                string pcode = ds1.Tables[0].Rows[i]["B"].ToString();
                string pname = ds1.Tables[0].Rows[i]["C"].ToString();
                string pcs = ds1.Tables[0].Rows[i]["D"].ToString();
                string awbno = ds1.Tables[0].Rows[i]["E"].ToString();

                if (i == 0)
                {
                    ds = cn.RunSql("sp_addManifestCSV 'I','','" + txtdate.Text + "','" + HifDestination.Value + "','" + weight + "','" + pcode + "','" + pname + "','" + pcs + "','" + awbno + "','" + Request.Cookies["branchid"].Value + "','" + Request.Cookies["compid"].Value + "'", "Data");
                    pid = ds.Tables[0].Rows[0][0].ToString();
                }
                else
                {
                    ds = cn.RunSql("sp_addManifestCSV 'C','" + pid + "','" + txtdate.Text + "','" + HifDestination.Value + "','" + weight + "','" + pcode + "','" + pname + "','" + pcs + "','" + awbno + "','" + Request.Cookies["branchid"].Value + "','" + Request.Cookies["compid"].Value + "'", "Data");
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
                writer.WriteLine("Col3=C Text");
                writer.WriteLine("Col4=D Text");
                writer.WriteLine("Col5=E Double");
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

                    ds = cn.RunSql("sp_addManifestTran 'PUCU','" + txtmanifest.Text + "','" + txtdate.Text + "','" + HifDestination.Value + "','" + txtweight.Text + "','" + HifProduct.Value + "','" + txtpcs.Text + "','" + txtawbno.Text + "','" + Request.Cookies["branchid"].Value + "','" + HIDPFID.Value + "','" + Request.QueryString["cid"] + "','1','" + Request.Cookies["loginid"].Value + "'","insert");
                    if (ds.Tables[0].Rows[0][0].ToString() == "Enter Weight and Pcs")
                    {
                        txtweight.Focus();
                        txtpcs.Text = "0";
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

                    ds = cn.RunSql("sp_addManifestTran 'PUCI','" + txtmanifest.Text + "','" + txtdate.Text + "','" + HifDestination.Value + "','" + txtweight.Text + "','" + HifProduct.Value + "','" + txtpcs.Text + "','" + txtawbno.Text + "','" + Request.Cookies["branchid"].Value + "','" + HIDPFID.Value + "','','1','" + Request.Cookies["loginid"].Value + "'", "insert");
                    if (ds.Tables[0].Rows[0][0].ToString() == "Enter Weight and Pcs")
                    {
                        txtweight.Focus();
                        txtpcs.Text = "0";
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
                ds = cn.RunSql("sp_addManifestTran 'I','" + txtmanifest.Text + "','" + txtdate.Text + "','" + HifDestination.Value + "','" + txtweight.Text + "','" + HifProduct.Value + "','" + txtpcs.Text + "','" + txtawbno.Text + "','" + Request.Cookies["branchid"].Value + "','','','1','" + Request.Cookies["loginid"].Value + "'", "insert");
                if (ds.Tables[0].Rows[0][0].ToString() == "Enter Weight and Pcs")
                {
                    txtweight.Focus();
                    txtpcs.Text = "0";
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
