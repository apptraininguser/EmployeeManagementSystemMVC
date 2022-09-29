using EmployeeManagementSystem.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Provider
{
    public class EmployeeClient : IEmployeeClient
    {

        private readonly HttpClient _httpClient;

        public EmployeeClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public List<EmployeeViewModel> GetEmployee()
        {
            using (var response = _httpClient.GetAsync("https://localhost:5001/getEmployee").Result)
            {
                var employee = JsonConvert.DeserializeObject<List<EmployeeViewModel>>(response.Content.ReadAsStringAsync().Result);

                return employee;
            }
        }

    }
}
