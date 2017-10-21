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

public partial class MasterDomestic : System.Web.UI.Page
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
        txtdomesticcode.Focus();
        if (IsPostBack == false)
        {
            try
            {
                ds = cn.RunSql("sp_usermanagement '" + Request.Cookies["branchid"].Value + "','" + Request.Cookies["loginid"].Value + "'", "select");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["cDestination"].ToString().Substring(0, 1) != "1")
                    {
                        Response.Redirect("home.aspx");
                    }
                    if (ds.Tables[0].Rows[0]["cDestination"].ToString().Substring(1, 1) != "1" && ds.Tables[0].Rows[0]["cDestination"].ToString().Substring(2, 1) != "1" && ds.Tables[0].Rows[0]["cDestination"].ToString().Substring(3, 1) != "1")
                    {
                        btnlist.Visible = false;
                    }
                }

                ds = cn.RunSql("sp_getsrno 'dom','" + Request.Cookies["branchid"].Value + "'", "select");
                txtsrno.Text = ds.Tables[0].Rows[0]["nsrno"] != DBNull.Value ? ds.Tables[0].Rows[0]["nsrno"].ToString() : "";


                if (Request.QueryString["id"] != null)
                {
                    ds = cn.RunSql("sp_listdomestic 's','" + Request.Cookies["branchid"].Value + "','" + Request.QueryString["id"] + "'", "search");
                    txtsrno.Text = ds.Tables[0].Rows[0]["nsrno"] != DBNull.Value ? ds.Tables[0].Rows[0]["nsrno"].ToString() : "";
                    txtdomesticcode.Text = ds.Tables[0].Rows[0]["cDomesticCode"] != DBNull.Value ? ds.Tables[0].Rows[0]["cDomesticCode"].ToString() : "";
                    txtdomesticname.Text = ds.Tables[0].Rows[0]["cDomesticName"] != DBNull.Value ? ds.Tables[0].Rows[0]["cDomesticName"].ToString() : "";
                    txtdomesticaddress.Text = ds.Tables[0].Rows[0]["cAddress"] != DBNull.Value ? ds.Tables[0].Rows[0]["cAddress"].ToString() : "";
                    txtzone.Text = ds.Tables[0].Rows[0]["cZoneName"] != DBNull.Value ? ds.Tables[0].Rows[0]["cZoneName"].ToString() : "";
                    txtcountry.Text = ds.Tables[0].Rows[0]["cCountryName"] != DBNull.Value ? ds.Tables[0].Rows[0]["cCountryName"].ToString() : "";
                    TxtCPersnName.Text = ds.Tables[0].Rows[0]["cContactPerson"] != DBNull.Value ? ds.Tables[0].Rows[0]["cContactPerson"].ToString() : "";
                    TxtCNo.Text = ds.Tables[0].Rows[0]["cCNO"] != DBNull.Value ? ds.Tables[0].Rows[0]["cCNO"].ToString() : "";
                    TxtMobileNo.Text = ds.Tables[0].Rows[0]["cMobileNo"] != DBNull.Value ? ds.Tables[0].Rows[0]["cMobileNo"].ToString() : "";
                    HifZone.Value = ds.Tables[0].Rows[0]["cZoneID"] != DBNull.Value ? ds.Tables[0].Rows[0]["cZoneID"].ToString() : "";
                    HifCountry.Value = ds.Tables[0].Rows[0]["cCountryID"] != DBNull.Value ? ds.Tables[0].Rows[0]["cCountryID"].ToString() : "";

                    if (Request.QueryString["D"] == "1")
                    {
                        ddldelete.Visible = true;
                        btnsubmit.Text = "Delete";
                    }

                    ds = cn.RunSql("sp_checkuserrights 'destination','" + Request.Cookies["branchid"].Value + "','" + Request.QueryString["id"] + "'", "select");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0][0].ToString() == "1")
                        {
                            btnsubmit.Enabled = false;
                        }
                    }


                }
            }
            catch (Exception ex)
            {
                lblerror.Text = ex.Message;
                diverror.Visible = false;
            }
            finally
            {
                ds.Dispose();
            }
        }

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
            for (int i = 0; i < ds.Tables[0].Rows.Count;i++ )
            {
                cnm = AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(ds.Tables[0].Rows[i]["cZoneName"].ToString(), ds.Tables[0].Rows[i]["nid"].ToString());
                zone.Add(cnm);
            }
        }
       
        return zone;
    }

    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static List<string> SearchCountry(string prefixText,int count)
    {
        DataSet ds = new DataSet();
        SqlPavanCourier cn = new SqlPavanCourier();
        List<string> country = new List<string>();
        string cnm = "";
        ds = cn.RunSql("sp_Searchforautocomplete 'CB','" + prefixText + "','" + HttpContext.Current.Request.Cookies["compid"].Value + "','" + HttpContext.Current.Request.Cookies["branchid"].Value + "'", "select");
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cnm = AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(ds.Tables[0].Rows[i]["cCountryName"].ToString(), ds.Tables[0].Rows[i]["nid"].ToString());
                country.Add(cnm);
            }
        }

        return country;
    }
    
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString["id"] != null)
            {
                if (Request.QueryString["E"] == "1")
                {
                    ds = cn.RunSql("sp_adddomesticmaster 'U','" + txtsrno.Text + "','" + txtdomesticcode.Text + "','" + txtdomesticname.Text + "','" + TxtCPersnName.Text + "','" + TxtCNo.Text + "','" + TxtMobileNo.Text + "','" + txtdomesticaddress.Text + "','" + HifZone.Value + "','" + HifCountry.Value + "','" + Request.Cookies["compid"].Value + "','" + Request.Cookies["loginid"].Value + "','" + Request.QueryString["id"] + "','" + Request.Cookies["branchid"].Value + "'", "insert");
                    Session["Msg"] = "You have sucessfully Update Domestic !!";
                    Response.Redirect("ListDomestic.aspx");
                }
                if (Request.QueryString["D"] == "1")
                {
                    if (ddldelete.SelectedValue == "Yes")
                    {
                        ds = cn.RunSql("sp_adddomesticmaster 'D','" + txtsrno.Text + "','" + txtdomesticcode.Text + "','" + txtdomesticname.Text + "','" + TxtCPersnName.Text + "','" + TxtCNo.Text + "','" + TxtMobileNo.Text + "','" + txtdomesticaddress.Text + "','" + HifZone.Value + "','" + HifCountry.Value + "','" + Request.Cookies["compid"].Value + "','" + Request.Cookies["loginid"].Value + "','" + Request.QueryString["id"] + "','" + Request.Cookies["branchid"].Value + "'", "insert");
                        Session["Msg"] = "You have sucessfully Delete Domestic !!";
                        Response.Redirect("ListDomestic.aspx");
                    }
                }
            }
            else
            {
                ds = cn.RunSql("sp_adddomesticmaster 'I','" + txtsrno.Text + "','" + txtdomesticcode.Text + "','" + txtdomesticname.Text + "','" + TxtCPersnName.Text + "','" + TxtCNo.Text + "','" + TxtMobileNo.Text + "','" + txtdomesticaddress.Text + "','" + HifZone.Value + "','" + HifCountry.Value + "','" + Request.Cookies["compid"].Value + "','" + Request.Cookies["loginid"].Value + "','','" + Request.Cookies["branchid"].Value + "'", "insert");
                Session["Msg"] = "You have sucessfully insert Domestic !!";
                Response.Redirect("MasterDomestic.aspx");
            }
        }
        catch (Exception ex)
        {
            lblerror.Text=ex.Message;
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
                    Session["Msg"] = "You have sucessfully Upload Destination !!";
                    Response.Redirect("MasterDomestic.aspx");

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
                string code = ds1.Tables[0].Rows[i]["A"].ToString();
                string name = ds1.Tables[0].Rows[i]["B"].ToString();
                string contactperson = ds1.Tables[0].Rows[i]["C"].ToString();
                string cno = ds1.Tables[0].Rows[i]["D"].ToString();
                string MobNo = ds1.Tables[0].Rows[i]["E"].ToString();
                string address = ds1.Tables[0].Rows[i]["F"].ToString();
                string zone = ds1.Tables[0].Rows[i]["G"].ToString();
                string country = ds1.Tables[0].Rows[i]["H"].ToString();

                ds = cn.RunSql("sp_addDestinationCSV 'I','" + code + "','" + name + "','" + contactperson + "','" + cno + "','" + MobNo + "','" + address + "','" + zone + "','" + country + "','" + Request.Cookies["branchid"].Value + "','" + Request.Cookies["compid"].Value + "','" + Request.Cookies["loginid"].Value + "'", "Data");
                  
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
                writer.WriteLine("Col1=A Text");
                writer.WriteLine("Col2=B Text");
                writer.WriteLine("Col3=C Text");
                writer.WriteLine("Col4=D Text");
                writer.WriteLine("Col5=E Text");
                writer.WriteLine("Col6=F Text");
                writer.WriteLine("Col7=G Text");
                writer.WriteLine("Col8=H Text");
                writer.Close();
                writer.Dispose();
            }
            FileStr.Close();
            FileStr.Dispose();

        }

    }

    protected void btnlist_Click(object sender, EventArgs e)
    {
        Response.Redirect("ListDomestic.aspx");
    }
}