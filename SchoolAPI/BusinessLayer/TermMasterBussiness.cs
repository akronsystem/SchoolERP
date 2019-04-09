using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolAPI.Models;
using SchoolAPI.Param;
using SchoolAPI.ResultModel;

namespace SchoolAPI.BusinessLayer
{
    public class TermMasterBussiness
    {
        SchoolAdminContext db = new SchoolAdminContext();
        public object SaveTerm(TermMasterParam b)
        {
            if (b.TermName == null)
            {
                return new Error() { IsError = true, Message = "Required Term" };
            }
            var data = db.Tbl_Term_Master.FirstOrDefault(r => r.TermName == b.TermName);
            if (data != null)
            {
                return new Error() { IsError = true, Message = "Duplicate Entry Not Allowed" };
            }
            try
            {
                Tbl_Term_Master obj = new Tbl_Term_Master();
                obj.TermName = b.TermName;              
                obj.Status = 1;
                obj.CreatedBy = 1;
                obj.CreatedDate = System.DateTime.Today.Date;
                obj.ModifiedBy = null;
                obj.ModifiedDate = System.DateTime.Today.Date;
                db.Tbl_Term_Master.Add(obj);
                db.SaveChanges();
                return new Result() { IsSucess = true, ResultData = "Created Term" };
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }

        }
        public object GetTermList(UserCredential obj)
        {
            try
            {
                List<ViewTermList> term = null;

                if (obj.Status == "0")
                {
                    term = db.ViewTermLists.Where(r => r.Status == 0).ToList();
                }
                else
                {

                    term = db.ViewTermLists.Where(r => r.Status == 1).ToList();

                }
                if (obj.Status == null)
                {
                    term = db.ViewTermLists.Where(r => r.Status == 1).ToList();

                }

                if (term == null)
                {
                    return new Error() { IsError = true, Message = "No Records Found !!" };
                }
                return term;

            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }


        }
        public object GetSingleTerm(TermUpdateParam b)
        {
            try
            {

                var data = db.ViewTermLists.Where(r => r.TermID == b.TermID).FirstOrDefault();
                return new Result() { IsSucess = true, ResultData = data };
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }


        }
        public object TermUpdate(TermUpdateParam b)
        {
            if (b.TermName == null)
            {
                return new Error() { IsError = true, Message = "Required Term" };
            }
            var data = db.Tbl_Term_Master.Where(r => r.TermID == b.TermID).FirstOrDefault();
            try
            {
                Tbl_Term_Master obj = new Tbl_Term_Master();
                data.TermName = b.TermName;
                data.ModifiedBy = null;
                data.ModifiedDate = System.DateTime.Today.Date;
                db.SaveChanges();
                return new Result() { IsSucess = true, ResultData = "Update Term" };
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }

        }
        public object DeleteTerm(TermUpdateParam PM)
        {
            try
            {
                Tbl_Term_Master obj = db.Tbl_Term_Master.Where(r => r.TermID == PM.TermID).FirstOrDefault();


                if (obj.Status == 1)
                {
                    obj.Status = 0;
                }
                else
                {
                    obj.Status = 1;
                }

                db.SaveChanges();

                return new Result() { IsSucess = true, ResultData = "Term Deactivated Successfully." };
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }

        }
        //Unit/Terminal
        public object SaveUnit(UnitMasterParam b)
        {
            if (b.TermID == 0)
            {
                return new Error() { IsError = true, Message = " Required Term Name" };
            }
            var data = db.Tbl_Unit_Master.FirstOrDefault(r => r.UnitName == b.UnitName);
            if (data != null)
            {
                return new Error() { IsError = true, Message = "Duplicate Entry Not Allowed" };
            }
            try
            {
                Tbl_Unit_Master obj = new Tbl_Unit_Master();
                obj.UnitName = b.UnitName;
                obj.TermID = b.TermID;
                obj.Status = 1;
                obj.CreatedBy = 1;
                obj.CreatedDate = System.DateTime.Today.Date;
                obj.ModifiedBy = null;
                obj.ModifiedDate = System.DateTime.Today.Date;
                db.Tbl_Unit_Master.Add(obj);
                db.SaveChanges();
                return new Result() { IsSucess = true, ResultData = "Created Unit" };
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }

        }
        public object GetUnitList(UserCredential obj)
        {
            try
            {
                List<ViewUnitList> unit = null;

                if (obj.Status == "0")
                {
                    unit = db.ViewUnitLists.Where(r => r.Status == 0).ToList();
                }
                else
                {

                    unit = db.ViewUnitLists.Where(r => r.Status == 1).ToList();

                }
                if (obj.Status == null)
                {
                    unit = db.ViewUnitLists.Where(r => r.Status == 1).ToList();

                }

                if (unit == null)
                {
                    return new Error() { IsError = true, Message = "No Records Found !!" };
                }
                return unit;

            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }


        }
        public object GetSingleUnit(UpdateUnitParam b)
        {
            try
            {

                var data = db.ViewUnitLists.Where(r => r.UnitID == b.UnitID).FirstOrDefault();
                return new Result() { IsSucess = true, ResultData = data };
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }


        }
        public object UnitUpdate(UpdateUnitParam b)
        {
            if (b.UnitName == null)
            {
                return new Error() { IsError = true, Message = "Required Unit Name" };
            }
            var data = db.Tbl_Unit_Master.Where(r => r.UnitID == b.UnitID).FirstOrDefault();
            try
            {
                Tbl_Unit_Master obj = new Tbl_Unit_Master();
                data.UnitName = b.UnitName;
                data.TermID = b.TermID;
                data.ModifiedBy = null;
                data.ModifiedDate = System.DateTime.Today.Date;
                db.SaveChanges();
                return new Result() { IsSucess = true, ResultData = "Update Unit" };
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }

        }
        public object DeleteUnit(UpdateUnitParam PM)
        {
            try
            {
                Tbl_Unit_Master obj = db.Tbl_Unit_Master.Where(r => r.UnitID == PM.UnitID).FirstOrDefault();


                if (obj.Status == 1)
                {
                    obj.Status = 0;
                }
                else
                {
                    obj.Status = 1;
                }

                db.SaveChanges();

                return new Result() { IsSucess = true, ResultData = "Unit Deactivated Successfully." };
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }

        }

        //TermCommencement
        public object SaveTermCommencement(TermCommencementParam b)
        {
            if (b.TermID == 0)
            {
                return new Error() { IsError = true, Message = "Required Terminal" };
            }
            var data = db.Tbl_TermCommencementDate.FirstOrDefault(r => r.TermID == b.TermID);
            if (data != null)
            {
                return new Error() { IsError = true, Message = "Duplicate Entry Not Allowed" };
            }
            try
            {
                Tbl_TermCommencementDate obj = new Tbl_TermCommencementDate();
                 obj.TermID = b.TermID;
                obj.StartDate = b.StartDate;
                obj.EndDate = b.EndDate;
                obj.Status = 1;
                obj.CreatedBy = 1;
                obj.CreatedDate = System.DateTime.Today.Date;
                obj.ModifiedBy = null;
                obj.ModifiedDate = System.DateTime.Today.Date;
                db.Tbl_TermCommencementDate.Add(obj);
                db.SaveChanges();
                return new Result() { IsSucess = true, ResultData = "Created Term" };
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }

        }
        public object GetTermCommencementList(UserCredential obj)
        {
            try
            {
                List<ViewTermCommencementList> List = null;

                if (obj.Status == "0")
                {
                    List = db.ViewTermCommencementLists.Where(r => r.Status == 0).ToList();
                }
                else
                {

                    List = db.ViewTermCommencementLists.Where(r => r.Status == 1).ToList();

                }
                if (obj.Status == null)
                {
                    List = db.ViewTermCommencementLists.Where(r => r.Status == 1).ToList();

                }

                if (List == null)
                {
                    return new Error() { IsError = true, Message = "No Records Found !!" };
                }
                return List;

            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }


        }
        public object GetSingleTermCommencement(TermCommencementUpdateParam b)
        {
            try
            {
                var data = db.ViewTermCommencementLists.Where(r => r.TermCommID == b.TermCommID).FirstOrDefault();
                return new Result() { IsSucess = true, ResultData = data };
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }


        }
        public object TermCommencementUpdate(TermCommencementUpdateParam b)
        {
            if (b.TermID == 0)
            {
                return new Error() { IsError = true, Message = "Required Terminal" };
            }
            var data = db.Tbl_TermCommencementDate.Where(r => r.TermCommID == b.TermCommID).FirstOrDefault();
            try
            {
                Tbl_TermCommencementDate obj = new Tbl_TermCommencementDate();
                data.TermID = b.TermID;
                data.StartDate = b.StartDate;
                data.EndDate = b.EndDate;
                data.ModifiedBy = null;
                data.ModifiedDate = System.DateTime.Today.Date;
                db.SaveChanges();
                return new Result() { IsSucess = true, ResultData = "Update Term" };
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }

        }
        public object DeleteTermCommencement(TermCommencementUpdateParam PM)
        {
            try
            {
                Tbl_TermCommencementDate obj = db.Tbl_TermCommencementDate.Where(r => r.TermCommID == PM.TermCommID).FirstOrDefault();


                if (obj.Status == 1)
                {
                    obj.Status = 0;
                }
                else
                {
                    obj.Status = 1;
                }

                db.SaveChanges();

                return new Result() { IsSucess = true, ResultData = "Unit Deactivated Successfully." };
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }

        }
    }
}