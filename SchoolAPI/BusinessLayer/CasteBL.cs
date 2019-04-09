using SchoolAPI.Models;
using SchoolAPI.Param;
using SchoolAPI.ResultModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolAPI.BusinessLayer
{
    public class CasteBL
    {
        SchoolAdminContext db = new SchoolAdminContext();

        public object GetReligion()
        {
            try
            {
                var Religionlist = db.TblReligionMasters.Where(R => R.Status == 1).ToList();
                if (Religionlist.Count() == 0)
                {
                    return new Error() { IsError = true, Message = "No Religion Found." };
                }
                else
                {
                    return new Result() { IsSucess = true, ResultData = Religionlist };
                }
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }
        }

        public object GetCategory()
        {
            try
            {
                var Categorylist = db.Tbl_Category_Master.Where(R => R.Status == 1).ToList();
                if (Categorylist.Count() == 0)
                {
                    return new Error() { IsError = true, Message = "No Category Found." };
                }
                else
                {
                    return new Result() { IsSucess = true, ResultData = Categorylist };
                }
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }
        }

        public object GetCaste()
        {
            try
            {
                var Castelist = db.Tbl_Caste_Master.Where(R => R.Status == 1).ToList();
                if (Castelist.Count() == 0)
                {
                    return new Error() { IsError = true, Message = "No Caste Found." };
                }
                else
                {
                    return new Result() { IsSucess = true, ResultData = Castelist };
                }
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }
        }

        public object SaveReligion(ReligionParam MP)
        {
            try
            {
                string msg = "";
                if (MP.BtnStatus == "Save")
                {
                    var usercode = db.TblReligionMasters.Where(r => r.ReligionName == MP.ReligionName.ToUpper()).FirstOrDefault();
                    if (usercode != null)
                    {
                        return new Error() { IsError = true, Message = "Religion Name Already Exists!" };
                    }
                    Tbl_Religion_Master objReligion = new Tbl_Religion_Master();

                    objReligion.ReligionName = MP.ReligionName.ToUpper();
                    objReligion.CreatedBy = MP.CreatedBy;
                    objReligion.CreatedDate = DateTime.Now;
                    objReligion.Status = 1;
                    db.TblReligionMasters.Add(objReligion);
                    db.SaveChanges();
                    msg = "Religion Saved Successfully!";

                }
                else
                {
                    Tbl_Religion_Master objReligion = db.TblReligionMasters.Where(r => r.ReligionID == MP.ReligionID).FirstOrDefault();
                    var Data = db.TblReligionMasters.Where(r => r.ReligionName == MP.ReligionName.ToUpper()).FirstOrDefault();
                    if (Data != null)
                    {
                        return new Error() { IsError = true, Message = "Religion Name Already Exists!" };
                    }
                    objReligion.ReligionName = MP.ReligionName.ToUpper();
                    objReligion.ModifiedDate = DateTime.Now;
                    objReligion.ReligionID = MP.ReligionID;
                    db.SaveChanges();
                    msg = "Religion Updated Successfully!";
                }

                return new Result() { IsSucess = true, ResultData = msg };


            }
            catch (Exception ex)
            {
                return new Error() { IsError = true, Message = ex.Message };
            }
        }

        public object SaveCategory(CategoryParam MP)
        {
            try
            {
                string msg = "";
                if (MP.BtnStatus == "Save")
                {
                    var usercode = db.Tbl_Category_Master.Where(r => r.CategoryName == MP.CategoryName.ToUpper()).FirstOrDefault();
                    if (usercode != null)
                    {
                        return new Error() { IsError = true, Message = "Category Name Already Exists!" };
                    }
                    Tbl_Category_Master objCategory = new Tbl_Category_Master();

                    objCategory.CategoryName = MP.CategoryName.ToUpper();
                    objCategory.CreatedBy = MP.CreatedBy;
                    objCategory.CreatedDate = DateTime.Now;
                    objCategory.Status = 1;
                    db.Tbl_Category_Master.Add(objCategory);
                    db.SaveChanges();
                    msg = "Category Saved Successfully!";

                }
                else
                {
                    Tbl_Category_Master objCategory = db.Tbl_Category_Master.Where(r => r.CategoryID == MP.CategoryID).FirstOrDefault();
                    var data = db.Tbl_Category_Master.Where(r => r.CategoryName == MP.CategoryName).FirstOrDefault();
                    if(data!=null)
                    {
                        return new Error() { IsError = true, Message = "Category Name Already Exists!" };
                    }
                    objCategory.CategoryName = MP.CategoryName.ToUpper();
                    objCategory.ModifiedDate = DateTime.Now;
                    objCategory.CategoryID = MP.CategoryID;
                    db.SaveChanges();
                    msg = "Category Updated Successfully!";
                }

                return new Result() { IsSucess = true, ResultData = msg };


            }
            catch (Exception ex)
            {
                return new Error() { IsError = true, Message = ex.Message };
            }
        }

        public object SaveMinority(MinorityParam MP)
        {
            try
            {
                string msg = "";
                if (MP.BtnStatus == "Save")
                {
                    var usercode = db.Tbl_Minority_Master.Where(r => r.MinorityName == MP.MinorityName.ToUpper()).FirstOrDefault();
                    if (usercode != null)
                    {
                        return new Error() { IsError = true, Message = "Minority Name Already Exists!" };
                    }
                    Tbl_Minority_Master objMinority = new Tbl_Minority_Master();

                    objMinority.MinorityName = MP.MinorityName.ToUpper();
                    objMinority.CreatedBy = MP.CreatedBy;
                    objMinority.CreatedDate = DateTime.Now;
                    objMinority.Status = 1;
                    db.Tbl_Minority_Master.Add(objMinority);
                    db.SaveChanges();
                    msg = "Minority Saved Successfully!";

                }
                else
                {
                    Tbl_Minority_Master objMinority = db.Tbl_Minority_Master.Where(r => r.MinorityID == MP.MinorityID).FirstOrDefault();
                    var Data = db.Tbl_Minority_Master.Where(r => r.MinorityName == MP.MinorityName.ToUpper()).FirstOrDefault();
                    if (Data != null)
                    {
                        return new Error() { IsError = true, Message = "Minority Name Already Exists!" };
                    }
                    objMinority.MinorityName = MP.MinorityName.ToUpper();
                    objMinority.ModifiedDate = DateTime.Now;
                    objMinority.MinorityID = MP.MinorityID;
                    db.SaveChanges();
                    msg = "Minority Updated Successfully!";
                }

                return new Result() { IsSucess = true, ResultData = msg };


            }
            catch (Exception ex)
            {
                return new Error() { IsError = true, Message = ex.Message };
            }
        }


        public object SaveCaste(CasteParam MP)
        {
            try
            {
                string msg = "";
                if (MP.BtnStatus == "Save")
                {
                    var usercode = db.Tbl_Caste_Master.Where(r => r.CasteName == MP.CasteName.ToUpper()).FirstOrDefault();
                    if (usercode != null)
                    {
                        return new Error() { IsError = true, Message = "Caste Name Already Exists!" };
                    }
                    Tbl_Caste_Master objCaste = new Tbl_Caste_Master();

                    objCaste.CasteName = MP.CasteName.ToUpper();
                    objCaste.ReligionID = MP.ReligionID;
                    objCaste.CategoryID = MP.CategoryID;
                    objCaste.CreatedBy = MP.CreatedBy;
                    objCaste.CreatedDate = DateTime.Now;
                    objCaste.Status = 1;
                    db.Tbl_Caste_Master.Add(objCaste);
                    db.SaveChanges();
                    msg = "Caste Saved Successfully!";

                }
                else
                {
                    Tbl_Caste_Master objCaste = db.Tbl_Caste_Master.Where(r => r.CasteID == MP.CasteID).FirstOrDefault();

                    objCaste.CasteName = MP.CasteName.ToUpper();
                    objCaste.ReligionID = MP.ReligionID;
                    objCaste.CategoryID = MP.CategoryID;
                    objCaste.ModifiedDate = DateTime.Now;
                    objCaste.CasteID = MP.CasteID;
                    db.SaveChanges();
                    msg = "Caste Updated Successfully!";
                }

                return new Result() { IsSucess = true, ResultData = msg };


            }
            catch (Exception ex)
            {
                return new Error() { IsError = true, Message = ex.Message };
            }
        }


        public object SaveSubCaste(SubCasteParam MP)
        {
            try
            {
                string msg = "";
                if (MP.BtnStatus == "Save")
                {
                    var usercode = db.Tbl_Sub_Caste_Master.Where(r => r.SubCasteName == MP.SubCasteName.ToUpper()).FirstOrDefault();
                    if (usercode != null)
                    {
                        return new Error() { IsError = true, Message = "Sub Caste Name Already Exists!" };
                    }
                    Tbl_Sub_Caste_Master objSubCaste = new Tbl_Sub_Caste_Master();

                    objSubCaste.SubCasteName = MP.SubCasteName.ToUpper();
                    objSubCaste.CasteID = MP.CasteID;
                    objSubCaste.CreatedBy = MP.CreatedBy;
                    objSubCaste.CreatedDate = DateTime.Now;
                    objSubCaste.Status = 1;
                    db.Tbl_Sub_Caste_Master.Add(objSubCaste);
                    db.SaveChanges();
                    msg = "Sub Caste Saved Successfully!";

                }
                else
                {
                    Tbl_Sub_Caste_Master objSubCaste = db.Tbl_Sub_Caste_Master.Where(r => r.SubCasteID == MP.SubCasteID).FirstOrDefault();
                    var Data = db.Tbl_Sub_Caste_Master.Where(r => r.SubCasteName == MP.SubCasteName.ToUpper()).FirstOrDefault();
                    if (Data != null)
                    {
                        return new Error() { IsError = true, Message = "Sub Caste Name Already Exists!" };
                    }
                    objSubCaste.SubCasteName = MP.SubCasteName.ToUpper();
                    objSubCaste.CasteID = MP.CasteID;
                    objSubCaste.SubCasteID = MP.SubCasteID;
                    objSubCaste.ModifiedDate = DateTime.Now;
                    db.SaveChanges();
                    msg = "Sub Caste Updated Successfully!";
                }

                return new Result() { IsSucess = true, ResultData = msg };


            }
            catch (Exception ex)
            {
                return new Error() { IsError = true, Message = ex.Message };
            }
        }


        public object GetReligionList(int status)
        {
            try
            {
                List<SchoolAPI.Models.ViewReligionList> GetReligion = null;

                if (status == 0)
                {
                    GetReligion = db.ViewReligionLists.Where(r => r.Status != 1).ToList();
                }
                else

                {
                    GetReligion = db.ViewReligionLists.Where(r => r.Status == 1).ToList();

                }

                if (GetReligion == null)
                {
                    return new Error { IsError = true, Message = "Religion Not Found." };
                }
                else
                {
                    return new Result { IsSucess = true, ResultData = GetReligion };
                }
            }
            catch (Exception E)
            {
                return new Error() { IsError = true, Message = E.Message };
            }
        }


        public object GetCategoryList(int status)
        {
            try
            {
                List<SchoolAPI.Models.ViewCategoryList> GetCategory = null;

                if (status == 0)
                {
                    GetCategory = db.ViewCategoryLists.Where(r => r.Status != 1).ToList();
                }
                else

                {
                    GetCategory = db.ViewCategoryLists.Where(r => r.Status == 1).ToList();

                }

                if (GetCategory == null)
                {
                    return new Error { IsError = true, Message = "Category Not Found." };
                }
                else
                {
                    return new Result { IsSucess = true, ResultData = GetCategory };
                }
            }
            catch (Exception E)
            {
                return new Error() { IsError = true, Message = E.Message };
            }
        }

        public object GetMinorityList(int status)
        {
            try
            {
                List<SchoolAPI.Models.ViewMinorityList> GetMinority = null;

                if (status == 0)
                {
                    GetMinority = db.ViewMinorityLists.Where(r => r.Status != 1).ToList();
                }
                else

                {
                    GetMinority = db.ViewMinorityLists.Where(r => r.Status == 1).ToList();

                }

                if (GetMinority == null)
                {
                    return new Error { IsError = true, Message = "Minority Not Found." };
                }
                else
                {
                    return new Result { IsSucess = true, ResultData = GetMinority };
                }
            }
            catch (Exception E)
            {
                return new Error() { IsError = true, Message = E.Message };
            }
        }


        public object GetCasteList(int status)
        {
            try
            {
                List<SchoolAPI.Models.ViewCasteList> GetCaste = null;

                if (status == 0)
                {
                    GetCaste = db.ViewCasteLists.Where(r => r.Status != 1).ToList();
                }
                else

                {
                    GetCaste = db.ViewCasteLists.Where(r => r.Status == 1).ToList();

                }

                if (GetCaste == null)
                {
                    return new Error { IsError = true, Message = "Caste Not Found." };
                }
                else
                {
                    return new Result { IsSucess = true, ResultData = GetCaste };
                }
            }
            catch (Exception E)
            {
                return new Error() { IsError = true, Message = E.Message };
            }
        }


        public object GetSubCasteList(int status)
        {
            try
            {
                List<SchoolAPI.Models.ViewSubCasteList> GetSubCaste = null;

                if (status == 0)
                {
                    GetSubCaste = db.ViewSubCasteLists.Where(r => r.Status != 1).ToList();
                }
                else

                {
                    GetSubCaste = db.ViewSubCasteLists.Where(r => r.Status == 1).ToList();

                }

                if (GetSubCaste == null)
                {
                    return new Error { IsError = true, Message = "Sub Caste Not Found." };
                }
                else
                {
                    return new Result { IsSucess = true, ResultData = GetSubCaste };
                }
            }
            catch (Exception E)
            {
                return new Error() { IsError = true, Message = E.Message };
            }
        }

        public object GetSingleReligion(ReligionParam objgr)
        {
            try
            {
                var SingleReligionlist = db.ViewReligionLists.Where(r => r.ReligionID == objgr.ReligionID).FirstOrDefault();
                return SingleReligionlist;
            }
            catch (Exception E)
            {
                return new Error() { IsError = true, Message = E.Message };
            }
        }

        public object GetSingleCategory(CategoryParam objgr)
        {
            try
            {
                var SingleCategorylist = db.ViewCategoryLists.Where(r => r.CategoryID == objgr.CategoryID).FirstOrDefault();
                return SingleCategorylist;
            }
            catch (Exception E)
            {
                return new Error() { IsError = true, Message = E.Message };
            }
        }

        public object GetSingleMinority(MinorityParam objgr)
        {
            try
            {
                var SingleMinoritylist = db.ViewMinorityLists.Where(r => r.MinorityID == objgr.MinorityID).FirstOrDefault();
                return SingleMinoritylist;
            }
            catch (Exception E)
            {
                return new Error() { IsError = true, Message = E.Message };
            }
        }

        public object GetSingleCaste(CasteParam objgr)
        {
            try
            {
                var SingleCastelist = db.ViewCasteLists.Where(r => r.CasteID == objgr.CasteID).FirstOrDefault();
                return SingleCastelist;
            }
            catch (Exception E)
            {
                return new Error() { IsError = true, Message = E.Message };
            }
        }

        public object GetSingleSubCaste(SubCasteParam objgr)
        {
            try
            {
                var SingleSubCastelist = db.ViewSubCasteLists.Where(r => r.SubCasteID == objgr.SubCasteID).FirstOrDefault();
                return SingleSubCastelist;
            }
            catch (Exception E)
            {
                return new Error() { IsError = true, Message = E.Message };
            }
        }

        public object DeleteReligion(ReligionParam MP)
        {
            try
            {
                Tbl_Religion_Master objreligion = db.TblReligionMasters.Where(r => r.ReligionID == MP.ReligionID).FirstOrDefault();

                if (objreligion.Status == 1)
                {
                    objreligion.Status = 0;
                }
                else
                {
                    objreligion.Status = 1;
                }

                db.SaveChanges();

                return new Result() { IsSucess = true, ResultData = "Religion Updated Successfully!" };
            }
            catch (Exception ex)
            {
                return new Error() { IsError = true, Message = ex.Message };
            }
        }

        public object DeleteCategory(CategoryParam MP)
        {
            try
            {
                Tbl_Category_Master objcategory = db.Tbl_Category_Master.Where(r => r.CategoryID == MP.CategoryID).FirstOrDefault();

                if (objcategory.Status == 1)
                {
                    objcategory.Status = 0;
                }
                else
                {
                    objcategory.Status = 1;
                }

                db.SaveChanges();

                return new Result() { IsSucess = true, ResultData = "Category Updated Successfully!" };
            }
            catch (Exception ex)
            {
                return new Error() { IsError = true, Message = ex.Message };
            }
        }

        public object DeleteMinority(MinorityParam MP)
        {
            try
            {
                Tbl_Minority_Master objminority = db.Tbl_Minority_Master.Where(r => r.MinorityID == MP.MinorityID).FirstOrDefault();

                if (objminority.Status == 1)
                {
                    objminority.Status = 0;
                }
                else
                {
                    objminority.Status = 1;
                }

                db.SaveChanges();

                return new Result() { IsSucess = true, ResultData = "Minority Updated Successfully!" };
            }
            catch (Exception ex)
            {
                return new Error() { IsError = true, Message = ex.Message };
            }
        }

        public object DeleteCaste(CasteParam MP)
        {
            try
            {
                Tbl_Caste_Master objCaste = db.Tbl_Caste_Master.Where(r => r.CasteID == MP.CasteID).FirstOrDefault();

                if (objCaste.Status == 1)
                {
                    objCaste.Status = 0;
                }
                else
                {
                    objCaste.Status = 1;
                }

                db.SaveChanges();

                return new Result() { IsSucess = true, ResultData = "Caste Updated Successfully!" };
            }
            catch (Exception ex)
            {
                return new Error() { IsError = true, Message = ex.Message };
            }
        }

        public object DeleteSubCaste(SubCasteParam MP)
        {
            try
            {
                Tbl_Sub_Caste_Master objSubCaste = db.Tbl_Sub_Caste_Master.Where(r => r.SubCasteID == MP.SubCasteID).FirstOrDefault();

                if (objSubCaste.Status == 1)
                {
                    objSubCaste.Status = 0;
                }
                else
                {
                    objSubCaste.Status = 1;
                }

                db.SaveChanges();

                return new Result() { IsSucess = true, ResultData = "Sub Caste Updated Successfully!" };
            }
            catch (Exception ex)
            {
                return new Error() { IsError = true, Message = ex.Message };
            }
        }
    }
}