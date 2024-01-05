
using System.Reflection;
using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Vb.Data;
using Vb.Business.Cqrs;
using Vb.Business.Mapper;
using Vb.Business.Validator;

namespace VbApi;

public class Startup
{
    public IConfiguration Configuration;

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        string connection = Configuration.GetConnectionString("MsSqlConnection");
        services.AddDbContext<VbDbContext>(options => options.UseSqlServer(connection));
        //services.AddDbContext<VbDbContext>(options => options.UseNpgsql(connection));
        
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateCustomerCommand).GetTypeInfo().Assembly));

        var mapperConfig = new MapperConfiguration(cfg => cfg.AddProfile(new MapperConfig()));
        services.AddSingleton(mapperConfig.CreateMapper());

        //validator eklendi
        services.AddControllers().AddFluentValidation(x =>
        {
            x.RegisterValidatorsFromAssemblyContaining<CreateAccountValidator>();
            x.RegisterValidatorsFromAssemblyContaining<CreateAccountTransactionValidator>();
            x.RegisterValidatorsFromAssemblyContaining<CreateAddressValidator>();
            x.RegisterValidatorsFromAssemblyContaining<CreateContactValidator>();
            x.RegisterValidatorsFromAssemblyContaining<CreateCustomerValidator>();
            x.RegisterValidatorsFromAssemblyContaining<CreateEftTransactionValidator>();
            x.RegisterValidatorsFromAssemblyContaining<UpdateAccountValidator>();
            x.RegisterValidatorsFromAssemblyContaining<UpdateAccountTransactionValidator>();
            x.RegisterValidatorsFromAssemblyContaining<UpdateAddressValidator>();
            x.RegisterValidatorsFromAssemblyContaining<UpdateContactValidator>();
            x.RegisterValidatorsFromAssemblyContaining<UpdateCustomerValidator>();
            x.RegisterValidatorsFromAssemblyContaining<UpdateEftTransactionValidator>();
        });
        
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }
    
    public void Configure(IApplicationBuilder app,IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthorization();
        app.UseEndpoints(x => { x.MapControllers(); });
    }
}
