using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElectronNET.API;
using ElectronNET.API.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace todo_e_nc_web
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
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            Bootstrap();
        }

        public async void Bootstrap()
        {
            var options = new BrowserWindowOptions
            {
                Show = false,
                Icon = @"C:\Source\Github\todo-electron-netcore\src\todo-e-nc-console\todo-e-nc-web\wwwroot\img\icon.ico"
            };

            var mainWindow = await Electron.WindowManager.CreateWindowAsync(options);

            mainWindow.OnReadyToShow += () =>
            {
                mainWindow.SetTitle("Yet Another To Do App [Y-ToDo]");
                mainWindow.Show();
            };

            var menu = new MenuItem[]
            {
                new MenuItem{
                    Label = "File",
                    Submenu = new MenuItem[]{
                        new MenuItem {
                        Label = "Exit",
                        Click = () => {Electron.App.Exit(); }
                        }
                    }
                },

                new MenuItem
                {
                    Label = "Info",
                    Click = async () =>
                    {
                        await Electron.Dialog.ShowMessageBoxAsync("To Do List in Electron.NET. Version: 0.0.0");
                    }
                },
                new MenuItem
                {
                    Label = "Tools",
                    Submenu = new MenuItem[]
                    {
                        new MenuItem
                        {
                            Label = "Open Developer Tools",
                            Accelerator = "CmdOrCtrl+I",
                            Click = () => Electron.WindowManager.BrowserWindows.First().WebContents.OpenDevTools()
                        }
                    }
                }
            };
            Electron.Menu.SetApplicationMenu(menu);
        }
    }
}
