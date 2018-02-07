﻿using Discord.WebSocket;
using LunaBot.ServerUtilities;
using LunaBot;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace LunaBot.Commands
{
    [LunaBotCommand("Mute")]
    class MuteCommand : BaseCommand
    {
        public override async Task ProcessAsync(SocketMessage message, string[] parameters)
        {
            UserIds userIds = JsonConvert.DeserializeObject<UserIds>(File.ReadAllText(@"C:\Constants.json"));

            ulong userId = message.Author.Id;
            foreach(ulong mod in userIds.Mods)
            {
                if (userId == mod)
                {
                    // Sanity check
                    if (message.MentionedUsers.Count == 0)
                    {
                        Logger.Warning(message.Author.Username, "Failed timout command. No mentioned user.");
                        await message.Channel.SendMessageAsync("No mentioned user. kmute [user] [time]");

                        return;
                    }

                    if (parameters.Length < 2)
                    {
                        Logger.Warning(message.Author.Username, "Failed timout command. Time given.");
                        await message.Channel.SendMessageAsync("Please specify an amount of time. kmute [user] [time]");

                        return;
                    }

                    if (!int.TryParse(parameters[1], out int seconds))
                    {
                        Logger.Warning(message.Author.Username, "Failed timout command. Time for timout failed.");
                        await message.Channel.SendMessageAsync("Time requested not a number. kmute [user] [time]");

                        return;
                    }

                    await MuteUserHelper.MuteAsync(message.Channel as SocketTextChannel, message.MentionedUsers.FirstOrDefault() as SocketGuildUser, seconds);

                    return;
                }
            }

            Logger.Warning(message.Author.Username, "Tried to use mute command");
            await message.Channel.SendMessageAsync("Sorry you do not have permission to use this command");

            return;
        }

    }
}