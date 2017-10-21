using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App_Code;
using System.Data;
public partial class ListStockInward : System.Web.UI.Page
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

        try
        {

            ds = cn.RunSql("sp_usermanagement '" + Request.Cookies["branchid"].Value + "','" + Request.Cookies["loginid"].Value + "'", "select");
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["cStockInward"].ToString().Substring(0, 1) != "1")
                {
                    btnaddnew.Visible = false;
                }
                if (ds.Tables[0].Rows[0]["cStockInward"].ToString().Substring(1, 1) != "1" && ds.Tables[0].Rows[0]["cStockInward"].ToString().Substring(2, 1) != "1" && ds.Tables[0].Rows[0]["cStockInward"].ToString().Substring(3, 1) != "1")
                {
                    Response.Redirect("home.aspx");
                }

            }


            //ds = cn.RunSql("sp_liststockinward 'L','" + Request.Cookies["branchid"].Value + "',''", "select");
            //GvZoneList.DataSource = ds;
            //GvZoneList.DataBind();
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
    protected void btnaddnew_Click(object sender, EventArgs e)
    {
        Response.Redirect("TranStockInward.aspx");
    }
    //protected void OnDataBound(object sender, EventArgs e)
    //{
    //    GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
    //    for (int i = 1; i < GvZoneList.Columns.Count; i++)
    //    {
    //        TableHeaderCell cell = new TableHeaderCell();
    //        TextBox txtSearch = new TextBox();
    //        txtSearch.Attributes["placeholder"] = GvZoneList.Columns[i].HeaderText;
    //        txtSearch.CssClass = "search_textbox";
    //        txtSearch.ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
    //        cell.Controls.Add(txtSearch);
    //    }
    //    GvZoneList.HeaderRow.Parent.Controls.AddAt(1, row);
    //}
    //protected void GvZoneList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    try
    //    {
    //        GvZoneList.PageIndex = e.NewPageIndex;
    //        ds = cn.RunSql("sp_liststockinward 'L','" + Request.Cookies["branchid"].Value + "',''", "select");
    //        GvZoneList.DataSource = ds;
    //        GvZoneList.DataBind();
    //    }
    //    catch (Exception ex)
    //    {
    //        lblerror.Text = ex.Message;
    //        diverror.Visible = true;
    //    }
    //}
}