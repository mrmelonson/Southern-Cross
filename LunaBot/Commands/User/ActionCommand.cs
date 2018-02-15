using System;
using System.Linq;
using System.Threading.Tasks;
using Discord.WebSocket;
using LunaBot.ServerUtilities;


namespace LunaBot.Commands
{
    [LunaBotCommand("Action", "A")]
    class ActionCommand : BaseCommand
    {
        public override async Task ProcessAsync(SocketMessage message, string[] parameters)
        {
            ulong userId = message.Author.Id;
            ulong userId2;

            if (message.MentionedUsers.Count > 0)
            {
                string action = parameters[0];
                action = action.ToLower();
                action.ToLower();

                userId2 = message.MentionedUsers.FirstOrDefault().Id;

                Logger.Info(message.Author.Username, " is using an action.");

                if (userId == userId2)
                {
                    await message.Channel.SendMessageAsync($"Sorry, <@{userId}>, You cannot use commands on yourself.");
                }
                else
                {
                    if (message.MentionedUsers.Count == 0)
                    {
                        await message.Channel.SendMessageAsync($"Sorry, <@{userId}>, Please mention a user to use this command:\n" +
                                                                "kaction [action] [user]");
                        return;
                    }
                    if (action == "bap")
                    {
                        if (userId2 == UserIds.Luna)
                        {
                            await message.Channel.SendMessageAsync($">:V <@{userId2}> :newspaper2: <@{userId}>");
                        }
                        else
                        {
                            await message.Channel.SendMessageAsync($"<@{userId}> :newspaper2: <@{userId2}>");
                        }
                    }
                    else if (action == "smooch")
                    {
                        if (userId2 == UserIds.Luna)
                        {
                            await message.Channel.SendMessageAsync($">///< T-Thank you, <@{userId}>.");
                        }
                        else
                        {
                            await message.Channel.SendMessageAsync($":heart: <@{userId}> :kissing_heart: <@{userId2}> :heart:");
                        }
                    }
                    else if (action == "boop")
                    {
                        if (userId2 == UserIds.Luna)
                        {
                            await message.Channel.SendMessageAsync($"*receives boop*");
                        }
                        else
                        {
                            await message.Channel.SendMessageAsync($"<@{userId}> :point_right: <@{userId2}> *Boop*.");
                        }
                    }
                    else if (action == "punch")
                    {
                        if (userId2 == UserIds.Luna)
                        {
                            await message.Channel.SendMessageAsync($"no");

                        }
                        else
                        {
                            await message.Channel.SendMessageAsync($"<@{userId}> :right_facing_fist: :boom: <@{userId2}>");
                        }
                    }
                    else if (action == "snug")
                    {
                        await message.Channel.SendMessageAsync($"AWWW!! <@{userId}> and <@{userId2}> are snuggling!!");
                    }
                    else
                    {
                        await message.Channel.SendMessageAsync($"Sorry <@{userId}> that was not an action or it was misspelt...\n" +
                                                                $"Avaliable actions:\n" +
                                                                $"```\n" +
                                                                $"Bap\n" +
                                                                $"Smooch\n" +
                                                                $"Boop\n" +
                                                                $"Punch\n" +
                                                                $"Snug" +
                                                                $"```");
                    }
                }
            }
            else
            {
                await message.Channel.SendMessageAsync($"The command goes like this: \n kaction [Action] [user] \n" +
                                                        $"Avaliable actions:\n" +
                                                        $"```\n" +
                                                        $"Bap\n" +
                                                        $"Smooch\n" +
                                                        $"Boop\n" +
                                                        $"Punch\n" +
                                                        $"Snug" +
                                                        $"```");
                return;

            }
        }
    }
}