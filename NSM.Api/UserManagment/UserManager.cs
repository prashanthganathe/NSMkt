using RestSharp;

namespace NSM.Api.UserManagment
{
    public class UserManager
    {
        //public async Task<string> RegisterUser()
        //{
        //    var client = new RestClient("https://localhost:44372/api/Authenticate/Register");
        //   // client.Timeout = -1;
        //    var request = new RestRequest(Method.Post);
        //    request.AddHeader("Content-Type", "application/json");
        //    request.AddParameter("application/json", "{\r\n  \"username\": \"prashanth\",\r\n  \"email\": \"prashanthganathe@gmail.com\",\r\n  \"password\": \"Test123!\"\r\n}", ParameterType.RequestBody);
             
        //    IRestResponse response = await client.ExecuteAsync(request);
        //    Console.WriteLine(response.Content);
        //    return response.Content; 
        //}

        //public async  Task<string> Login()
        //{
        //    var client = new RestClient("https://localhost:44372/api/Authenticate/Login");
        //    //client.Timeout = -1;
        //    var request = new RestRequest(Method.Post);
        //    request.AddHeader("Content-Type", "application/json");
        //    request.AddParameter("application/json", "{\r\n  \"username\": \"prashanth\",\r\n  \"password\": \"Test123!\"\r\n}", ParameterType.RequestBody);
        //    IRestResponse response =await client.ExecuteAsync(request);
        //    Console.WriteLine(response.Content);
        //}

        //public async Task<string> RegisterAdmin()
        //{
        //    var client = new RestClient("https://localhost:44372/api/Authenticate/register-admin");
        //   // client.Timeout = -1;
        //    var request = new RestRequest(Method.POST);
        //    request.AddHeader("Content-Type", "application/json");
        //    request.AddParameter("application/json", "{\r\n  \"username\": \"prashanth-admin\",\r\n  \"email\": \"prashanthganathe@gmail.com\",\r\n  \"password\": \"Test123!\"\r\n}", ParameterType.RequestBody);
        //    IRestResponse response = client.Execute(request);
        //    Console.WriteLine(response.Content);
        //}


        //public async Task<string> GetWeatherList()
        //{
        //    var client = new RestClient("https://localhost:44372/api/WeatherForecast");
        //    client.Timeout = -1;
        //    var request = new RestRequest(Method.GET);
        //    request.AddHeader("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoicHJhc2hhbnRoIiwianRpIjoiNGJhNGMxNzYtOGU2NS00NTFjLTgxYTktNmNlNmY3NTRlMWM4IiwiZXhwIjoxNjQ3NjEzMzYwLCJpc3MiOiJodHRwczovL2xvY2FsaG9zdDo1MDAwIiwiYXVkIjoiaHR0cDovL2xvY2FsaG9zdDo0MDAwIn0.yIwzUQBCxDxW8VFrOfMjKCxd4yao2LyetacxgJdgrGM");
        //    request.AddParameter("text/plain", "", ParameterType.RequestBody);
        //    IRestResponse response = client.Execute(request);
        //    Console.WriteLine(response.Content);
        //}
    }
}
