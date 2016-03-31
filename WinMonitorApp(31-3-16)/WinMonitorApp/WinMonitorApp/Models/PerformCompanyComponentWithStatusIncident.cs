using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using WinMonitorApp.Models;

namespace WinMonitorApp.Models
{
    public class PerformCompanyComponentWithStatusIncident
    {

        // To generate sequences from the self generated sequences in the database
        public string getseqDBCompanyId()
        {
            WinMonitorEntityModelContext mDBContext = new WinMonitorEntityModelContext();
            string intnextseqDBCompanyId = 'C' + mDBContext.Database.SqlQuery<int>("select next value for seqDBCompanyId").FirstOrDefault().ToString();
            return intnextseqDBCompanyId;
        }

        public string getseqDBIncidentId()
        {
            WinMonitorEntityModelContext mDBContext = new WinMonitorEntityModelContext();
            string intnextseqDBIncidentId = 'I' + mDBContext.Database.SqlQuery<int>("select next value for seqDBIncidentId").FirstOrDefault().ToString();
            return intnextseqDBIncidentId;
        }

        public string getseqMasterDBCSId()
        {
            WinMonitorEntityModelContext mDBContext = new WinMonitorEntityModelContext();
            string intnextseqMasterDBCSId = "MCWS" + mDBContext.Database.SqlQuery<int>("select next value for seqMasterDBCSId").FirstOrDefault().ToString();
            return intnextseqMasterDBCSId;
        }

        public string getseqSpecificDBCSId()
        {
            WinMonitorEntityModelContext mDBContext = new WinMonitorEntityModelContext();
            string intnextseqSpecificDBCSId = "SCWS" + mDBContext.Database.SqlQuery<int>("select next value for seqSpecificDBCSId").FirstOrDefault().ToString();
            return intnextseqSpecificDBCSId;
        }


       //USER FUNCTIONS
        //get user CompanyId from CompanyName in url
        public string mGetUserCompanyId(string pstringCompanyName)
        {
            WinMonitorEntityModelContext mDBContext = new WinMonitorEntityModelContext();

            string mCompanyId = mDBContext.Database.SqlQuery<String>("select DBCompanyId from DBCompany where DBCompanyName='"+pstringCompanyName+"'").FirstOrDefault().ToString();

            return mCompanyId;
        }

        //show status page values
        public List<GetStatus> mGetStatus(string pstringCompanyId)
        {
            WinMonitorEntityModelContext mDBContext = new WinMonitorEntityModelContext();
            return mDBContext.Database.SqlQuery<GetStatus>("select DBComponentName as ComponentName, DBStatus as Status from DBComponent_With_Status where DBCompanyId='" + pstringCompanyId + "'").ToList();
        }




        //ADMIN FUNCTIONS       
        //show company details
        public List<DBCompany> mRetrieveCompanyDetails()
        {
            WinMonitorEntityModelContext mDBContext = new WinMonitorEntityModelContext();
            return mDBContext.DBCompanies.ToList();
        }

        //Company Save details method
        public string mSaveAddCompanyDetails(string pstringCompanyName, string pstringURL)
        {
            try
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
                return "Company Successfully added !!";
            }
            catch (DbUpdateException exUpdateDB)
            {
                Console.Write(exUpdateDB);
                return "DbUpdateException";
            }
            catch (DbEntityValidationException exEntityValidateDB)
            {
                Console.Write(exEntityValidateDB);
                return "DbEntityValidationException";
            }
            catch (NotSupportedException exNotSupportedDB)
            {
                Console.Write(exNotSupportedDB);
                return "NotSupportedException";
            }
            catch (ObjectDisposedException exObjectDisposedDB)
            {
                Console.Write(exObjectDisposedDB);
                return "ObjectDisposedException";
            }
            catch (InvalidOperationException exInvalidOperationDB)
            {
                Console.Write(exInvalidOperationDB);
                return "InvalidOperationException";
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return "Misllaneous Exception";
            }
        }


        //Specific Components Save details method
        public string mSaveAddSpecificComponentDetails(string pstringSpecificComponentName, string pstringSpecificComponentStatus, string pstringSpecificComponentCompanyId)
        {
            try
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
                return "Specific Component Successfully added !!";
            }
            catch (DbUpdateException exUpdateDB)
            {
                Console.Write(exUpdateDB);
                return "DbUpdateException";
            }
            catch (DbEntityValidationException exEntityValidateDB)
            {
                Console.Write(exEntityValidateDB);
                return "DbEntityValidationException";
            }
            catch (NotSupportedException exNotSupportedDB)
            {
                Console.Write(exNotSupportedDB);
                return "NotSupportedException";
            }
            catch (ObjectDisposedException exObjectDisposedDB)
            {
                Console.Write(exObjectDisposedDB);
                return "ObjectDisposedException";
            }
            catch (InvalidOperationException exInvalidOperationDB)
            {
                Console.Write(exInvalidOperationDB);
                return "InvalidOperationException";
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return "Misllaneous Exception";
            }
        }


        //update staus of selected components
        public string UpdatingStatusOfComponentsSelected(List<string> pselectedComponentList, string statusToBeChanged) {
            try
            {
                WinMonitorEntityModelContext contextObj = new WinMonitorEntityModelContext();
                foreach (string componentId in pselectedComponentList) {

                    contextObj.Database.SqlQuery<int>("update DBComponent_With_Status set DBStatus='"+statusToBeChanged+"' where DBCompanyId='"+componentId+"';");
                    contextObj.SaveChanges();
                }
                return "Incident Successfully added !!";
            }
            catch (DbUpdateException exUpdateDB)
            {
                Console.Write(exUpdateDB);
                return "DbUpdateException";
            }
            catch (DbEntityValidationException exEntityValidateDB)
            {
                Console.Write(exEntityValidateDB);
                return "DbEntityValidationException";
            }
            catch (NotSupportedException exNotSupportedDB)
            {
                Console.Write(exNotSupportedDB);
                return "NotSupportedException";
            }
            catch (ObjectDisposedException exObjectDisposedDB)
            {
                Console.Write(exObjectDisposedDB);
                return "ObjectDisposedException";
            }
            catch (InvalidOperationException exInvalidOperationDB)
            {
                Console.Write(exInvalidOperationDB);
                return "InvalidOperationException";
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return "Misllaneous Exception";
            }

            
        }



        //Incidents Save details method
        public string mSaveAddIncidentDetails(string pstringIncidentName, string pstringIncidentDetails, List<string> pstringComponentIdList)
        {
            try
            {
                WinMonitorEntityModelContext mDBContext = new WinMonitorEntityModelContext();
                DBIncident mDBIncidentObj = new DBIncident();
                foreach (string componentId in pstringComponentIdList)
                {

                    mDBIncidentObj.DBIncidentId = getseqDBIncidentId();
                    mDBIncidentObj.DBIncidentName = pstringIncidentName;
                    mDBIncidentObj.DBDescription = pstringIncidentDetails;
                    mDBIncidentObj.DBCSId = componentId;


                    //adds new incident to the incidents table
                    mDBContext.DBIncidents.Add(mDBIncidentObj);

                    //save the specific component details to the database
                    mDBContext.SaveChanges();
                }
                    return "Incident Successfully added !!";
                }
                catch (DbUpdateException exUpdateDB)
                {
                    Console.Write(exUpdateDB);
                    return "DbUpdateException";
                }
                catch (DbEntityValidationException exEntityValidateDB)
                {
                    Console.Write(exEntityValidateDB);
                    return "DbEntityValidationException";
                }
                catch (NotSupportedException exNotSupportedDB)
                {
                    Console.Write(exNotSupportedDB);
                    return "NotSupportedException";
                }
                catch (ObjectDisposedException exObjectDisposedDB)
                {
                    Console.Write(exObjectDisposedDB);
                    return "ObjectDisposedException";
                }
                catch (InvalidOperationException exInvalidOperationDB)
                {
                    Console.Write(exInvalidOperationDB);
                    return "InvalidOperationException";
                }
                catch(Exception ex)
                {
                    Console.Write(ex);
                    return "Misllaneous Exception";
                }
        }


        //Display Component Page Elements
        public IEnumerable<DummyClassForComponentPageDisplay> LoadExistingComponentsFromDataBase(String pCompanyId)
        {
            WinMonitorEntityModelContext contextObj = new WinMonitorEntityModelContext();
            IEnumerable<DummyClassForComponentPageDisplay> result;
            result = contextObj.Database.SqlQuery<DummyClassForComponentPageDisplay>("select cws.DBCSId as mstrComponentId, cws.DBComponentName as mstrComponentName, cws.DBType as mstrComponentType, comp.DBCompanyName as mstrCompanyName, i.DBIncidentName as mstrIncidentName from DBComponent_With_Status cws inner join DBCompany comp on cws.DBCompanyId = comp.DBCompanyId left join DBIncidents i on i.DBCSId = cws.DBCSId where comp.DBCompanyId= '" + pCompanyId + "'").ToList();
            return result;
        }


        //fetching master component list from database
        public IEnumerable<DBMaster_DBComponent_With_Status> MasterComponentDataFromDB()
        {
            WinMonitorEntityModelContext contextObj = new WinMonitorEntityModelContext();
            IEnumerable<DBMaster_DBComponent_With_Status> masterComponentList;
            masterComponentList = (from masterComponent in contextObj.DBMaster_DBComponent_With_Status
                                   select masterComponent).AsEnumerable();
            return masterComponentList;
        }
        public string GetCompanyNameById(String pstrCompanyId) 
        {
            WinMonitorEntityModelContext contextObj;
            DBCompany result;
            contextObj = new WinMonitorEntityModelContext();
            result = (from company in contextObj.DBCompanies
                      where company.DBCompanyId == pstrCompanyId
                      select company).SingleOrDefault();
            return result.DBCompanyName;
        }

        public void AddComponentToDb(List<DBComponent_With_Status> pCWSObj)
        {
            WinMonitorEntityModelContext contextObj = new WinMonitorEntityModelContext();
            foreach(DBComponent_With_Status component in pCWSObj)
            {
                contextObj.DBComponent_With_Status.Add(component);
                contextObj.SaveChanges();
            }
        }

    }
}