using EventApi.Interfaces;
using EventApi.Services;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);


        builder.Services.AddControllers();
        builder.Services.AddSingleton<IEventService, EventService>();
        builder.Services.AddSwaggerGen();

        if (builder.Environment.IsDevelopment())
        {
            builder.Host.UseDefaultServiceProvider(options =>
            {
                options.ValidateScopes = true;
                options.ValidateOnBuild = true;
            });
        }

        
        var app = builder.Build();



        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }


        app.MapControllers();

        app.Run();
    }
}