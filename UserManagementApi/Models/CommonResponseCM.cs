using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;

namespace UserManagementApi.Models
{
    public class CommonResponseCM
    {
        public bool Succeeded { get; set; }

        public string? Content { get; set; }

        public string? Message { get; set; }

        public CommonResponseCM(bool succeeded, string message = " no message")
        {
            Succeeded = succeeded;
            Message = message;

        }

        public void CreateContent<T>(T content)
        {
            Content = JsonConvert.SerializeObject(content);
        }
    }
}
