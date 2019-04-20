using SchoolAPI.Models;
using SchoolAPI.Param;
using SchoolAPI.ResultModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolAPI.BusinessLayer
{
    public class CommitteeBusiness
    {
        SchoolAdminContext db = new SchoolAdminContext();
        public object SaveCommitteeType(CommitteeTypeParam b)
        {
            if (b.CommitteeType == null)
            {
                return new Error() { IsError = true, Message = "Required CommitteeType" };
            }
            var data = db.Tbl_CommitteeType_Master.Where(r => r.CommitteeType == b.CommitteeType).FirstOrDefault();
            if (data != null)
            {
                return new Error() { IsError = true, Message = "Duplicate Entry Not Allowed" };
            }
            try
            {
                Tbl_CommitteeType_Master obj = new Tbl_CommitteeType_Master();
                obj.CommitteeType = b.CommitteeType;
                obj.Status = 1;
                obj.CreatedBy = 1;
                obj.CreatedDate = System.DateTime.Today.Date;
                obj.ModifiedBy = null;
                obj.ModifiedDate = System.DateTime.Today.Date;
                db.Tbl_CommitteeType_Master.Add(obj);
                db.SaveChanges();
                return new Result() { IsSucess = true, ResultData = "Created CommitteeType" };
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }

        }
        public object CommitteTypeUpdate(CommitteeTypeUpdateParam b)
        {
            if (b.CommitteeType == null)
            {
                return new Error() { IsError = true, Message = "Required CommitteeType" };
            }
            var data = db.Tbl_CommitteeType_Master.Where(r => r.CommitteeTypeId == b.CommitteeTypeId).FirstOrDefault();
            try
            {
                Tbl_CommitteeType_Master obj = new Tbl_CommitteeType_Master();
                data.CommitteeType = b.CommitteeType;
                data.ModifiedBy = null;
                data.ModifiedDate = System.DateTime.Today.Date;
                db.SaveChanges();
                return new Result() { IsSucess = true, ResultData = "Update CommiteeType" };
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }

        }
        public object GetCommiteeType(UserCredential obj)
        {
            try
            {
                List<ViewCommitteeList> CommitteType = null;

                if (obj.Status == "0")
                {
                    CommitteType = db.ViewCommitteeLists.Where(r => r.Status == 0).ToList();
                }
                else
                {

                    CommitteType = db.ViewCommitteeLists.Where(r => r.Status == 1).ToList();

                }
                if (obj.Status == null)
                {
                    CommitteType = db.ViewCommitteeLists.Where(r => r.Status == 1).ToList();

                }

                if (CommitteType == null)
                {
                    return new Error() { IsError = true, Message = "No Records Found !!" };
                }
                return CommitteType;

            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }


        }
        public object GetSingleCommitteType(CommitteeTypeUpdateParam b)
        {
            try
            {
                var CommitteType = db.ViewCommitteeLists.Where(r => r.CommitteeTypeId == b.CommitteeTypeId).FirstOrDefault();
                return new Result() { IsSucess = true, ResultData = CommitteType };
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }


        }
        public object DeleteCommitteType(CommitteeTypeUpdateParam PM)
        {
            try
            {
                Tbl_CommitteeType_Master obj = db.Tbl_CommitteeType_Master.Where(r => r.CommitteeTypeId == PM.CommitteeTypeId).FirstOrDefault();


                if (obj.Status == 1)
                {
                    obj.Status = 0;
                }
                else
                {
                    obj.Status = 1;
                }

                db.SaveChanges();

                return new Result() { IsSucess = true, ResultData = "CommitteType Deactivated Successfully." };
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }

        }

        //CommitteeMaster
        public object SaveCommittee(CommitteeMasterParam b)
        {
            if (b.CommitteeTypeID == 0)
            {
                return new Error() { IsError = true, Message = "Required CommitteeType" };
            }
            var data = db.Tbl_CommitteeMaster.Where(r => r.CommitteeTypeID == b.CommitteeTypeID).FirstOrDefault();
            if (data != null)
            {
                return new Error() { IsError = true, Message = "Duplicate Entry Not Allowed" };
            }
            try
            {
                Tbl_CommitteeMaster obj = new Tbl_CommitteeMaster();
                obj.CommitteeTypeID = b.CommitteeTypeID;
                obj.Status = 1;
                obj.CreatedBy = 1;
                obj.CreatedDate = System.DateTime.Today.Date;
                obj.ModifiedBy = null;
                obj.ModifiedDate = System.DateTime.Today.Date;
                db.Tbl_CommitteeMaster.Add(obj);
                db.SaveChanges();
                return new Result() { IsSucess = true, ResultData = "Created Committee" };
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }

        }
        public object CommitteUpdate(CommitteeMasterUpdateParam b)
        {
            if (b.CommitteeTypeID == 0)
            {
                return new Error() { IsError = true, Message = "Required CommitteeType" };
            }
            var data = db.Tbl_CommitteeMaster.Where(r => r.CommitteeID == b.CommitteeID).FirstOrDefault();
            try
            {
                Tbl_CommitteeMaster obj = new Tbl_CommitteeMaster();
                data.CommitteeTypeID = b.CommitteeTypeID;
                data.ModifiedBy = null;
                data.ModifiedDate = System.DateTime.Today.Date;
                db.SaveChanges();
                return new Result() { IsSucess = true, ResultData = "Update Commitee" };
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }

        }
        public object GetCommitee(UserCredential obj)
        {
            try
            {
                List<ViewCommitteMasterList> Committee = null;

                if (obj.Status == "0")
                {
                    Committee = db.ViewCommitteMasterLists.Where(r => r.Status == 0).ToList();
                }
                else
                {

                    Committee = db.ViewCommitteMasterLists.Where(r => r.Status == 1).ToList();

                }
                if (obj.Status == null)
                {
                    Committee = db.ViewCommitteMasterLists.Where(r => r.Status == 1).ToList();

                }

                if (Committee == null)
                {
                    return new Error() { IsError = true, Message = "No Records Found !!" };
                }
                return Committee;

            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }


        }
        public object GetSingleCommittee(CommitteeMasterUpdateParam b)
        {
            try
            {
                var Committee = db.ViewCommitteMasterLists.Where(r => r.CommitteeID == b.CommitteeID).FirstOrDefault();
                return new Result() { IsSucess = true, ResultData = Committee };
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }


        }
        public object DeleteCommittee(CommitteeMasterUpdateParam PM)
        {
            try
            {
                Tbl_CommitteeMaster obj = db.Tbl_CommitteeMaster.Where(r => r.CommitteeID == PM.CommitteeID).FirstOrDefault();


                if (obj.Status == 1)
                {
                    obj.Status = 0;
                }
                else
                {
                    obj.Status = 1;
                }

                db.SaveChanges();

                return new Result() { IsSucess = true, ResultData = "Committe Deactivated Successfully." };
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }

        }
    }
}