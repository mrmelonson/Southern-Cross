﻿using Discord;
using System.Collections.Generic;
using System.Linq;
using Discord.WebSocket;
using System.Threading.Tasks;
using LunaBot.ServerUtilities;
using System;

namespace LunaBot.Commands
{
    [LunaBotCommand("Help")]
    class HelpCommand : BaseCommand
    {
        public override async Task ProcessAsync(SocketMessage message, string[] parameters)
        {
            List<string> commands = new List<string>();

            ulong userId = message.Author.Id;
            SocketUser user = message.Author;

            foreach (ulong users in UserIds.Mods)
            {
                if (userId == users)
                {
                    commands.Add("**Moderation Commands**");

                    commands.Add("Timeout:\n" +
                        "```ktimeout [user] [time (in seconds)]```");
                    commands.Add("Timout without timer:\n" +
                        "```ktimeout [user] 0```");
                    commands.Add("Message purge:\n" +
                        "```kpurge [amount]```");
                    commands.Add("Unmute:\n" +
                        "```kunmute [user]```");
                }
            }

            commands.Add("**User Commands**");

            commands.Add("Assign roles:\n" +
                "```kassign [role]```");
            commands.Add("Remove roles:\n" +
                "```kremove [role]```");
            commands.Add("Use an action:\n" +
                "```kaction [action] [user]```");
            commands.Add("Ping:\n" +
                "```kping```");
            try
            {
                await user.SendMessageAsync(string.Join('\n', commands));
                await message.Channel.SendMessageAsync($"<@{userId}>, I have sent you your available commands.");
            }
            catch (Exception e)
            {
                await message.Channel.SendMessageAsync($"Sorry, <@{userId}>, you have blocked me from sending you DMs so here are your commands.");
                await message.Channel.SendMessageAsync(string.Join('\n', commands));
                Logger.Warning(message.Author.Username, "Blocks DMs, Sending commands to server.");
            }

        }
    }
}