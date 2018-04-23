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
            /*
            BOSS
            */
            //Hellblaze Wolf
            180623286747660288,

            /*
            Admins
            */
            //Doodles
            285606103243554816,

            /*
            MODERATORS
            */
            //rox
            269785752748032000,
            //ana
            72949258646458368,
            //Boz
            164204053226586112,

            /*
            HELPERS
            */
            //zelenyy
            284861595396472834,
            //ura
            416586444404948993
        };

        internal static ulong Luna = 405679003740012565;

    }

    internal static class Channels
    {
        //lobby is actually "botspam"
        internal static ulong Lobby = 409717426159091725;
        //not used
        internal static ulong BotLogs = 405676964515676161;
        //change roles
        internal static ulong Change_Roles = 409721129515614210;
        //staff channels
        internal static ulong[] Staff_Channels = { };

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

    internal static class Species
    {
        internal static string[] Roles =
        {
            "Alsatian","Badger","Blue Heeler","Boer Goat","Cat","Cheetah","Deer","Dragon","Dragon-cat","Duck","Dutch Angel Dragon","Fae Wolf","Fox","Goat (Unspecified)","Gryphon","Hellhound","Husky","Kangaroo","Kitsune","Lion","Lynx","Octopus","Otter","Pokemon","Protogen","Rat","Robo-liz","Scalie","Sergal","Shark","Shiba","Tabby Cat","Tasmanian Devil","Tiger","Timber Wolf","Utahraptor","Wolf","Wolf-Dog"
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
    
}
