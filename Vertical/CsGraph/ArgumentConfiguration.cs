using System;
using Vertical.CommandLine.Configuration;

namespace Vertical.CsGraph
{
    public class ArgumentConfiguration : ApplicationConfiguration<Options>
    {
        public ArgumentConfiguration(Action<Options> run)
        {
            PositionArgument(arg => arg.MapMany.ToCollection(opt => opt.SourceDirectories));

            Switch("--packages", sw => sw.Map.ToProperty(opt => opt.Packages));
            Switch("--paths", sw => sw.Map.ToProperty(opt => opt.Paths));
            Switch("--projects", sw => sw.Map.ToProperty(opt => opt.Projects));
            
            OnExecute(run);
        }
    }
}