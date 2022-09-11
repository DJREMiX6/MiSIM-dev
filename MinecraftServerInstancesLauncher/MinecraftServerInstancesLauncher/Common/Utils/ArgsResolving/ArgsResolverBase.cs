using System.CommandLine;
using System.CommandLine.Parsing;
using System.CommandLine.Invocation;

namespace MinecraftServerInstancesLauncher.Common.Utils.ArgsResolving
{
    /// <summary>
    /// Holds all the methods to wrap the <c>System.CommandLine</c> dependency.
    /// </summary>
    public abstract class ArgsResolverBase
    {

        #region INTERNAL FIELDS

        internal RootCommand _rootCommand { get; set; }
        internal ParseResult _parseResult { get; set; }
        internal IEnumerable<Option> _options { get; set; }
        internal string[] _args { get; set; }

        #endregion INTERNAL FIELDS

        #region CTORS

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

        #endregion CTORS

        #region PRIVATE METHODS

        /// <summary>
        /// RootCommand handler to parse the application arguments results.
        /// </summary>
        private void SetParseResult(InvocationContext context) => _parseResult = context.ParseResult;

        #endregion PRIVATE METHODS

        #region PUBLIC METHODS

        /// <summary>
        /// Adds an <c>OptionWrapper</c>.
        /// </summary>
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

        #endregion PUBLIC METHODS

        #region PUBLIC ABSTRACT METHODS

        /// <summary>
        /// Resolves the application arguments.
        /// </summary>
        /// <returns>Returns itself to chain the methods.</returns>
        public abstract ArgsResolverBase Resolve();
        /// <summary>
        /// Asynchronously resolves the application arguments.
        /// </summary>
        /// <returns>Returns itself to chain the methods.</returns>
        public abstract Task<ArgsResolverBase> ResolveAsync();
        /// <summary>
        /// Outs an application argument option value based on its name.
        /// </summary>
        /// <returns>Returns itself to chain the methods.</returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="InvalidDataException"></exception>
        public abstract ArgsResolverBase GetResultChain<T>(string optionName, out T? result);
        /// <summary>
        /// Gets an application argument option value based on its name.
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="InvalidDataException"></exception>
        public abstract T GetResult<T>(string optionName);

        #endregion PUBLIC ABSTRACT METHODS

    }
}
