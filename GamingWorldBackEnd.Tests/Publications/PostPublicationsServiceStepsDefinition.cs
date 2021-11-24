using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using GamingWorld.API;
using GamingWorld.API.Publications.Resources;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using SpecFlow.Internal.Json;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Xunit;

namespace GamingWorldBackEnd.Tests
{
    [Binding]
    public class PublicationServiceStepsDefinition
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private HttpClient _client;
        private Uri _baseUri;
        private Task<HttpResponseMessage> Response { get; set; }
        public PublicationServiceStepsDefinition(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Given(@"the endpoint http://localhost:(.*)/api/v(.*)/publications is available")]
        public void GivenTheEndpointHttpLocalhostApiVPublicationsIsAvailable(int port, int version)
        {
            _baseUri = new Uri($"https://localhost:{port}/api/v{version}/publications");
            _client = _factory.CreateClient(new WebApplicationFactoryClientOptions {BaseAddress = _baseUri});
        }

        [When(@"a POST Request is sent with body")]
        public void WhenApostRequestIsSentWithBody(Table savePublicationResource)
        {
            var resource = savePublicationResource.CreateSet<SavePublicationResource>().First();
            var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
            Response = _client.PostAsync(_baseUri, content);
        }

        [Then(@"a Response with Status (.*) is received")]
        public void ThenAResponseWithStatusIsReceived(int expectedStatus)
        {
            var expectedStatusCode2 = ((HttpStatusCode) expectedStatus).ToString();
            var actualStatusCode2 = Response.Result.StatusCode.ToString();
            Assert.Equal(expectedStatusCode2, actualStatusCode2);
        }

        [Then(@"a Publication Resource is included in the response body\.")]
        public async void ThenAPublicationResourceIsIncludedInTheResponseBody(Table expectedPublicationResource)
        {
            var expectedResource = expectedPublicationResource.CreateSet<PublicationResource>().First();
            var responseData = await Response.Result.Content.ReadAsStringAsync();
            var resource = JsonConvert.DeserializeObject<PublicationResource>(responseData);
            expectedResource.Id = resource.Id;
            var jsonExpectedResource = expectedResource.ToJson();
            var jsonActualResource = resource.ToJson();
            Assert.Equal(jsonExpectedResource, jsonActualResource);
        }
    }
}