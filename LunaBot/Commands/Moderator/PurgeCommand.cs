using Discord;
using Discord.Rest;
using Discord.WebSocket;
using LunaBot.ServerUtilities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace LunaBot.Commands
{
    [LunaBotCommand("Purge")]
    class PurgeCommand : BaseCommand
    {
        public override async Task ProcessAsync(SocketMessage message, string[] parameters)
        {
            UserIds userIds = JsonConvert.DeserializeObject<UserIds>(File.ReadAllText(@"C:\Constants.json"));
            ulong userId = message.Author.Id;
            SocketUser user = message.Author;

            foreach (ulong mod in userIds.Mods)
            {
                if (userId == mod)
                {

                    if (parameters.Length != 1)
                    {
                        Logger.Warning(message.Author.Username, "Failed purge command. Time given.");
                        await message.Channel.SendMessageAsync("Please specify an amount of messages to delete. kpurge [amount]");

                        return;
                    }

                    if (!int.TryParse(parameters[0], out int seconds))
                    {
                        Logger.Warning(message.Author.Username, "Failed purge command. amount for deletion failed.");
                        await message.Channel.SendMessageAsync("Amount requested not a number. kpurge [amount]");

                        return;
                    }


                    int amount = int.Parse(parameters[0]);

                    await message.Channel.SendMessageAsync($"<@{userId}>, You are purging {amount} messages. Purge will starts in 5 seconds.");

                    Logger.Warning(message.Author.Username, "Purging messages");
                    Thread.Sleep(5000);
                    Logger.Warning(message.Author.Username, "Finished");

                    var messagesToDelete = await message.Channel.GetMessagesAsync(amount + 1).Flatten();
                    await message.Channel.DeleteMessagesAsync(messagesToDelete);

                    return;
                }
            }

            Logger.Warning(message.Author.Username, "Tried to use purge command");
            await message.Channel.SendMessageAsync("Sorry you do not have permission to use this command");

            return;
        }

    }
}