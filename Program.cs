using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<UnitOfWork>();

var connectionString = builder.Configuration.GetConnectionString("LocalConnection")
?? throw new InvalidOperationException("No Connection String Was Found");


builder.Services.AddControllers().AddJsonOptions(options =>
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles)
.ConfigureApiBehaviorOptions(options =>
{
    options.InvalidModelStateResponseFactory = context =>
    {
        // Extract validation errors from the ModelState
        var errors = context.ModelState
            .Where(e => e.Value.Errors.Count > 0)
            .ToDictionary(
                kvp => kvp.Key,
                kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
            );

        // Create a BaseResponse<object> for the 400 Bad Request response
        var response = new BaseResponse<object>
        {
            Success = false,
            Message = "One or more validation errors occurred.",
            Errors = errors.SelectMany(e => e.Value).ToList()
        };

        // Return a BadRequestObjectResult with the custom response
        return new BadRequestObjectResult(response)
        {
            ContentTypes = { "application/json" }
        };
    };
});



builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(connectionString, o =>
    {
        o.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName);
    });
    options.EnableSensitiveDataLogging();
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/openapi/v1.json", "version one");
        c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
