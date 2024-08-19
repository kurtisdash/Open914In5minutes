using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Doors;
using PlayerRoles;
using MEC;
using System.Linq;
using System.Collections.Generic;

namespace Open914After5Minutes.Events
{


    /// <summary>
    /// Handles server-related events.
    /// </summary>
    internal sealed class ServerHandler
    {
        /// <inheritdoc cref="Exiled.Events.Handlers.Server.OnRoundStarted"/>
        public void OnRoundStarted()
        {
            Log.Info("round started");
            Timing.RunCoroutine(wait5Minutes().CancelWith(Server.Host.GameObject));
        }

        public IEnumerator<float> wait5Minutes()
        {
            Log.Info("scp 079 checker started");

            //Wait for 4 min 30 secs
            yield return Timing.WaitForSeconds(270);

            //If there is no computer, notify the server that there is no computer and that 914 is opening in 30 seconds.
            if (!(Player.List.Any(player => player.Role == RoleTypeId.Scp079)))
            {
                Log.Info("There is no SCP-079 in the game.");
                Cassie.MessageTranslated(
                 "Attention all personnel . SCP 0 7 9 is offline. Sector 9 14 will open and lock in 30 seconds .",
                 "Attention all personnel: SCP-079 is offline. Sector 914 will open and lock in 30 seconds.",
                 true,
                 false,
                 true);

                //Wait for 30 more seconds to make it 5 minutes then open 914.
                yield return Timing.WaitForSeconds(30);
                Door door914 = Door.Get(DoorType.Scp914Gate);
                door914.IsOpen = true;
                door914.ChangeLock(DoorLockType.Warhead);
            }


            //If SCP-079 is in the game, don't open 914
            else
            {
                Log.Info("SCP-079 is online. 914 will remain unchanged.");
            }
        }
    }
}
