﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.Extensions.Configuration;
using System.Globalization;

namespace SecureClient
{
    public class AuthConfig
    {
        public string Instance { get; set; } = "https://login.microsoftonline.com/{0}";
        public string TenantId { get; set; }
        public string ClientId { get; set; }
        public string Authority
        {
            get
            {
                return String.Format(CultureInfo.InvariantCulture, Instance, TenantId);
            }

            set { }
        }
        public string ClientSecret { get; set; }
        public string BaseAddress { get; set; }
        public string ResourceId { get; set; }

        public static AuthConfig ReadJsonFromFile(string path)
        {
            IConfiguration Configuration;

            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(path);

            Configuration = builder.Build();

            return Configuration.Get<AuthConfig>();
        }
    }
}
