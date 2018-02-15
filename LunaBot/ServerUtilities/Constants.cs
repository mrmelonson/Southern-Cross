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
    internal static class UserIds
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
            //rox
            269785752748032000,
            //zelenyy
            284861595396472834
        };

        internal static ulong Luna = 405679003740012565;

    }

    internal static class Channels
    {
        internal static ulong Lobby = 409717426159091725;

        internal static ulong BotLogs = 405676964515676161;

        internal static ulong Change_Roles = 409721129515614210;

        internal static ulong[] Staff_Channels =  { };

    }

    internal static class Guilds
    {
        /// ID for server
        internal static ulong Guild = 311366698538369025;

    }

    internal static class Roles
    {
        internal static string Muted = "Muted";
    }

    internal static class Unassignable
    {
        internal static string[] Roles =
        {
            "Muted"
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
    /*
    public class UserIds
    {
        public List<ulong> Mods { get; set; }
        /*
        0. Hellblaze
        1. Flash
        2. Noodles
        3. Rox
        4. Zelenyy
         
        public ulong Luna { get; set; }
        public ulong Lobby { get; set; }
        public ulong Change_Roles { get; set; }
        public ulong Staff_spam { get; set; }
        public ulong Guild { get; set; }
        public List<string> Roles { get; set; }
        public string Muted { get; set; }
        public List<ulong> Staff_Channels { get; set; }
    }*/
}
