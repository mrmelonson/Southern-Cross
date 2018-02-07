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
    [LunaBotCommand("Unmute")]
    class UnmuteCommand : BaseCommand
    {
        public override async Task ProcessAsync(SocketMessage message, string[] parameters)
        {
            UserIds userIds = JsonConvert.DeserializeObject<UserIds>(File.ReadAllText(@"C:\Constants.json"));

            ulong userId = message.Author.Id;
            foreach (ulong mod in userIds.Mods)
            {
                if (userId == mod)
                {
                    // Check if command params are correct.
                    if (parameters.Length != 1)
                    {
                        Logger.Verbose(message.Author.Username, "Failed unmute command");
                        await message.Channel.SendMessageAsync("Error: Wrong syntax, try kunmute [user].");

                        return;
                    }

                    // Check if user attached is correct.
                    if (message.MentionedUsers.Count() == 0)
                    {
                        Logger.Verbose(message.Author.Username, "Failed unmute command");
                        await message.Channel.SendMessageAsync($"Error: No user mentioned, try kunmute [user].");

                        return;
                    }

                    ulong user = message.MentionedUsers.FirstOrDefault().Id;

                    SocketGuildChannel guildChannel = message.Channel as SocketGuildChannel;
                    List<SocketRole> roles = guildChannel.Guild.Roles.ToList();

                    try
                    {
                        Predicate<SocketRole> roleFinder = (SocketRole sr) => { return sr.Name.ToLower() == "mute"; };
                        SocketRole role = roles.Find(roleFinder);

                        await guildChannel.GetUser((ulong)user).RemoveRoleAsync(role);

                        await message.Channel.SendMessageAsync($"<@{user}>, You have been unmuted.");
                        Logger.Warning(message.Author.Username, $"Has been unmuted");
                    }
                    catch (Exception e)
                    {
                        await message.Channel.SendMessageAsync($"<@{user}>, Sorry, either you mis-spelt the role or i dont have permission to remove that role.");
                        Logger.Warning(message.Author.Username, $"Command failed: {e.Message}");
                    }

                    return;
                }
            }

            Logger.Warning(message.Author.Username, "Tried to use unmute command");
            await message.Channel.SendMessageAsync("Sorry you do not have permission to use this command");

            return;
        }
    }
}