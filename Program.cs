using ConsoleApp2;

//Get The Jobs
var list = Data.GetJobData();


//Transform Dev Manager descriptions
var ManagementDescriptionProf = new RuleGroup()
{
    Rules = new() {
        new() { Expression = "Profession == \"Management\"", Operator = Operator.NONE },
        new() { Expression = "Expertise == \"Development\"", Operator = Operator.AND },
    },
    RuleActions = new() { new() { SetProperty = "Description", Value = "This is a dev manager position!" } }
};


//Set process flag to true only if status is open or On Hold
var ShouldProcess = new RuleGroup()
{
    Rules = new() {
        new() { Expression = "Status == \"Open\"", Operator = Operator.NONE },
        new() { Expression = "Status == \"On Hold\"", Operator = Operator.OR }
    },
    RuleActions = new() { 
        new() { SetProperty = "ShouldProcess", Value = true },
        new() { SetProperty = "Description", Value = "This job is open"}
    }
};


var entityRules = new EntityRuleSet<ServiceBusModel, JobDto>()
{
    SourceKey = "ExternalId",
    RuleGroups = new() { ShouldProcess, EngineeringProf, DesignProf, ManagementProf, ManagementProf, ManagementDescriptionProf }
};

//Execute the ruleset
var results = entityRules.Execute(list);

results.ForEach(result => Console.WriteLine(result));





