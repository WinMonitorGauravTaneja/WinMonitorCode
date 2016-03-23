using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WinMonitorApp.Models;

namespace WinMonitorApp.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        string testCompanyId;

        public ActionResult Master()
        {
            return View();
        }

        public ActionResult CompanyDashboard()
        {
            PerformCompanyComponentWithStatusIncident PerformCompanyComponentWithStatusIncidentObj = new PerformCompanyComponentWithStatusIncident();
            List<DBCompany> ModelCompany = PerformCompanyComponentWithStatusIncidentObj.mRetrieveCompanyDetails();
            return View(ModelCompany);
        }

        public ActionResult ComponentandStatus()
        {
            return View();
        }

        public ActionResult PerformanceMetrics()
        {
            return View();
        }

        public ActionResult ActivatePage()
        {
            return View();
        }

        public ActionResult RegisteredAdmin()
        {
            PerformLogin PerformLoginObj = new PerformLogin();
            List<DBLogin> ModelLogin = PerformLoginObj.mRetrieveLoginDetails();
            return View(ModelLogin);
        }

        public ActionResult Settings()
        {
            return View();
        }

        public JsonResult ComponentandStatusFromDB(string companyIdFromPage)
        {
            PerformCompanyComponentWithStatusIncident performObj = new PerformCompanyComponentWithStatusIncident();
            IEnumerable<DBCompany> resultObj = performObj.LoadExistingComponentsFromDataBase(companyIdFromPage);
            return Json(resultObj, JsonRequestBehavior.AllowGet);
        }

        public JsonResult addMasterComponentToDB(string pMasterComponentListFromPage)
        {
            PerformCompanyComponentWithStatusIncident performObj = new PerformCompanyComponentWithStatusIncident();
            string companyName = performObj.GetMasterComponentNameById("c74");
            string data = "";
            List<DBMaster_DBComponent_With_Status> MasterComponentListFromPage = new List<DBMaster_DBComponent_With_Status>();
            DBMaster_DBComponent_With_Status singleMasterComponent = new DBMaster_DBComponent_With_Status();
            string[] distributedMasterComponents = pMasterComponentListFromPage.Split(new char[] { '&' });
            foreach (var masterComponentFromPage in distributedMasterComponents)
            {
                string[] componentProp = masterComponentFromPage.Split(new char[] { '=' });
                singleMasterComponent.DBMasterComponentName = componentProp[1];
                MasterComponentListFromPage.Add(singleMasterComponent);
            }
            DBComponent_With_Status component = new DBComponent_With_Status();
            foreach (var masterComponent in MasterComponentListFromPage)
            {
                string masterComponentId = performObj.getseqMasterDBCSId();
                component.DBCSId = masterComponentId;
                component.DBComponentName = masterComponent.DBMasterComponentName;
                component.DBStatus = "Operational";
                component.DBType = "Master";
                component.DBCompanyId = testCompanyId;
                component.DBMasterComponentName = masterComponent.DBMasterComponentName;
                performObj.AddComponentToDb(component);
                data = data + "{'PageComponentId':'" + masterComponentId + "','PageComponentName':'" + masterComponent.DBMasterComponentName + "','PageComponentType':'Master','PageCompanyName':'" + companyName + "','PageIncidentName':'null'},";
            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        


        // perform CompanyTable details save and display ajax operation
        public class jsonCompanyServer
        {
            public string jsonCompanyName { get; set; }
            public string jsonCompanyURL { get; set; }
        }


        public string jsonCompanyRetrieve(jsonCompanyServer jsonCompanyServers)
        {
            string mCompanyNameSend = jsonCompanyServers.jsonCompanyName.ToString();
            string mCompanyURLSend = jsonCompanyServers.jsonCompanyURL.ToString();

            PerformCompanyComponentWithStatusIncident CompanyAddAccountObj = new PerformCompanyComponentWithStatusIncident();
            CompanyAddAccountObj.mSaveAddCompanyDetails(mCompanyNameSend, mCompanyURLSend);

            string result = "Company Added Successfully";
            return result;
        }



        //perform Specific Component details save and display ajax operation
        public class jsonSpecificComponentServer
        {
            public string jsonSpecificComponentName { get; set; }
            public string jsonSpecificComponentStatus { get; set; }
            public string jsonSpecificComponentCompanyId { get; set; } //comes from global variable
        }

        public string jsonSpecificComponentRetrieve(jsonSpecificComponentServer jsonSpecificComponentServers)
        {
            string mSpecificComponentNameSend = jsonSpecificComponentServers.jsonSpecificComponentName.ToString();
            string mSpecificComponentStatusSend = jsonSpecificComponentServers.jsonSpecificComponentStatus.ToString();
            string mSpecificComponentCompanyId = jsonSpecificComponentServers.jsonSpecificComponentCompanyId.ToString();

            PerformCompanyComponentWithStatusIncident SpecificComponentAddObj = new PerformCompanyComponentWithStatusIncident();
            SpecificComponentAddObj.mSaveAddSpecificComponentDetails(mSpecificComponentNameSend, mSpecificComponentStatusSend, mSpecificComponentCompanyId);

            string result = "Specific component added successfully";
            return result;
        }


        //perform Incident details save and display ajax operation
        public class jsonIncidentServer
        {
            public string jsonIncidentName { get; set; }
            public string jsonIncidentDetails { get; set; }
        }

        public string jsonIncidentRetreive(jsonIncidentServer jsonIncidentServers)
        {
            string mIncidentNameSend = jsonIncidentServers.jsonIncidentName.ToString();
            string mIncidentDetailsSend = jsonIncidentServers.jsonIncidentDetails.ToString();

            PerformCompanyComponentWithStatusIncident IncidentAddObj = new PerformCompanyComponentWithStatusIncident();
            IncidentAddObj.mSaveAddIncidentDetails(mIncidentNameSend, mIncidentDetailsSend);

            string result = "Incident added successfully";
            return result;
        }
    }
}
