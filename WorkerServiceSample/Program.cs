using WorkerServiceSample;

var builder = Host.CreateApplicationBuilder(args);

var serviceConfig = builder.Configuration.GetSection("WorkerConfig");
builder.Services.Configure<WorkerConfiguration>(serviceConfig);

builder.Services.AddWindowsService();
builder.Services.AddHostedService<Worker>();

var host = builder.Build();
await host.RunAsync();
