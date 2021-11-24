using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using GamingWorld.API;
using GamingWorld.API.Security.Resources;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using SpecFlow.Internal.Json;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Xunit;

namespace GamingWorldBackEnd.Tests
{
    [Binding]
    public class PostUsersServiceStepsDefinition
    {
        
        private readonly WebApplicationFactory<Startup> _factory;
        private HttpClient _client;
        private Uri _baseUri;
        private Task<HttpResponseMessage> Response { get; set; }

        public PostUsersServiceStepsDefinition(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }
        
        [Given(@"the endpoint http://localhost:(.*)/api/v(.*)/users is available")]
        public void GivenTheEndpointHttpLocalhostApiVUsersIsAvailable(int port, int version)
        {
            _baseUri = new Uri($"https://localhost:{port}/api/v{version}/users");
            _client = _factory.CreateClient(new WebApplicationFactoryClientOptions {BaseAddress = _baseUri});
        }

        [When(@"a POST Request is sent")]
        public void WhenApostRequestIsSent(Table saveUserResource)
        {
            var resource = saveUserResource.CreateSet<SaveUserResource>().First();
            var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
            Response = _client.PostAsync(_baseUri, content);
        }
        
        [Then(@"a Response With Status (.*) is received")]
        public void ThenAResponseIsReceivedWithStatus(int expectedStatus)
        {
            var expectedStatusCode3 = ((HttpStatusCode) expectedStatus).ToString();
            var actualStatusCode3 = Response.Result.StatusCode.ToString();
            Assert.Equal(expectedStatusCode3, actualStatusCode3);
        }

        [Then(@"a User Resource is included in the response body\.")]
        public async void ThenAUserResourceIsIncludedInTheResponseBody(Table expectedUserResource)
        {
            var expectedResource = expectedUserResource.CreateSet<UserResource>().First();
            var responseData = await Response.Result.Content.ReadAsStringAsync();
            var resource = JsonConvert.DeserializeObject<UserResource>(responseData);
            expectedResource.Id = resource.Id;
            var jsonExpectedResource = expectedResource.ToJson();
            var jsonActualResource = resource.ToJson();
            Assert.Equal(jsonExpectedResource, jsonActualResource);
        }
    }
}