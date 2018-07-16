using Discord;
using System.Collections.Generic;
using System.Linq;
using Discord.WebSocket;
using System.Threading.Tasks;
using LunaBot.ServerUtilities;
using System;
using System.IO;
using Newtonsoft.Json;

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

            if (IsModeratorHelper.IsModerator(message.Author as SocketGuildUser))
            {
                commands.Add("**Moderation Commands**");

                commands.Add("Mute:\n" +
                    "```kmute [user] [time (in minutes)]```");
                commands.Add("Mute without timer:\n" +
                    "```kmute [user]```");
                commands.Add("Message purge:\n" +
                    "```kpurge [amount]```");
                commands.Add("Unmute:\n" +
                    "```kunmute [user]```");
                commands.Add("Kick for inactivity:\n" +
                    "```kinactive [user]```");

            }

            commands.Add("**User Commands**");

            commands.Add("Assign roles:\n" +
                "```kassign [role]```");
            commands.Add("Remove roles:\n" +
                "```kremove [role]```");
            commands.Add("List roles:\n" +
                "```kroles```");
            commands.Add("Roll Command:\n" +
                "```kroll [Amount of dice]d[Amount of sides]\n" +
                "E.g. kroll 1d6```");
            commands.Add("Use an action:\n" +
                "```kaction [action] [user]```");
            commands.Add("Ping:\n" +
                "```kping```");
            commands.Add("Infomation :\n" +
                "```kinfo```");
            commands.Add("Check if role exists:\n" +
                "```kcheckrole [role]```");
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