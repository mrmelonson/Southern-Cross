using System.Threading.Tasks;
using Discord.WebSocket;
using System.Threading;
using System.Collections.Generic;
using System;

namespace LunaBot.Commands
{
    [LunaBotCommand("Dab")]
    class DabCommand : BaseCommand
    {
        public override async Task ProcessAsync(SocketMessage message, string[] parameters)
        {
            // What the fuck am i doing with my life
            ulong userid = message.Author.Id;
            string[] dabflavours = {$"<@{userid}> dabs on those ni:b::b:as", $"Wow that was one hard dab <@{userid}>!", $"<@{userid}> dabs so hard their arms almost dislocate.", $"*Sigh* fine, <@{userid}> dabs. Yay! wtf is wrong with you people."}; 
            Random r = new Random(); //It hurts to live
            await message.Channel.SendMessageAsync(dabflavours[r.Next(dabflavours.Length)]);
            // TODO
            // Reevaluate life choices
        }
    }
}
