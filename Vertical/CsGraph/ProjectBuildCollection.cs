using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Vertical.CsGraph
{
    public class ProjectBuildCollection : IEnumerable<Project>
    {
        private readonly IDictionary<string, Project> _packageNameDictionary;
        private readonly ISet<Project> _addedHashSet = new HashSet<Project>();
        private readonly LinkedList<Project> _orderedList = new LinkedList<Project>();
        
        public ProjectBuildCollection(IEnumerable<Project> projects)
        {
            _packageNameDictionary = projects.ToDictionary(proj => proj.PackageName, StringComparer.OrdinalIgnoreCase);

            foreach (var project in _packageNameDictionary.Values)
            {
                AddProject(project);
            }
        }

        private void AddProject(Project project)
        {
            if (!_addedHashSet.Add(project))
                return;

            var node = _orderedList.AddLast(project);

            AddDependencies(node);
        }

        private void AddDependencies(LinkedListNode<Project> node)
        {
            var project = node.Value;

            foreach (var packageName in project.Dependencies)
            {
                if (!_packageNameDictionary.TryGetValue(packageName, out var dependency))
                    continue;
                
                if (!_addedHashSet.Add(dependency))
                    continue;

                var childNode = _orderedList.AddBefore(node, dependency);
                
                AddDependencies(childNode);
            }
        }

        /// <inheritdoc />
        public IEnumerator<Project> GetEnumerator() => _orderedList.GetEnumerator();

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}