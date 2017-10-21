using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App_Code;
using System.Data;

public partial class TranCopyContract : System.Web.UI.Page
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
    }
    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static List<string> SearchContract(string prefixText, int count)
    {
        DataSet ds = new DataSet();
        SqlPavanCourier cn = new SqlPavanCourier();
        List<string> co = new List<string>();
        string cnm = "";
        ds = cn.RunSql("sp_Searchforautocomplete 'CONU','" + prefixText + "','" + HttpContext.Current.Request.Cookies["compid"].Value + "','" + HttpContext.Current.Request.Cookies["branchid"].Value + "','" + HttpContext.Current.Request.Cookies["loginid"].Value + "'", "select");
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
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        try
        {
            ds = cn.RunSql("sp_copycontract '" + HifContract.Value + "','" + TxtNewConName.Text + "','" + Request.Cookies["loginid"].Value + "'", "insert");
            Session["Msg"] = "You have Sucessfully Create Contract!!";
            Response.Redirect("TranCopyContract.aspx");
        }
        catch (Exception ex)
        {
            lblerror.Text = ex.Message;
            diverror.Visible = true;
        }
    }
    protected void Btnreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("TranCopyContract.aspx");
    }
}