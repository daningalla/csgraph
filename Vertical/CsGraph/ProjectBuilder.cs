using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;

namespace Vertical.CsGraph
{
    public static class ProjectBuilder
    {
        public static Project BuildFromPath(string path)
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.Load(path);
            
            return new Project
            {
                Path = path,
                PackageName = GetResolvedProjectName(path, xmlDocument),
                Dependencies = BuildDependencies(xmlDocument).ToArray()
            };
        }

        private static IEnumerable<string> BuildDependencies(XmlDocument xmlDocument)
        {
            return xmlDocument
                .SelectNodes("Project/ItemGroup/PackageReference")
                .Cast<XmlElement>()
                .Select(element => element.GetAttribute("Include"));
        }

        private static string GetResolvedProjectName(string path, XmlDocument xmlDocument)
        {
            var packageIdNode = xmlDocument.SelectSingleNode("Project/PropertyGroup/PackageId");

            return packageIdNode != null ? packageIdNode.InnerText : Path.GetFileNameWithoutExtension(path);
        }
    }
}