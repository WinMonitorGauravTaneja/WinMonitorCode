using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WinMonitorApp.Models
{
    public class PerformCompanyComponentWithStatusIncident
    {
        
        // To generate sequences from the self generated sequences in the database
        public string getseqDBCompanyId()
        {
            WinMonitorEntityModelContext mDBContext = new WinMonitorEntityModelContext();
            string intnextseqDBCompanyId = 'C'+mDBContext.Database.SqlQuery<int>("select next value for seqDBCompanyId").FirstOrDefault().ToString();
            return intnextseqDBCompanyId;
        }

        public string getseqDBIncidentId()
        {
            WinMonitorEntityModelContext mDBContext = new WinMonitorEntityModelContext();
            string intnextseqDBIncidentId = 'I'+mDBContext.Database.SqlQuery<int>("select next value for seqDBIncidentId").FirstOrDefault().ToString();
            return intnextseqDBIncidentId;
        }

        public string getseqMasterDBCSId()
        {
            WinMonitorEntityModelContext mDBContext = new WinMonitorEntityModelContext();
            string intnextseqMasterDBCSId = "MCWS"+mDBContext.Database.SqlQuery<int>("select next value for seqMasterDBCSId").FirstOrDefault().ToString();
            return intnextseqMasterDBCSId;
        }

        public string getseqSpecificDBCSId()
        {
            WinMonitorEntityModelContext mDBContext = new WinMonitorEntityModelContext();
            string intnextseqSpecificDBCSId = "SCWS"+mDBContext.Database.SqlQuery<int>("select next value for seqSpecificDBCSId").FirstOrDefault().ToString();
            return intnextseqSpecificDBCSId;
        }

        //show company details
        public List<DBCompany> mRetrieveCompanyDetails()
        {
            WinMonitorEntityModelContext mDBContext = new WinMonitorEntityModelContext();
            return mDBContext.DBCompanies.ToList();
        }

        //Company Save details method
        public void mSaveAddCompanyDetails(string pstringCompanyName, string pstringURL)
        {
            WinMonitorEntityModelContext mDBContext = new WinMonitorEntityModelContext();
            DBCompany mDBCompanyObj = new DBCompany();


            mDBCompanyObj.DBCompanyId = getseqDBCompanyId();
            mDBCompanyObj.DBCompanyName = pstringCompanyName;
            mDBCompanyObj.DBURL = pstringURL;

            //adds new to the company
            mDBContext.DBCompanies.Add(mDBCompanyObj);

            //save the company details to the database
            mDBContext.SaveChanges();
        }


        //Specific Components Save details method
        public void mSaveAddSpecificComponentDetails(string pstringSpecificComponentName, string pstringSpecificComponentStatus, string pstringSpecificComponentCompanyId)
        {
            WinMonitorEntityModelContext mDBContext = new WinMonitorEntityModelContext();
            DBComponent_With_Status mDBSpecific_Component_With_StatusObj = new DBComponent_With_Status();

            mDBSpecific_Component_With_StatusObj.DBCSId = getseqSpecificDBCSId();
            mDBSpecific_Component_With_StatusObj.DBComponentName = pstringSpecificComponentName;
            mDBSpecific_Component_With_StatusObj.DBStatus = pstringSpecificComponentStatus;
            mDBSpecific_Component_With_StatusObj.DBType = "Specific";
            mDBSpecific_Component_With_StatusObj.DBCompanyId = pstringSpecificComponentCompanyId;
            mDBSpecific_Component_With_StatusObj.DBMasterComponentName = null;


            //adds new specific component to the components table
            mDBContext.DBComponent_With_Status.Add(mDBSpecific_Component_With_StatusObj);

            //save the specific component details to the database
            mDBContext.SaveChanges();
        }


        //Incidents Save details method
        public void mSaveAddIncidentDetails(string pstringIncidentName, string pstringIncidentDetails)
        {
                WinMonitorEntityModelContext mDBContext = new WinMonitorEntityModelContext();
                DBIncident mDBIncidentObj = new DBIncident();

                mDBIncidentObj.DBIncidentId = getseqDBIncidentId();
                mDBIncidentObj.DBIncidentName = pstringIncidentName;
                mDBIncidentObj.DBDescription = pstringIncidentDetails;
                mDBIncidentObj.DBCSId = "SCWS1";                                       //needs to be changed

                //adds new incident to the incidents table
                mDBContext.DBIncidents.Add(mDBIncidentObj);

                //save the specific component details to the database
                mDBContext.SaveChanges();
          
        }


        //Display Component Page Elements
        public IEnumerable<DBCompany> LoadExistingComponentsFromDataBase(String pCompanyId)
        {
            WinMonitorEntityModelContext contextObj;
            IEnumerable<DBCompany> result= null;
            contextObj = new WinMonitorEntityModelContext();
            contextObj.Configuration.LazyLoadingEnabled = true;
            result = (from companyObj in contextObj.DBCompanies
                          where companyObj.DBCompanyId == pCompanyId
                          select companyObj).ToList();
            return result;
        }
        public IEnumerable<DBMaster_DBComponent_With_Status> MasterComponentDataFromDB()
        {
            WinMonitorEntityModelContext contextObj = new WinMonitorEntityModelContext();
            contextObj.Configuration.LazyLoadingEnabled = false;
            return contextObj.DBMaster_DBComponent_With_Status.AsEnumerable();
        }
        public string GetMasterComponentNameById(String pstrCompanyId) 
        {
            WinMonitorEntityModelContext contextObj;
            DBCompany result;
            contextObj = new WinMonitorEntityModelContext();
            contextObj.Configuration.LazyLoadingEnabled = false;
            result = (from masterComponent in contextObj.DBCompanies
                      where masterComponent.DBCompanyId == pstrCompanyId
                      select masterComponent).SingleOrDefault();
            return result.DBCompanyName;
        }

        public void AddComponentToDb(DBComponent_With_Status pCWSObj)
        {
            WinMonitorEntityModelContext contextObj = new WinMonitorEntityModelContext();
            contextObj.Configuration.LazyLoadingEnabled = false;
            contextObj.DBComponent_With_Status.Add(pCWSObj);
            contextObj.SaveChanges();
        }

    }
}