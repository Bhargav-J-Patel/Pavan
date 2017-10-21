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

public partial class MasterAgent : System.Web.UI.Page
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

                ds = cn.RunSql("sp_usermanagement '" + Request.Cookies["branchid"].Value + "','" + Request.Cookies["loginid"].Value + "'", "select");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["cCustomer"].ToString().Substring(0, 1) != "1")
                    {
                        Response.Redirect("home.aspx");
                    }
                    if (ds.Tables[0].Rows[0]["cCustomer"].ToString().Substring(1, 1) != "1" && ds.Tables[0].Rows[0]["cCustomer"].ToString().Substring(2, 1) != "1" && ds.Tables[0].Rows[0]["cCustomer"].ToString().Substring(3, 1) != "1")
                    {
                        btnlist.Visible = false;
                    }
                }



                ds = cn.RunSql("sp_selectcharge '" + Request.Cookies["compid"].Value + "','" + Request.Cookies["branchid"].Value + "'", "select");
                ChkCharge.DataSource = ds;
                ChkCharge.DataBind();


                if (Request.QueryString["id"] != null)
                {
                    ds = cn.RunSql("sp_listcustomer 's','" + Request.Cookies["compid"].Value + "','" + Request.QueryString["id"] + "'", "search");
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
                    //DdlType.SelectedValue = ds.Tables[0].Rows[0]["cType"] != DBNull.Value ? ds.Tables[0].Rows[0]["cType"].ToString() : "";
                    HifContract.Value = ds.Tables[0].Rows[0]["cContract"] != DBNull.Value ? ds.Tables[0].Rows[0]["cContract"].ToString() : "";
                    HifLocation.Value = ds.Tables[0].Rows[0]["cLocationID"] != DBNull.Value ? ds.Tables[0].Rows[0]["cLocationID"].ToString() : "";
                    txtcommission.Text = ds.Tables[0].Rows[0]["ncommision"] != DBNull.Value ? ds.Tables[0].Rows[0]["ncommision"].ToString() : "";
                    TxtExtraRate.Text = ds.Tables[0].Rows[0]["nextrarate"] != DBNull.Value ? ds.Tables[0].Rows[0]["nextrarate"].ToString() : "";
                    TxtContactPerson.Text = ds.Tables[0].Rows[0]["cContactPerson"] != DBNull.Value ? ds.Tables[0].Rows[0]["cContactPerson"].ToString() : "";
                    //chkservicetzx.Checked = ds.Tables[0].Rows[0]["cServiceTax"].ToString() == "1" ? true : false;
                    //chkfuelcharge.Checked = ds.Tables[0].Rows[0]["cFuelCharge"].ToString() == "1" ? true : false;
                    txtcusname.Enabled = false;

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
                    if (Request.QueryString["De"] == "1")
                    {
                        ddldelete.Visible = true;
                        Button1.Text = "Active/Deactive";
                        
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
        Response.Redirect("ListAgentMaster.aspx");
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
                    ds = cn.RunSql("sp_addcustomer 'U','" + txtcuscode.Text + "','" + txtcusname.Text + "','" + txtaddress.Text + "','" + HifLocation.Value + "','" + TxPhNo.Text + "','" + txtmobile.Text + "','" + txtemailid.Text + "','" + txtdob.Text + "','" + ddlpaymenttype.SelectedValue + "','" + charge + "','" + HifContract.Value + "','1','" + Request.Cookies["compid"].Value + "','" + Request.Cookies["loginid"].Value + "','" + Request.Cookies["branchid"].Value + "','" + Request.QueryString["id"] + "','" + txtcommission.Text + "','" + TxtExtraRate.Text + "','" + TxtContactPerson.Text + "'", "insert");
                    Session["Msg"] = "You have sucessfully Update Agent !!";
                    Response.Redirect("ListAgentMaster.aspx");
                }
                if (Request.QueryString["D"] == "1")
                {
                    if (ddldelete.SelectedValue == "Yes")
                    {
                        ds = cn.RunSql("sp_addcustomer 'D','" + txtcuscode.Text + "','" + txtcusname.Text + "','" + txtaddress.Text + "','" + HifLocation.Value + "','" + TxPhNo.Text + "','" + txtmobile.Text + "','" + txtemailid.Text + "','" + txtdob.Text + "','" + ddlpaymenttype.SelectedValue + "','" + charge + "','" + HifContract.Value + "','1','" + Request.Cookies["compid"].Value + "','" + Request.Cookies["loginid"].Value + "','" + Request.Cookies["branchid"].Value + "','" + Request.QueryString["id"] + "','" + txtcommission.Text + "','" + TxtExtraRate.Text + "','" + TxtContactPerson.Text + "'", "insert");
                        Session["Msg"] = "You have sucessfully Delete Agent !!";
                        Response.Redirect("ListAgentMaster.aspx");
                    }
                }
                if (Request.QueryString["De"] == "1")
                {
                    if (ddldelete.SelectedValue == "Yes")
                    {
                        ds = cn.RunSql("sp_addcustomer 'De','" + txtcuscode.Text + "','" + txtcusname.Text + "','" + txtaddress.Text + "','" + HifLocation.Value + "','" + TxPhNo.Text + "','" + txtmobile.Text + "','" + txtemailid.Text + "','" + txtdob.Text + "','" + ddlpaymenttype.SelectedValue + "','" + charge + "','" + HifContract.Value + "','1','" + Request.Cookies["compid"].Value + "','" + Request.Cookies["loginid"].Value + "','" + Request.Cookies["branchid"].Value + "','" + Request.QueryString["id"] + "','" + txtcommission.Text + "','" + TxtExtraRate.Text + "','" + TxtContactPerson.Text + "'", "insert");
                        Session["Msg"] = "You have sucessfully Delete Agent !!";
                        Response.Redirect("ListAgentMaster.aspx");
                    }
                }
            }
            else
            {
                ds = cn.RunSql("sp_addcustomer 'I','" + txtcuscode.Text + "','" + txtcusname.Text + "','" + txtaddress.Text + "','" + HifLocation.Value + "','" + TxPhNo.Text + "','" + txtmobile.Text + "','" + txtemailid.Text + "','" + txtdob.Text + "','" + ddlpaymenttype.SelectedValue + "','" + charge + "','" + HifContract.Value + "','1','" + Request.Cookies["compid"].Value + "','" + Request.Cookies["loginid"].Value + "','" + Request.Cookies["branchid"].Value + "','','" + txtcommission.Text + "','" + TxtExtraRate.Text + "'", "insert");
                Session["Msg"] = "You have sucessfully insert Customer !!";
                Response.Redirect("MasterAgent.aspx");
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
        Response.Redirect("MasterAgent.aspx");
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
                    Session["Msg"] = "You have sucessfully Upload Agent !!";
                    Response.Redirect("MasterAgent.aspx");

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
            string agname = ds1.Tables[0].Rows[i]["B"].ToString();
            string name = ds1.Tables[0].Rows[i]["C"].ToString();
            string address = ds1.Tables[0].Rows[i]["D"].ToString();
            string location = ds1.Tables[0].Rows[i]["E"].ToString();
            string phoneno = ds1.Tables[0].Rows[i]["F"].ToString();
            string mobileno = ds1.Tables[0].Rows[i]["G"].ToString();
            string emailid = ds1.Tables[0].Rows[i]["H"].ToString();
            string contract = ds1.Tables[0].Rows[i]["I"].ToString();
            string kgrate = ds1.Tables[0].Rows[i]["J"].ToString();
            string extrarate = ds1.Tables[0].Rows[i]["K"].ToString();

            ds = cn.RunSql("sp_addAgentCSV 'I','" + code + "','" + agname + "','" + name + "','" + address + "','" + location + "','" + phoneno + "','" + mobileno + "','" + emailid + "','" + contract + "','" + kgrate + "','" + extrarate + "','" + Request.Cookies["branchid"].Value + "','" + Request.Cookies["compid"].Value + "','" + Request.Cookies["loginid"].Value + "'", "Data");

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
                writer.WriteLine("Col9=I Text");
                writer.WriteLine("Col10=J Text");
                writer.WriteLine("Col11=K Text");
                writer.Close();
                writer.Dispose();
            }
            FileStr.Close();
            FileStr.Dispose();

        }

    }

}