using SchoolAPI.Models;
using SchoolAPI.Param;
using SchoolAPI.ResultModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolAPI.BusinessLayer
{
    public class TemplateTypeBL
    {
        SchoolERPContext db = new SchoolERPContext();
        public object SaveTemplateType(TemplateTypeParam TP)
        {
            try
            {
                string msg = "";
                if (TP.BtnStatus == "Save")
                {
                    var usercode = db.TblTemplateTypeMasters.Where(r => r.TemplateType == TP.TemplateType.ToUpper()).FirstOrDefault();
                    if (usercode != null)
                    {
                        return new Error() { IsError = true, Message = "Template Type Name is Already Exists!" };
                    }
                    TblTemplateTypeMaster objTemplate = new TblTemplateTypeMaster();

                    objTemplate.TemplateType = TP.TemplateType.ToUpper();

                    objTemplate.CreatedBy = TP.CreatedBy;
                    objTemplate.CreatedDate = DateTime.Now;

                    objTemplate.Status = 1;
                    db.TblTemplateTypeMasters.Add(objTemplate);
                    db.SaveChanges();
                    msg = "Template Type Saved Successfully!";

                }
                else
                {
                    TblTemplateTypeMaster objTempalte = db.TblTemplateTypeMasters.Where(r => r.TemplateTypeId == TP.TemplateTypeId).FirstOrDefault();
                    var Data = db.TblTemplateTypeMasters.Where(r => r.TemplateType == TP.TemplateType && r.TemplateTypeId == TP.TemplateTypeId).FirstOrDefault();
                    if(Data==null)
                    {
                        return new Error() { IsError = true, Message = "Duplicate Entry Not Allowed" };
                    }
                    objTempalte.TemplateType = TP.TemplateType.ToUpper();
                    objTempalte.ModifiedBy = TP.ModifiedBy;
                    objTempalte.ModifiedDate = DateTime.Now;
                    objTempalte.TemplateTypeId = TP.TemplateTypeId;
                    db.SaveChanges();
                    msg = "Template Type Updated Successfully!";
                }

                return new Result() { IsSucess = true, ResultData = msg };


            }
            catch (Exception ex)
            {
                return new Error() { IsError = true, Message = ex.Message };
            }
        }


        public object GetTemplateTypeList(int status)
        {
            try
            {
                List<SchoolAPI.Models.ViewTemplateType> GetModule = null;

                if (status == 0)
                {
                    GetModule = db.ViewTemplateTypes.Where(r => r.Status != 1).ToList();
                }
                else

                {
                    GetModule = db.ViewTemplateTypes.Where(r => r.Status == 1).ToList();

                }

                if (GetModule == null)
                {
                    return new Error { IsError = true, Message = "Template Type Not Found." };
                }
                else
                {
                    return new Result { IsSucess = true, ResultData = GetModule };
                }
            }
            catch (Exception E)
            {
                return new Error() { IsError = true, Message = E.Message };
            }
        }

        public object GetSingleTemplateType(TemplateTypeParam objgr)
        {
            try
            {
                var SingleModulelist = db.ViewTemplateTypes.Where(r => r.TemplateTypeId == objgr.TemplateTypeId).FirstOrDefault();
                return SingleModulelist;
            }
            catch (Exception E)
            {
                return new Error() { IsError = true, Message = E.Message };
            }
        }

        public object DeleteTemplateType(TemplateTypeParam TP)
        {
            try
            {
                TblTemplateTypeMaster objmodule = db.TblTemplateTypeMasters.Where(r => r.TemplateTypeId == TP.TemplateTypeId).FirstOrDefault();

                if (objmodule.Status == 1)
                {
                    objmodule.Status = 0;
                }
                else
                {
                    objmodule.Status = 1;
                }

                db.SaveChanges();

                return new Result() { IsSucess = true, ResultData = "Template Type Updated Successfully!" };
            }
            catch (Exception ex)
            {
                return new Error() { IsError = true, Message = ex.Message };
            }
        }


    }
}