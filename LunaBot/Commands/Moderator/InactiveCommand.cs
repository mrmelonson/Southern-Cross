using Discord.WebSocket;
using LunaBot.ServerUtilities;
using LunaBot;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace LunaBot.Commands
{
    [LunaBotCommand("Inactive")]
    class InactiveCommand : BaseCommand
    {
        public override async Task ProcessAsync(SocketMessage message, string[] parameters)
        {
            ulong userId = message.Author.Id;
            if (IsModeratorHelper.IsModerator(message.Author as SocketGuildUser))
            {
                // Sanity check
                if (message.MentionedUsers.Count == 0)
                {
                    Logger.Warning(message.Author.Username, "Failed inactive command. No mentioned user.");
                    await message.Channel.SendMessageAsync("No mentioned user. kinactive [user]");

                    return;
                }

                await KickUserHelper.KickAsync(message.Channel as SocketTextChannel, message.MentionedUsers.FirstOrDefault() as SocketGuildUser);

                return;

            }
            else
            {
                Logger.Warning(message.Author.Username, "Tried to use inactive command");
                await message.Channel.SendMessageAsync("Sorry you do not have permission to use this command");

                return;
            }
        }

    }
}