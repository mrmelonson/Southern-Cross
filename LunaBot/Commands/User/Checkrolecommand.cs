using Discord.WebSocket;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using LunaBot.ServerUtilities;

namespace LunaBot.Commands
{
    [LunaBotCommand("Checkrole")]
    class CheckroleCommand : BaseCommand
    {
        public override async Task ProcessAsync(SocketMessage message, string[] parameters)
        {

            if (parameters.Length == 0)
            {
                Logger.Verbose(message.Author.Username, "Failed checkrole command");
                await message.Channel.SendMessageAsync("Error: Wrong syntax, try kcheckrole `role`.");

                return;
            }

            string roleName = string.Join(" ", parameters).ToLower();

            SocketGuildChannel guildChannel = message.Channel as SocketGuildChannel;
            List<SocketRole> roles = guildChannel.Guild.Roles.ToList();

            try
            {
                Predicate<SocketRole> roleFinder = (SocketRole sr) => { return sr.Name.ToLower() == roleName; };
                SocketRole role = roles.Find(roleFinder);

                await message.Channel.SendMessageAsync($"Role `{role.Name}` exists.");
                Logger.Verbose(message.Author.Username, $"Exists: {role.Name}");
            }
            catch (Exception e)
            {
                await message.Channel.SendMessageAsync($"Role `{roleName}` does not exist.");
                Logger.Verbose(message.Author.Username, $"Does not exist: {roleName}");
            }
        }
    }
}