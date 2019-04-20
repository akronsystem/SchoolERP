using SchoolAPI.Models;
using SchoolAPI.Param;
using SchoolAPI.ResultModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolAPI.BusinessLayer
{
    public class TemplateMasterBL
    {
        SchoolERPContext db = new SchoolERPContext();


        public object GetTemplateType()
        {
            try
            {
                var TemplateType = db.TblTemplateTypeMasters.Where(R => R.Status == 1).ToList();
                if (TemplateType.Count() == 0)
                {
                    return new Error() { IsError = true, Message = "Template Type Not Found." };
                }
                else
                {
                    return new Result() { IsSucess = true, ResultData = TemplateType };
                }
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }
        }


        public object GetMenuList()
        {
            try
            {
                var Menulist = db.TblModuleMasters.Where(R => R.Status == 1 && R.ParentModuleId!=0).ToList();
                if (Menulist.Count() == 0)
                {
                    return new Error() { IsError = true, Message = "Menu List Not Found." };
                }
                else
                {
                    return new Result() { IsSucess = true, ResultData = Menulist };
                }
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }
        }
        public object SaveTemplateMaster(TemplateMasterParam TP)
        {
            try
            {
                TblTemplatesMaster objTemplate = new TblTemplatesMaster();

                string msg = "";
                if (TP.BtnStatus == "Save")
                {
                    var usercode = db.TblTemplatesMasters.Where(r => r.Name == TP.Name.ToUpper()).FirstOrDefault();
                    if (usercode != null)
                    {
                        return new Error() { IsError = true, Message = "Template Name Already Exists!" };
                    }
                   
                    objTemplate.Name = TP.Name.ToUpper();
                    objTemplate.TemplateTypeId = TP.TemplateTypeId;
                    objTemplate.CreatedBy = TP.CreatedBy;
                    objTemplate.CreatedDate = DateTime.Now;
                    objTemplate.Status = 1;
                    db.TblTemplatesMasters.Add(objTemplate);
                    db.SaveChanges();

                    TblTemplateModule objTemplateModule = new TblTemplateModule();
                    
                    string MenuIds = TP.MenuListIds.Trim(',');
                    string[] ids = MenuIds.Split(',');
                    for(int i=0;i<ids.Length;i++)
                    {
                        objTemplateModule.TemplateId = objTemplate.TemplateId;
                        objTemplateModule.ModuleId = Convert.ToInt32(ids[i]);
                        objTemplateModule.CreatedBy= TP.CreatedBy;
                        objTemplateModule.CreatedDate = DateTime.Now;
                        objTemplateModule.Status = 1;
                        db.TblTemplateModules.Add(objTemplateModule);
                        db.SaveChanges();
                    }
                    msg = "Template Master Saved Successfully!";
                }
                else
                {
                    var Data = db.TblTemplatesMasters.Where(r => r.Name == TP.Name).FirstOrDefault();
                    if(Data==null)
                    {
                        return new Error() { IsError = true, Message = "Duplicate Entry Not Allowed" };
                    }
                    TblTemplatesMaster objTempalte = db.TblTemplatesMasters.Where(r => r.TemplateId == TP.TemplateId).FirstOrDefault();
                    objTempalte.Name = TP.Name.ToUpper();
                    objTempalte.TemplateId = TP.TemplateId;
                    objTempalte.ModifiedBy = TP.ModifiedBy;
                    objTempalte.ModifiedDate = DateTime.Now;
                    objTempalte.TemplateTypeId = TP.TemplateTypeId;
                    db.SaveChanges();

                 
                    db.TblTemplateModules.RemoveRange(db.TblTemplateModules.Where(c => c.TemplateId == TP.TemplateId));
                   
                    db.SaveChanges();
                    
                    TblTemplateModule objTemplateModule = new TblTemplateModule();

                    string MenuIds = TP.MenuListIds.Trim(',');
                    string[] ids = MenuIds.Split(',');
                    for (int i = 0; i < ids.Length; i++)
                    {
                        objTemplateModule.TemplateId = TP.TemplateId;
                        objTemplateModule.ModuleId = Convert.ToInt32(ids[i]);
                        objTemplateModule.CreatedBy = TP.CreatedBy;
                        objTemplateModule.CreatedDate = DateTime.Now;
                        objTemplateModule.Status = 1;
                        db.TblTemplateModules.Add(objTemplateModule);
                        db.SaveChanges();
                    }
                    msg = "Template Master Updated Successfully!";
                }

                return new Result() { IsSucess = true, ResultData = msg };
                
            }
            catch (Exception ex)
            {
                return new Error() { IsError = true, Message = ex.Message };
            }
        }


        public object GetTemplateMasterList(int status)
        {
            try
            {
                // List<SchoolAPI.Models.ViewTemplateType> GetModule = null;
                List<SchoolAPI.Models.ViewDisplayTemplateMaster> GetTemplateMaster = null;

                if (status == 0)
                {
                    GetTemplateMaster = db.ViewDisplayTemplateMasters.Where(r => r.Status != 1).ToList();
                }
                else

                {
                    GetTemplateMaster = db.ViewDisplayTemplateMasters.Where(r => r.Status == 1).ToList();

                }

                if (GetTemplateMaster == null)
                {
                    return new Error { IsError = true, Message = "Template Masters Not Found." };
                }
                else
                {
                    return new Result { IsSucess = true, ResultData = GetTemplateMaster };
                }
            }
            catch (Exception E)
            {
                return new Error() { IsError = true, Message = E.Message };
            }
        }

        public object GetSingleTemplateMaster(TemplateMasterParam objgr)
        {
            try
            {
                var SingleTemplatelist = db.ViewDisplayTemplateMasters.Where(r => r.TemplateId == objgr.TemplateId).FirstOrDefault();
                return SingleTemplatelist;
            }
            catch (Exception E)
            {
                return new Error() { IsError = true, Message = E.Message };
            }
        }
        public object GetMenuDetails(TemplateMasterParam objgr)
        {
            try
            {
                var MenuDetails = db.ViewBindMenuListUpdates.Where(r => r.TemplateId == objgr.TemplateId).ToList();
               
                return MenuDetails;
            }
            catch (Exception E)
            {
                return new Error() { IsError = true, Message = E.Message };
            }
        }

        public object DeleteTemplateMaster(TemplateMasterParam TP)
        {
            try
            {
                TblTemplatesMaster objTemplate = db.TblTemplatesMasters.Where(r => r.TemplateId == TP.TemplateId).FirstOrDefault();

                if (objTemplate.Status == 1)
                {
                    objTemplate.Status = 0;
                }
                else
                {
                    objTemplate.Status = 1;
                }

                db.SaveChanges();
                if(objTemplate.Status==1)
                {
                    return new Result() { IsSucess = true, ResultData = "Template Master Activated Successfully!" };

                }
                else
                {
                    return new Result() { IsSucess = true, ResultData = "Template Master De-Activated Successfully!" };

                }
            }
            catch (Exception ex)
            {
                return new Error() { IsError = true, Message = ex.Message };
            }
        }
    }
}