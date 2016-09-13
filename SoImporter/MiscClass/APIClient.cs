using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Windows.Forms;

namespace SoImporter.MiscClass
{
    public class APIClient
    {
        public static APIResult POST(string url, string json_data)
        {
            APIResult result = new APIResult();

            try
            {
                HttpWebRequest http = (HttpWebRequest)WebRequest.Create(new Uri(url));
                http.Accept = "application/json";
                http.ContentType = "application/json";
                http.Method = "POST";

                string parsedContent = json_data;
                Encoding encoding = Encoding.GetEncoding("utf-8");
                Byte[] bytes = encoding.GetBytes(parsedContent);

                Stream newStream = http.GetRequestStream();
                newStream.Write(bytes, 0, bytes.Length);
                newStream.Close();

                var response = http.GetResponse();

                var stream = response.GetResponseStream();
                var sr = new StreamReader(stream);
                var content = sr.ReadToEnd();
                Console.WriteLine(" ... >> " + content);
                http = null;

                result.Success = true;
                result.ReturnValue = content;
                result.ErrorMessage = null;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.ReturnValue = null;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public static APIResult GET(string url, string api_key, string additional_params = "")
        {
            APIResult result = new APIResult();

            try
            {
                HttpWebRequest http = (HttpWebRequest)WebRequest.Create(new Uri(url + "?api_key=" + api_key + additional_params));
                http.Method = "GET";

                var response = http.GetResponse();
                var stream = response.GetResponseStream();
                var sr = new StreamReader(stream);
                var content = sr.ReadToEnd();
                http = null;

                result.Success = true;
                result.ReturnValue = content;
                result.ErrorMessage = null;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.ReturnValue = null;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }
    }


    public class APIResult
    {
        public bool Success { get; set; }
        public string ReturnValue { get; set; }
        public string ErrorMessage { get; set; }
    }
}
