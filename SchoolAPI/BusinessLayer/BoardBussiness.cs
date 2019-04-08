using SchoolAPI.Param;
using SchoolAPI.ResultModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolAPI;
using SchoolAPI.Models;

namespace SchoolAPI.BusinessLayer
{
    public class BoardBussiness
    {
        SchoolAdminContext db = new SchoolAdminContext();
        public object SaveBoard(BoardParam b)
        {
            if (b.BoardName == null)
            {
                return new Error() { IsError = true, Message = "Required BoardName" };
            }
            var data = db.Tbl_Board_Master.FirstOrDefault(r => r.BoardName == b.BoardName);
            if (data != null)
            {
                return new Error() { IsError = true, Message = "Duplicate Entry Not Allowed" };
            }
            try
            {
                Tbl_Board_Master obj = new Tbl_Board_Master();
                obj.BoardName = b.BoardName;
                obj.Status = 1;
                obj.CreatedBy = 1;
                obj.CreatedDate = System.DateTime.Today.Date;
                obj.ModifiedBy = null;
                obj.ModifiedDate = System.DateTime.Today.Date;
                db.Tbl_Board_Master.Add(obj);
                db.SaveChanges();
                return new Result() { IsSucess = true, ResultData = "Created Board" };
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }

        }
        public object BoardUpdate(BoardParam b)
        {
            if (b.BoardName == null)
            {
                return new Error() { IsError = true, Message = "Required BoardName" };
            }
            var Info = db.Tbl_Board_Master.FirstOrDefault(r => r.BoardName == b.BoardName);
            if (Info != null)
            {
                return new Error() { IsError = true, Message = "Duplicate Entry Not Allowed" };
            }
            var data = db.Tbl_Board_Master.Where(r => r.BoardID == b.BoardId).FirstOrDefault();
            try
            {
                TblBoard obj = new TblBoard();
                data.BoardName = b.BoardName;
                data.ModifiedBy = null;
                data.ModifiedDate = System.DateTime.Today.Date;
                db.SaveChanges();
                return new Result() { IsSucess = true, ResultData = "Update Board" };
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }

        }
        public object GetBoard(UserCredential obj)
        {
            try
            {
                List<Tbl_Board_Master> board = null;

                if (obj.Status == "0")
                {
                    board = db.Tbl_Board_Master.Where(r => r.Status == 0).ToList();
                }
                else
                {

                    board = db.Tbl_Board_Master.Where(r => r.Status == 1).ToList();

                }
                if (obj.Status == null)
                {
                    board = db.Tbl_Board_Master.Where(r => r.Status == 1).ToList();

                }

                if (board == null)
                {
                    return new Error() { IsError = true, Message = "No Records Found !!" };
                }
                return board;

            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }


        }
        public object GetSingleBoard(BoardParam b)
        {
            try
            {
                var board = db.Tbl_Board_Master.Where(r => r.BoardID == b.BoardId).FirstOrDefault();
                return new Result() { IsSucess = true, ResultData = board };
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }


        }
        public object DeleteBoard(BoardParam PM)
        {
            try
            {
                Tbl_Board_Master obj = db.Tbl_Board_Master.Where(r => r.BoardID == PM.BoardId).FirstOrDefault();


                if (obj.Status == 1)
                {
                    obj.Status = 0;
                }
                else
                {
                    obj.Status = 1;
                }

                db.SaveChanges();

                return new Result() { IsSucess = true, ResultData = "Board Deactivated Successfully." };
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }

        }
    }
}