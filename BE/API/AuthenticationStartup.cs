﻿using WebShop.API.Auth;
using WebShop.API.Data;
using WebShop.API.Helpers;
using WebShop.API.Models;
using WebShop.API.Models.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;

namespace WebShop.API
{
    public static class AuthenticationStartup
    {
        private const string SecretKey = "UwwzJLeEGYEQDOw3GbyBSV9EIUN6RFlV2IEDBXMaNgupCA8XOAcJByVRUAkrr92Aj8R64X4PEHt+AgzaGHhO7FQ=";
        private static readonly SymmetricSecurityKey _signingKey = new SymmetricSecurityKey(Convert.FromBase64String(SecretKey));

        public static void Configure(IConfiguration configuration, IServiceCollection services)
        {
            services.AddSingleton<IJwtFactory, JwtFactory>();

            var jwtAppSettingOptions = configuration.GetSection(nameof(JwtIssuerOptions));

            // Configure JwtIssuerOptions
            services.Configure<JwtIssuerOptions>(options =>
            {
                options.Issuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
                options.Audience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)];
                options.SigningCredentials = new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256);
            });

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)],

                ValidateAudience = true,
                ValidAudience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)],

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = _signingKey,

                RequireExpirationTime = false,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, configureOptions =>
            {
                configureOptions.ClaimsIssuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
                configureOptions.TokenValidationParameters = tokenValidationParameters;
                configureOptions.SaveToken = true;
            });

            // define authorization policies;
            // specify what roles are allowed to access each policy
            services.AddAuthorization(options =>
            {
                options.AddPolicy(AuthPolicies.RequireAdmin, policy => policy.RequireClaim(AuthConstants.JwtClaimIdentifiers.Rol, AuthRoles.Admin));
            });

            // add identity
            var builder = services.AddIdentityCore<ApiUser>(o =>
            {
                // configure identity options
                o.Password.RequireDigit = false;
                o.Password.RequireLowercase = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequiredLength = 6;
            });
            builder = new IdentityBuilder(builder.UserType, typeof(IdentityRole), builder.Services);
            builder.AddEntityFrameworkStores<ApiDbContext>().AddDefaultTokenProviders();
            builder.AddRoles<IdentityRole>();

            services.AddCors(options => options.AddPolicy("AllowAll", p => p.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .WithExposedHeaders("X-Pagination")));
        }
    }
}
