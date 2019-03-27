using SchoolAPI.Param;
using SchoolAPI.ResultModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolAPI.Models;
namespace SchoolAPI.BusinessLayer
{
    public class AssignWidgetBL
    {
        SchoolERPContext db = new SchoolERPContext();
        SchoolAdminContext dbSA = new SchoolAdminContext();
        public object GetWidgetList(UserCredential obj)
        {
            try
            {
                List<ViewWidgetList> lstWidget = null;
                lstWidget = db.ViewWidgetLists.Where(r => r.Status == 1).ToList();
                if(lstWidget==null)
                {
                    return new Error { IsError = true, Message = "No Records Found!" };
                }
                else
                {
                    return lstWidget;
                }

            }
            catch(Exception ex)
            {
                return new Error {IsError=true,Message=ex.Message };
            }
        }

        public object GetRole()
        {
            try
            {
                List<ViewRoleList> lstRole = null;
                lstRole = dbSA.ViewRoleLists.Where(r => r.Status == 1).ToList();
                if(lstRole==null)
                {
                    return new Error { IsError=true,Message="No Records Found!"};
                }
                else
                {
                    return lstRole;
                }
            }
            catch(Exception ex)
            {
                return new Error { IsError=true,Message=ex.Message};
            }
        }

        public object GetAssignWidget(UserCredential obj)
        {
            try
            {
                List<ViewAssignWidget> lstAssignWidget = null;
                lstAssignWidget = dbSA.ViewAssignWidgets.AsNoTracking().ToList();
                if(lstAssignWidget.Count==0)
                {
                    return new Error { IsError = true, Message = "No Records Found" };
                }
                else
                {
                    return lstAssignWidget;
                }
            }
            catch(Exception ex)
            {
                return new Error { IsError = true, Message = ex.Message };
            }
        }

       public object SaveAssignWidget(AssignWidgetParam Pobj)
        {
            try
            {
                TblAssignWidgetMaster AwmObj = new TblAssignWidgetMaster();//save only RoleID
              
                dbSA.TblAssignWidgetMasters.RemoveRange(dbSA.TblAssignWidgetMasters.Where(c => c.RoleID == Pobj.RoleID));
                dbSA.TblAssignWidgetDetails.RemoveRange(dbSA.TblAssignWidgetDetails.Where(c => c.AssignWidgetID == Pobj.AssignWidgetID));
                dbSA.SaveChanges();
                
                AwmObj.RoleID = Pobj.RoleID.ToString();
                AwmObj.Status = 1;
                AwmObj.CreatedBy = Pobj.CreatedBy;
                AwmObj.CreatedDate = DateTime.Now;

                dbSA.TblAssignWidgetMasters.Add(AwmObj);
                dbSA.SaveChanges();


                TblAssignWidgetDetail AdObj = new TblAssignWidgetDetail();

               
                //string WidgetIDList = Pobj.WidgetIDs.Trim(',');
                string[] Wids = Pobj.WidgetIDs.Trim(',').Split(',');
                string[] Wids1 = Wids.Where(c => c != "undefined" && c != "").ToArray();
                // string SequenceList = Pobj.SequenceIDs.Trim(',');

                string[] Seq = Pobj.SequenceIDs.Trim(',').Split(',');
                
                string[] seq1 = Seq.Where(c => c != "undefined" && c!="").ToArray();

                for (int i = 0; i < Wids1.Length; i++)
                {
                    AdObj.AssignWidgetID = AwmObj.AssignWidgetID;
                    
                    AdObj.WidgetID = Convert.ToInt32(Wids1[i]);
                    AdObj.Sequence = Convert.ToInt32(seq1[i]);
                    dbSA.TblAssignWidgetDetails.Add(AdObj);
                    dbSA.SaveChanges();
                    
                }
                return new Result { IsSucess=true,ResultData="Widget Assign Successfully!"};
            }
            catch(Exception ex)
            {
                return new Error { IsError = true, Message = ex.Message };

            }
        }


        public object GetAssignWidgetRoleWise(AssignWidgetParam Pobj)
        {
            try
            {
                List<ViewGetAssignWidgetRoleWise> lstAssignWidgetRoleWise = null;
                int Roleid = Convert.ToInt32(Pobj.RoleID);
                lstAssignWidgetRoleWise = dbSA.ViewGetAssignWidgetRoleWises.AsNoTracking().Where(r=>r.RoleID== Roleid).ToList();
                if (lstAssignWidgetRoleWise.Count == 0)
                {
                    return new Error { IsError = true, Message = "No Records Found" };
                }
                else
                {
                    return lstAssignWidgetRoleWise;
                }
            }
            catch(Exception ex)
            {
                return new Error { IsError=true,Message=ex.Message};
            }
        }
    }
}