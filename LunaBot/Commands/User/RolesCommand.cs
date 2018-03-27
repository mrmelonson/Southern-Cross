using Discord;
using System.Collections.Generic;
using System.Linq;
using Discord.WebSocket;
using System.Threading.Tasks;
using LunaBot.ServerUtilities;
using System;


namespace LunaBot.Commands
{
    [LunaBotCommand("Roles")]
    class RolesCommand : BaseCommand
    {
        public override async Task ProcessAsync(SocketMessage message, string[] parameters)
        {

            List<string> commands = new List<string>();

            ulong userId = message.Author.Id;
            SocketUser user = message.Author;
            commands.Add("***ROLES***");
            commands.Add("**===Countries===**");
            commands.Add("```\n" +
                         "Australia\n" +
                         "Zealand\n" +
                        "International```");

            commands.Add("**==States (for AUS)==**");
            commands.Add("```\n" +
                         "QLD\n" +
                         "NSW\n" +
                         "ACT\n" +
                         "VIC\n" +
                         "TAS\n" +
                         "SA\n" +
                         "WA\n" +
                         "NT```");

            commands.Add("**===Sexuality===**");
            commands.Add("```\n" +
                         "Bi\n" +
                         "Straight\n" +
                         "Gay```");

            commands.Add("**===Pref (for Bi)===**");
            commands.Add("```\n" +
                         "Male Preference\n" +
                         "Female Preference```");

            commands.Add("**===Genders===**");
            commands.Add("```\n" +
                         "Unspecified Gender\n" +
                         "Trans\n" +
                         "Male\n" +
                         "Female\n" +
                         "Non-binary\n" +
                         "Androgynous```");

            commands.Add("**===DM Roles===**");
            commands.Add("```\n" +
                         "DM Friendly\n" +
                         "DM Unfriendly\n" +
                         "DM Request```");

            commands.Add("**===Artist Roles===-**");
            commands.Add("```\n" +
                         "Artist\n" +
                         "Commissions Open\n" +
                         "Commissions Closed```");

            commands.Add("**===Species Roles===**");
            commands.Add("```\n");
            foreach(string role in Species.Roles)
            {
                commands.Add(role);
            }
            commands.Add("```");


            try
            {
                await user.SendMessageAsync(string.Join('\n', commands));
                await message.Channel.SendMessageAsync($"<@{userId}>, I have sent you your available commands.");
            }
            catch (Exception e)
            {
                await message.Channel.SendMessageAsync($"Sorry, <@{userId}>, you have blocked me from sending you DMs, please read pins in <#{Channels.Change_Roles}>");
                Logger.Warning(message.Author.Username, "Blocks DMs.");
            }

        }
    }
}