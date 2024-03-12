using Application.Extensions;
using Domain.Movie.Data;
using Infrastructure.Extentions;
using Infrastructure.Movie.Repositories;
using Infrastructure.Profiles;
using MediatR;
using AutoMapper;



namespace MovieApp
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(Configuration);

            services.AddControllers();
            //services.AddMvc();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddAutoMapper(typeof(MovieProfile));
           
            services.AddInfrastructureConfiguration();
            services.AddApplicationConfiguration();
            //services.AddMediatR(typeof(MovieRepository).Assembly);
            //services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());   
            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
