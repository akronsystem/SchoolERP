using SchoolAPI.Models;
using SchoolAPI.Param;
using SchoolAPI.ResultModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolAPI.BusinessLayer
{
    public class StdWiseDivBussiness
    {
        SchoolERPContext db = new SchoolERPContext();
        public object GetAllStandard()
        {
            var result = db.ViewDisplayStandards.Where(r => r.Status == 1).ToList();
            return new Result() { IsSucess = true, ResultData = result };
        }
        public object GetBoard()
        {
            var result = db.View_Display_Board.Where(r => r.Status == 1).ToList();
            return new Result() { IsSucess = true, ResultData = result };
        }
        public object GetDivision()
        {
            var result = db.View_DisplayDivision.Where(r => r.Status == 1).ToList();
            return new Result() { IsSucess = true, ResultData = result };
        }
        public object SaveStdWiseDiv(StdWiseDivParam objParam)
        {
            try
            {


                objParam.DivisionID = objParam.DivisionID.Trim(',');
                string[] division = objParam.DivisionID.Split(',');
                int count = 0;
                String DivisionName = "";
                string StandardName = "";

                for (int i = 0; i < division.Length; i++)
                {
                    var divid = Convert.ToInt32(division[i]);

                    var duplicate = db.View_Display_StandardWiseDivision.SingleOrDefault(r => r.DivisionID == divid && r.StandardID == objParam.StandardID && r.Status == 1);
                    if (duplicate != null)
                    {
                        DivisionName = DivisionName + duplicate.DivisionName + ",";
                        StandardName = duplicate.StandardName;
                        count = 1;
                    }
                    if (i == division.Length - 1)
                    {


                        if (count == 0)
                        {
                            Tbl_StandardWiseDivision obj = new Tbl_StandardWiseDivision();
                            obj.BoardID = objParam.BoardId;
                            obj.DivisionID = Convert.ToInt64(division[i].ToString());
                            obj.StandardID = objParam.StandardID;
                            obj.Status = 1;
                            obj.CreatedBy = 1;
                            obj.CreatedDate = DateTime.Now;
                            obj.ModifiedBy = null;
                            obj.ModifiedDate = null;
                            db.Tbl_StandardWiseDivision.Add(obj);
                            db.SaveChanges();
                        }


                        else
                        {
                            DivisionName = DivisionName.Trim(',');
                            StandardName = StandardName.Trim(',');

                            return new Result { IsSucess = true, ResultData = "Division " + DivisionName + " Already Assign to Standard " + StandardName };
                        }
                    }



                }

                return new Result { IsSucess = true, ResultData = "Division Assign Successfully" };
            }
            catch (Exception ex)
            {
                return new Result { IsSucess = false, ResultData = "Error" };
            }

        }
        public object DisplayStdWiseDiv(StdWiseDivParam objParam)
        {
            try
            {
                List<View_Display_StandardWiseDivision> result = new List<View_Display_StandardWiseDivision>();
                if (objParam.status == 1)
                {
                    result = db.View_Display_StandardWiseDivision.Where(r => r.Status == 1).ToList();
                }
                else
                {
                    result = db.View_Display_StandardWiseDivision.Where(r => r.Status == 0).ToList();
                }

                return new Result { IsSucess = true, ResultData = result };
            }
            catch (Exception ex)
            {
                return new Result { IsSucess = false, ResultData = "Error" };
            }
        }
        public object GetSingleStdWiseDiv(StdWiseDivParam objParam)
        {
            try
            {


                int division = Convert.ToInt32(objParam.DivisionID);
                var result = db.Tbl_StandardWiseDivision.SingleOrDefault(r => r.StdWiseDivisionId == objParam.StdWiseDivisionId && r.Status == 1);
                //return new Result() { IsSucess = true, ResultData = result };
                return result;
            }
            catch (Exception ex)
            {
                return new Result() { IsSucess = false, ResultData = "Error" };
            }
        }
        public object UpdateStdDiv(StdWiseDivParam objParam)
        {
            try
            {
                objParam.DivisionID = objParam.DivisionID.Trim(',');
                string[] division = objParam.DivisionID.Split(',');
                int count = 0;
                String DivisionName = "";
                string StandardName = "";

                for (int i = 0; i < division.Length; i++)
                {
                    var divid = Convert.ToInt32(division[i]);

                    var duplicate = db.View_Display_StandardWiseDivision.SingleOrDefault(r => r.DivisionID == divid && r.StandardID == objParam.StandardID && r.Status == 1);
                    if (duplicate != null)
                    {
                        DivisionName = DivisionName + duplicate.DivisionName + ",";
                        StandardName = duplicate.StandardName;
                        count = 1;
                    }
                    if (i == division.Length - 1)
                    {


                        if (count == 0)
                        {
                            Tbl_StandardWiseDivision obj = new Tbl_StandardWiseDivision();

                            //int UpdatedivisionID = Convert.ToInt32(objParam.DivisionID);
                            obj = db.Tbl_StandardWiseDivision.SingleOrDefault(r => r.StdWiseDivisionId == objParam.StdWiseDivisionId && r.Status == 1);
                            obj.BoardID = objParam.BoardId;
                            obj.DivisionID = Convert.ToInt32(objParam.DivisionID);
                            obj.StandardID = objParam.StandardID;
                            obj.ModifiedBy = 1;
                            obj.ModifiedDate = DateTime.Now;
                            db.SaveChanges();
                        }


                        else
                        {
                            DivisionName = DivisionName.Trim(',');
                            StandardName = StandardName.Trim(',');

                            return new Result { IsSucess = true, ResultData = "Division " + DivisionName + " Already Assign to Standard " + StandardName };
                        }
                    }



                }

                return new Result { IsSucess = true, ResultData = "Division Assign Successfully" };



            }
            catch (Exception ex)
            {
                return new Result { IsSucess = false, ResultData = "Error" };
            }
        }


        public object DeleteSingleStdDivision(StdWiseDivParam objParam)
        {
            try
            {
                Tbl_StandardWiseDivision obj = new Tbl_StandardWiseDivision();
                if (objParam.status == 1)
                {
                    obj = db.Tbl_StandardWiseDivision.SingleOrDefault(r => r.StdWiseDivisionId == objParam.StdWiseDivisionId && r.Status == 1);
                    obj.Status = 0;
                    db.SaveChanges();
                    return new Result { IsSucess = true, ResultData = "Status Deactivated Successfully" };
                }
                else
                {
                    obj = db.Tbl_StandardWiseDivision.SingleOrDefault(r => r.StdWiseDivisionId == objParam.StdWiseDivisionId && r.Status == 0);
                    obj.Status = 1;
                    db.SaveChanges();
                    return new Result { IsSucess = true, ResultData = "Status Activated Successfully" };
                }

            }
            catch (Exception ex)
            {
                return new Result { IsSucess = false, ResultData = "Error" };
            }
        }



    }
}