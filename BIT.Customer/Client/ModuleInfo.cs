using Oqtane.Models;
using Oqtane.Modules;

namespace BIT.Customer
{
    public class ModuleInfo : IModule
    {
        public ModuleDefinition ModuleDefinition => new ModuleDefinition
        {
            Name = "Customer",
            Description = "Customer",
            Version = "1.0.0",
            ServerManagerType = "BIT.Customer.Manager.CustomerManager, BIT.Customer.Server.Oqtane",
            ReleaseVersions = "1.0.0",
            Dependencies = "BIT.Customer.Shared.Oqtane"
        };
    }
}
