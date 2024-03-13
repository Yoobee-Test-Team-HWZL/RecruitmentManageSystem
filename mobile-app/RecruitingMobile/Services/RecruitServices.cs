using RecruitingMobile.Models;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace RecruitingMobile.Services
{
    public class RecruitServices
    {
        private readonly HttpClient httpClient;
        List<Job>? jobs { get; set; }
        
        private const string BaseUrl = "http://13.239.118.124/api";

        public RecruitServices()
        {
            httpClient = new HttpClient();
        }
        public async Task<List<Job>?> GetJobs(PageEntity page)
        {
            if (jobs != null && jobs.Count > 0)
            {
                return jobs;
            }
            // Get all jobs
            //var apiurl = BaseUrl + $"/getpositionlist?page_size={page.PageSize}&page_num={page.PageNumber}";
            //var response = await httpClient.GetAsync(apiurl);
            //if (!response.IsSuccessStatusCode) return jobs;
            //var content = await response.Content.ReadAsStringAsync();
            //jobs = JsonSerializer.Deserialize<List<Job>>(content);

            // TODO - Hardcoded data for testing while the API is not ready
                jobs = new List<Job>
                {
                    new Job()
                    {
                        Id = 1,
                        Title = "Software Developer",
                        Description = "We are looking for a software developer to join our team",
                        StartTime = DateTime.Now,
                        EndTime = DateTime.Now.AddDays(30),
                        EmployerName = "Google",
                        EmployerEmail = "test@test.com",
                        CompanyAddress = "Auckland",
                        LogoUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/c/c1/Google_%22G%22_logo.svg/1200px-Google_%22G%22_logo.svg.png",
                        Salary = "50000",
                        CreatedTime = DateTime.Now,
                        Status = 0
                    },
                    new Job()
                    {
                        Id = 1,
                        Title = "Software Developer",
                        Description = "We are looking for a software developer to join our team",
                        StartTime = DateTime.Now,
                        EndTime = DateTime.Now.AddDays(30),
                        EmployerName = "Google",
                        EmployerEmail = "test@test.com",
                        CompanyAddress = "Auckland",
                        LogoUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/c/c1/Google_%22G%22_logo.svg/1200px-Google_%22G%22_logo.svg.png",
                        Salary = "50000",
                        CreatedTime = DateTime.Now,
                        Status = 0
                    },
                    new Job()
                    {
                        Id = 1,
                        Title = "Software Developer",
                        Description = "We are looking for a software developer to join our team",
                        StartTime = DateTime.Now,
                        EndTime = DateTime.Now.AddDays(30),
                        EmployerName = "Google",
                        EmployerEmail = "test@test.com",
                        CompanyAddress = "Auckland",
                        LogoUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/c/c1/Google_%22G%22_logo.svg/1200px-Google_%22G%22_logo.svg.png",
                        Salary = "50000",
                        CreatedTime = DateTime.Now,
                        Status = 0
                    },
                    new Job()
                    {
                        Id = 1,
                        Title = "Software Developer",
                        Description = "We are looking for a software developer to join our team",
                        StartTime = DateTime.Now,
                        EndTime = DateTime.Now.AddDays(30),
                        EmployerName = "Google",
                        EmployerEmail = "test@test.com",
                        CompanyAddress = "Auckland",
                        LogoUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/c/c1/Google_%22G%22_logo.svg/1200px-Google_%22G%22_logo.svg.png",
                        Salary = "50000",
                        CreatedTime = DateTime.Now,
                        Status = 0
                    },
                    new Job()
                    {
                        Id = 1,
                        Title = "Software Developer",
                        Description = "We are looking for a software developer to join our team",
                        StartTime = DateTime.Now,
                        EndTime = DateTime.Now.AddDays(30),
                        EmployerName = "Google",
                        EmployerEmail = "test@test.com",
                        CompanyAddress = "Auckland",
                        LogoUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/c/c1/Google_%22G%22_logo.svg/1200px-Google_%22G%22_logo.svg.png",
                        Salary = "50000",
                        CreatedTime = DateTime.Now,
                        Status = 0
                    },
                    new Job()
                    {
                        Id = 1,
                        Title = "Software Developer",
                        Description = "We are looking for a software developer to join our team",
                        StartTime = DateTime.Now,
                        EndTime = DateTime.Now.AddDays(30),
                        EmployerName = "Google",
                        EmployerEmail = "test@test.com",
                        CompanyAddress = "Auckland",
                        LogoUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/c/c1/Google_%22G%22_logo.svg/1200px-Google_%22G%22_logo.svg.png",
                        Salary = "50000",
                        CreatedTime = DateTime.Now,
                        Status = 0
                    }



            };

            return jobs;
        }
    }
}
