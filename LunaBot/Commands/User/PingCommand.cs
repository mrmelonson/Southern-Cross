using System.Threading.Tasks;
using Discord.WebSocket;
using System.Threading;
using System.Diagnostics;

namespace LunaBot.Commands
{
    [LunaBotCommand("Ping")]
    class PingCommand : BaseCommand
    {
        public override async Task ProcessAsync(SocketMessage message, string[] parameters)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            await message.Channel.SendMessageAsync(":ping_pong: Pong!");
            sw.Stop();
            await message.Channel.SendMessageAsync($":stopwatch: {sw.ElapsedMilliseconds}ms");
        }
    }
}
