//using System.Text;
//using System.Text.Json;
//using static System.Console;
//class demo
//{
//    static async Task PostAsync(HttpClient httpClient)
//    {
//        using StringContent jsonContent = new(
//            JsonSerializer.Serialize(new
//            {
//               name="Priyansh",
//               Class="BE-3"
//            }),
//            Encoding.UTF8,
//            "application/json");

//        using HttpResponseMessage response = await httpClient.PostAsync(
//            "todos",
//            jsonContent);

//        response.EnsureSuccessStatusCode().
//            WriteRequestToConsole();

//        var jsonResponse = await response.Content.ReadAsStringAsync();
//        WriteLine($"{jsonResponse}\n");

//        // Expected output:
//        //   POST https://jsonplaceholder.typicode.com/todos HTTP/1.1
//        //   {
//        //     "userId": 77,
//        //     "id": 201,
//        //     "title": "write code sample",
//        //     "completed": false
//        //   }
//    }
//}
using System;
using System.Text;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        using (HttpClient client = new HttpClient())
        {
            // Set the request URI and content
            Uri uri = new Uri("https://localhost:7289/api/Students");
            var data = new
            {
                Name = "Shrey",
                Class = "Be-3"
            };
            var json = JsonSerializer.Serialize(data);
            HttpContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            // Send the POST request
            HttpResponseMessage response = await client.PostAsync(uri, content);

            // Get the response content
            string responseContent = await response.Content.ReadAsStringAsync();

            // Print the response content
            Console.WriteLine(responseContent);
            
        }
    }
}
