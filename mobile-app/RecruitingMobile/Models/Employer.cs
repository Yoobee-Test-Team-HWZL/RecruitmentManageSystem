namespace RecruitingMobile.Models;

public class Employer
{
    public int Id { get; set; }
    public string CompanyName { get; set; }
    public string OfficialWeb { get; set; }
    public string Email { get; set; }
    public int EmployeeNumber { get; set; }
    public DateTime CreatedTime { get; set; }
    public DateTime UpdatedTime { get; set; }
}