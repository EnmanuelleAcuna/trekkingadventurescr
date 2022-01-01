using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using trekkingadventurescr.Models.Data.EntityFramework;
using Microsoft.EntityFrameworkCore;
using trekkingadventurescr.Models;
using trekkingadventurescr.Models.Data.Identity;

namespace trekkingadventurescr
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
			var connectionString = "server=217.71.206.171;user=emanuel;password=Amelie2406.;database=trekkingadventurescr";

			services.AddDbContext<trekkingadventurescr_DB_Context>(dbContextOptions => dbContextOptions.UseMySql(connectionString));

			// ASP.Net Identity
			services.AddDbContext<ApplicationDbContext>(options => options.UseMySql(connectionString));

			services.AddIdentity<User, Role>(options =>
			{
				options.User.RequireUniqueEmail = true;
				options.SignIn.RequireConfirmedAccount = false;
				options.Password.RequiredLength = 6;
			})
			.AddEntityFrameworkStores<ApplicationDbContext>()
			.AddTokenProvider<DataProtectorTokenProvider<User>>(TokenOptions.DefaultProvider);

			services.Configure<CookiePolicyOptions>(options =>
			{
				options.CheckConsentNeeded = context => false;
				options.MinimumSameSitePolicy = SameSiteMode.Lax;
			});

			services.Configure<CookieOptions>(options =>
			{
				options.SameSite = SameSiteMode.Strict;
				options.Secure = true;
			});

			services.ConfigureApplicationCookie(options =>
			{
				options.Cookie.Name = ".trekkingadventurescr.AspNetCore";
				options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
				options.SlidingExpiration = true;
				options.LoginPath = "/Account/LogIn";
				options.Cookie.SameSite = SameSiteMode.Strict;
			});

			// services.AddControllersWithViews();

			services.AddControllersWithViews().AddRazorRuntimeCompilation();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseDatabaseErrorPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			// app.UseStatusCodePages();

			// app.UseStatusCodePagesWithRedirects("/Home/Error");

			app.UseHttpsRedirection();

			app.UseStaticFiles();

			app.UseCookiePolicy();

			app.UseRouting();

			app.UseAuthentication();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
