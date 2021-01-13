using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;

namespace APITestProj
{
    [TestFixture]
    public class MyFirstTest
    {
        [Test]
        public void ValidateGetBookingRequest()
        {
            string myBookingId = "10";
            //create client connection
            //RestClient restClient = new RestClient("https://restful-booker.herokuapp.com/booking/10");
            RestClient restClient = new RestClient($"https://restful-booker.herokuapp.com/booking/{myBookingId}");

            //create request get data
            RestRequest restRequest = new RestRequest(Method.GET);

            //execute request to server
            IRestResponse restResponse = restClient.Execute(restRequest.AddHeader("Accept", "application/json"));

            //extract data from response
            var response = restResponse.Content;

            //assert            
            Assert.IsTrue(response.Contains("Sally"));
        }

        [Test]
        public void ValidatePostRequest()
        {
            //create client connection
            RestClient restClient = new RestClient("https://restful-booker.herokuapp.com/auth");
            JObject objectBody = new JObject();
            objectBody.Add("username", "admin");
            objectBody.Add("password", "password123");

            //create request post data
            RestRequest restRequest = new RestRequest(Method.POST);
            restRequest.AddParameter("application/json", objectBody, ParameterType.RequestBody);

            //execute request to server
            IRestResponse response = restClient.Execute(restRequest);

            //assert            
            Assert.IsTrue(response.Content.Contains("token"));
            Assert.AreEqual(response.StatusCode.ToString(),"OK");
            Assert.AreEqual((int)response.StatusCode,200);

            //
            //restRequest.RequestFormat = DataFormat.Json;
            //restRequest.AddBody();

        }
    }
}
