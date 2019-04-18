using SchoolAPI.Param;
using SchoolAPI.ResultModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolAPI.Models;


namespace SchoolAPI.BusinessLayer
{
    public class StateBusiness
    {
        SchoolAdminContext db = new SchoolAdminContext();
        public object SaveState(StateParam b)
        {
            if (b.State == null)
            {
                return new Error() { IsError = true, Message = "Required State" };
            }
            var data = db.Tbl_State.FirstOrDefault(r => r.State == b.State);
            if (data != null)
            {
                return new Error() { IsError = true, Message = "Duplicate Entry Not Allowed" };
            }
            try
            {
                Tbl_State obj = new Tbl_State();
                obj.State = b.State;
                obj.Status = 1;
                obj.CreatedBy = 1;
                obj.CreatedDate = System.DateTime.Today.Date;
                obj.ModifiedBy = null;
                obj.ModifiedDate = System.DateTime.Today.Date;
                db.Tbl_State.Add(obj);
                db.SaveChanges();
                return new Result() { IsSucess = true, ResultData = "Created State" };
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }

        }
        public object GetState(UserCredential obj)
        {
            try
            {
                List<ViewStateList> state = null;

                if (obj.Status == "0")
                {
                    state = db.ViewStateLists.Where(r => r.Status == 0).ToList();
                }
                else
                {

                    state = db.ViewStateLists.Where(r => r.Status == 1).ToList();

                }
                if (obj.Status == null)
                {
                    state = db.ViewStateLists.Where(r => r.Status == 1).ToList();

                }

                if (state == null)
                {
                    return new Error() { IsError = true, Message = "No Records Found !!" };
                }
                return state;

            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }


        }
        public object GetSingleState(UpdateState b)
        {
            try
            {
       
                var state = db.ViewStateLists.Where(r => r.StateID == b.StateId).FirstOrDefault();
                return new Result() { IsSucess = true, ResultData = state };
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }


        }
        public object StateUpdate(UpdateState b)
        {
            if (b.State == null)
            {
                return new Error() { IsError = true, Message = "Required State" };
            }
            var Info = db.Tbl_State.Where(r => r.State == b.State && r.Status == 1).FirstOrDefault();
            if (Info != null)
            {
                return new Error() { IsError = true, Message = "Duplicate Entry Not Allowed" };
            }
            var data = db.Tbl_State.Where(r => r.StateID == b.StateId).FirstOrDefault();
            try
            {
                TblBoard obj = new TblBoard();
                data.State = b.State;
                data.ModifiedBy = null;
                data.ModifiedDate = System.DateTime.Today.Date;
                db.SaveChanges();
                return new Result() { IsSucess = true, ResultData = "Update State" };
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }

        }
        public object DeleteState(UpdateState PM)
        {
            try
            {
                Tbl_State obj = db.Tbl_State.Where(r => r.StateID == PM.StateId).FirstOrDefault();


                if (obj.Status == 1)
                {
                    obj.Status = 0;
                }
                else
                {
                    obj.Status = 1;
                }

                db.SaveChanges();

                return new Result() { IsSucess = true, ResultData = "State Deactivated Successfully." };
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }

        }
        //District
        public object SaveDistrict(DistrictParam b)
        {
            if (b.District == null)
            {
                return new Error() { IsError = true, Message = "Required District" };
            }
            var data = db.Tbl_District.FirstOrDefault(r => r.District == b.District);
            if (data != null)
            {
                return new Error() { IsError = true, Message = "Duplicate Entry Not Allowed" };
            }
            try
            {
                Tbl_District obj = new Tbl_District();
                obj.District = b.District;
                obj.StateID = b.StateID;
                obj.Status = 1;
                obj.CreatedBy = 1;
                obj.CreatedDate = System.DateTime.Today.Date;
                obj.ModifiedBy = null;
                obj.ModifiedDate = System.DateTime.Today.Date;
                db.Tbl_District.Add(obj);
                db.SaveChanges();
                return new Result() { IsSucess = true, ResultData = "Created District" };
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }

        }
        public object GetDistrict(UserCredential obj)
        {
            try
            {
                var district = db.ViewDistrictLists.ToList();

                if (obj.Status == "0")
                {
                    district = db.ViewDistrictLists.Where(r => r.Status == 0).ToList();
                }
                else
                {

                    district = db.ViewDistrictLists.Where(r => r.Status == 1).ToList();

                }
                if (obj.Status == null)
                {
                    district = db.ViewDistrictLists.Where(r => r.Status == 1).ToList();

                }

                if (district == null)
                {
                    return new Error() { IsError = true, Message = "No Records Found !!" };
                }
                return district;

            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }


        }
        public object GetSingleDistrict(DistrictParam b)
        {
            try
            {

                var district = db.ViewDistrictLists.Where(r => r.DistrictID == b.DistrictID).FirstOrDefault();
                return new Result() { IsSucess = true, ResultData = district };
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }


        }
        public object DistrictUpdate(DistrictParam b)
        {
            if (b.District == null)
            {
                return new Error() { IsError = true, Message = "Required District" };
            }
            var data = db.Tbl_District.Where(r => r.DistrictID == b.DistrictID).FirstOrDefault();
            try
            {
                TblBoard obj = new TblBoard();
                data.District = b.District;
                data.StateID = b.StateID;
                data.ModifiedBy = null;
                data.ModifiedDate = System.DateTime.Today.Date;
                db.SaveChanges();
                return new Result() { IsSucess = true, ResultData = "Update District" };
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }

        }
        public object DeleteDistrict(DistrictParam PM)
        {
            try
            {
                Tbl_District obj = db.Tbl_District.Where(r => r.DistrictID == PM.DistrictID).FirstOrDefault();


                if (obj.Status == 1)
                {
                    obj.Status = 0;
                }
                else
                {
                    obj.Status = 1;
                }

                db.SaveChanges();

                return new Result() { IsSucess = true, ResultData = "District Deactivated Successfully." };
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }

        }
        //Taluka
        public object SaveTaluka(TalukaParam b)
        {
            if (b.Taluka == null)
            {
                return new Error() { IsError = true, Message = "Required Taluka" };
            }
            var data = db.Tbl_Taluka.FirstOrDefault(r => r.Taluka == b.Taluka);
            if (data != null)
            {
                return new Error() { IsError = true, Message = "Duplicate Entry Not Allowed" };
            }
            try
            {
                Tbl_Taluka obj = new Tbl_Taluka();
                obj.Taluka = b.Taluka;
                obj.DistrictID = b.DistrictID;
                obj.Status = 1;
                obj.CreatedBy = 1;
                obj.CreatedDate = System.DateTime.Today.Date;
                obj.ModifiedBy = null;
                obj.ModifiedDate = System.DateTime.Today.Date;
                db.Tbl_Taluka.Add(obj);
                db.SaveChanges();
                return new Result() { IsSucess = true, ResultData = "Created Taluka" };
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }

        }
        public object GetTaluka(UserCredential obj)
        {
            try
            {
                var Taluka = db.ViewTalukaLists.ToList();

                if (obj.Status == "0")
                {
                    Taluka = db.ViewTalukaLists.Where(r => r.Status == 0).ToList();
                }
                else
                {

                    Taluka = db.ViewTalukaLists.Where(r => r.Status == 1).ToList();

                }
                if (obj.Status == null)
                {
                    Taluka = db.ViewTalukaLists.Where(r => r.Status == 1).ToList();

                }

                if (Taluka == null)
                {
                    return new Error() { IsError = true, Message = "No Records Found !!" };
                }
                return Taluka;

            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }


        }
        public object GetSingleTaluka(TalukaParam b)
        {
            try
            {

                var taluka = db.ViewTalukaLists.Where(r => r.TalukaID == b.TalukaID && r.Status==1).FirstOrDefault();
                return new Result() { IsSucess = true, ResultData = taluka  };
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }


        }
        public object TalukaUpdate(TalukaParam b)
        {
            if (b.Taluka == null)
            {
                return new Error() { IsError = true, Message = "Required Taluka" };
            }
            var data = db.Tbl_Taluka.Where(r => r.TalukaID == b.TalukaID).FirstOrDefault();
            try
            {
                Tbl_Taluka obj = new Tbl_Taluka();
                data.Taluka = b.Taluka;
                data.DistrictID = b.DistrictID;
                data.ModifiedBy = null;
                data.ModifiedDate = System.DateTime.Today.Date;
                db.SaveChanges();
                return new Result() { IsSucess = true, ResultData = "Update Taluka" };
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }

        }
        public object DeleteTaluka(TalukaParam PM)
        {
            try
            {
                Tbl_Taluka obj = db.Tbl_Taluka.Where(r => r.TalukaID == PM.TalukaID).FirstOrDefault();


                if (obj.Status == 1)
                {
                    obj.Status = 0;
                }
                else
                {
                    obj.Status = 1;
                }

                db.SaveChanges();

                return new Result() { IsSucess = true, ResultData = "Taluka Deactivated Successfully." };
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }

        }
        public object GetStateInfo()
        {
            try
            {
                var data = db.ViewStateLists.Where(r=>r.Status==1).ToList();
                if (data == null)
                {
                    return new Error() { IsError = true, Message = "No Records Found !!" };
                }
                return data;

            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }


        }
        public object GetStateunderDistrict(TalukaParam p)
        {
            try
            {
                List<ViewDistrictList> Info=null;
                var data = db.ViewDistrictLists.Where(r => r.Status == 1 && r.StateID==p.StateId).ToList();
                if (data == null)
                {
                    Info = db.ViewDistrictLists.Where(r => r.Status == 1).ToList();
                    return Info;
                }

                return data;

            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }


        }

    }
}