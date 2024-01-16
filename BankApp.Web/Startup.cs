using BankApp.Web.Data.Context;
using BankApp.Web.Data.Interfaces;
using BankApp.Web.Data.Repositories;
using BankApp.Web.Data.UnitOfWork;
using BankApp.Web.Mapping;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BankApp.Web
{
	public class Startup
	{
		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<BankContext>(
				opt =>
				{
					opt.UseSqlServer("server= DESKTOP-UBI1M1S\\SQLEXPRESS; database=BankDb; integrated security=true;  ");
				});
			//services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
			//services.AddScoped<IApplicationUserRepository,ApplicationUserRepository>();
			//services.AddScoped<IAccountRepository,AccountRepository>();
			services.AddScoped<IUow, Uow>();
			services.AddScoped<IUserMapper ,UserMapper>();
			services.AddScoped<IAccountMapper, AccountMapper>();
			services.AddControllersWithViews();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			app.UseStaticFiles();
			app.UseStaticFiles(new StaticFileOptions
			{
				FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "node_modules")),
				RequestPath = "/node_modules"
			
			}); 
			app.UseRouting();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapDefaultControllerRoute();

			});
		}
	}
}
