using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public static class Data
    {

        public static List<ServiceBusModel> GetJobData()
        {
            return new()
        {
            new ServiceBusModel
            {
                ExternalId = 1,
                JobTitle = "Angular Developer",
                JobDescription = "Develop and maintain Angular app. We're sorry in advance.",
                EmploymentType = "Full-Time",
                Expertise = "Front End",
                Profession = "Engineering",
                Status = "Open"
            },
            new ServiceBusModel
            {
                ExternalId = 2,
                JobTitle = "DBE",
                JobDescription = "Analyze and interpret complex data sets, write queries, pull hair out.",
                EmploymentType = "Part-Time",
                Expertise = "Database",
                Profession = "Engineering",
                Status = "Closed"
            },
            new ServiceBusModel
            {
                ExternalId = 3,
                JobTitle = "API Developer",
                JobDescription = "Write lots of C# and doesn't afraid of anything.",
                EmploymentType = "Contract",
                Expertise = "Back End",
                Profession = "Engineering",
                Status = "On Hold"
            },
            new ServiceBusModel
            {
                ExternalId = 4,
                JobTitle = "UX Designer",
                JobDescription = "Designs? More like gentle suggestions!",
                EmploymentType = "Full-Time",
                Expertise = "UI/UX",
                Profession = "Design",
                Status = "Open"
            },
            new ServiceBusModel
            {
                ExternalId = 5,
                JobTitle = "Dev Manager",
                JobDescription = "A little bit of everything, but not enough to get excited about any of it.",
                EmploymentType = "Full-Time",
                Expertise = "Development",
                Profession = "Management",
                Status = "Open"
            }
        };
        }
    }
}
