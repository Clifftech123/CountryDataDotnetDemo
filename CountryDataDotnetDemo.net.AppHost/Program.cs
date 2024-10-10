var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.CountryDataDotnetDemo_API>("countrydatadotnetdemo-api");

builder.AddProject<Projects.CountryDataDotnetDemo_Web>("countrydatadotnetdemo-web");

builder.Build().Run();
