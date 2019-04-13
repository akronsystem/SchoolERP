using SchoolAPI.BusinessLayer;
using SchoolAPI.Param;
using SchoolAPI.ResultModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SchoolAPI.API
{
    public class CommiteeMasterController : ApiController
    {

        [HttpPost]
        public object AddCommitteeType([FromBody]CommitteeTypeParam obj)
        {
            try
            {
                CommitteeBusiness save = new CommitteeBusiness();
                var result = save.SaveCommitteeType(obj);
                return result;
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }



        }
        [HttpPost]
        public object GetCommitteTypeInfo(UserCredential uc)
        {
            try
            {
                CommitteeBusiness data = new CommitteeBusiness();
                var Result = data.GetCommiteeType(uc);

                return Result;
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }

        }
        [HttpPost]
        public object GetSingleCommitteTypeInfo(CommitteeTypeUpdateParam b)
        {
            try
            {
                CommitteeBusiness type = new CommitteeBusiness();
                var Result = type.GetSingleCommitteType(b);

                return Result;
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }

        }
        [HttpPost]
        public object UpdateCommitteType(CommitteeTypeUpdateParam b)
        {
            try
            {
                CommitteeBusiness type = new CommitteeBusiness();
                var Result = type.CommitteTypeUpdate(b);

                return Result;
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }

        }
        [HttpPost]
        public object DeleteCommitteType([FromBody] CommitteeTypeUpdateParam PM)
        {
            try
            {
                CommitteeBusiness b = new CommitteeBusiness();
                var Result = b.DeleteCommitteType(PM);
                return Result;
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }
        }

        //CommitteeMaster
        [HttpPost]
        public object AddCommittee([FromBody]CommitteeMasterParam obj)
        {
            try
            {
                CommitteeBusiness save = new CommitteeBusiness();
                var result = save.SaveCommittee(obj);
                return result;
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }



        }
        [HttpPost]
        public object GetCommitteeInfo(UserCredential uc)
        {
            try
            {
                CommitteeBusiness data = new CommitteeBusiness();
                var Result = data.GetCommitee(uc);

                return Result;
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }

        }
        [HttpPost]
        public object GetSingleCommitteeInfo(CommitteeMasterUpdateParam b)
        {
            try
            {
                CommitteeBusiness type = new CommitteeBusiness();
                var Result = type.GetSingleCommittee(b);

                return Result;
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }

        }
        [HttpPost]
        public object UpdateCommittee(CommitteeMasterUpdateParam b)
        {
            try
            {
                CommitteeBusiness type = new CommitteeBusiness();
                var Result = type.CommitteUpdate(b);

                return Result;
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }

        }
        [HttpPost]
        public object DeleteCommittee([FromBody] CommitteeMasterUpdateParam PM)
        {
            try
            {
                CommitteeBusiness b = new CommitteeBusiness();
                var Result = b.DeleteCommittee(PM);
                return Result;
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }
        }
    }
}
