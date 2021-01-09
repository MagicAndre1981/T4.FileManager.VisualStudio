﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.5.0.0
//      SpecFlow Generator Version:3.5.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace T4.FileManager.VisualStudio.AcceptanceCriteria.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.5.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [TechTalk.SpecRun.FeatureAttribute("UT013 Generate File without modifications", new string[] {
            "db-127"}, Description="\tAs a developer\r\n\tI can generate code with the T4.FileManager and supress changes" +
        " if the file exist", SourceFile="Features\\UT013_Generate_File_Without_Modifications.feature", SourceLine=1)]
    public partial class UT013GenerateFileWithoutModificationsFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = new string[] {
                "db-127"};
        
#line 1 "UT013_Generate_File_Without_Modifications.feature"
#line hidden
        
        [TechTalk.SpecRun.FeatureInitialize()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "UT013 Generate File without modifications", "\tAs a developer\r\n\tI can generate code with the T4.FileManager and supress changes" +
                    " if the file exist", ProgrammingLanguage.CSharp, new string[] {
                        "db-127"});
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [TechTalk.SpecRun.FeatureCleanup()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void TestInitialize()
        {
        }
        
        [TechTalk.SpecRun.ScenarioCleanup()]
        public virtual void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
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
#line 6
#line hidden
#line 7
 testRunner.Given("the file manager", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 8
 testRunner.And("the script \"TestNoDelete.tt\" with the following content", @"<#@ template debug=""false"" hostspecific=""true"" language=""C#"" #>
<#@ assembly name=""System.Core"" #>
<#@ import namespace=""System.Linq"" #>
<#@ import namespace=""System.Text"" #>
<#@ import namespace=""System.Collections.Generic"" #>
<#@ output extension="".txt"" #>

<#@ include file=""$(ProjectDir)\T4.FileManager.VisualStudio.ttinclude"" #>

<#
var fileManager = T4FileManager.Create(this);
fileManager.CanOverwriteExistingFile = false;
fileManager.CreateNewFile(""TestNoDelete.g.cs"","""",""TestOverwrite"",null);	
#>
namespace Test
{
public class TestNoDelete
{
// first run template
}
}
<#
fileManager.Generate();
#>", ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("No files deleted if CanOverwriteExistingFile is set to false", SourceLine=35)]
        public virtual void NoFilesDeletedIfCanOverwriteExistingFileIsSetToFalse()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("No files deleted if CanOverwriteExistingFile is set to false", null, tagsOfScenario, argumentsOfScenario);
#line 36
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
#line 6
this.FeatureBackground();
#line hidden
#line 37
 testRunner.Given("I run the script", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table16 = new TechTalk.SpecFlow.Table(new string[] {
                            "File",
                            "Folder"});
                table16.AddRow(new string[] {
                            "TestNoDelete.g.cs",
                            "TestOverwrite"});
#line 38
 testRunner.And("the following files are generated:", ((string)(null)), table16, "And ");
#line hidden
                TechTalk.SpecFlow.Table table17 = new TechTalk.SpecFlow.Table(new string[] {
                            "From",
                            "To"});
                table17.AddRow(new string[] {
                            "fileManager.CreateNewFile(\"TestNoDelete.g.cs\",\"\",\"TestOverwrite\",null);",
                            "fileManager.CreateNewFile(\"TestNoDelete2.g.cs\",\"\",\"TestOverwrite\",null);"});
                table17.AddRow(new string[] {
                            "public class TestNoDelete",
                            "public class TestNoDelete2"});
#line 41
 testRunner.And("I change the line", ((string)(null)), table17, "And ");
#line hidden
#line 45
 testRunner.When("I run the script", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
                TechTalk.SpecFlow.Table table18 = new TechTalk.SpecFlow.Table(new string[] {
                            "File",
                            "Folder"});
                table18.AddRow(new string[] {
                            "TestNoDelete.g.cs",
                            "TestOverwrite"});
                table18.AddRow(new string[] {
                            "TestNoDelete2.g.cs",
                            "TestOverwrite"});
#line 46
 testRunner.Then("the following files are generated:", ((string)(null)), table18, "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("No content changes if CanOverwriteExistingFile is set to false", SourceLine=51)]
        public virtual void NoContentChangesIfCanOverwriteExistingFileIsSetToFalse()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("No content changes if CanOverwriteExistingFile is set to false", null, tagsOfScenario, argumentsOfScenario);
#line 52
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
#line 6
this.FeatureBackground();
#line hidden
#line 53
 testRunner.Given("I run the script", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table19 = new TechTalk.SpecFlow.Table(new string[] {
                            "File",
                            "Folder"});
                table19.AddRow(new string[] {
                            "TestNoDelete.g.cs",
                            "TestOverwrite"});
#line 54
 testRunner.And("the following files are generated:", ((string)(null)), table19, "And ");
#line hidden
                TechTalk.SpecFlow.Table table20 = new TechTalk.SpecFlow.Table(new string[] {
                            "From",
                            "To"});
                table20.AddRow(new string[] {
                            "// first run template",
                            "// second run template"});
#line 57
 testRunner.And("I change the line", ((string)(null)), table20, "And ");
#line hidden
#line 60
 testRunner.When("I run the script", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
                TechTalk.SpecFlow.Table table21 = new TechTalk.SpecFlow.Table(new string[] {
                            "File",
                            "Contains",
                            "Folder"});
                table21.AddRow(new string[] {
                            "TestNoDelete.g.cs",
                            "// first run template",
                            "TestOverwrite"});
#line 61
 testRunner.Then("the following files are generated:", ((string)(null)), table21, "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion