using ConsumeApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace ConsumeApi.Controllers
{
    public class EmployeeController : Controller
    {
        HttpClient client;

        public EmployeeController()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, SslPolicyErrors) => { return true; };

            client = new HttpClient(handler);
        }

        public IActionResult Index()
        {
            string url = "https://localhost:7146/api/Employee/GetEmp";

            List<Emp> emp = new List<Emp>();

            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsondata = response.Content.ReadAsStringAsync().Result;
                var obj = JsonConvert.DeserializeObject<List<Emp>>(jsondata);
                if (obj != null)
                {
                    emp = obj;
                }
            }
            return View(emp);
        }
    }
}
