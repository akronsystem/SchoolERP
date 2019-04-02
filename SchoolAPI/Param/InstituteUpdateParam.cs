using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolAPI.Param
{
    public class InstituteUpdateParam
    {
        public long InstituteId { get; set; }
        public string InstituteName { get; set; }

        public long SectionId { get; set; }

        public long UdiseNo { get; set; }

        public long BoardId { get; set; }

        public long AffilationNo { get; set; }

        public DateTime EstablishedYear { get; set; }

        public long InstituteOrganizationNo { get; set; }

        public string OrganizationAddress { get; set; }

        public string InstituteOrganizationName { get; set; }
        public string OrganizationRegistrationNo { get; set; }

        public string RegistrationCertificateNo { get; set; }

        public long InstituteRecognitionNoPrimary { get; set; }

        public int Status { get; set; }

        public long CreatedId { get; set; }

        public DateTime CreatedOn { get; set; }

        public long ModifiedId { get; set; }

        public DateTime ModifiedOn { get; set; }
    }
}