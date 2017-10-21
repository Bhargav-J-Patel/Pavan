using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Serialization;
using App_Code;
using System.Data;


[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.Web.Script.Services.ScriptService]
public class ListPage : System.Web.Services.WebService
{


    public class myClass
    {
        public string BranchID = HttpContext.Current.Request.Cookies["branchid"].Value.ToString();
        public string CompID = HttpContext.Current.Request.Cookies["compid"].Value.ToString();
        public string loginid = HttpContext.Current.Request.Cookies["loginid"].Value.ToString();

        public string zone, country, location, product, destination, customer, contact, route, courier, exception, charge, inward, issue, drs, manifest, pod, cash, credit;

    }

    public class ListAll
    {
        public string NID, nSrNo, code, name, charge, chargeper, commision, mobno, loc, zone, country, mob, eid, contract, product, sdate, fawbno, tawbno, total, cusname, drsno, drsdt, bookdt, route, locname, domestic, manifestno, awbno, status, deldt, recname, BookinbNo, BookingDt, cust, weight, amt, dest, editdelete, cedit, cdelete, cprint, dDate, cimage, date;
        public string Ctype;
        public string cName;
        public string cContactNo;
        public string cPassword;
        public string nExtraRate;
        public string cDeactive;
        public string astatus;



    }

    [WebMethod]
    public void ListZone(int iDisplayLength, int iDisplayStart, int iSortCol_0, string sSortDir_0, string sSearch)
    {
        int displayLength = iDisplayLength;
        int displayStart = iDisplayStart;
        int sortCol = iSortCol_0;
        string sortDir = sSortDir_0;
        string search = sSearch;


        ListAll cls2 = new ListAll();
        List<ListAll> myList = new List<ListAll>();



        int filteredCount = 0;
        DataSet DS = new DataSet();
        SqlPavanCourier CN = new SqlPavanCourier();

        DS = CN.RunSql("SP_ListMasterZone '" + displayLength + "','" + displayStart + "','" + sortCol + "','" + sortDir + "','" + search + "','" + HttpContext.Current.Request.Cookies["branchid"].Value.ToString() + "'", "List");


        if (DS.Tables.Count > 0)
        {
            if (DS.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
                {
                    ListAll cls = new ListAll();



                    filteredCount = Convert.ToInt32(DS.Tables[0].Rows[i]["TotalCount"] != DBNull.Value ? DS.Tables[0].Rows[i]["TotalCount"].ToString() : "0");
                    cls.nSrNo = DS.Tables[0].Rows[i]["nSrNo"] != DBNull.Value ? DS.Tables[0].Rows[i]["nSrNo"].ToString() : "";
                    cls.code = DS.Tables[0].Rows[i]["cZoneCode"] != DBNull.Value ? DS.Tables[0].Rows[i]["cZoneCode"].ToString() : "";
                    cls.name = DS.Tables[0].Rows[i]["cZoneName"] != DBNull.Value ? DS.Tables[0].Rows[i]["cZoneName"].ToString() : "";
                    cls.NID = DS.Tables[0].Rows[i]["NID"] != DBNull.Value ? DS.Tables[0].Rows[i]["NID"].ToString() : "";
                    cls.cedit = DS.Tables[0].Rows[i]["cedit"] != DBNull.Value ? DS.Tables[0].Rows[i]["cedit"].ToString() : "";
                    cls.cdelete = DS.Tables[0].Rows[i]["cdelete"] != DBNull.Value ? DS.Tables[0].Rows[i]["cdelete"].ToString() : "";

                    myList.Add(cls);
                }
            }
        }

        var result = new
        {
            iTotalRecords = GetTotalCount("LISTZONE", ""),
            //iTotalRecords = 5000,
            iTotalDisplayRecords = filteredCount,
            aaData = myList
        };
        JavaScriptSerializer js = new JavaScriptSerializer();
        Context.Response.Write(js.Serialize(result));
    }

    [WebMethod]
    public void ListCountry(int iDisplayLength, int iDisplayStart, int iSortCol_0, string sSortDir_0, string sSearch)
    {
        int displayLength = iDisplayLength;
        int displayStart = iDisplayStart;
        int sortCol = iSortCol_0;
        string sortDir = sSortDir_0;
        string search = sSearch;


        ListAll cls2 = new ListAll();
        List<ListAll> myList = new List<ListAll>();



        int filteredCount = 0;
        DataSet DS = new DataSet();
        SqlPavanCourier CN = new SqlPavanCourier();

        DS = CN.RunSql("SP_ListMasterCountry '" + displayLength + "','" + displayStart + "','" + sortCol + "','" + sortDir + "','" + search + "','" + HttpContext.Current.Request.Cookies["branchid"].Value.ToString() + "'", "List");


        if (DS.Tables.Count > 0)
        {
            if (DS.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
                {
                    ListAll cls = new ListAll();



                    filteredCount = Convert.ToInt32(DS.Tables[0].Rows[i]["TotalCount"] != DBNull.Value ? DS.Tables[0].Rows[i]["TotalCount"].ToString() : "0");
                    cls.nSrNo = DS.Tables[0].Rows[i]["nSrNo"] != DBNull.Value ? DS.Tables[0].Rows[i]["nSrNo"].ToString() : "";
                    cls.code = DS.Tables[0].Rows[i]["cCountryCode"] != DBNull.Value ? DS.Tables[0].Rows[i]["cCountryCode"].ToString() : "";
                    cls.name = DS.Tables[0].Rows[i]["cCountryName"] != DBNull.Value ? DS.Tables[0].Rows[i]["cCountryName"].ToString() : "";
                    cls.NID = DS.Tables[0].Rows[i]["NID"] != DBNull.Value ? DS.Tables[0].Rows[i]["NID"].ToString() : "";
                    cls.cedit = DS.Tables[0].Rows[i]["cedit"] != DBNull.Value ? DS.Tables[0].Rows[i]["cedit"].ToString() : "";
                    cls.cdelete = DS.Tables[0].Rows[i]["cdelete"] != DBNull.Value ? DS.Tables[0].Rows[i]["cdelete"].ToString() : "";

                    myList.Add(cls);
                }
            }
        }

        var result = new
        {
            iTotalRecords = GetTotalCount("LISTCountry", ""),
            //iTotalRecords = 5000,
            iTotalDisplayRecords = filteredCount,
            aaData = myList
        };
        JavaScriptSerializer js = new JavaScriptSerializer();
        Context.Response.Write(js.Serialize(result));
    }

    [WebMethod]
    public void ListLocation(int iDisplayLength, int iDisplayStart, int iSortCol_0, string sSortDir_0, string sSearch)
    {
        int displayLength = iDisplayLength;
        int displayStart = iDisplayStart;
        int sortCol = iSortCol_0;
        string sortDir = sSortDir_0;
        string search = sSearch;


        ListAll cls2 = new ListAll();
        List<ListAll> myList = new List<ListAll>();



        int filteredCount = 0;
        DataSet DS = new DataSet();
        SqlPavanCourier CN = new SqlPavanCourier();

        DS = CN.RunSql("SP_ListMasterLocation '" + displayLength + "','" + displayStart + "','" + sortCol + "','" + sortDir + "','" + search + "','"+ HttpContext.Current.Request.Cookies["branchid"].Value.ToString() +"'", "List");


        if (DS.Tables.Count > 0)
        {
            if (DS.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
                {
                    ListAll cls = new ListAll();



                    filteredCount = Convert.ToInt32(DS.Tables[0].Rows[i]["TotalCount"] != DBNull.Value ? DS.Tables[0].Rows[i]["TotalCount"].ToString() : "0");
                    cls.nSrNo = DS.Tables[0].Rows[i]["nSrNo"] != DBNull.Value ? DS.Tables[0].Rows[i]["nSrNo"].ToString() : "";
                    cls.code = DS.Tables[0].Rows[i]["cLocationCode"] != DBNull.Value ? DS.Tables[0].Rows[i]["cLocationCode"].ToString() : "";
                    cls.name = DS.Tables[0].Rows[i]["cLocationName"] != DBNull.Value ? DS.Tables[0].Rows[i]["cLocationName"].ToString() : "";
                    cls.NID = DS.Tables[0].Rows[i]["NID"] != DBNull.Value ? DS.Tables[0].Rows[i]["NID"].ToString() : "";
                    cls.cedit = DS.Tables[0].Rows[i]["cedit"] != DBNull.Value ? DS.Tables[0].Rows[i]["cedit"].ToString() : "";
                    cls.cdelete = DS.Tables[0].Rows[i]["cdelete"] != DBNull.Value ? DS.Tables[0].Rows[i]["cdelete"].ToString() : "";

                    myList.Add(cls);
                }
            }
        }

        var result = new
        {
            iTotalRecords = GetTotalCount("LISTLocation", ""),
            //iTotalRecords = 5000,
            iTotalDisplayRecords = filteredCount,
            aaData = myList
        };
        JavaScriptSerializer js = new JavaScriptSerializer();
        Context.Response.Write(js.Serialize(result));
    }

    [WebMethod]
    public void ListProduct(int iDisplayLength, int iDisplayStart, int iSortCol_0, string sSortDir_0, string sSearch)
    {
        int displayLength = iDisplayLength;
        int displayStart = iDisplayStart;
        int sortCol = iSortCol_0;
        string sortDir = sSortDir_0;
        string search = sSearch;


        ListAll cls2 = new ListAll();
        List<ListAll> myList = new List<ListAll>();



        int filteredCount = 0;
        DataSet DS = new DataSet();
        SqlPavanCourier CN = new SqlPavanCourier();

        DS = CN.RunSql("SP_ListMasterProduct '" + displayLength + "','" + displayStart + "','" + sortCol + "','" + sortDir + "','" + search + "','" + HttpContext.Current.Request.Cookies["branchid"].Value.ToString() + "'", "List");


        if (DS.Tables.Count > 0)
        {
            if (DS.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
                {
                    ListAll cls = new ListAll();



                    filteredCount = Convert.ToInt32(DS.Tables[0].Rows[i]["TotalCount"] != DBNull.Value ? DS.Tables[0].Rows[i]["TotalCount"].ToString() : "0");
                    cls.nSrNo = DS.Tables[0].Rows[i]["nSrNo"] != DBNull.Value ? DS.Tables[0].Rows[i]["nSrNo"].ToString() : "";
                    cls.code = DS.Tables[0].Rows[i]["cProductCode"] != DBNull.Value ? DS.Tables[0].Rows[i]["cProductCode"].ToString() : "";
                    cls.name = DS.Tables[0].Rows[i]["cProductName"] != DBNull.Value ? DS.Tables[0].Rows[i]["cProductName"].ToString() : "";
                    cls.NID = DS.Tables[0].Rows[i]["NID"] != DBNull.Value ? DS.Tables[0].Rows[i]["NID"].ToString() : "";
                    cls.cedit = DS.Tables[0].Rows[i]["cedit"] != DBNull.Value ? DS.Tables[0].Rows[i]["cedit"].ToString() : "";
                    cls.cdelete = DS.Tables[0].Rows[i]["cdelete"] != DBNull.Value ? DS.Tables[0].Rows[i]["cdelete"].ToString() : "";

                    myList.Add(cls);
                }
            }
        }

        var result = new
        {
            iTotalRecords = GetTotalCount("LISTProduct", ""),
            //iTotalRecords = 5000,
            iTotalDisplayRecords = filteredCount,
            aaData = myList
        };
        JavaScriptSerializer js = new JavaScriptSerializer();
        Context.Response.Write(js.Serialize(result));
    }


    [WebMethod]
    public void ListStatus(int iDisplayLength, int iDisplayStart, int iSortCol_0, string sSortDir_0, string sSearch)
    {
        int displayLength = iDisplayLength;
        int displayStart = iDisplayStart;
        int sortCol = iSortCol_0;
        string sortDir = sSortDir_0;
        string search = sSearch;


        ListAll cls2 = new ListAll();
        List<ListAll> myList = new List<ListAll>();



        int filteredCount = 0;
        DataSet DS = new DataSet();
        SqlPavanCourier CN = new SqlPavanCourier();

        DS = CN.RunSql("SP_ListMasterStatus '" + displayLength + "','" + displayStart + "','" + sortCol + "','" + sortDir + "','" + search + "','" + HttpContext.Current.Request.Cookies["branchid"].Value.ToString() + "'", "List");


        if (DS.Tables.Count > 0)
        {
            if (DS.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
                {
                    ListAll cls = new ListAll();



                    filteredCount = Convert.ToInt32(DS.Tables[0].Rows[i]["TotalCount"] != DBNull.Value ? DS.Tables[0].Rows[i]["TotalCount"].ToString() : "0");
                    cls.nSrNo = DS.Tables[0].Rows[i]["nSrNo"] != DBNull.Value ? DS.Tables[0].Rows[i]["nSrNo"].ToString() : "";
                    cls.code = DS.Tables[0].Rows[i]["cStatusCode"] != DBNull.Value ? DS.Tables[0].Rows[i]["cStatusCode"].ToString() : "";
                    cls.name = DS.Tables[0].Rows[i]["cStatusDetail"] != DBNull.Value ? DS.Tables[0].Rows[i]["cStatusDetail"].ToString() : "";
                    cls.NID = DS.Tables[0].Rows[i]["NID"] != DBNull.Value ? DS.Tables[0].Rows[i]["NID"].ToString() : "";
                    cls.cedit = DS.Tables[0].Rows[i]["cedit"] != DBNull.Value ? DS.Tables[0].Rows[i]["cedit"].ToString() : "";
                    cls.cdelete = DS.Tables[0].Rows[i]["cdelete"] != DBNull.Value ? DS.Tables[0].Rows[i]["cdelete"].ToString() : "";

                    myList.Add(cls);
                }
            }
        }

        var result = new
        {
            iTotalRecords = GetTotalCount("LISTStatus", ""),
            //iTotalRecords = 5000,
            iTotalDisplayRecords = filteredCount,
            aaData = myList
        };
        JavaScriptSerializer js = new JavaScriptSerializer();
        Context.Response.Write(js.Serialize(result));
    }

    [WebMethod]
    public void ListCharge(int iDisplayLength, int iDisplayStart, int iSortCol_0, string sSortDir_0, string sSearch)
    {
        int displayLength = iDisplayLength;
        int displayStart = iDisplayStart;
        int sortCol = iSortCol_0;
        string sortDir = sSortDir_0;
        string search = sSearch;


        ListAll cls2 = new ListAll();
        List<ListAll> myList = new List<ListAll>();



        int filteredCount = 0;
        DataSet DS = new DataSet();
        SqlPavanCourier CN = new SqlPavanCourier();

        DS = CN.RunSql("SP_ListMasterCharge '" + displayLength + "','" + displayStart + "','" + sortCol + "','" + sortDir + "','" + search + "','" + HttpContext.Current.Request.Cookies["branchid"].Value.ToString() + "'", "List");


        if (DS.Tables.Count > 0)
        {
            if (DS.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
                {
                    ListAll cls = new ListAll();



                    filteredCount = Convert.ToInt32(DS.Tables[0].Rows[i]["TotalCount"] != DBNull.Value ? DS.Tables[0].Rows[i]["TotalCount"].ToString() : "0");
                    cls.nSrNo = DS.Tables[0].Rows[i]["nSrNo"] != DBNull.Value ? DS.Tables[0].Rows[i]["nSrNo"].ToString() : "";
                    cls.charge = DS.Tables[0].Rows[i]["cChargeName"] != DBNull.Value ? DS.Tables[0].Rows[i]["cChargeName"].ToString() : "";
                    cls.chargeper = DS.Tables[0].Rows[i]["cChargePer"] != DBNull.Value ? DS.Tables[0].Rows[i]["cChargePer"].ToString() : "";
                    cls.NID = DS.Tables[0].Rows[i]["NID"] != DBNull.Value ? DS.Tables[0].Rows[i]["NID"].ToString() : "";
                    cls.cedit = DS.Tables[0].Rows[i]["cedit"] != DBNull.Value ? DS.Tables[0].Rows[i]["cedit"].ToString() : "";
                    cls.cdelete = DS.Tables[0].Rows[i]["cdelete"] != DBNull.Value ? DS.Tables[0].Rows[i]["cdelete"].ToString() : "";

                    myList.Add(cls);
                }
            }
        }

        var result = new
        {
            iTotalRecords = GetTotalCount("LISTCharge", ""),
            //iTotalRecords = 5000,
            iTotalDisplayRecords = filteredCount,
            aaData = myList
        };
        JavaScriptSerializer js = new JavaScriptSerializer();
        Context.Response.Write(js.Serialize(result));
    }


    [WebMethod]
    public void ListCourier(int iDisplayLength, int iDisplayStart, int iSortCol_0, string sSortDir_0, string sSearch)
    {
        int displayLength = iDisplayLength;
        int displayStart = iDisplayStart;
        int sortCol = iSortCol_0;
        string sortDir = sSortDir_0;
        string search = sSearch;


        ListAll cls2 = new ListAll();
        List<ListAll> myList = new List<ListAll>();



        int filteredCount = 0;
        DataSet DS = new DataSet();
        SqlPavanCourier CN = new SqlPavanCourier();

        DS = CN.RunSql("SP_ListMasterCourier '" + displayLength + "','" + displayStart + "','" + sortCol + "','" + sortDir + "','" + search + "','" + HttpContext.Current.Request.Cookies["branchid"].Value.ToString() + "','" + HttpContext.Current.Request.Cookies["loginid"].Value.ToString() + "'", "List");


        if (DS.Tables.Count > 0)
        {
            if (DS.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
                {
                    ListAll cls = new ListAll();



                    filteredCount = Convert.ToInt32(DS.Tables[0].Rows[i]["TotalCount"] != DBNull.Value ? DS.Tables[0].Rows[i]["TotalCount"].ToString() : "0");
                    cls.nSrNo = DS.Tables[0].Rows[i]["nSrNo"] != DBNull.Value ? DS.Tables[0].Rows[i]["nSrNo"].ToString() : "";
                    cls.code = DS.Tables[0].Rows[i]["cCode"] != DBNull.Value ? DS.Tables[0].Rows[i]["cCode"].ToString() : "";
                    cls.name = DS.Tables[0].Rows[i]["cCustomerName"] != DBNull.Value ? DS.Tables[0].Rows[i]["cCustomerName"].ToString() : "";
                    cls.commision = DS.Tables[0].Rows[i]["cCommision"] != DBNull.Value ? DS.Tables[0].Rows[i]["cCommision"].ToString() : "";
                    cls.mobno = DS.Tables[0].Rows[i]["cMobNo"] != DBNull.Value ? DS.Tables[0].Rows[i]["cMobNo"].ToString() : "";
                    cls.NID = DS.Tables[0].Rows[i]["NID"] != DBNull.Value ? DS.Tables[0].Rows[i]["NID"].ToString() : "";
                    cls.cedit = DS.Tables[0].Rows[i]["cedit"] != DBNull.Value ? DS.Tables[0].Rows[i]["cedit"].ToString() : "";
                    cls.cdelete = DS.Tables[0].Rows[i]["cdelete"] != DBNull.Value ? DS.Tables[0].Rows[i]["cdelete"].ToString() : "";
                    cls.nExtraRate = DS.Tables[0].Rows[i]["nExtraRate"] != DBNull.Value ? DS.Tables[0].Rows[i]["nExtraRate"].ToString() : "";

                    myList.Add(cls);
                }
            }
        }

        var result = new
        {
            iTotalRecords = GetTotalCount("LISTCourier", ""),
            //iTotalRecords = 5000,
            iTotalDisplayRecords = filteredCount,
            aaData = myList
        };
        JavaScriptSerializer js = new JavaScriptSerializer();
        Context.Response.Write(js.Serialize(result));
    }


    [WebMethod]
    public void ListDeliveryRoute(int iDisplayLength, int iDisplayStart, int iSortCol_0, string sSortDir_0, string sSearch)
    {
        int displayLength = iDisplayLength;
        int displayStart = iDisplayStart;
        int sortCol = iSortCol_0;
        string sortDir = sSortDir_0;
        string search = sSearch;


        ListAll cls2 = new ListAll();
        List<ListAll> myList = new List<ListAll>();



        int filteredCount = 0;
        DataSet DS = new DataSet();
        SqlPavanCourier CN = new SqlPavanCourier();

        DS = CN.RunSql("SP_ListMasterDeliveryRoute '" + displayLength + "','" + displayStart + "','" + sortCol + "','" + sortDir + "','" + search + "','" + HttpContext.Current.Request.Cookies["branchid"].Value.ToString() + "','" + HttpContext.Current.Request.Cookies["loginid"].Value.ToString() + "'", "List");


        if (DS.Tables.Count > 0)
        {
            if (DS.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
                {
                    ListAll cls = new ListAll();



                    filteredCount = Convert.ToInt32(DS.Tables[0].Rows[i]["TotalCount"] != DBNull.Value ? DS.Tables[0].Rows[i]["TotalCount"].ToString() : "0");
                    cls.nSrNo = DS.Tables[0].Rows[i]["nSrNo"] != DBNull.Value ? DS.Tables[0].Rows[i]["nSrNo"].ToString() : "";
                    cls.code = DS.Tables[0].Rows[i]["cDeliveryCode"] != DBNull.Value ? DS.Tables[0].Rows[i]["cDeliveryCode"].ToString() : "";
                    cls.name = DS.Tables[0].Rows[i]["cDeliveryName"] != DBNull.Value ? DS.Tables[0].Rows[i]["cDeliveryName"].ToString() : "";
                    cls.loc = DS.Tables[0].Rows[i]["cLocationName"] != DBNull.Value ? DS.Tables[0].Rows[i]["cLocationName"].ToString() : "";
                    cls.NID = DS.Tables[0].Rows[i]["NID"] != DBNull.Value ? DS.Tables[0].Rows[i]["NID"].ToString() : "";
                    cls.cedit = DS.Tables[0].Rows[i]["cedit"] != DBNull.Value ? DS.Tables[0].Rows[i]["cedit"].ToString() : "";
                    cls.cdelete = DS.Tables[0].Rows[i]["cdelete"] != DBNull.Value ? DS.Tables[0].Rows[i]["cdelete"].ToString() : "";

                    myList.Add(cls);
                }
            }
        }

        var result = new
        {
            iTotalRecords = GetTotalCount("LISTDelieryRoute", ""),
            //iTotalRecords = 5000,
            iTotalDisplayRecords = filteredCount,
            aaData = myList
        };
        JavaScriptSerializer js = new JavaScriptSerializer();
        Context.Response.Write(js.Serialize(result));
    }

    [WebMethod]
    public void ListDestination(int iDisplayLength, int iDisplayStart, int iSortCol_0, string sSortDir_0, string sSearch)
    {
        int displayLength = iDisplayLength;
        int displayStart = iDisplayStart;
        int sortCol = iSortCol_0;
        string sortDir = sSortDir_0;
        string search = sSearch;


        ListAll cls2 = new ListAll();
        List<ListAll> myList = new List<ListAll>();



        int filteredCount = 0;
        DataSet DS = new DataSet();
        SqlPavanCourier CN = new SqlPavanCourier();

        DS = CN.RunSql("SP_ListMasterDestination '" + displayLength + "','" + displayStart + "','" + sortCol + "','" + sortDir + "','" + search + "','" + HttpContext.Current.Request.Cookies["branchid"].Value.ToString() + "'", "List");


        if (DS.Tables.Count > 0)
        {
            if (DS.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
                {
                    ListAll cls = new ListAll();



                    filteredCount = Convert.ToInt32(DS.Tables[0].Rows[i]["TotalCount"] != DBNull.Value ? DS.Tables[0].Rows[i]["TotalCount"].ToString() : "0");
                    cls.nSrNo = DS.Tables[0].Rows[i]["nSrNo"] != DBNull.Value ? DS.Tables[0].Rows[i]["nSrNo"].ToString() : "";
                    cls.code = DS.Tables[0].Rows[i]["cDomesticCode"] != DBNull.Value ? DS.Tables[0].Rows[i]["cDomesticCode"].ToString() : "";
                    cls.name = DS.Tables[0].Rows[i]["cDomesticName"] != DBNull.Value ? DS.Tables[0].Rows[i]["cDomesticName"].ToString() : "";
                    cls.zone = DS.Tables[0].Rows[i]["cZoneName"] != DBNull.Value ? DS.Tables[0].Rows[i]["cZoneName"].ToString() : "";
                    cls.country = DS.Tables[0].Rows[i]["cCountryName"] != DBNull.Value ? DS.Tables[0].Rows[i]["cCountryName"].ToString() : "";
                    cls.NID = DS.Tables[0].Rows[i]["NID"] != DBNull.Value ? DS.Tables[0].Rows[i]["NID"].ToString() : "";
                    cls.cedit = DS.Tables[0].Rows[i]["cedit"] != DBNull.Value ? DS.Tables[0].Rows[i]["cedit"].ToString() : "";
                    cls.cdelete = DS.Tables[0].Rows[i]["cdelete"] != DBNull.Value ? DS.Tables[0].Rows[i]["cdelete"].ToString() : "";

                    myList.Add(cls);
                }
            }
        }

        var result = new
        {
            iTotalRecords = GetTotalCount("LISTDestination", ""),
            //iTotalRecords = 5000,
            iTotalDisplayRecords = filteredCount,
            aaData = myList
        };
        JavaScriptSerializer js = new JavaScriptSerializer();
        Context.Response.Write(js.Serialize(result));
    }

    [WebMethod]
    public void ListCustomer(int iDisplayLength, int iDisplayStart, int iSortCol_0, string sSortDir_0, string sSearch)
    {
        int displayLength = iDisplayLength;
        int displayStart = iDisplayStart;
        int sortCol = iSortCol_0;
        string sortDir = sSortDir_0;
        string search = sSearch;


        ListAll cls2 = new ListAll();
        List<ListAll> myList = new List<ListAll>();



        int filteredCount = 0;
        DataSet DS = new DataSet();
        SqlPavanCourier CN = new SqlPavanCourier();

        DS = CN.RunSql("SP_ListMasterCustomer '" + displayLength + "','" + displayStart + "','" + sortCol + "','" + sortDir + "','" + HttpContext.Current.Request.Cookies["branchid"].Value.ToString() + "','" + HttpContext.Current.Request.Cookies["cAgent"].Value.ToString() + "','" + search + "','" + HttpContext.Current.Request.Cookies["loginid"].Value.ToString() + "'", "List");


        if (DS.Tables.Count > 0)
        {
            if (DS.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
                {
                    ListAll cls = new ListAll();



                    filteredCount = Convert.ToInt32(DS.Tables[0].Rows[i]["TotalCount"] != DBNull.Value ? DS.Tables[0].Rows[i]["TotalCount"].ToString() : "0");
                    cls.nSrNo = DS.Tables[0].Rows[i]["nSrNo"] != DBNull.Value ? DS.Tables[0].Rows[i]["nSrNo"].ToString() : "";
                    cls.code = DS.Tables[0].Rows[i]["cCustomerCode"] != DBNull.Value ? DS.Tables[0].Rows[i]["cCustomerCode"].ToString() : "";
                    cls.name = DS.Tables[0].Rows[i]["cCustomerName"] != DBNull.Value ? DS.Tables[0].Rows[i]["cCustomerName"].ToString() : "";
                    cls.mob = DS.Tables[0].Rows[i]["cMobNo"] != DBNull.Value ? DS.Tables[0].Rows[i]["cMobNo"].ToString() : "";
                    cls.eid = DS.Tables[0].Rows[i]["cEmailID"] != DBNull.Value ? DS.Tables[0].Rows[i]["cEmailID"].ToString() : "";
                    cls.contract = DS.Tables[0].Rows[i]["cContractName"] != DBNull.Value ? DS.Tables[0].Rows[i]["cContractName"].ToString() : "";
                    cls.NID = DS.Tables[0].Rows[i]["NID"] != DBNull.Value ? DS.Tables[0].Rows[i]["NID"].ToString() : "";
                    cls.Ctype = DS.Tables[0].Rows[i]["ctype"] != DBNull.Value ? DS.Tables[0].Rows[i]["ctype"].ToString() : "";
                    cls.cedit = DS.Tables[0].Rows[i]["cedit"] != DBNull.Value ? DS.Tables[0].Rows[i]["cedit"].ToString() : "";
                    cls.cdelete = DS.Tables[0].Rows[i]["cdelete"] != DBNull.Value ? DS.Tables[0].Rows[i]["cdelete"].ToString() : "";

                    myList.Add(cls);
                }
            }
        }

        var result = new
        {
            iTotalRecords = GetTotalCount("LISTCustomer", ""),
            //iTotalRecords = 5000,
            iTotalDisplayRecords = filteredCount,
            aaData = myList
        };
        JavaScriptSerializer js = new JavaScriptSerializer();
        Context.Response.Write(js.Serialize(result));
    }

    [WebMethod]
    public void ListAgentMaster(int iDisplayLength, int iDisplayStart, int iSortCol_0, string sSortDir_0, string sSearch)
    {
        int displayLength = iDisplayLength;
        int displayStart = iDisplayStart;
        int sortCol = iSortCol_0;
        string sortDir = sSortDir_0;
        string search = sSearch;


        ListAll cls2 = new ListAll();
        List<ListAll> myList = new List<ListAll>();



        int filteredCount = 0;
        DataSet DS = new DataSet();
        SqlPavanCourier CN = new SqlPavanCourier();

        DS = CN.RunSql("SP_ListMasterAgentM '" + displayLength + "','" + displayStart + "','" + sortCol + "','" + sortDir + "','" + HttpContext.Current.Request.Cookies["branchid"].Value.ToString() + "','" + HttpContext.Current.Request.Cookies["cAgent"].Value.ToString() + "','" + search + "','" + HttpContext.Current.Request.Cookies["loginid"].Value.ToString() + "'", "List");


        if (DS.Tables.Count > 0)
        {
            if (DS.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
                {
                    ListAll cls = new ListAll();



                    filteredCount = Convert.ToInt32(DS.Tables[0].Rows[i]["TotalCount"] != DBNull.Value ? DS.Tables[0].Rows[i]["TotalCount"].ToString() : "0");
                    cls.nSrNo = DS.Tables[0].Rows[i]["nSrNo"] != DBNull.Value ? DS.Tables[0].Rows[i]["nSrNo"].ToString() : "";
                    cls.code = DS.Tables[0].Rows[i]["cCustomerCode"] != DBNull.Value ? DS.Tables[0].Rows[i]["cCustomerCode"].ToString() : "";
                    cls.name = DS.Tables[0].Rows[i]["cCustomerName"] != DBNull.Value ? DS.Tables[0].Rows[i]["cCustomerName"].ToString() : "";
                    cls.mob = DS.Tables[0].Rows[i]["cMobNo"] != DBNull.Value ? DS.Tables[0].Rows[i]["cMobNo"].ToString() : "";
                    cls.eid = DS.Tables[0].Rows[i]["cEmailID"] != DBNull.Value ? DS.Tables[0].Rows[i]["cEmailID"].ToString() : "";
                    cls.contract = DS.Tables[0].Rows[i]["cContractName"] != DBNull.Value ? DS.Tables[0].Rows[i]["cContractName"].ToString() : "";
                    cls.NID = DS.Tables[0].Rows[i]["NID"] != DBNull.Value ? DS.Tables[0].Rows[i]["NID"].ToString() : "";
                    cls.Ctype = DS.Tables[0].Rows[i]["ctype"] != DBNull.Value ? DS.Tables[0].Rows[i]["ctype"].ToString() : "";
                    cls.cedit = DS.Tables[0].Rows[i]["cedit"] != DBNull.Value ? DS.Tables[0].Rows[i]["cedit"].ToString() : "";
                    cls.cdelete = DS.Tables[0].Rows[i]["cdelete"] != DBNull.Value ? DS.Tables[0].Rows[i]["cdelete"].ToString() : "";
                    cls.cDeactive = DS.Tables[0].Rows[i]["cDeactive"] != DBNull.Value ? DS.Tables[0].Rows[i]["cDeactive"].ToString() : "";
                    cls.astatus = DS.Tables[0].Rows[i]["astatus"] != DBNull.Value ? DS.Tables[0].Rows[i]["astatus"].ToString() : "";
                    cls.cPassword = DS.Tables[0].Rows[i]["cPassword"] != DBNull.Value ? DS.Tables[0].Rows[i]["cPassword"].ToString() : "";
                    myList.Add(cls);
                }
            }
        }

        var result = new
        {
            iTotalRecords = GetTotalCount("LISTAgentM", ""),
            //iTotalRecords = 5000,
            iTotalDisplayRecords = filteredCount,
            aaData = myList
        };
        JavaScriptSerializer js = new JavaScriptSerializer();
        Context.Response.Write(js.Serialize(result));
    }


    [WebMethod]
    public void ListAgent(int iDisplayLength, int iDisplayStart, int iSortCol_0, string sSortDir_0, string sSearch)
    {
        int displayLength = iDisplayLength;
        int displayStart = iDisplayStart;
        int sortCol = iSortCol_0;
        string sortDir = sSortDir_0;
        string search = sSearch;


        ListAll cls2 = new ListAll();
        List<ListAll> myList = new List<ListAll>();



        int filteredCount = 0;
        DataSet DS = new DataSet();
        SqlPavanCourier CN = new SqlPavanCourier();

        DS = CN.RunSql("SP_ListMasterAgent '" + displayLength + "','" + displayStart + "','" + sortCol + "','" + sortDir + "','" + HttpContext.Current.Request.Cookies["branchid"].Value.ToString() + "','" + search + "'", "List");


        if (DS.Tables.Count > 0)
        {
            if (DS.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
                {
                    ListAll cls = new ListAll();



                    filteredCount = Convert.ToInt32(DS.Tables[0].Rows[i]["TotalCount"] != DBNull.Value ? DS.Tables[0].Rows[i]["TotalCount"].ToString() : "0");
                    cls.cName = DS.Tables[0].Rows[i]["cName"] != DBNull.Value ? DS.Tables[0].Rows[i]["cName"].ToString() : "";
                    cls.cContactNo = DS.Tables[0].Rows[i]["cContactNo"] != DBNull.Value ? DS.Tables[0].Rows[i]["cContactNo"].ToString() : "";
                    cls.cPassword = DS.Tables[0].Rows[i]["cPassword"] != DBNull.Value ? DS.Tables[0].Rows[i]["cPassword"].ToString() : "";
                    //cls.NID = DS.Tables[0].Rows[i]["NID"] != DBNull.Value ? DS.Tables[0].Rows[i]["NID"].ToString() : "";
                    cls.cdelete = DS.Tables[0].Rows[i]["cedit"] != DBNull.Value ? DS.Tables[0].Rows[i]["cedit"].ToString() : "";

                    myList.Add(cls);
                }
            }
        }

        var result = new
        {
            iTotalRecords = GetTotalCount("LISTAgentLogin", ""),
            //iTotalRecords = 5000,
            iTotalDisplayRecords = filteredCount,
            aaData = myList
        };
        JavaScriptSerializer js = new JavaScriptSerializer();
        Context.Response.Write(js.Serialize(result));
    }


    [WebMethod]
    public void ListVendor(int iDisplayLength, int iDisplayStart, int iSortCol_0, string sSortDir_0, string sSearch)
    {
        int displayLength = iDisplayLength;
        int displayStart = iDisplayStart;
        int sortCol = iSortCol_0;
        string sortDir = sSortDir_0;
        string search = sSearch;


        ListAll cls2 = new ListAll();
        List<ListAll> myList = new List<ListAll>();



        int filteredCount = 0;
        DataSet DS = new DataSet();
        SqlPavanCourier CN = new SqlPavanCourier();

        DS = CN.RunSql("SP_ListMasterVendor '" + displayLength + "','" + displayStart + "','" + sortCol + "','" + sortDir + "','" + search + "','" + HttpContext.Current.Request.Cookies["branchid"].Value.ToString() + "','" + HttpContext.Current.Request.Cookies["loginid"].Value.ToString() + "'", "List");


        if (DS.Tables.Count > 0)
        {
            if (DS.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
                {
                    ListAll cls = new ListAll();



                    filteredCount = Convert.ToInt32(DS.Tables[0].Rows[i]["TotalCount"] != DBNull.Value ? DS.Tables[0].Rows[i]["TotalCount"].ToString() : "0");
                    cls.nSrNo = DS.Tables[0].Rows[i]["nSrNo"] != DBNull.Value ? DS.Tables[0].Rows[i]["nSrNo"].ToString() : "";
                    cls.code = DS.Tables[0].Rows[i]["cCustomerCode"] != DBNull.Value ? DS.Tables[0].Rows[i]["cCustomerCode"].ToString() : "";
                    cls.name = DS.Tables[0].Rows[i]["cCustomerName"] != DBNull.Value ? DS.Tables[0].Rows[i]["cCustomerName"].ToString() : "";
                    cls.mob = DS.Tables[0].Rows[i]["cMobNo"] != DBNull.Value ? DS.Tables[0].Rows[i]["cMobNo"].ToString() : "";
                    cls.eid = DS.Tables[0].Rows[i]["cEmailID"] != DBNull.Value ? DS.Tables[0].Rows[i]["cEmailID"].ToString() : "";
                    cls.contract = DS.Tables[0].Rows[i]["cContractName"] != DBNull.Value ? DS.Tables[0].Rows[i]["cContractName"].ToString() : "";
                    cls.NID = DS.Tables[0].Rows[i]["NID"] != DBNull.Value ? DS.Tables[0].Rows[i]["NID"].ToString() : "";
                    cls.cedit = DS.Tables[0].Rows[i]["cedit"] != DBNull.Value ? DS.Tables[0].Rows[i]["cedit"].ToString() : "";
                    cls.cdelete = DS.Tables[0].Rows[i]["cdelete"] != DBNull.Value ? DS.Tables[0].Rows[i]["cdelete"].ToString() : "";

                    myList.Add(cls);
                }
            }
        }

        var result = new
        {
            iTotalRecords = GetTotalCount("LISTVendor", ""),
            //iTotalRecords = 5000,
            iTotalDisplayRecords = filteredCount,
            aaData = myList
        };
        JavaScriptSerializer js = new JavaScriptSerializer();
        Context.Response.Write(js.Serialize(result));
    }

    [WebMethod]
    public void ListContract(int iDisplayLength, int iDisplayStart, int iSortCol_0, string sSortDir_0, string sSearch)
    {
        int displayLength = iDisplayLength;
        int displayStart = iDisplayStart;
        int sortCol = iSortCol_0;
        string sortDir = sSortDir_0;
        string search = sSearch;


        ListAll cls2 = new ListAll();
        List<ListAll> myList = new List<ListAll>();



        int filteredCount = 0;
        DataSet DS = new DataSet();
        SqlPavanCourier CN = new SqlPavanCourier();

        DS = CN.RunSql("SP_ListMasterContract '" + displayLength + "','" + displayStart + "','" + sortCol + "','" + sortDir + "','" + search + "','" + HttpContext.Current.Request.Cookies["branchid"].Value.ToString() + "','" + HttpContext.Current.Request.Cookies["loginid"].Value.ToString() + "'", "List");


        if (DS.Tables.Count > 0)
        {
            if (DS.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
                {
                    ListAll cls = new ListAll();



                    filteredCount = Convert.ToInt32(DS.Tables[0].Rows[i]["TotalCount"] != DBNull.Value ? DS.Tables[0].Rows[i]["TotalCount"].ToString() : "0");
                    cls.nSrNo = DS.Tables[0].Rows[i]["nSrNo"] != DBNull.Value ? DS.Tables[0].Rows[i]["nSrNo"].ToString() : "";
                    cls.code = DS.Tables[0].Rows[i]["cContractCode"] != DBNull.Value ? DS.Tables[0].Rows[i]["cContractCode"].ToString() : "";
                    cls.name = DS.Tables[0].Rows[i]["cContractName"] != DBNull.Value ? DS.Tables[0].Rows[i]["cContractName"].ToString() : "";
                    cls.product = DS.Tables[0].Rows[i]["cProductName"] != DBNull.Value ? DS.Tables[0].Rows[i]["cProductName"].ToString() : "";
                    //cls.zone = DS.Tables[0].Rows[i]["cZoneName"] != DBNull.Value ? DS.Tables[0].Rows[i]["cZoneName"].ToString() : "";
                    cls.NID = DS.Tables[0].Rows[i]["NID"] != DBNull.Value ? DS.Tables[0].Rows[i]["NID"].ToString() : "";
                    cls.cedit = DS.Tables[0].Rows[i]["cedit"] != DBNull.Value ? DS.Tables[0].Rows[i]["cedit"].ToString() : "";
                    cls.cdelete = DS.Tables[0].Rows[i]["cdelete"] != DBNull.Value ? DS.Tables[0].Rows[i]["cdelete"].ToString() : "";

                    myList.Add(cls);
                }
            }
        }

        var result = new
        {
            iTotalRecords = GetTotalCount("LISTContract", ""),
            //iTotalRecords = 5000,
            iTotalDisplayRecords = filteredCount,
            aaData = myList
        };
        JavaScriptSerializer js = new JavaScriptSerializer();
        Context.Response.Write(js.Serialize(result));
    }

    [WebMethod]
    public void ListStockInward(int iDisplayLength, int iDisplayStart, int iSortCol_0, string sSortDir_0, string sSearch)
    {
        int displayLength = iDisplayLength;
        int displayStart = iDisplayStart;
        int sortCol = iSortCol_0;
        string sortDir = sSortDir_0;
        string search = sSearch;


        ListAll cls2 = new ListAll();
        List<ListAll> myList = new List<ListAll>();

        myClass m = new myClass();

        int filteredCount = 0;
        DataSet DS = new DataSet();
        SqlPavanCourier CN = new SqlPavanCourier();

        DS = CN.RunSql("SP_ListTranStockInward '" + displayLength + "','" + displayStart + "','" + sortCol + "','" + sortDir + "','" + search + "','" + m.BranchID + "','" + HttpContext.Current.Request.Cookies["loginid"].Value.ToString() + "'", "List");


        if (DS.Tables.Count > 0)
        {
            if (DS.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
                {
                    ListAll cls = new ListAll();



                    filteredCount = Convert.ToInt32(DS.Tables[0].Rows[i]["TotalCount"] != DBNull.Value ? DS.Tables[0].Rows[i]["TotalCount"].ToString() : "0");
                    cls.nSrNo = DS.Tables[0].Rows[i]["nSrNo"] != DBNull.Value ? DS.Tables[0].Rows[i]["nSrNo"].ToString() : "";
                    cls.sdate = DS.Tables[0].Rows[i]["dt"] != DBNull.Value ? DS.Tables[0].Rows[i]["dt"].ToString() : "";
                    cls.fawbno = DS.Tables[0].Rows[i]["nFromAWBNo"] != DBNull.Value ? DS.Tables[0].Rows[i]["nFromAWBNo"].ToString() : "";
                    cls.tawbno = DS.Tables[0].Rows[i]["nToAWBNo"] != DBNull.Value ? DS.Tables[0].Rows[i]["nToAWBNo"].ToString() : "";
                    cls.total = DS.Tables[0].Rows[i]["nTotal"] != DBNull.Value ? DS.Tables[0].Rows[i]["nTotal"].ToString() : "";
                    cls.NID = DS.Tables[0].Rows[i]["NID"] != DBNull.Value ? DS.Tables[0].Rows[i]["NID"].ToString() : "";
                    cls.cedit = DS.Tables[0].Rows[i]["cedit"] != DBNull.Value ? DS.Tables[0].Rows[i]["cedit"].ToString() : "";
                    cls.cdelete = DS.Tables[0].Rows[i]["cdelete"] != DBNull.Value ? DS.Tables[0].Rows[i]["cdelete"].ToString() : "";

                    myList.Add(cls);
                }
            }
        }

        var result = new
        {
            iTotalRecords = GetTotalCount("LISTStockInward", ""),
            //iTotalRecords = 5000,
            iTotalDisplayRecords = filteredCount,
            aaData = myList
        };
        JavaScriptSerializer js = new JavaScriptSerializer();
        Context.Response.Write(js.Serialize(result));
    }

    [WebMethod]
    public void ListStockIssue(int iDisplayLength, int iDisplayStart, int iSortCol_0, string sSortDir_0, string sSearch)
    {
        int displayLength = iDisplayLength;
        int displayStart = iDisplayStart;
        int sortCol = iSortCol_0;
        string sortDir = sSortDir_0;
        string search = sSearch;


        ListAll cls2 = new ListAll();
        List<ListAll> myList = new List<ListAll>();

        myClass m = new myClass();

        int filteredCount = 0;
        DataSet DS = new DataSet();
        SqlPavanCourier CN = new SqlPavanCourier();

        DS = CN.RunSql("SP_ListTranStockIssue '" + displayLength + "','" + displayStart + "','" + sortCol + "','" + sortDir + "','" + search + "','" + m.BranchID + "','" + HttpContext.Current.Request.Cookies["loginid"].Value.ToString() + "'", "List");


        if (DS.Tables.Count > 0)
        {
            if (DS.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
                {
                    ListAll cls = new ListAll();



                    filteredCount = Convert.ToInt32(DS.Tables[0].Rows[i]["TotalCount"] != DBNull.Value ? DS.Tables[0].Rows[i]["TotalCount"].ToString() : "0");
                    cls.nSrNo = DS.Tables[0].Rows[i]["nSrNo"] != DBNull.Value ? DS.Tables[0].Rows[i]["nSrNo"].ToString() : "";
                    cls.sdate = DS.Tables[0].Rows[i]["cIssueDate"] != DBNull.Value ? DS.Tables[0].Rows[i]["cIssueDate"].ToString() : "";
                    cls.fawbno = DS.Tables[0].Rows[i]["nFromAMWNo"] != DBNull.Value ? DS.Tables[0].Rows[i]["nFromAMWNo"].ToString() : "";
                    cls.tawbno = DS.Tables[0].Rows[i]["nToAMWNo"] != DBNull.Value ? DS.Tables[0].Rows[i]["nToAMWNo"].ToString() : "";
                    cls.total = DS.Tables[0].Rows[i]["nTotal"] != DBNull.Value ? DS.Tables[0].Rows[i]["nTotal"].ToString() : "";
                    cls.cusname = DS.Tables[0].Rows[i]["cCustomerName"] != DBNull.Value ? DS.Tables[0].Rows[i]["cCustomerName"].ToString() : "";
                    cls.NID = DS.Tables[0].Rows[i]["NID"] != DBNull.Value ? DS.Tables[0].Rows[i]["NID"].ToString() : "";
                    cls.cedit = DS.Tables[0].Rows[i]["cedit"] != DBNull.Value ? DS.Tables[0].Rows[i]["cedit"].ToString() : "";
                    cls.cdelete = DS.Tables[0].Rows[i]["cdelete"] != DBNull.Value ? DS.Tables[0].Rows[i]["cdelete"].ToString() : "";

                    myList.Add(cls);
                }
            }
        }

        var result = new
        {
            iTotalRecords = GetTotalCount("LISTStockIssue", ""),
            //iTotalRecords = 5000,
            iTotalDisplayRecords = filteredCount,
            aaData = myList
        };
        JavaScriptSerializer js = new JavaScriptSerializer();
        Context.Response.Write(js.Serialize(result));
    }
    [WebMethod]
    public void ListDRS(int iDisplayLength, int iDisplayStart, int iSortCol_0, string sSortDir_0, string sSearch)
    {
        int displayLength = iDisplayLength;
        int displayStart = iDisplayStart;
        int sortCol = iSortCol_0;
        string sortDir = sSortDir_0;
        string search = sSearch;


        ListAll cls2 = new ListAll();
        List<ListAll> myList = new List<ListAll>();

        myClass m = new myClass();

        int filteredCount = 0;
        DataSet DS = new DataSet();
        SqlPavanCourier CN = new SqlPavanCourier();

        DS = CN.RunSql("SP_ListTranDRS '" + displayLength + "','" + displayStart + "','" + sortCol + "','" + sortDir + "','" + search + "','" + m.BranchID + "','" + HttpContext.Current.Request.Cookies["loginid"].Value.ToString() + "'", "List");


        if (DS.Tables.Count > 0)
        {
            if (DS.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
                {
                    ListAll cls = new ListAll();



                    filteredCount = Convert.ToInt32(DS.Tables[0].Rows[i]["TotalCount"] != DBNull.Value ? DS.Tables[0].Rows[i]["TotalCount"].ToString() : "0");
                    cls.drsno = DS.Tables[0].Rows[i]["nDRSNo"] != DBNull.Value ? DS.Tables[0].Rows[i]["nDRSNo"].ToString() : "";
                    cls.drsdt = DS.Tables[0].Rows[i]["dDate"] != DBNull.Value ? DS.Tables[0].Rows[i]["dDate"].ToString() : "";
                    cls.bookdt = DS.Tables[0].Rows[i]["dBookDate"] != DBNull.Value ? DS.Tables[0].Rows[i]["dBookDate"].ToString() : "";
                    cls.route = DS.Tables[0].Rows[i]["cDeliveryName"] != DBNull.Value ? DS.Tables[0].Rows[i]["cDeliveryName"].ToString() : "";
                    cls.locname = DS.Tables[0].Rows[i]["cLocationName"] != DBNull.Value ? DS.Tables[0].Rows[i]["cLocationName"].ToString() : "";
                    cls.NID = DS.Tables[0].Rows[i]["NID"] != DBNull.Value ? DS.Tables[0].Rows[i]["NID"].ToString() : "";
                    cls.cedit = DS.Tables[0].Rows[i]["cedit"] != DBNull.Value ? DS.Tables[0].Rows[i]["cedit"].ToString() : "";
                    cls.cdelete = DS.Tables[0].Rows[i]["cdelete"] != DBNull.Value ? DS.Tables[0].Rows[i]["cdelete"].ToString() : "";
                    cls.cprint = DS.Tables[0].Rows[i]["cprint"] != DBNull.Value ? DS.Tables[0].Rows[i]["cprint"].ToString() : "";


                    myList.Add(cls);
                }
            }
        }

        var result = new
        {
            iTotalRecords = GetTotalCount("LISTDRS", ""),
            //iTotalRecords = 5000,
            iTotalDisplayRecords = filteredCount,
            aaData = myList
        };
        JavaScriptSerializer js = new JavaScriptSerializer();
        Context.Response.Write(js.Serialize(result));
    }

    [WebMethod]
    public void ListManifest(int iDisplayLength, int iDisplayStart, int iSortCol_0, string sSortDir_0, string sSearch)
    {
        int displayLength = iDisplayLength;
        int displayStart = iDisplayStart;
        int sortCol = iSortCol_0;
        string sortDir = sSortDir_0;
        string search = sSearch;


        ListAll cls2 = new ListAll();
        List<ListAll> myList = new List<ListAll>();

        myClass m = new myClass();

        int filteredCount = 0;
        DataSet DS = new DataSet();
        SqlPavanCourier CN = new SqlPavanCourier();

        DS = CN.RunSql("SP_ListTranManifest '" + displayLength + "','" + displayStart + "','" + sortCol + "','" + sortDir + "','" + search + "','" + m.BranchID + "','" + HttpContext.Current.Request.Cookies["loginid"].Value.ToString() + "'", "List");


        if (DS.Tables.Count > 0)
        {
            if (DS.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
                {
                    ListAll cls = new ListAll();



                    filteredCount = Convert.ToInt32(DS.Tables[0].Rows[i]["TotalCount"] != DBNull.Value ? DS.Tables[0].Rows[i]["TotalCount"].ToString() : "0");
                    cls.manifestno = DS.Tables[0].Rows[i]["nManifestNo"] != DBNull.Value ? DS.Tables[0].Rows[i]["nManifestNo"].ToString() : "";
                    cls.drsdt = DS.Tables[0].Rows[i]["dDate"] != DBNull.Value ? DS.Tables[0].Rows[i]["dDate"].ToString() : "";
                    cls.domestic = DS.Tables[0].Rows[i]["cDomesticName"] != DBNull.Value ? DS.Tables[0].Rows[i]["cDomesticName"].ToString() : "";
                    cls.NID = DS.Tables[0].Rows[i]["NID"] != DBNull.Value ? DS.Tables[0].Rows[i]["NID"].ToString() : "";
                    cls.cedit = DS.Tables[0].Rows[i]["cedit"] != DBNull.Value ? DS.Tables[0].Rows[i]["cedit"].ToString() : "";
                    cls.cdelete = DS.Tables[0].Rows[i]["cdelete"] != DBNull.Value ? DS.Tables[0].Rows[i]["cdelete"].ToString() : "";
                    cls.cprint = DS.Tables[0].Rows[i]["cprint"] != DBNull.Value ? DS.Tables[0].Rows[i]["cprint"].ToString() : "";

                    myList.Add(cls);
                }
            }
        }

        var result = new
        {
            iTotalRecords = GetTotalCount("LISTManifest", ""),
            //iTotalRecords = 5000,
            iTotalDisplayRecords = filteredCount,
            aaData = myList
        };
        JavaScriptSerializer js = new JavaScriptSerializer();
        Context.Response.Write(js.Serialize(result));
    }


    [WebMethod]
    public void ListLoadRecved(int iDisplayLength, int iDisplayStart, int iSortCol_0, string sSortDir_0, string sSearch)
    {
        int displayLength = iDisplayLength;
        int displayStart = iDisplayStart;
        int sortCol = iSortCol_0;
        string sortDir = sSortDir_0;
        string search = sSearch;


        ListAll cls2 = new ListAll();
        List<ListAll> myList = new List<ListAll>();

        myClass m = new myClass();

        int filteredCount = 0;
        DataSet DS = new DataSet();
        SqlPavanCourier CN = new SqlPavanCourier();

        DS = CN.RunSql("SP_ListTranLoadRecvd '" + displayLength + "','" + displayStart + "','" + sortCol + "','" + sortDir + "','" + search + "','" + m.BranchID + "','"+ HttpContext.Current.Request.Cookies["loginid"].Value.ToString() +"'", "List");


        if (DS.Tables.Count > 0)
        {
            if (DS.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
                {
                    ListAll cls = new ListAll();
                    filteredCount = Convert.ToInt32(DS.Tables[0].Rows[i]["TotalCount"] != DBNull.Value ? DS.Tables[0].Rows[i]["TotalCount"].ToString() : "0");
                    cls.date = DS.Tables[0].Rows[i]["dDate"] != DBNull.Value ? DS.Tables[0].Rows[i]["dDate"].ToString() : "";
                    cls.NID = DS.Tables[0].Rows[i]["NID"] != DBNull.Value ? DS.Tables[0].Rows[i]["NID"].ToString() : "";
                    cls.cedit = DS.Tables[0].Rows[i]["cedit"] != DBNull.Value ? DS.Tables[0].Rows[i]["cedit"].ToString() : "";
                    cls.cdelete = DS.Tables[0].Rows[i]["cdelete"] != DBNull.Value ? DS.Tables[0].Rows[i]["cdelete"].ToString() : "";
                    myList.Add(cls);
                }
            }
        }

        var result = new
        {
            iTotalRecords = GetTotalCount("LISTLoadRecvd", ""),
            //iTotalRecords = 5000,
            iTotalDisplayRecords = filteredCount,
            aaData = myList
        };
        JavaScriptSerializer js = new JavaScriptSerializer();
        Context.Response.Write(js.Serialize(result));
    }


    [WebMethod]
    public void ListPOD(int iDisplayLength, int iDisplayStart, int iSortCol_0, string sSortDir_0, string sSearch)
    {
        int displayLength = iDisplayLength;
        int displayStart = iDisplayStart;
        int sortCol = iSortCol_0;
        string sortDir = sSortDir_0;
        string search = sSearch;


        ListAll cls2 = new ListAll();
        List<ListAll> myList = new List<ListAll>();

        myClass m = new myClass();

        int filteredCount = 0;
        DataSet DS = new DataSet();
        SqlPavanCourier CN = new SqlPavanCourier();

        DS = CN.RunSql("SP_ListTranPOD '" + displayLength + "','" + displayStart + "','" + sortCol + "','" + sortDir + "','" + search + "','" + m.BranchID + "','"+ HttpContext.Current.Request.Cookies["loginid"].Value.ToString() +"'", "List");


        if (DS.Tables.Count > 0)
        {
            if (DS.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
                {
                    ListAll cls = new ListAll();



                    filteredCount = Convert.ToInt32(DS.Tables[0].Rows[i]["TotalCount"] != DBNull.Value ? DS.Tables[0].Rows[i]["TotalCount"].ToString() : "0");
                    cls.awbno = DS.Tables[0].Rows[i]["cAwbno"] != DBNull.Value ? DS.Tables[0].Rows[i]["cAwbno"].ToString() : "";
                    cls.status = DS.Tables[0].Rows[i]["statusd"] != DBNull.Value ? DS.Tables[0].Rows[i]["statusd"].ToString() : "";
                    cls.deldt = DS.Tables[0].Rows[i]["dDelDate"] != DBNull.Value ? DS.Tables[0].Rows[i]["dDelDate"].ToString() : "";
                    cls.recname = DS.Tables[0].Rows[i]["cRecName"] != DBNull.Value ? DS.Tables[0].Rows[i]["cRecName"].ToString() : "";
                    cls.NID = DS.Tables[0].Rows[i]["NID"] != DBNull.Value ? DS.Tables[0].Rows[i]["NID"].ToString() : "";
                    cls.cedit = DS.Tables[0].Rows[i]["cedit"] != DBNull.Value ? DS.Tables[0].Rows[i]["cedit"].ToString() : "";
                    cls.cdelete = DS.Tables[0].Rows[i]["cdelete"] != DBNull.Value ? DS.Tables[0].Rows[i]["cdelete"].ToString() : "";

                    myList.Add(cls);
                }
            }
        }

        var result = new
        {
            iTotalRecords = GetTotalCount("LISTPOD", ""),
            //iTotalRecords = 5000,
            iTotalDisplayRecords = filteredCount,
            aaData = myList
        };
        JavaScriptSerializer js = new JavaScriptSerializer();
        Context.Response.Write(js.Serialize(result));
    }



    [WebMethod]
    public void ListCreditBooking(int iDisplayLength, int iDisplayStart, int iSortCol_0, string sSortDir_0, string sSearch)
    {
        int displayLength = iDisplayLength;
        int displayStart = iDisplayStart;
        int sortCol = iSortCol_0;
        string sortDir = sSortDir_0;
        string search = sSearch;

        myClass m = new myClass();

        ListAll cls2 = new ListAll();
        List<ListAll> myList = new List<ListAll>();



        int filteredCount = 0;
        DataSet DS = new DataSet();
        SqlPavanCourier CN = new SqlPavanCourier();

        DS = CN.RunSql("SP_ListTranCreditBooking '" + displayLength + "','" + displayStart + "','" + sortCol + "','" + sortDir + "','" + search + "','" + m.BranchID + "','" + HttpContext.Current.Request.Cookies["loginid"].Value.ToString() + "'", "List");


        if (DS.Tables.Count > 0)
        {
            if (DS.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
                {
                    ListAll cls = new ListAll();

                    filteredCount = Convert.ToInt32(DS.Tables[0].Rows[i]["TotalCount"] != DBNull.Value ? DS.Tables[0].Rows[i]["TotalCount"].ToString() : "0");
                    cls.BookinbNo = DS.Tables[0].Rows[i]["nBookingNo"] != DBNull.Value ? DS.Tables[0].Rows[i]["nBookingNo"].ToString() : "";
                    cls.BookingDt = DS.Tables[0].Rows[i]["dBookingDt"] != DBNull.Value ? DS.Tables[0].Rows[i]["dBookingDt"].ToString() : "";
                    cls.cust = DS.Tables[0].Rows[i]["cCustomerName"] != DBNull.Value ? DS.Tables[0].Rows[i]["cCustomerName"].ToString() : "";
                    cls.dest = DS.Tables[0].Rows[i]["cDomesticName"] != DBNull.Value ? DS.Tables[0].Rows[i]["cDomesticName"].ToString() : "";
                    cls.weight = DS.Tables[0].Rows[i]["cWeight"] != DBNull.Value ? DS.Tables[0].Rows[i]["cWeight"].ToString() : "";
                    cls.amt = DS.Tables[0].Rows[i]["nAmt"] != DBNull.Value ? DS.Tables[0].Rows[i]["nAmt"].ToString() : "";
                    cls.cedit = DS.Tables[0].Rows[i]["cedit"] != DBNull.Value ? DS.Tables[0].Rows[i]["cedit"].ToString() : "";
                    cls.cdelete = DS.Tables[0].Rows[i]["cdelete"] != DBNull.Value ? DS.Tables[0].Rows[i]["cdelete"].ToString() : "";

                    myList.Add(cls);
                }
            }
        }

        var result = new
        {
            iTotalRecords = GetTotalCount("ListCredit", ""),
            //iTotalRecords = 5000,
            iTotalDisplayRecords = filteredCount,
            aaData = myList
        };
        JavaScriptSerializer js = new JavaScriptSerializer();
        Context.Response.Write(js.Serialize(result));
    }

    [WebMethod]
    public void ListCashBooking(int iDisplayLength, int iDisplayStart, int iSortCol_0, string sSortDir_0, string sSearch)
    {
        int displayLength = iDisplayLength;
        int displayStart = iDisplayStart;
        int sortCol = iSortCol_0;
        string sortDir = sSortDir_0;
        string search = sSearch;

        myClass m = new myClass();

        ListAll cls2 = new ListAll();
        List<ListAll> myList = new List<ListAll>();



        int filteredCount = 0;
        DataSet DS = new DataSet();
        SqlPavanCourier CN = new SqlPavanCourier();

        DS = CN.RunSql("SP_ListTranCashBooking '" + displayLength + "','" + displayStart + "','" + sortCol + "','" + sortDir + "','" + search + "','" + m.BranchID + "','"+ HttpContext.Current.Request.Cookies["loginid"].Value.ToString() +"'", "List");


        if (DS.Tables.Count > 0)
        {
            if (DS.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
                {
                    ListAll cls = new ListAll();

                    filteredCount = Convert.ToInt32(DS.Tables[0].Rows[i]["TotalCount"] != DBNull.Value ? DS.Tables[0].Rows[i]["TotalCount"].ToString() : "0");
                    cls.BookinbNo = DS.Tables[0].Rows[i]["nBookingNo"] != DBNull.Value ? DS.Tables[0].Rows[i]["nBookingNo"].ToString() : "";
                    cls.BookingDt = DS.Tables[0].Rows[i]["dBookingDt"] != DBNull.Value ? DS.Tables[0].Rows[i]["dBookingDt"].ToString() : "";
                    cls.cust = DS.Tables[0].Rows[i]["cCustomer"] != DBNull.Value ? DS.Tables[0].Rows[i]["cCustomer"].ToString() : "";
                    cls.dest = DS.Tables[0].Rows[i]["cDomesticName"] != DBNull.Value ? DS.Tables[0].Rows[i]["cDomesticName"].ToString() : "";
                    cls.weight = DS.Tables[0].Rows[i]["cWeight"] != DBNull.Value ? DS.Tables[0].Rows[i]["cWeight"].ToString() : "";
                    cls.amt = DS.Tables[0].Rows[i]["nAmt"] != DBNull.Value ? DS.Tables[0].Rows[i]["nAmt"].ToString() : "";
                    cls.cedit = DS.Tables[0].Rows[i]["cedit"] != DBNull.Value ? DS.Tables[0].Rows[i]["cedit"].ToString() : "";
                    cls.cdelete = DS.Tables[0].Rows[i]["cdelete"] != DBNull.Value ? DS.Tables[0].Rows[i]["cdelete"].ToString() : "";
                    cls.cprint = DS.Tables[0].Rows[i]["cprint"] != DBNull.Value ? DS.Tables[0].Rows[i]["cprint"].ToString() : "";
                    myList.Add(cls);
                }
            }
        }

        var result = new
        {
            iTotalRecords = GetTotalCount("ListCash", ""),
            //iTotalRecords = 5000,
            iTotalDisplayRecords = filteredCount,
            aaData = myList
        };
        JavaScriptSerializer js = new JavaScriptSerializer();
        Context.Response.Write(js.Serialize(result));
    }


    [WebMethod(EnableSession = true)]
    public myClass UserManagement()
    {

        DataSet DS = new DataSet();
        SqlPavanCourier CN = new SqlPavanCourier();
        myClass m = new myClass();

        DS = CN.RunSql("sp_usermanagement '" + m.BranchID + "','" + m.loginid + "'", "select");
        if (DS.Tables[0].Rows.Count > 0)
        {

            m.zone = DS.Tables[0].Rows[0]["cZone"] != DBNull.Value ? DS.Tables[0].Rows[0]["cZone"].ToString() : "";
            m.country = DS.Tables[0].Rows[0]["cCountry"] != DBNull.Value ? DS.Tables[0].Rows[0]["cCountry"].ToString() : "";
            m.location = DS.Tables[0].Rows[0]["cLocation"] != DBNull.Value ? DS.Tables[0].Rows[0]["cLocation"].ToString() : "";
            m.product = DS.Tables[0].Rows[0]["cProduct"] != DBNull.Value ? DS.Tables[0].Rows[0]["cProduct"].ToString() : "";
            m.destination = DS.Tables[0].Rows[0]["cDestination"] != DBNull.Value ? DS.Tables[0].Rows[0]["cDestination"].ToString() : "";
            m.customer = DS.Tables[0].Rows[0]["cCustomer"] != DBNull.Value ? DS.Tables[0].Rows[0]["cCustomer"].ToString() : "";
            m.contact = DS.Tables[0].Rows[0]["cContract"] != DBNull.Value ? DS.Tables[0].Rows[0]["cContract"].ToString() : "";
            m.route = DS.Tables[0].Rows[0]["cDeliveryRoute"] != DBNull.Value ? DS.Tables[0].Rows[0]["cDeliveryRoute"].ToString() : "";
            m.courier = DS.Tables[0].Rows[0]["cCourier"] != DBNull.Value ? DS.Tables[0].Rows[0]["cCourier"].ToString() : "";
            m.exception = DS.Tables[0].Rows[0]["cDeliveryException"] != DBNull.Value ? DS.Tables[0].Rows[0]["cDeliveryException"].ToString() : "";
            m.charge = DS.Tables[0].Rows[0]["cCharge"] != DBNull.Value ? DS.Tables[0].Rows[0]["cCharge"].ToString() : "";
            m.inward = DS.Tables[0].Rows[0]["cStockInward"] != DBNull.Value ? DS.Tables[0].Rows[0]["cStockInward"].ToString() : "";
            m.issue = DS.Tables[0].Rows[0]["cStockIssue"] != DBNull.Value ? DS.Tables[0].Rows[0]["cStockIssue"].ToString() : "";
            m.drs = DS.Tables[0].Rows[0]["cDRS"] != DBNull.Value ? DS.Tables[0].Rows[0]["cDRS"].ToString() : "";
            m.manifest = DS.Tables[0].Rows[0]["cManifest"] != DBNull.Value ? DS.Tables[0].Rows[0]["cManifest"].ToString() : "";
            m.pod = DS.Tables[0].Rows[0]["cPOD"] != DBNull.Value ? DS.Tables[0].Rows[0]["cPOD"].ToString() : "";
            m.cash = DS.Tables[0].Rows[0]["cCashBooking"] != DBNull.Value ? DS.Tables[0].Rows[0]["cCashBooking"].ToString() : "";
            m.credit = DS.Tables[0].Rows[0]["cCreditBooking"] != DBNull.Value ? DS.Tables[0].Rows[0]["cCreditBooking"].ToString() : "";
        }
        return m;

    }



    [WebMethod]
    public void ListDRSImage(int iDisplayLength, int iDisplayStart, int iSortCol_0, string sSortDir_0, string sSearch)
    {
        int displayLength = iDisplayLength;
        int displayStart = iDisplayStart;
        int sortCol = iSortCol_0;
        string sortDir = sSortDir_0;
        string search = sSearch;


        ListAll cls2 = new ListAll();
        List<ListAll> myList = new List<ListAll>();



        int filteredCount = 0;
        DataSet DS = new DataSet();
        SqlPavanCourier CN = new SqlPavanCourier();
        myClass m = new myClass();


        DS = CN.RunSql("SP_ListTranDRSRunsheetImage '" + displayLength + "','" + displayStart + "','" + sortCol + "','" + sortDir + "','" + search + "','" + m.BranchID + "','"+ HttpContext.Current.Request.Cookies["loginid"].Value.ToString() +"'", "List");


        if (DS.Tables.Count > 0)
        {
            if (DS.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
                {
                    ListAll cls = new ListAll();



                    filteredCount = Convert.ToInt32(DS.Tables[0].Rows[i]["TotalCount"] != DBNull.Value ? DS.Tables[0].Rows[i]["TotalCount"].ToString() : "0");
                    cls.nSrNo = DS.Tables[0].Rows[i]["nSrNo"] != DBNull.Value ? DS.Tables[0].Rows[i]["nSrNo"].ToString() : "";
                    cls.dDate = DS.Tables[0].Rows[i]["dDate"] != DBNull.Value ? DS.Tables[0].Rows[i]["dDate"].ToString() : "";
                    cls.cimage = DS.Tables[0].Rows[i]["cimage"] != DBNull.Value ? DS.Tables[0].Rows[i]["cimage"].ToString() : "";
                    cls.NID = DS.Tables[0].Rows[i]["NID"] != DBNull.Value ? DS.Tables[0].Rows[i]["NID"].ToString() : "";
                    cls.cedit = DS.Tables[0].Rows[i]["cedit"] != DBNull.Value ? DS.Tables[0].Rows[i]["cedit"].ToString() : "";
                    cls.cdelete = DS.Tables[0].Rows[i]["cdelete"] != DBNull.Value ? DS.Tables[0].Rows[i]["cdelete"].ToString() : "";

                    myList.Add(cls);
                }
            }
        }

        var result = new
        {
            iTotalRecords = GetTotalCount("LISTDRSImage", ""),
            //iTotalRecords = 5000,
            iTotalDisplayRecords = filteredCount,
            aaData = myList
        };
        JavaScriptSerializer js = new JavaScriptSerializer();
        Context.Response.Write(js.Serialize(result));
    }

    private int GetTotalCount(string pageName, string cType)
    {
        myClass m = new myClass();

        int totalCount = 0;
        DataSet DS = new DataSet();
        SqlPavanCourier CN = new SqlPavanCourier();

        DS = CN.RunSql("SP_GetTotalCount '" + pageName + "','" + cType + "','" + m.BranchID + "','" + HttpContext.Current.Request.Cookies["loginid"].Value.ToString() + "'", "Count");
        totalCount = Convert.ToInt32(DS.Tables[0].Rows[0][0].ToString());
        return totalCount;
    }




}
