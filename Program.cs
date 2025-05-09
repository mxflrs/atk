using atk_api.Application.Dtos;
using atk_api.Application.Dtos.Requests;
using atk_api.Application.Dtos.Responses;
using atk_api.Application.Interfaces;
using atk_api.Application.Services;
using atk_api.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("PostgreSQLConnection"),
         o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)));

builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<IBaseService<StyleDto, UpsertStyleRequest>, StyleService>();
builder.Services.AddScoped<IBaseService<MediumDto, UpsertMediumRequest>, MediumService>();
builder.Services.AddScoped<IBaseService<SeriesDto, UpsertSeriesRequest>, SeriesService>();
builder.Services.AddScoped<IBaseService<MaterialDto, UpsertMaterialRequest>, MaterialService>();
builder.Services.AddScoped<IBaseService<LaborTypeDto, UpsertLaborTypeRequest>, LaborTypeService>();

// builder.Services.AddSwaggerGen(c => 
// {
//     c.TagActionsBy(api => [api.ActionDescriptor.RouteValues["action"]]);
// });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
