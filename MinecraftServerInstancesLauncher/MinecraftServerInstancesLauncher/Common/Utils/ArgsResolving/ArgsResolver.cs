using System.CommandLine;
using System.CommandLine.Parsing;

namespace MinecraftServerInstancesLauncher.Common.Utils.ArgsResolving
{
    public class ArgsResolver : ArgsResolverBase
    {

        public ArgsResolver(string ApplicationName, IEnumerable<Option> options, string[] args) : base(ApplicationName, options, args)
        { }

        public ArgsResolver(string ApplicationName, string[] args) : base(ApplicationName, args)
        { }

        public override ArgsResolverBase Resolve()
        {
            _rootCommand.Invoke(_args);
            return this;
        }

        public override async Task<ArgsResolverBase> ResolveAsync()
        {
            await _rootCommand.InvokeAsync(_args);
            return this;
        }

        public override T GetResult<T>(string optionName) where T : default
        {
            if (_parseResult is null)
            {
                return default(T);
            }
            Option<T>? option = (Option<T>?)_options.FirstOrDefault(opt => opt.Name == optionName);
            if (option == null)
            {
                throw new ArgumentException($"No Option find with {optionName} name.");
            }
            if (_parseResult.Errors.Count > 0)
            {
                throw new InvalidDataException("Errors while parsing data from command line.");
            }

            return _parseResult.GetValueForOption<T>(option);
        }

        public override ArgsResolverBase GetResultChain<T>(string optionName, out T? result) where T : default
        {
            if(_parseResult is null)
            {
                result = default(T);
                return this;
            }
            Option<T>? option = (Option<T>?)_options.FirstOrDefault(opt => opt.Name == optionName);
            if(option == null)
            {
                throw new ArgumentException($"No Option find with {optionName} name.");
            }
            if (_parseResult.Errors.Count > 0)
            {
                throw new InvalidDataException("Errors while parsing data from command line.");
            }
            
            result = _parseResult.GetValueForOption(option);
            return this;
        }
    }
}
