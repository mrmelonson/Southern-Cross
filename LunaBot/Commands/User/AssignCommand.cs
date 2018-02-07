using Discord.WebSocket;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using LunaBot.ServerUtilities;
using Newtonsoft.Json;
using System.IO;

namespace LunaBot.Commands
{
    [LunaBotCommand("Assign")]
    class AssignCommand : BaseCommand
    {
        public override async Task ProcessAsync(SocketMessage message, string[] parameters)
        {
            UserIds userIds = JsonConvert.DeserializeObject<UserIds>(File.ReadAllText(@"C:\Constants.json"));

            if (parameters.Length  == 0)
            {
                Logger.Verbose(message.Author.Username, "Failed assign command");
                await message.Channel.SendMessageAsync("Error: Wrong syntax, try kassign `role`.");

                return;
            }

            ulong user = message.Author.Id;

            string roleName = string.Join(" ", parameters).ToLower();

            SocketGuildChannel guildChannel = message.Channel as SocketGuildChannel;
            List<SocketRole> roles = guildChannel.Guild.Roles.ToList();

            try
            {
                Predicate<SocketRole> roleFinder = (SocketRole sr) => { return sr.Name.ToLower() == roleName; };
                SocketRole role = roles.Find(roleFinder);
                
                foreach (string ur in userIds.Roles)
                {
                    if (role.Name.ToLower() == ur.ToLower())
                    {
                        throw new Exception("Forbidden");
                    }
                }

                await guildChannel.GetUser((ulong)user).AddRoleAsync(role);

                await message.Channel.SendMessageAsync($"<@{user}>, Has been given the role: {role.Name}");
                Logger.Verbose(message.Author.Username, $"Has been given role: {role.Name}");
            }
            catch (Exception e)
            {
                await message.Channel.SendMessageAsync($"<@{user}>, Sorry, either you mis-spelt the role or i dont have permission to give you that role.");
                Logger.Verbose(message.Author.Username, $"Command failed: {e.Message}");
            }
        }
    }
}