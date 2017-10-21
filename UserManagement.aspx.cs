using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App_Code;
using System.Data;

public partial class UserManagement : System.Web.UI.Page
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

        if (IsPostBack == false)
        {
            try
            {
                ds = cn.RunSql("sp_getbranch 'L',''", "select");
                DDlBranch.DataSource = ds;
                DDlBranch.DataBind();
            }
            catch (Exception ex)
            {
                lblerror.Text = ex.Message;
                diverror.Visible = true;
            }
        }
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {

    }
    protected void DDlBranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ds = cn.RunSql("sp_alluser '" + DDlBranch.SelectedValue + "','" + Request.Cookies["compid"].Value + "'", "select");
            DDLUsername.DataSource = ds;
            DDLUsername.DataBind();
        }
        catch (Exception ex)
        {
            lblerror.Text = ex.Message;
            diverror.Visible = true;
        }
    }
    protected void Btnsubmit_Click(object sender, EventArgs e)
    {
        try
        {
            string zone = Convert.ToString(chkzonea.Checked == true ? "1" : "0") + Convert.ToString(chkzoneu.Checked == true ? "1" : "0") + Convert.ToString(chkzoned.Checked == true ? "1" : "0") + Convert.ToString(chkzonel.Checked == true ? "1" : "0");
            string country = Convert.ToString(chkcountrya.Checked == true ? "1" : "0") + Convert.ToString(chkcountryu.Checked == true ? "1" : "0") + Convert.ToString(chkcountryd.Checked == true ? "1" : "0") + Convert.ToString(chkcountryl.Checked == true ? "1" : "0");
            string location = Convert.ToString(chkloca.Checked == true ? "1" : "0") + Convert.ToString(chklocu.Checked == true ? "1" : "0") + Convert.ToString(chklocd.Checked == true ? "1" : "0") + Convert.ToString(chklocl.Checked == true ? "1" : "0");
            string product = Convert.ToString(chkproducta.Checked == true ? "1" : "0") + Convert.ToString(chkproductu.Checked == true ? "1" : "0") + Convert.ToString(chkproductd.Checked == true ? "1" : "0") + Convert.ToString(chkproductl.Checked == true ? "1" : "0");
            string destination = Convert.ToString(chkdestnationa.Checked == true ? "1" : "0") + Convert.ToString(chkdestnationu.Checked == true ? "1" : "0") + Convert.ToString(chkdestnationd.Checked == true ? "1" : "0") + Convert.ToString(chkdestnationl.Checked == true ? "1" : "0");
            string customer = Convert.ToString(chkcustomera.Checked == true ? "1" : "0") + Convert.ToString(chkcustomeru.Checked == true ? "1" : "0") + Convert.ToString(chkcustomerd.Checked == true ? "1" : "0") + Convert.ToString(chkcustomerl.Checked == true ? "1" : "0");
            string contract = Convert.ToString(chkcontracta.Checked == true ? "1" : "0") + Convert.ToString(chkcontractu.Checked == true ? "1" : "0") + Convert.ToString(chkcontractd.Checked == true ? "1" : "0") + Convert.ToString(chkcontractl.Checked == true ? "1" : "0");
            string delvroute = Convert.ToString(chkdelroutea.Checked == true ? "1" : "0") + Convert.ToString(chkdelrouteu.Checked == true ? "1" : "0") + Convert.ToString(chkdelrouted.Checked == true ? "1" : "0") + Convert.ToString(chkdelroutel.Checked == true ? "1" : "0");
            string courier = Convert.ToString(chkcouriera.Checked == true ? "1" : "0") + Convert.ToString(chkcourieru.Checked == true ? "1" : "0") + Convert.ToString(chkcourierd.Checked == true ? "1" : "0") + Convert.ToString(chkcourierl.Checked == true ? "1" : "0");
            string delexcption = Convert.ToString(chkdelexceptiona.Checked == true ? "1" : "0") + Convert.ToString(chkdelexceptionu.Checked == true ? "1" : "0") + Convert.ToString(chkdelexceptiond.Checked == true ? "1" : "0") + Convert.ToString(chkdelexceptionl.Checked == true ? "1" : "0");
            string charge = Convert.ToString(chkchargea.Checked == true ? "1" : "0") + Convert.ToString(chkchargeu.Checked == true ? "1" : "0") + Convert.ToString(chkcharged.Checked == true ? "1" : "0") + Convert.ToString(chkchargel.Checked == true ? "1" : "0");
            string stockinward = Convert.ToString(chkstockinwarda.Checked == true ? "1" : "0") + Convert.ToString(chkstockinwardu.Checked == true ? "1" : "0") + Convert.ToString(chkstockinwardd.Checked == true ? "1" : "0") + Convert.ToString(chkstockinwardl.Checked == true ? "1" : "0");
            string stockissue = Convert.ToString(chkstockissuea.Checked == true ? "1" : "0") + Convert.ToString(chkstockissueu.Checked == true ? "1" : "0") + Convert.ToString(chkstockissued.Checked == true ? "1" : "0") + Convert.ToString(chkstockissuel.Checked == true ? "1" : "0");
            string drs = Convert.ToString(chkdrsa.Checked == true ? "1" : "0") + Convert.ToString(chkdrsu.Checked == true ? "1" : "0") + Convert.ToString(chkdrsd.Checked == true ? "1" : "0") + Convert.ToString(chkdrsl.Checked == true ? "1" : "0");
            string manifest = Convert.ToString(chkmanifesta.Checked == true ? "1" : "0") + Convert.ToString(chkmanifestu.Checked == true ? "1" : "0") + Convert.ToString(chkmanifestd.Checked == true ? "1" : "0") + Convert.ToString(chkmanifestl.Checked == true ? "1" : "0");
            string pod = Convert.ToString(chkpoda.Checked == true ? "1" : "0") + Convert.ToString(chkpodu.Checked == true ? "1" : "0") + Convert.ToString(chkpodd.Checked == true ? "1" : "0") + Convert.ToString(chkpodl.Checked == true ? "1" : "0");
            string creditbooking = Convert.ToString(chkCreditBookingA.Checked == true ? "1" : "0") + Convert.ToString(chkCreditBookingU.Checked == true ? "1" : "0") + Convert.ToString(chkCreditBookingD.Checked == true ? "1" : "0") + Convert.ToString(chkCreditBookingL.Checked == true ? "1" : "0");
            string cashbooking = Convert.ToString(ChkCashBookingA.Checked == true ? "1" : "0") + Convert.ToString(ChkCashBookingU.Checked == true ? "1" : "0") + Convert.ToString(ChkCashBookingD.Checked == true ? "1" : "0") + Convert.ToString(ChkCashBookingL.Checked == true ? "1" : "0");

            string trace = ChkTrace.Checked == true ? "1" : "0";
            string consignee = ChkConsignee.Checked == true ? "1" : "0";

            string stockinwarddt = ChkStockInwardR.Checked == true ? "1" : "0";
            string stockissuedt = ChkStockIssueRDt.Checked == true ? "1" : "0";
            string stockissuecus = ChkStockIssueC.Checked == true ? "1" : "0";
            string manifestrpt = ChkManifestR.Checked == true ? "1" : "0";
            string dailyrpt = chkDailyR.Checked == true ? "1" : "0";

            ds = cn.RunSql("sp_selectuser '" + DDlBranch.SelectedValue + "','" + DDLUsername.SelectedValue + "'", "select");
            if (ds.Tables[0].Rows.Count > 0)
            {
                ds = cn.RunSql("sp_addusermanagement 'U','" + DDlBranch.SelectedValue + "','" + DDLUsername.SelectedValue + "','" + zone + "','" + country + "','" + location + "','" + product + "','" + destination + "','" + customer + "','" + contract + "','" + delvroute + "','" + courier + "','" + delexcption + "','" + charge + "','" + stockinward + "','" + stockissue + "','" + drs + "','" + manifest + "','" + pod + "','" + creditbooking + "','" + cashbooking + "','" + trace + "','" + consignee + "','" + stockinwarddt + "','" + stockissuedt + "','" + stockissuecus + "','" + manifestrpt + "','" + dailyrpt + "'", "update");
                Session["Msg"] = "You have sucessfully Update User Rights !!";
                Response.Redirect("UserManagement.aspx");
            }
            else
            {
                ds = cn.RunSql("sp_addusermanagement 'I','" + DDlBranch.SelectedValue + "','" + DDLUsername.SelectedValue + "','" + zone + "','" + country + "','" + location + "','" + product + "','" + destination + "','" + customer + "','" + contract + "','" + delvroute + "','" + courier + "','" + delexcption + "','" + charge + "','" + stockinward + "','" + stockissue + "','" + drs + "','" + manifest + "','" + pod + "','" + creditbooking + "','" + cashbooking + "','" + trace + "','" + consignee + "','" + stockinwarddt + "','" + stockissuedt + "','" + stockissuecus + "','" + manifestrpt + "','" + dailyrpt + "'", "add");
                Session["Msg"] = "You have sucessfully Insert User Rights !!";
                Response.Redirect("UserManagement.aspx");
            }

        }
        catch (Exception ex)
        {
            lblerror.Text = ex.Message;
            diverror.Visible = true;
        }

    }
    protected void DDLUsername_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ds = cn.RunSql("sp_usermanagement '" + DDlBranch.SelectedValue + "','" + DDLUsername.SelectedValue + "'", "select");
            if (ds.Tables[0].Rows.Count > 0)
            {
                chkzonea.Checked = ds.Tables[0].Rows[0]["cZone"].ToString().Substring(0, 1) == "1" ? true : false;
                chkzoneu.Checked = ds.Tables[0].Rows[0]["cZone"].ToString().Substring(1, 1) == "1" ? true : false;
                chkzoned.Checked = ds.Tables[0].Rows[0]["cZone"].ToString().Substring(2, 1) == "1" ? true : false;
                chkzonel.Checked = ds.Tables[0].Rows[0]["cZone"].ToString().Substring(3, 1) == "1" ? true : false;

                chkcountrya.Checked = ds.Tables[0].Rows[0]["cCountry"].ToString().Substring(0, 1) == "1" ? true : false;
                chkcountryu.Checked = ds.Tables[0].Rows[0]["cCountry"].ToString().Substring(1, 1) == "1" ? true : false;
                chkcountryd.Checked = ds.Tables[0].Rows[0]["cCountry"].ToString().Substring(2, 1) == "1" ? true : false;
                chkcountryl.Checked = ds.Tables[0].Rows[0]["cCountry"].ToString().Substring(3, 1) == "1" ? true : false;

                chkloca.Checked = ds.Tables[0].Rows[0]["cLocation"].ToString().Substring(0, 1) == "1" ? true : false;
                chklocu.Checked = ds.Tables[0].Rows[0]["cLocation"].ToString().Substring(1, 1) == "1" ? true : false;
                chklocd.Checked = ds.Tables[0].Rows[0]["cLocation"].ToString().Substring(2, 1) == "1" ? true : false;
                chklocl.Checked = ds.Tables[0].Rows[0]["cLocation"].ToString().Substring(3, 1) == "1" ? true : false;

                chkproducta.Checked = ds.Tables[0].Rows[0]["cProduct"].ToString().Substring(0, 1) == "1" ? true : false;
                chkproductu.Checked = ds.Tables[0].Rows[0]["cProduct"].ToString().Substring(1, 1) == "1" ? true : false;
                chkproductd.Checked = ds.Tables[0].Rows[0]["cProduct"].ToString().Substring(2, 1) == "1" ? true : false;
                chkproductl.Checked = ds.Tables[0].Rows[0]["cProduct"].ToString().Substring(3, 1) == "1" ? true : false;

                chkdestnationa.Checked = ds.Tables[0].Rows[0]["cDestination"].ToString().Substring(0, 1) == "1" ? true : false;
                chkdestnationu.Checked = ds.Tables[0].Rows[0]["cDestination"].ToString().Substring(1, 1) == "1" ? true : false;
                chkdestnationd.Checked = ds.Tables[0].Rows[0]["cDestination"].ToString().Substring(2, 1) == "1" ? true : false;
                chkdestnationl.Checked = ds.Tables[0].Rows[0]["cDestination"].ToString().Substring(3, 1) == "1" ? true : false;

                chkcustomera.Checked = ds.Tables[0].Rows[0]["cCustomer"].ToString().Substring(0, 1) == "1" ? true : false;
                chkcustomeru.Checked = ds.Tables[0].Rows[0]["cCustomer"].ToString().Substring(1, 1) == "1" ? true : false;
                chkcustomerd.Checked = ds.Tables[0].Rows[0]["cCustomer"].ToString().Substring(2, 1) == "1" ? true : false;
                chkcustomerl.Checked = ds.Tables[0].Rows[0]["cCustomer"].ToString().Substring(3, 1) == "1" ? true : false;

                chkcontracta.Checked = ds.Tables[0].Rows[0]["cContract"].ToString().Substring(0, 1) == "1" ? true : false;
                chkcontractu.Checked = ds.Tables[0].Rows[0]["cContract"].ToString().Substring(1, 1) == "1" ? true : false;
                chkcontractd.Checked = ds.Tables[0].Rows[0]["cContract"].ToString().Substring(2, 1) == "1" ? true : false;
                chkcontractl.Checked = ds.Tables[0].Rows[0]["cContract"].ToString().Substring(3, 1) == "1" ? true : false;

                chkdelroutea.Checked = ds.Tables[0].Rows[0]["cDeliveryRoute"].ToString().Substring(0, 1) == "1" ? true : false;
                chkdelrouteu.Checked = ds.Tables[0].Rows[0]["cDeliveryRoute"].ToString().Substring(1, 1) == "1" ? true : false;
                chkdelrouted.Checked = ds.Tables[0].Rows[0]["cDeliveryRoute"].ToString().Substring(2, 1) == "1" ? true : false;
                chkdelroutel.Checked = ds.Tables[0].Rows[0]["cDeliveryRoute"].ToString().Substring(3, 1) == "1" ? true : false;

                chkcouriera.Checked = ds.Tables[0].Rows[0]["cCourier"].ToString().Substring(0, 1) == "1" ? true : false;
                chkcourieru.Checked = ds.Tables[0].Rows[0]["cCourier"].ToString().Substring(1, 1) == "1" ? true : false;
                chkcourierd.Checked = ds.Tables[0].Rows[0]["cCourier"].ToString().Substring(2, 1) == "1" ? true : false;
                chkcourierl.Checked = ds.Tables[0].Rows[0]["cCourier"].ToString().Substring(3, 1) == "1" ? true : false;

                chkdelexceptiona.Checked = ds.Tables[0].Rows[0]["cDeliveryException"].ToString().Substring(0, 1) == "1" ? true : false;
                chkdelexceptionu.Checked = ds.Tables[0].Rows[0]["cDeliveryException"].ToString().Substring(1, 1) == "1" ? true : false;
                chkdelexceptiond.Checked = ds.Tables[0].Rows[0]["cDeliveryException"].ToString().Substring(2, 1) == "1" ? true : false;
                chkdelexceptionl.Checked = ds.Tables[0].Rows[0]["cDeliveryException"].ToString().Substring(3, 1) == "1" ? true : false;

                chkchargea.Checked = ds.Tables[0].Rows[0]["cCharge"].ToString().Substring(0, 1) == "1" ? true : false;
                chkchargeu.Checked = ds.Tables[0].Rows[0]["cCharge"].ToString().Substring(1, 1) == "1" ? true : false;
                chkcharged.Checked = ds.Tables[0].Rows[0]["cCharge"].ToString().Substring(2, 1) == "1" ? true : false;
                chkchargel.Checked = ds.Tables[0].Rows[0]["cCharge"].ToString().Substring(3, 1) == "1" ? true : false;

                chkstockinwarda.Checked = ds.Tables[0].Rows[0]["cStockInward"].ToString().Substring(0, 1) == "1" ? true : false;
                chkstockinwardu.Checked = ds.Tables[0].Rows[0]["cStockInward"].ToString().Substring(1, 1) == "1" ? true : false;
                chkstockinwardd.Checked = ds.Tables[0].Rows[0]["cStockInward"].ToString().Substring(2, 1) == "1" ? true : false;
                chkstockinwardl.Checked = ds.Tables[0].Rows[0]["cStockInward"].ToString().Substring(3, 1) == "1" ? true : false;

                chkstockissuea.Checked = ds.Tables[0].Rows[0]["cStockIssue"].ToString().Substring(0, 1) == "1" ? true : false;
                chkstockissueu.Checked = ds.Tables[0].Rows[0]["cStockIssue"].ToString().Substring(1, 1) == "1" ? true : false;
                chkstockissued.Checked = ds.Tables[0].Rows[0]["cStockIssue"].ToString().Substring(2, 1) == "1" ? true : false;
                chkstockissuel.Checked = ds.Tables[0].Rows[0]["cStockIssue"].ToString().Substring(3, 1) == "1" ? true : false;

                chkdrsa.Checked = ds.Tables[0].Rows[0]["cDRS"].ToString().Substring(0, 1) == "1" ? true : false;
                chkdrsu.Checked = ds.Tables[0].Rows[0]["cDRS"].ToString().Substring(1, 1) == "1" ? true : false;
                chkdrsd.Checked = ds.Tables[0].Rows[0]["cDRS"].ToString().Substring(2, 1) == "1" ? true : false;
                chkdrsl.Checked = ds.Tables[0].Rows[0]["cDRS"].ToString().Substring(3, 1) == "1" ? true : false;

                chkmanifesta.Checked = ds.Tables[0].Rows[0]["cManifest"].ToString().Substring(0, 1) == "1" ? true : false;
                chkmanifestu.Checked = ds.Tables[0].Rows[0]["cManifest"].ToString().Substring(1, 1) == "1" ? true : false;
                chkmanifestd.Checked = ds.Tables[0].Rows[0]["cManifest"].ToString().Substring(2, 1) == "1" ? true : false;
                chkmanifestl.Checked = ds.Tables[0].Rows[0]["cManifest"].ToString().Substring(3, 1) == "1" ? true : false;

                chkpoda.Checked = ds.Tables[0].Rows[0]["cPOD"].ToString().Substring(0, 1) == "1" ? true : false;
                chkpodu.Checked = ds.Tables[0].Rows[0]["cPOD"].ToString().Substring(1, 1) == "1" ? true : false;
                chkpodd.Checked = ds.Tables[0].Rows[0]["cPOD"].ToString().Substring(2, 1) == "1" ? true : false;
                chkpodl.Checked = ds.Tables[0].Rows[0]["cPOD"].ToString().Substring(3, 1) == "1" ? true : false;

                ChkCashBookingA.Checked = ds.Tables[0].Rows[0]["cCashBooking"].ToString().Substring(0, 1) == "1" ? true : false;
                ChkCashBookingU.Checked = ds.Tables[0].Rows[0]["cCashBooking"].ToString().Substring(1, 1) == "1" ? true : false;
                ChkCashBookingD.Checked = ds.Tables[0].Rows[0]["cCashBooking"].ToString().Substring(2, 1) == "1" ? true : false;
                ChkCashBookingL.Checked = ds.Tables[0].Rows[0]["cCashBooking"].ToString().Substring(3, 1) == "1" ? true : false;

                chkCreditBookingA.Checked = ds.Tables[0].Rows[0]["cCreditBooking"].ToString().Substring(0, 1) == "1" ? true : false;
                chkCreditBookingU.Checked = ds.Tables[0].Rows[0]["cCreditBooking"].ToString().Substring(1, 1) == "1" ? true : false;
                chkCreditBookingD.Checked = ds.Tables[0].Rows[0]["cCreditBooking"].ToString().Substring(2, 1) == "1" ? true : false;
                chkCreditBookingL.Checked = ds.Tables[0].Rows[0]["cCreditBooking"].ToString().Substring(3, 1) == "1" ? true : false;

                ChkTrace.Checked = ds.Tables[0].Rows[0]["cTrace"].ToString() == "1" ? true : false;
                ChkConsignee.Checked = ds.Tables[0].Rows[0]["cConsignee"].ToString() == "1" ? true : false;

                ChkStockInwardR.Checked = ds.Tables[0].Rows[0]["cStockInwardDt"].ToString() == "1" ? true : false;
                ChkStockIssueRDt.Checked = ds.Tables[0].Rows[0]["cStockIssueDt"].ToString() == "1" ? true : false;
                ChkStockIssueC.Checked = ds.Tables[0].Rows[0]["cStockIssueCus"].ToString() == "1" ? true : false;
                ChkManifestR.Checked = ds.Tables[0].Rows[0]["cManifestRpt"].ToString() == "1" ? true : false;
                chkDailyR.Checked = ds.Tables[0].Rows[0]["cDailyRpt"].ToString() == "1" ? true : false;
            }
        }
        catch (Exception ex)
        {
            lblerror.Text = ex.Message;
            diverror.Visible = true;
        }
    }
}