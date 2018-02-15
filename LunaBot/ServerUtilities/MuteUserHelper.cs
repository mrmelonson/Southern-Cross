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
    class MuteUserHelper
    {
        private static IList<string> kickFlavorText = new List<string>()
        {
            "{0} has been muted."
        };


        public static async Task MuteAsync(SocketTextChannel channel, SocketGuildUser user, int seconds)
        {
            UserIds userIds = JsonConvert.DeserializeObject<UserIds>(File.ReadAllText(@"C:\Constants.json"));

            if (user.Id == userIds.Luna)
                return;

            // Logging, telling the user, and announcing in server.
            Random r = new Random();
            await channel.SendMessageAsync(String.Format(kickFlavorText[r.Next(kickFlavorText.Count)], user.Username));

            Predicate<SocketRole> muteFinder;
            SocketRole mute;
            List<SocketRole> roles = channel.Guild.Roles.ToList();

            // Set mute role
            muteFinder = (SocketRole sr) => {return sr.Name == userIds.Muted;};
            mute = roles.Find(muteFinder);
            await user.AddRoleAsync(mute);

            if (seconds != 0)
            {
                try
                {
                    await user.SendMessageAsync($"You have been muted for {seconds} seconds");
                }
                catch (Exception e)
                {
                    Logger.Warning(user.Username, e.Message);
                    await channel.SendMessageAsync($"<@{user.Id}> you block DMs, you have been muted for {seconds} seconds");
                    Logger.Info("System", $"Muting {user.Username}, for {seconds} seconds");
                }

#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
                    Task.Run(async () =>
                    {
                        Thread.Sleep(seconds * 1000);
                        if (user.Roles.Contains(mute))
                        {
                            await channel.SendMessageAsync($"<@{user.Id}>, You have been unmuted. Welcome back.");
                        }
                        await user.RemoveRoleAsync(mute);
                    });
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            }
            else
            {
                Logger.Info("System", $"Muting {user.Username}.");
                try
                {
                    await user.SendMessageAsync($"You have been muted until further notice.");
                }
                catch (Exception e)
                {
                    Logger.Warning(user.Username, e.Message);
                    await channel.SendMessageAsync($"<@{user.Id}> you block DMs, you have been muted until further notice.");
                }
            }
        }
    }
}
