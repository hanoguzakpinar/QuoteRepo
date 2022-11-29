using QuoteRepo.Core.Repositories;
using QuoteRepo.Core.UnitOfWorks;
using QuoteRepo.Data.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(opt =>
{
    opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});
builder.Services.AddFluentValidation(opt =>
{
    // Other way to register validators
    //opt.ImplicitlyValidateChildProperties = true;
    //opt.ImplicitlyValidateRootCollectionElements = true;
    //opt.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());

    opt.RegisterValidatorsFromAssemblyContaining<Program>();
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<QuoteContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Belbim"));
});
builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<ICountryService, CountryService>();
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IQuoteService, QuoteService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddAutoMapper(opt =>
{
    opt.AddProfiles(new List<Profile>()
    {
        new ApiProfile(),
        new CountryProfile(),
        new AuthorProfile(),
        new QuoteProfile()
    });
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
