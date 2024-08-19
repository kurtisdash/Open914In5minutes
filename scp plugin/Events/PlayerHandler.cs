using Exiled.Events.EventArgs.Player;
using Exiled.API.Features;
using MEC;
using PlayerRoles;
using Exiled.API.Enums;
using Exiled.API.Features.Doors;
using System.Collections.Generic;
using System.Linq;

namespace Open914After5Minutes.Events
{
    internal sealed class PlayerHandler
    {
        /// <inheritdoc cref="Exiled.Events.Handlers.Player.OnChangingRole(ChangingRoleEventArgs)"/>
        /// 

        bool is079Alive = false;

        public void OnChangingRole(ChangingRoleEventArgs ev)
        {
            //Log.Info("someone changed their role!");
        }    
    }
}
