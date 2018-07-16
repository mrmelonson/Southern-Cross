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
        // Obselete code
        // Keep just in case
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
        //mute channel
        internal static ulong Mute_channel = 409717972144357385;

    }

    internal static class Guilds
    {
        /// ID for server
        internal static ulong Guild = 311366698538369025;

    }

    internal static class Roles
    {
        internal static string Muted = "Muted";
        internal static string NSFW = "NSFW";
        internal static ulong ModeratorID = 311408378968539136;
        internal static ulong HelperID = 410422032774332416;
        internal static ulong BossID = 311369512437940224;
        internal static ulong AdminID = 311408039469252608;

    }

    internal static class Unassignable
    {
        internal static string[] Roles =
        {
            "Muted",
            "NSFW"
        };

    }

    internal static class Species
    {
        internal static string[] Roles =
        {
            "Alsatian","Astral Wolf","Avian","Badger","Bat","Bear","Blue Heeler","Bluejay","Boer Goat","Cat","Cheetah","Cockatiel","Cow","Deer","Dog","Dragon","Dragon-cat","Duck","Dutch Angel Dragon","Fae Wolf","Fox","Goat (Unspecified)","Gryphon","Hellhound","Husky","Hyena","Kangaroo","KayNine-Tiger","Kitsune","Lemur","Lion","Lizard","Lynx","Maned Wolf","Mouse","Octopus","Otter","Owl","Pig","Pokemon","Protogen","Rabbit","Rat","Red Panda","Robo-liz","Sabertooth","Scalie","Sergal","Shark","Sheep","Shiba Inu","Shibe","Snake","Spotted Eagle Ray","Sugar Glider","Tabby Cat","Tasmanian Devil","Tiger","Timber Wolf","Utahraptor","Werewolf","Wolf","Wolf-Dog","Wombat";
        };
    }

    internal static class Info
    {
        internal static string VersionNum = "1.01.04";
        internal static string Creator = "Zelenyy";
        internal static string BaseCodeMaker = "Haby001";
        internal static string GitHub = "https://github.com/mrmelonson/Southern-Cross";
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
