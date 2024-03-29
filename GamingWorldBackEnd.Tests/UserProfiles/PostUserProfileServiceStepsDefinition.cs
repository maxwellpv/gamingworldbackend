﻿using System;
using System.Linq;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using GamingWorld.API;
using GamingWorld.API.Profiles.Resources;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using SpecFlow.Internal.Json;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Xunit;

namespace GamingWorldBackEnd.Tests.UserProfiles
{
    [Binding]
    public class PostUserProfileServiceStepsDefinition
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private HttpClient _client;
        private Uri _baseUri;
        private Task<HttpResponseMessage> Response { get; set; }
        public PostUserProfileServiceStepsDefinition(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }
        
        [Given(@"the endpoint https://localhost:(.*)/api/v(.*)/profiles is available")]
        public void GivenTheEndpointHttpLocalhostApiVUserprofilesIsAvailable(int port, int version)
        {
            _baseUri = new Uri($"https://localhost:{port}/api/v{version}/profiles");
            _client = _factory.CreateClient(new WebApplicationFactoryClientOptions {BaseAddress = _baseUri});
        }

        [When(@"a POST Request is sent with this body")]
        public void WhenApostRequestIsSentWithThisBody(Table saveUserProfileResource)
        {
            var resource = saveUserProfileResource.CreateSet<SaveProfileResource>().First();
            var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
            Response = _client.PostAsync(_baseUri, content);
        }
        
        
        [Then(@"a UserProfile resource is included in the response body\.")]
        public async void ThenAUserProfileResourceIsIncludedInTheResponseBody(Table expectedUserProfileResource)
        {
            var expectedResource = expectedUserProfileResource.CreateSet<ProfileResource>().First();
            var responseData = await Response.Result.Content.ReadAsStringAsync();
            var resource = JsonConvert.DeserializeObject<ProfileResource>(responseData);
            expectedResource.Id = resource.Id;
            var jsonExpectedResource = expectedResource.ToJson();
            var jsonActualResource = resource.ToJson();
            Assert.Equal(jsonExpectedResource, jsonActualResource);
        }

       
    }
}