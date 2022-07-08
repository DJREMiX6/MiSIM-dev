using System.CommandLine;
using System.CommandLine.Parsing;
using System.CommandLine.Invocation;

namespace MinecraftServerInstancesLauncher.Common.Utils.ArgsResolving
{
    public abstract class ArgsResolverBase
    {

        internal RootCommand _rootCommand { get; set; }
        internal ParseResult _parseResult { get; set; }
        internal IEnumerable<Option> _options { get; set; }
        internal string[] _args { get; set; }

        private void SetParseResult(InvocationContext context) => _parseResult = context.ParseResult;

        public ArgsResolverBase(string ApplicationName, IEnumerable<Option> options, string[] args)
        {
            _options = options;
            _args = args;
            _rootCommand = new RootCommand(ApplicationName);
            foreach (Option opt in options)
            {
                _rootCommand.AddOption(opt);
            }
            _rootCommand.SetHandler(SetParseResult);
        }

        public ArgsResolverBase(string ApplicationName, string[] args)
        {
            _args = args;
            _rootCommand = new RootCommand(ApplicationName);
            _rootCommand.SetHandler(SetParseResult);
        }

        public ArgsResolverBase AddOptionChain<T>(OptionWrapper<T> option)
        {
            AddOption(option);
            return this;
        }
        
        public void AddOption<T>(OptionWrapper<T> option)
        {
            _rootCommand.AddOption(option);
            if(_options is null)
            {
                _options = new Option[] { option };
                return;
            }
            _options = _options.Concat(new Option[] { option });
        }
        
        public abstract ArgsResolverBase Resolve();
        public abstract Task<ArgsResolverBase> ResolveAsync();
        public abstract ArgsResolverBase GetResultChain<T>(string optionName, out T? result);
        public abstract T GetResult<T>(string optionName);
    }
}
