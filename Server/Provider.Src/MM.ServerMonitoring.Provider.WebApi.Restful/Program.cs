using MM.ServerMonitoring.Provider.WebApi.Commands;
using MM.ServerMonitoring.Provider.WebApi.Repository.EntityFramework.Extensions;
using MM.ServerMonitoring.Provider.WebApi.Repository.EntityFramework.Model.Mapper;
using MM.ServerMonitoring.Provider.WebApi.Validation;

namespace MM.ServerMonitoring.Provider.WebApi.Restful;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        //todo do we need light inject? if so we should register all in lightinject
        builder.Services.AddRepositories();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddMapper();
        builder.Services.AddSwaggerGen();
        var swaggerConfiguration = new SwaggerConfiguration();

        builder.Services.AddDataContext();
        builder.Services.AddServices();
        builder.Services.AddModelBootstrapper();
        builder.Services.AddValidation();


        builder.Services.AddMvc(options => options.Filters.Add(new ExceptionFilter()));

        var app = builder.Build();
        app.UseRouting();

        app.Configuration.GetSection(nameof(SwaggerConfiguration)).Bind(swaggerConfiguration);


#if DEBUG
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            options.RoutePrefix = string.Empty;
        });
#endif
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseAuthorization();

        app.MapControllers();
        app.Run();
    }
}