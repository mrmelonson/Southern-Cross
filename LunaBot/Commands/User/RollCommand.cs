﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.WebSocket;

namespace LunaBot.Commands
{
    [LunaBotCommand("Roll")]
    class RollCommand : BaseCommand
    {
        public override async Task ProcessAsync(SocketMessage message, string[] parameters)
        {
            foreach (string p in parameters)
            {
                string[] rolePts = p.Split('d');
                if (rolePts.Count() != 2)
                {
                    await message.Channel.SendMessageAsync("Invalid roll, roll must be of the form [# of sides]d[# of dice]");
                    Logger.Verbose(message.Author.Username, "Has failed roll command");

                    return;
                }

                try
                {
                     int dice = Convert.ToInt32(rolePts[0]);
                    int diceType = Convert.ToInt32(rolePts[1]);
                    int sum = 0;
                    Random rand = new Random();
                    for (int i = 0; i < dice; i++)
                    {
                        sum += (rand.Next() % diceType) + 1;
                    }

                    await message.Channel.SendMessageAsync(string.Format("I rolled {0} and got {1}", p, sum));

                    return;
                }
                catch (Exception e)
                {
                    await message.Channel.SendMessageAsync("Invalid roll, roll must be of the form [# of sides]d[# of dice]");
                    Logger.Verbose(message.Author.Username, $"Has failed roll command, Reason: {e.Message}");

                    return;
                }
            }

            await message.Channel.SendMessageAsync("Invalid roll, roll must be of the form [# of sides]d[# of dice]");
            Logger.Verbose(message.Author.Username, "Has failed roll command");

            return;
        }
    }
}