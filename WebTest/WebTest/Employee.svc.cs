using CustomizesWebApp.MyClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WebTest
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Employee" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Employee.svc or Employee.svc.cs at the Solution Explorer and start debugging.
    public class Employee : IEmployee
    {
        Weltectemployees2Entities db = new Weltectemployees2Entities();

        General objGe = new General();
        public void DoWork()
        {
        }

        #region Empdetails
        public checkEmpdetails GetEmpDetails(string search)
        {
            checkEmpdetails ObjCheck = new checkEmpdetails();

            try
            {
                db = new Weltectemployees2Entities();

                var Emp = (from PD in db.PersonalDetails
                           join CD in db.ContactDetails on PD.EmployeeId equals CD.EmployeeId
                           join CM in db.CityMasters on CD.CityId equals CM.CityId
                           join SM in db.StateMasters on CD.StateId equals SM.StateId
                           join COU in db.CountryMasters on CD.CountryId equals COU.CountryId
                           join ED in db.EducationDetails on PD.EmployeeId equals ED.EmployeeId
                           join EX in db.ExperienceDetails on PD.EmployeeId equals EX.EmployeeId
                           join BD in db.BankDetails on PD.EmployeeId equals BD.EmployeeId
                           join Bo in db.BloodGroupMasters on PD.BloodGroupId equals Bo.BloodGroupId
                           where PD.IsActive == true && (search=="0" || search==PD.FirstName|| search==PD.LastName|| search==BD.BankName)
                           select new
                           {
                               PD.FirstName,
                               PD.LastName,
                               PD.Gender,
                               PD.Age,
                               CD.HomeAddress,
                               CM.CityName,
                               SM.StateName,
                               COU.CountryName,
                               ED.Qualification,
                               ED.PassOutYear,
                               ED.Grade,
                               ED.College,
                               EX.Designation,
                               EX.PreviousCompany,
                               EX.Experience,
                               BD.BankName,
                               BD.Branch,
                               BD.AccountType,
                               BD.BankAccountNo,
                               Bo.BGName

                           }).ToList();

                Empdetails objData = new Empdetails();

                if (Emp != null)
                {
                    var lstEmp = new List<Empdetails>();

                    foreach(var item in Emp) 
                    {
                        objData = new Empdetails();

                        objData.EmployeeName = item.FirstName + ' ' + item.LastName;
                        objData.Address = item.HomeAddress +' ' + item.CityName + ' ' + item.StateName + ' ' + item.CountryName;
                        objData.Eduction = item.Qualification + ' ' + item.College + ' ' + item.PassOutYear + ' ' + item.Grade;
                        objData.Exprience = item.Designation+' '+item.PreviousCompany+' '+item.Experience;
                        objData.Bank = item.BankName+' '+item.Branch+' '+item.AccountType+' '+item.BankAccountNo;
                        objData.BloodGroup = item.BGName;

                        lstEmp.Add(objData);
                    
                    }
                    ObjCheck.Data = lstEmp;
                    ObjCheck.status = true;
                    ObjCheck.message = "Sucess";

                }

                else
                {
                    ObjCheck.Data = null;
                    ObjCheck.status = false;
                    ObjCheck.message = "Failure";
                }

            }
            catch (Exception ex)
            {
                ObjCheck.Data = null;
                ObjCheck.status = false;
                ObjCheck.message = ex.Message;


            }
            return ObjCheck;


        }

        #endregion

    }
}
