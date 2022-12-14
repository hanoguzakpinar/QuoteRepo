using QuoteRepo.API.Middlewares;
using QuoteRepo.Core.Repositories;
using QuoteRepo.Core.UnitOfWorks;
using QuoteRepo.Data.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(opt => opt.Filters.Add(new ValidateFilterAttribute()))
    .AddNewtonsoftJson(opt =>
    {
        opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    })
    .AddFluentValidation(f => f.RegisterValidatorsFromAssemblyContaining<CreateQuoteCommandValidator>());
builder.Services.Configure<ApiBehaviorOptions>(f =>
{
    f.SuppressModelStateInvalidFilter = true;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped(typeof(NotFoundFilter<>));

builder.Services.AddDbContext<QuoteContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Belbim"));
});
builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<ICountryService, CountryService>();
builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IQuoteService, QuoteService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddAutoMapper(typeof(ApiProfile), typeof(BusinessProfile));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCustomException();

app.UseAuthorization();

app.MapControllers();

app.Run();
