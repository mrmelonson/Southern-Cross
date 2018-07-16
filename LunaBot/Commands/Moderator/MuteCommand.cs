using Discord.WebSocket;
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
            ulong userId = message.Author.Id;
            char timeindicator = 'h';
            string toparse = "0";
            if (IsModeratorHelper.IsModerator(message.Author as SocketGuildUser))
            {
                // Sanity check
                if (message.MentionedUsers.Count == 0)
                {
                    Logger.Warning(message.Author.Username, "Failed timout command. No mentioned user.");
                    await message.Channel.SendMessageAsync("No mentioned user. kmute [user] [time]");

                    return;
                }

                if (parameters.Length == 1)
                {
                    await MuteUserHelper.MuteAsync(message.Channel as SocketTextChannel, message.MentionedUsers.FirstOrDefault() as SocketGuildUser, 0, 'h');

                    return;
                }

                if (parameters.Length < 2)
                {
                    Logger.Warning(message.Author.Username, "Failed timout command. Time given.");
                    await message.Channel.SendMessageAsync("Please specify an amount of time. kmute [user] [time]");

                    return;
                }

                foreach (char letter in parameters[1])
                {
                    if (!(char.IsNumber(letter)))
                    {
                        timeindicator = letter;
                    } else
                    {
                        toparse = toparse + letter.ToString();
                    }
                    
                }

                if (!int.TryParse(toparse, out int time))
                {
                    Logger.Warning(message.Author.Username, "Failed timout command. Time for timout failed.");
                    await message.Channel.SendMessageAsync("Time requested not a number. kmute [user] [time]");

                    return;
                }

                await MuteUserHelper.MuteAsync(message.Channel as SocketTextChannel, message.MentionedUsers.FirstOrDefault() as SocketGuildUser, time, timeindicator);

                return;

            }
            else
            {

                Logger.Warning(message.Author.Username, "Tried to use mute command");
                await message.Channel.SendMessageAsync("Sorry you do not have permission to use this command");

                return;
            }
        }

    }
}