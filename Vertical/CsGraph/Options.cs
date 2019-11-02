using System.Collections.Generic;

namespace Vertical.CsGraph
{
    /// <summary>
    /// Defines the application options.
    /// </summary>
    public class Options 
    {
        /// <summary>
        /// Gets/sets the source directory
        /// </summary>
        public List<string> SourceDirectories { get; } = new List<string>(6);
        
        /// <summary>
        /// Gets/sets option to output names
        /// </summary>
        public bool Packages { get; set; }
        
        /// <summary>
        /// Gets/sets option to output project directory paths
        /// </summary>
        public bool Paths { get; set; }
        
        /// <summary>
        /// Gets/sets option to output project file paths
        /// </summary>
        public bool Projects { get; set; }
    }
}