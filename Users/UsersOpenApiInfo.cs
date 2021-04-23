using NSwag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Users
{
    public class UsersOpenApiInfo
    {
        //public UsersOpenApiInfo()
        //{
        //    Version = "v1";
        //    Title = "Users";
        //    Description = "API REST Users em netcore 2.1";
        //    Contact = new OpenApiContact
        //    {
        //        Name = "Squad X",
        //        Email = "squadx@email.com",
        //        Url = "https://gitlab.com/meurepo"
        //    };
        //}

        public static string Version = "v1";
        public static string Title = "Users";
        public static string Description = "API REST Users em netcore 2.1";
        public static OpenApiContact Contact = new OpenApiContact
        {
            Name = "Squad X",
            Email = "squadx@email.com",
            Url = "https://gitlab.com/meurepo"
        };
    }
}
