using Discord;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft;
using Newtonsoft.Json;
using System.IO;

/// <summary>
/// Stores constant like user, channel, and guild IDs
/// </summary>
namespace LunaBot.ServerUtilities
{
    class Serialize
    {
        static void Run()
        {
            UserIds meme = JsonConvert.DeserializeObject<UserIds>(File.ReadAllText(@"C:\Constants.json"));
           // userIds = new UserIds { };

            Console.WriteLine(meme.Mods);
        }
    }

    /*internal static class UserIds1
    {
        /// <summary>
        /// Owners of the FR server
        /// </summary>
        internal static ulong[] Mods =
        {
            //Hellblaze Wolf
            180623286747660288,
            //Fireflash
            92466867364433920,
            //Doodles
            285606103243554816,
            //zelenyy
            284861595396472834
        };

        internal static ulong Luna = 405679003740012565;

    }

    internal static class Channels
    {
        internal static ulong Lobby = 405676842335338503;

        internal static ulong BotLogs = 405676964515676161;

    }

    internal static class Guilds
    {
        /// ID for server
        internal static ulong Guild = 405676842335338499;

    }

    internal static class Unassignable
    {
        internal static string[] Roles =
        {
            "mute"
        };

    } 

    internal static class Permissions
    {
        internal static OverwritePermissions removeAllPerm = new OverwritePermissions(PermValue.Deny, PermValue.Deny, PermValue.Deny, PermValue.Deny, PermValue.Deny, PermValue.Deny, PermValue.Deny, PermValue.Deny, PermValue.Deny, PermValue.Deny, PermValue.Deny, PermValue.Deny, PermValue.Deny, PermValue.Deny, PermValue.Deny, PermValue.Deny, PermValue.Deny, PermValue.Deny, PermValue.Deny, PermValue.Deny);

        internal static OverwritePermissions userPerm = new OverwritePermissions(PermValue.Deny, PermValue.Deny, PermValue.Allow, PermValue.Allow, PermValue.Allow, PermValue.Deny, PermValue.Deny, PermValue.Deny, PermValue.Deny, PermValue.Allow, PermValue.Deny, PermValue.Deny, PermValue.Deny, PermValue.Deny, PermValue.Deny, PermValue.Deny, PermValue.Deny, PermValue.Deny, PermValue.Deny, PermValue.Deny);

        internal static OverwritePermissions lunaTutPerm = new OverwritePermissions(PermValue.Allow, PermValue.Allow, PermValue.Allow, PermValue.Allow, PermValue.Allow, PermValue.Allow, PermValue.Allow, PermValue.Allow, PermValue.Allow, PermValue.Allow, PermValue.Allow, PermValue.Allow, PermValue.Allow, PermValue.Allow, PermValue.Allow, PermValue.Allow, PermValue.Allow, PermValue.Allow, PermValue.Allow, PermValue.Allow);

        internal static OverwritePermissions roomPerm = new OverwritePermissions(PermValue.Allow, PermValue.Allow, PermValue.Allow, PermValue.Allow, PermValue.Allow, PermValue.Inherit, PermValue.Inherit, PermValue.Allow, PermValue.Allow, PermValue.Allow, PermValue.Inherit, PermValue.Inherit, PermValue.Inherit, PermValue.Inherit, PermValue.Inherit, PermValue.Inherit, PermValue.Inherit, PermValue.Inherit, PermValue.Inherit, PermValue.Inherit);

        internal static OverwritePermissions mutePerm = new OverwritePermissions(PermValue.Deny, PermValue.Deny, PermValue.Deny, PermValue.Allow, PermValue.Deny, PermValue.Deny, PermValue.Deny, PermValue.Deny, PermValue.Deny, PermValue.Allow, PermValue.Deny, PermValue.Deny, PermValue.Deny, PermValue.Deny, PermValue.Deny, PermValue.Deny, PermValue.Deny, PermValue.Deny, PermValue.Deny, PermValue.Deny);

    }
    */
    public class UserIds
    {
        public IList<ulong> Mods { get; set; }
        internal static ulong Luna { get; set; }
        internal static ulong Lobby { get; set; }
        internal static ulong Guild { get; set; }
        internal static IList<ulong> Roles { get; set; }
    }
}
