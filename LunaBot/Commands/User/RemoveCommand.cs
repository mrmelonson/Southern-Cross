﻿using Discord.WebSocket;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using LunaBot.ServerUtilities;
using System.IO;
using Newtonsoft.Json;

namespace LunaBot.Commands
{
    [LunaBotCommand("Remove")]
    class RemoveCommand : BaseCommand
    {
        public override async Task ProcessAsync(SocketMessage message, string[] parameters)
        {
            UserIds userIds = JsonConvert.DeserializeObject<UserIds>(File.ReadAllText(@"C:\Constants.json"));

            if (!(message.Channel.Id == userIds.Change_Roles))
            {
                return;
            }

            if (parameters.Length == 0)
            {
                Logger.Verbose(message.Author.Username, "Failed remove command");
                await message.Channel.SendMessageAsync("Error: Wrong syntax, try kremove `role`.");

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

                await guildChannel.GetUser((ulong)user).RemoveRoleAsync(role);

                await message.Channel.SendMessageAsync($"<@{user}>, I have removed the role: {role.Name}");
                Logger.Verbose(message.Author.Username, $"Removed: {role.Name}");
            }
            catch (Exception e)
            {
                await message.Channel.SendMessageAsync($"<@{user}>, Sorry, either you mis-spelt the role or i dont have permission to remove that role.");
                Logger.Verbose(message.Author.Username, $"Command failed: {e.Message}");
            }
        }
    }
}