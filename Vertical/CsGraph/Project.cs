namespace Vertical.CsGraph
{
    public class Project
    {
        public string Path { get; set; }
        
        public string PackageName { get; set; }
        
        public string[] Dependencies { get; set; }
    }
}