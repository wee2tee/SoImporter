using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileUpload
{
    public class FIleUpload
    {
        public static FileUploadResult Upload(string actionUrl, Stream paramFileStream, string post_object_name, string file_name)
        {
            try
            {
                //HttpContent stringContent = new StringContent(paramString);
                HttpContent file_stream_content = new StreamContent(paramFileStream);
                //HttpContent destination_folder = new StringContent(dest_folder);
                //HttpContent bytesContent = new ByteArrayContent(paramFileBytes);
                using (var client = new HttpClient())
                using (var formData = new MultipartFormDataContent())
                {
                    //formData.Add(stringContent, "param1", "param1");
                    formData.Add(file_stream_content, post_object_name, file_name);
                    //formData.Add(destination_folder, "destination_folder", "destination_folder");
                    //formData.Add(bytesContent, "file2", "file2");
                    var response = client.PostAsync(actionUrl, formData).Result;
                    if (!response.IsSuccessStatusCode)
                    {
                        return new FileUploadResult
                        {
                            Success = false,
                            Message = new StreamReader(response.Content.ReadAsStreamAsync().Result).ReadToEnd()
                        };
                    }
                    return new FileUploadResult
                    {
                        Success = true,
                        Message = new StreamReader(response.Content.ReadAsStreamAsync().Result).ReadToEnd()
                    };
                }
            }
            catch(Exception ex)
            {
                if(MessageBox.Show(ex.Message, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                {
                    return Upload(actionUrl, paramFileStream, post_object_name, file_name);
                }
            }

            return new FileUploadResult
            {
                Success = false,
                Message = "Unknown Error!"
            };
        }
    }

    public class FileUploadResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
