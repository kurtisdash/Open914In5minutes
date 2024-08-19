using Exiled.API.Interfaces;

namespace Open914After5Minutes
{
    public sealed class Config : IConfig
    {
        /// <inheritdoc/>
        public bool IsEnabled { get; set; } = true;

        /// <inheritdoc />
        public bool Debug { get; set; }
    }
}
