using System.CommandLine;
using System.CommandLine.Parsing;

namespace MinecraftServerInstancesLauncher.Common.Utils.ArgsResolving
{
    /// <summary>
    /// Holds all the methods to manage the application arguments. Wrapper for <c>System.CommandLine</c> .
    /// </summary>
    public class ArgsResolver : ArgsResolverBase
    {

        #region CTORS

        public ArgsResolver(string ApplicationName, IEnumerable<Option> options, string[] args) : base(ApplicationName, options, args)
        { }

        public ArgsResolver(string ApplicationName, string[] args) : base(ApplicationName, args)
        { }

        #endregion CTORS

        #region PUBLIC OVERRIDE METHODS

        /// <summary>
        /// Resolves the application arguments.
        /// </summary>
        /// <returns>Returns itself to chain the methods.</returns>
        public override ArgsResolverBase Resolve()
        {
            _rootCommand.Invoke(_args);
            return this;
        }

        /// <summary>
        /// Asynchronously resolves the application arguments.
        /// </summary>
        /// <returns>Returns itself to chain the methods.</returns>
        public override async Task<ArgsResolverBase> ResolveAsync()
        {
            await _rootCommand.InvokeAsync(_args);
            return this;
        }

        /// <summary>
        /// Outs an application argument option value based on its name.
        /// </summary>
        /// <returns>Returns itself to chain the methods.</returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="InvalidDataException"></exception>
        public override ArgsResolverBase GetResultChain<T>(string optionName, out T? result) where T : default
        {
            if (_parseResult is null)
            {
                result = default(T);
                return this;
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

            result = _parseResult.GetValueForOption(option);
            return this;
        }

        /// <summary>
        /// Gets an application argument option value based on its name.
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="InvalidDataException"></exception>
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

        #endregion PUBLIC OVERRIDE METHODS

    }
}
