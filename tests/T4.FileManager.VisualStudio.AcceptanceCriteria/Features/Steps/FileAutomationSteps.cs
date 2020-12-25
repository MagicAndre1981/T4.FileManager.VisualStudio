﻿namespace T4.FileManager.VisualStudio.AcceptanceCriteria.Features.Steps
{
    using System.Collections.Generic;
    using System.IO;

    using EnvDTE;

    using FluentAssertions;

    using T4.FileManager.VisualStudio.AcceptanceCriteria.Features.Dto;
    using T4.FileManager.VisualStudio.AcceptanceCriteria.Features.Helper;

    using TechTalk.SpecFlow;

    [Binding]
    public class FileAutomationSteps
    {
        private string projectName = "T4.FileManager.VisualStudio.AcceptanceCriteria";
        private string pathTestEnvironment;
        private ProjectItem t4Template;
        private string targetTestPath;
        private IList<GeneratedFile> files;
        private string currentTesteeFilePath;

        [Given(@"the file manager")]
        public void GivenTheFileManager()
        {
            this.pathTestEnvironment =
                VisualStudioHelper.GetProjectDirectory("T4.FileManager.VisualStudio.AcceptanceCriteria");
            var pathSource = Path.Combine(pathTestEnvironment, "..\\..\\", "src\\");

            var fileManagerFromSource = Path.Combine(pathSource, "T4.FileManager.VisualStudio.ttinclude");
            var fileManagerForTest = Path.Combine(this.pathTestEnvironment, "T4.FileManager.VisualStudio.ttinclude");

            File.Copy(fileManagerFromSource, fileManagerForTest, true);

            this.targetTestPath = this.pathTestEnvironment;
        }

        [Given(@"for target project ""(.*)"" to generate files")]
        public void GivenTargetProjectForToGenerateFiles(string name)
        {
            this.projectName = name;
            this.targetTestPath = Path.Combine(this.targetTestPath, "..\\", this.projectName);
        }

        [Given(@"the script ""(.*)"" with following content for automation")]
        public void GivenTheScriptWithFollowingContentForAutomation(string filename, string templateContent)
        {
            this.currentTesteeFilePath = Path.Combine(this.pathTestEnvironment, filename);
            File.WriteAllText(this.currentTesteeFilePath, templateContent);

            this.t4Template = VisualStudioHelper.AddFileToProject(
                this.projectName,
                this.currentTesteeFilePath);
        }

        [Given(@"the script ""(.*)"" modified by following content:")]
        public void GivenTheScriptModifiedByFollowingContent(string filename, string templateContent)
        {
            var file = Path.Combine(this.pathTestEnvironment, filename);

            VisualStudioHelper.RemoveFileFromProject(file);

            File.WriteAllText(file, templateContent);

            this.t4Template = VisualStudioHelper.AddFileToProject(
                this.projectName,
                file);
        }

        [Given(@"i change the line")]
        public void GivenIChangeTheLine(IList<TemplateChanges> changes)
        {
            var template = File.ReadAllText(this.currentTesteeFilePath);
            foreach (var change in changes)
            {
                template = template.Replace(change.From, change.To);
            }

            this.GivenTheScriptModifiedByFollowingContent(this.currentTesteeFilePath, template);
        }

        [Given(@"i run the script for automation")]
        [When(@"i run the script for automation again")]
        [When(@"i run the script for automation")]
        public void WhenIRunTheScriptForAutomation()
        {
            VisualStudioHelper.SaveFileAutomaticallyRunCustomTool(this.t4Template);
        }

        [Given(@"following files are generated:")]
        [Then(@"following files are generated:")]
        [Then(@"following files exists:")]
        public void ThenFollowingFilesExists(IList<GeneratedFile> files)
        {
            foreach (var file in files)
            {
                var testee = file.GetFullPath(this.targetTestPath);

                if (string.IsNullOrWhiteSpace(file.ContainsContent) == false)
                {
                    var testeeContent = File.ReadAllText(testee);
                    testeeContent.Should().Contain(file.ContainsContent);
                }

                File.Exists(testee).Should().BeTrue();
            }

            this.files = files;
        }

        [Then(@"the following files no longer exist:")]
        [Then(@"following files are cleaned up:")]
        public void ThenFollowingFilesNotExists(IList<GeneratedFile> files)
        {
            foreach (var file in files)
            {
                var testee = file.GetFullPath(this.targetTestPath);

                File.Exists(testee).Should().BeFalse();
            }
        }

        [Then(@"custom tool is set to ""(.*)"" for following files:")]
        public void ThenCustomToolIsSet(string customTool, IList<GeneratedFile> files)
        {
            foreach (var testee in files)
            {
                VisualStudioHelper.GetCustomToolByFileName(testee.Name, this.projectName).Should().Be(customTool);
            }
        }

        [Then(@"all files contains following content:")]
        public void ThenAllFilesContainsFollowingContent(string content)
        {
            foreach (var file in this.files)
            {
                var filePath = file.GetFullPath(this.targetTestPath);
                var testee = File.ReadAllText(filePath);
                
                testee.Should().Contain(content);
            }
        }
    }
}