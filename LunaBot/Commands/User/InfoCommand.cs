using Discord.WebSocket;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using LunaBot.ServerUtilities;


namespace LunaBot.Commands
{
    [LunaBotCommand("Info")]
    class InfoCommand : BaseCommand
    {
        public override async Task ProcessAsync(SocketMessage message, string[] parameters)
        {
            await message.Channel.SendMessageAsync($"Version number `{Info.VersionNum}`");
            await message.Channel.SendMessageAsync($"Creators: \n Base code programmer - {Info.BaseCodeMaker} \n Creator - {Info.Creator}");
            await message.Channel.SendMessageAsync($"Github - {Info.GitHub}");
        }
    }
}
