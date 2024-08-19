using Exiled.API.Enums;
using Exiled.API.Features.Doors;
using Exiled.API.Features;
using Open914After5Minutes.Events;
using Exiled.CustomRoles.Events;

namespace Open914After5Minutes
{
    public class Open914After5Minutes : Plugin<Config>
    {
        private static readonly Open914After5Minutes Singleton = new();

        private ServerHandler serverHandler;
        private PlayerHandler playerHandler;

        public static Open914After5Minutes Instance => Singleton;

        /// <inheritdoc/>
        public override PluginPriority Priority { get; } = PluginPriority.Last;

        /// <inheritdoc/>
        public override void OnEnabled()
        {
            RegisterEvents();

            base.OnEnabled();
        }

        /// <inheritdoc/>
        public override void OnDisabled()
        {

            Log.Warn("ron is a fatass");
            UnregisterEvents();

            base.OnDisabled();
        }

        private void RegisterEvents()
        {
            serverHandler = new ServerHandler();
            playerHandler = new PlayerHandler();
            Exiled.Events.Handlers.Server.RoundStarted += serverHandler.OnRoundStarted;
            Exiled.Events.Handlers.Player.ChangingRole += playerHandler.OnChangingRole;


        }

        private void UnregisterEvents()
        {
            Exiled.Events.Handlers.Server.RoundStarted -= serverHandler.OnRoundStarted;
            Exiled.Events.Handlers.Player.ChangingRole += playerHandler.OnChangingRole;
            serverHandler = null;
            playerHandler = null;
        }
        //private Open914After5Minutes() { }




    }
}