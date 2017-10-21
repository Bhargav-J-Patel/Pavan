using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App_Code;
using System.Data;

public partial class TranMultiplePOD : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    SqlPavanCourier cn = new SqlPavanCourier();

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static List<string> SearchStatus(string prefixText, int count)
    {
        DataSet ds = new DataSet();
        SqlPavanCourier cn = new SqlPavanCourier();
        List<string> loc = new List<string>();
        string cnm = "";
        ds = cn.RunSql("sp_Searchforautocomplete 'status','" + prefixText + "','" + HttpContext.Current.Request.Cookies["compid"].Value + "'", "select");
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cnm = AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(ds.Tables[0].Rows[i]["statusnm"].ToString(), ds.Tables[0].Rows[i]["nid"].ToString());
                loc.Add(cnm);
            }
        }
        return loc;
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        try
        {
            ds = cn.RunSql("sp_addmultiplepod '" + TxtDRSRunsheetNo.Text + "','" + HifStatus.Value + "','" + txtdeldate.Text + "','" + HttpContext.Current.Request.Cookies["branchid"].Value + "','" + HttpContext.Current.Request.Cookies["compid"].Value + "','" + Request.Cookies["loginid"].Value + "'", "select");
            Session["Msg"] = "You have sucessfully Added POD !!";
            Response.Redirect("TranMultiplePOD.aspx");
        }
        catch (Exception ex)
        {
            lblerror.Text = ex.Message;
            diverror.Visible = true;
        }
    }
    protected void btnreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("TranMultiplePOD.aspx");
    }
}