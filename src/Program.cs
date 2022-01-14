using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace trekkingadventurescr
{
	public class Program
	{
		public static void Main(string[] args)
		{
			CreateHostBuilder(args).Build().Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args)
		{
			IHostBuilder defaultHost = Host.CreateDefaultBuilder(args);
			defaultHost.ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>());
			return defaultHost;
		}
	}
}
