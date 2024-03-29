﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace GamingWorldBackEnd.Tests.UserProfiles
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class PostUserProfilesServiceTestFeature : object, Xunit.IClassFixture<PostUserProfilesServiceTestFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "PostUserProfileServiceTests.feature"
#line hidden
        
        public PostUserProfilesServiceTestFeature(PostUserProfilesServiceTestFeature.FixtureData fixtureData, GamingWorldBackEnd_Tests_XUnitAssemblyFixture assemblyFixture, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "UserProfiles", "PostUserProfilesServiceTest", "As a developer\r\nI want to post a user profile through an API\r\nSo that i dont have" +
                    " to manually create one in the database.", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void TestInitialize()
        {
        }
        
        public virtual void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void FeatureBackground()
        {
#line 7
#line hidden
#line 9
testRunner.Given("the endpoint http://localhost:5000/api/v1/userprofiles is available", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
        }
        
        void System.IDisposable.Dispose()
        {
            this.TestTearDown();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Create Profile")]
        [Xunit.TraitAttribute("FeatureTitle", "PostUserProfilesServiceTest")]
        [Xunit.TraitAttribute("Description", "Create Profile")]
        [Xunit.TraitAttribute("Category", "Profile_Creation")]
        public virtual void CreateProfile()
        {
            string[] tagsOfScenario = new string[] {
                    "Profile_Creation"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create Profile", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 11
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 7
this.FeatureBackground();
#line hidden
                TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                            "userId",
                            "gamingLevel",
                            "isStreamer",
                            "gameExperiences",
                            "streamingCategories",
                            "streamerSponsors",
                            "tournamentExperiences",
                            "favoriteGames"});
                table3.AddRow(new string[] {
                            "1",
                            "medium",
                            "false",
                            "Array",
                            "Array",
                            "Array",
                            "Array",
                            "Array"});
#line 13
testRunner.When("a POST Request is sent with this body", ((string)(null)), table3, "When ");
#line hidden
#line 17
testRunner.Then("a Response with Status 200 is received", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                            "id",
                            "userId",
                            "gamingLevel",
                            "isStreamer",
                            "gameExperiences",
                            "streamingCategories",
                            "streamerSponsors",
                            "tournamentExperiences",
                            "favoriteGames"});
                table4.AddRow(new string[] {
                            "1",
                            "1",
                            "medium",
                            "false",
                            "Array",
                            "Array",
                            "Array",
                            "Array",
                            "Array"});
#line 18
testRunner.And("a UserProfile resource is included in the response body.", ((string)(null)), table4, "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                PostUserProfilesServiceTestFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                PostUserProfilesServiceTestFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
