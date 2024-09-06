using System.Net.Http.Json;
using System.Text.Json;
using Azure;
using Core.Domain.Entities;

namespace YourBlazorApp.Services
{
    public class EmployeeService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _options;

        public EmployeeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<List<Employee>> GetEmployeesAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Employee>>("api/employee");
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Employee>($"api/employee/{id}");
        }

        public async System.Threading.Tasks.Task CreateEmployeeAsync(Employee employee)
        {
            
            var response = await _httpClient.PostAsJsonAsync("api/employee", employee);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al crear empleado: {errorContent}");
            }
        }

        public async System.Threading.Tasks.Task UpdateEmployeeAsync(Employee employee)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/employee/update/{employee.Id}", employee);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al asignar tarea: {errorContent}");
            }
        }

        public async System.Threading.Tasks.Task DeleteEmployeeAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/employee/{id}");
            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al asignar tarea: {errorContent}");
            }
        }

        public async System.Threading.Tasks.Task AssignTasksAsync(int employeeId, Core.Domain.Entities.Task tasks)
        {
            
                var response = await _httpClient.PutAsJsonAsync($"api/employee/{employeeId}/tasks?taskName={tasks.Name}", new { });

                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al asignar tarea: {errorContent}");
                }
            
        }
    }
}
