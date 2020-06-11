using System;
using System.ComponentModel;

namespace Csvuploadapi.Dto
{
    public class ReturnUploadedFileDto
    {

        public string Name { get; set; }

        public string LastName { get; set; }

        public int UserId {get; set;}

        public string BadgeId { get; set; }

        public int FacilityId { get; set; }

        public string SiteName { get; set; }

        public string CompanyName {get; set;}

        public string DepartmentId { get; set; }

        public string Phone { get; set; }

        public string AccessLevel { get; set; }

        public int Id {
            get {return this.UserId;}
            set {this.UserId = value;}
        }
 
    }
}