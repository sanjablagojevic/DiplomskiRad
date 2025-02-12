﻿using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserManagement.MVC.Data;
using UserManagement.MVC.Models;

[assembly: HostingStartup(typeof(UserManagement.MVC.Areas.Identity.IdentityHostingStartup))]
namespace UserManagement.MVC.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {

                //services.AddIdentity<ApplicationUser, IdentityRole>(options =>
                //{
                //    options.SignIn.RequireConfirmedAccount = true; //Kasnije true
                //    options.Password.RequireLowercase = false;
                //    options.Password.RequireUppercase = false;
                //    options.Password.RequireNonAlphanumeric = false;
                //});

            });
        }
    }
}