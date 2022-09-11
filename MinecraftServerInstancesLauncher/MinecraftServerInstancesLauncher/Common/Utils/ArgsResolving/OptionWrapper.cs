using System.CommandLine;

namespace MinecraftServerInstancesLauncher.Common.Utils.ArgsResolving
{
    /// <summary>
    /// Wrapper class for <c>System.CommandLine Option</c>.
    /// </summary>
    public class OptionWrapper<T> : Option<T>
    {
        public OptionWrapper(string name, string? description = null) : base(name, description)
        { }
        
        public OptionWrapper(string[] aliases, string? description = null) : base(aliases, description)
        { }
        
        public OptionWrapper(string name, Func<T> getDefaultValue, string? description = null) : base(name, getDefaultValue, description)
        { }
        
        public OptionWrapper(string[] aliases, Func<T> getDefaultValue, string? description = null) : base(aliases, getDefaultValue, description)
        { }
    }
}
