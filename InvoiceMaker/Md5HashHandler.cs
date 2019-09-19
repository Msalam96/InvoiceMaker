using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Text;

namespace InvoiceMaker
{
    public class Md5HashHandler : IHttpHandler
    {

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public void ProcessRequest(HttpContext context)
        {
            Uri uri = context.Request.Url;
            string path = uri.AbsolutePath;
            string extension = Path.GetExtension(uri.AbsolutePath);
            path = path.Substring(1, path.Length - extension.Length - 1);
            MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(path);
            byte[] hash = md5.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; ++i)
            {
                sb.Append(hash[i].ToString("X2"));
            }

            string hashedpath = sb.ToString();

            if (extension == ".hash")
            {
                context.Response.ContentType = "text/plain";
                context.Response.Write(hashedpath);
            }
            else
            {
                context.Response.ContentType = "application/octet-stream";
                context.Response.BinaryWrite(hash);
            }

            
        }
    }
}