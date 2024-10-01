var builder = DistributedApplication.CreateBuilder(args);

var password = builder.AddParameter("password", true);

var sql = builder
	.AddSqlServer("sql", password, port: 1433)
	.WithDataVolume();
var sqldb = sql.AddDatabase("appDb")
	.WithHealthCheck();

var myService = builder.AddProject<Projects.MagCoders_Orders_Api>("api")
					   .WithReference(sqldb)
					   .WithExternalHttpEndpoints()
					   .WaitFor(sql);

builder.AddProject<Projects.MagCoders_Orders_Ui>("magcoders-orders-ui")
	.WithReference(myService);
builder.Build().Run();