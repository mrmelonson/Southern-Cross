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
            if (user.Id == UserIds.Luna)
                return;

            // Logging, telling the user, and announcing in server.
            Random r = new Random();
            await channel.SendMessageAsync(String.Format(kickFlavorText[r.Next(kickFlavorText.Count)], user.Username));

            List<SocketTextChannel> channelList = channel.Guild.TextChannels.ToList();
            SocketTextChannel muteChannel;
            Predicate<SocketTextChannel> muteChannelFinder;

            muteChannelFinder = (SocketTextChannel sr) => { return sr.Id == Channels.Mute_channel; };
            muteChannel = channelList.Find(muteChannelFinder);
            await muteChannel.SendMessageAsync($"<@{user.Id}>, you're currently muted. \n" +
                                                "Please wait for a staff member, one will be with you shortly.\n" +
                                                "In the meantime, if you have information regarding your mute, or a possible reason as to why you should be unmuted, please compile it and have it ready.");
            

            Predicate<SocketRole> muteFinder;
            Predicate<SocketRole> nsfwFinder;
            SocketRole nsfw;
            SocketRole mute;
            List<SocketRole> roles = channel.Guild.Roles.ToList();

            // Set mute role
            muteFinder = (SocketRole sr) => {return sr.Name == Roles.Muted;};
            nsfwFinder = (SocketRole sr) => { return sr.Name == Roles.NSFW; };
            nsfw = roles.Find(nsfwFinder);
            mute = roles.Find(muteFinder);
            await user.AddRoleAsync(mute);
            await user.RemoveRoleAsync(nsfw);

            if (seconds != 0)
            {
                try
                {
                    await user.SendMessageAsync($"You have been muted for {seconds} minutes");
                }
                catch (Exception e)
                {
                    Logger.Warning(user.Username, e.Message);
                    await channel.SendMessageAsync($"<@{user.Id}> you block DMs, you have been muted for {seconds} minutes");
                    Logger.Info("System", $"Muting {user.Username}, for {seconds} minutes");
                }

#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
                    Task.Run(async () =>
                    {
                        Thread.Sleep(seconds * 60000);
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
