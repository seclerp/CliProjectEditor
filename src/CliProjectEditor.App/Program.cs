using System.Collections.Generic;
using Microsoft.Build.Evaluation;
using Microsoft.Build.Locator;

namespace CliProjectEditor.App
{
    class Program
    {
        static void Main(string[] args)
        {
            MSBuildLocator.RegisterDefaults();
            Execute(args);
        }

        // Code should be called in separate method from where MSBuildLocator.RegisterDefaults is called
        // see aka.ms/MSBuildLocator
        private static void Execute(IReadOnlyList<string> args)
        {
            var project = ProjectCollection.GlobalProjectCollection.LoadProject(args[0]);
            project.SetProperty(args[1], args[2]);
            project.Save();
            ProjectCollection.GlobalProjectCollection.UnloadProject(project);
        }
    }
}
