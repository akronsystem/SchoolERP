using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolAPI.Param
{
    public class InstituteAdressUpdateParam
    {
        public long InstituteDid { get; set; }

        public long InstituteId { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string  CityName { get; set; }

        public long StateId { get; set; }

        public string Pincode { get; set; }

        public string LandlineNumber { get; set; }

        public string PhoneNumber1 { get; set; }

        public string PhoneNumber2 { get; set; }

        public string Fax { get; set; }

        public string InstituteEmail { get; set; }

        public string PrinciaplEmail { get; set; }

        public string Website { get; set; }

        public int Status { get; set; }

        public long CreatedId { get; set; }

        public DateTime CreatedOn { get; set; }

        public long ModifiedId { get; set; }

        public DateTime ModifiedOn { get; set; }
    }
}