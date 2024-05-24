using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2;


public class JobDto

{
    public int JobId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string ExternalId { get; set; }
    public int EmploymentTypeId { get; set; }
    public int ExpertiseId { get; set; }
    public int ProfessionId { get; set; }
    public bool ShouldProcess { get; set; }

    public override string ToString()
    {
        return $@"
JobId: {JobId}
Title: {Title}
Description: {Description}
ExternalId: {ExternalId}
ProfessionId: {ProfessionId}
ShouldProcess: {ShouldProcess}
";
    }
}


public class ServiceBusModel : SourceModel<JobDto>

{
    public int ExternalId { get; set; }
    public string JobTitle { get; set; }
    public string JobDescription { get; set; }
    public string EmploymentType { get; set; }
    public string Expertise { get; set; }
    public string Profession { get; set; }
    public string Status { get; set; }

    public JobDto TransformToTarget()
    {
        return new JobDto()
        {
            JobId = new Random().Next(100000),
            ExternalId = this.ExternalId.ToString(),
            Title = JobTitle,
            Description = JobDescription,

        };
    }
}
