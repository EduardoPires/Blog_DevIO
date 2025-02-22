﻿using Blog_DevIO.Data.Repositories;
using Blog_DevIO.Domain.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Blog_DevIO.Data.IoC
{
    public static class RegisterEFServices
    {
        public static WebApplicationBuilder AddEF(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<BlogContext>(options =>
              options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddIdentity<IdentityUser, IdentityRole>()
                 .AddRoles<IdentityRole>()
                 .AddEntityFrameworkStores<BlogContext>()
                  .AddSignInManager()
                  .AddRoleManager<RoleManager<IdentityRole>>()
                  .AddDefaultTokenProviders();


            builder.Services.AddScoped<IPostRepository, PostRepository>();
            builder.Services.AddScoped<ICommentRepository, CommentRepository>();


            return builder;
        }
    }
}
