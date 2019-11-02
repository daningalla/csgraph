using System;
using System.IO;
using System.Linq;
using Vertical.CommandLine;

namespace Vertical.CsGraph
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            CommandLineApplication.Run(new ArgumentConfiguration(Run), args);
        }

        private static void Run(Options options)
        {
            var projects = options
                .SourceDirectories
                .SelectMany(path => Directory.EnumerateFiles(path, "*.csproj", SearchOption.AllDirectories))
                .Select(ProjectBuilder.BuildFromPath);

            foreach (var project in new ProjectBuildCollection(projects))
            {
                if (options.Packages)
                {
                    Console.WriteLine(project.PackageName);
                }
                else if (options.Paths)
                {
                    Console.WriteLine(Path.GetDirectoryName(project.Path));
                }
                else
                {
                    Console.WriteLine(project.Path);
                    
                }
            }
        }
    }
}