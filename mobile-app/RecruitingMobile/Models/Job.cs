using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitingMobile.Models
{
    public class Job
    {
        public int Id { get; set; }
        public int EmployerId { get; set; }
        public string? EmployerName { get; set; }
        public string EmployerEmail { get; set; }
        public string CompanyAddress { get; set; }
        public string LogoUrl { get; set; }
        public int HiredNumber { get; set; }
        public int AppliedNumber { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }        
        public DateTime CreatedTime { get; set; }
        public DateTime UpdatedTime { get; set; }
        public string Salary { get; set; }
        public int Status { get; set; } = 0;
    }
}
