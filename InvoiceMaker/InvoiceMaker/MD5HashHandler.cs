using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace InvoiceMaker
{
    public class Md5HashHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get
            {
                return true;
            }
        }

        public void ProcessRequest(HttpContext context)
        {
            // Get the full path of the request
            HttpRequest request = context.Request;
            Uri uri = request.Url;
            string absolutePath = uri.AbsolutePath;

            // Strip off the file extension and leading forward slash
            // Works backwards from the end of the string until it finds a '.'
            // Ends if it encounters a directory delimiter before a '.'
            string extension = Path.GetExtension(absolutePath);
            string pathNoExtension = absolutePath.Substring(1, absolutePath.Length - extension.Length - 1);


            // Set the response's content type and write the appropriate value to the response
            if (extension == ".hash")
            {
                // Caculate the MD5 hash
                string hashedPath = CalculateMd5Hash(pathNoExtension);
                context.Response.ContentType = "text/plain";
                context.Response.Write(hashedPath);
            }
            else if (extension == ".binhash")
            {
                // Caculate the MD5 hash
                byte[] hashedPath = CalculateMd5HashBinary(pathNoExtension);
                context.Response.ContentType = "application/octet-stream";
                context.Response.BinaryWrite(hashedPath);
            }
        }

        private string CalculateMd5Hash(string input)
        {
            MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            foreach (byte b in hash)
            {
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }

        private byte[] CalculateMd5HashBinary(string input)
        {
            MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            return hash;
        }
    }
}