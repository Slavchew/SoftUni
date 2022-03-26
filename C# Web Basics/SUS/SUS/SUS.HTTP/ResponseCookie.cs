using System;
using System.Collections.Generic;
using System.Text;

namespace SUS.HTTP
{
    public class ResponseCookie : Cookie
    {
        public ResponseCookie(string name, string value) 
            : base(name, value)
        {
            this.Path = "/";
        }

        public string Path { get; set; }

        public int MaxAge { get; set; }

        public bool HttpOnly { get; set; }

        // Domain, Secure
        public override string ToString()
        {
            StringBuilder cookieBuilder = new StringBuilder();
            cookieBuilder.Append($"{this.Name}={this.Value}; Path={this.Path};");
            if (this.MaxAge != 0)
            {
                cookieBuilder.Append($" Max-Age={this.MaxAge};");
            }

            if (this.HttpOnly)
            {
                cookieBuilder.Append($" HttpOnly;");
            }

            return cookieBuilder.ToString();
        }
    }
}
