using Microsoft.Extensions.DependencyInjection;
using Discord.Commands;
using LunaBot.ServerUtilities;


namespace LunaBot
{
    public class Program
    {
        // Used for commands
        private readonly IServiceCollection _map = new ServiceCollection();
        private readonly CommandService _commands = new CommandService();

        // Start in an async context
        static void Main(string[] args)
        {
            new LunaBot.ServerUtilities.Serialize().Run();
            new Engine().RunAsync().GetAwaiter().GetResult();
        }
    }
}
