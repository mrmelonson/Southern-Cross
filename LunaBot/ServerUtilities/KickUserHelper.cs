using Discord;
using Discord.Net;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Text;

namespace LunaBot.ServerUtilities
{
    class KickUserHelper
    {
        private static IList<string> kickFlavorText = new List<string>()
        {
            "{0} has been kicked for inactivity."
        };


        public static async System.Threading.Tasks.Task KickAsync(SocketTextChannel channel, SocketGuildUser user)
        {
            if (user.Id == UserIds.Luna)
                return;

            Logger.Info("System", $"Kicking {user.Username}");

            try
            {
                await user.SendMessageAsync("You have been kicked from the server from inactivity.\n" +
                    "You can join again but once you get kicked 3 times you will be banned.\n" +
                    "*Hint: respond to pings and we will let you in*\n" +
                    "https://discord.gg/FAYVfnT");
            }
#pragma warning disable CS0168 // Variable is declared but never used
            catch (HttpException e)
            {
                Logger.Info("System", $"{user.Username} blocks DMs.");
            }
#pragma warning restore CS0168 // Variable is declared but never used

            Random r = new Random();
            
            await user.KickAsync("Kicked for inactivity");
            await channel.SendMessageAsync(String.Format(kickFlavorText[r.Next(kickFlavorText.Count)], user.Username));
        }
    }
}
