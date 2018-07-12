﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Server.Core;
using Server.Data;
using Server.Middlewares;
using Server.Services;
using System.Linq;
using AutoMapper;
using Server.Models;
using Server.Repository;

namespace Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<SQLContext>(options =>
                            options.UseSqlite(Configuration.GetSection("connectionStrings").
                                GetChildren().Where(x => x.Key == "sqlite").FirstOrDefault().Value));
            services.AddScoped<ICardService, CardService>();
            services.AddScoped<IBusinessLogicService, BusinessLogicService>();
            services.AddScoped<IRepository<Card>, Repository<Card>>();
            services.AddScoped<IRepository<Transaction>, Repository<Transaction>>();
            services.AddScoped<IBusinessLogicService, BusinessLogicService>();
            services.AddSingleton<IBankRepository, BankRepository>();


            services.AddAutoMapper();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware<HttpStatusCodeExceptionMiddleware>();
            app.UseMvc();
        }
    }
}