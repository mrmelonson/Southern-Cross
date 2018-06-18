using Discord;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace LunaBot.ServerUtilities
{
    class IsModeratorHelper
    {
        public static bool IsModerator(SocketGuildUser user)
        {
            
            List<SocketRole> roles = user.Roles.ToList();

            foreach (SocketRole role in roles)
            {
                if (role.Id == Roles.ModeratorID)
                {
                    return true;
                }
                if (role.Id == Roles.AdminID)
                {
                    return true;
                }
                if (role.Id == Roles.BossID)
                {
                    return true;
                }
                if (role.Id == Roles.HelperID)
                {
                    return true;
                }
            }

            return false;

        }
    }
}
