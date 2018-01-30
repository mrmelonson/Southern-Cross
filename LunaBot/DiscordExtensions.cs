﻿using Discord;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunaBot
{
    public static class DiscordExtensions
    {
        /// <summary>
        /// Log the socket message
        /// </summary>
        /// <param name="message">The message to log</param>
        /// <param name="sev">The severity</param>
        /// <returns>the logging task</returns>
        public static Task LogAsync(this SocketMessage message, LogSeverity sev = LogSeverity.Verbose)
        {
            return Logger.LogAsync(new LogMessage(sev, message.Channel.Name + " - " + message.Author.ToString(), message.Content));
        }

        public static void Log(this Exception e, SocketMessage message = null)
        {
            //if(message != null)
            //{
            //    message.Channel.SendMessageAsync(string.Format("An error occured: {0}", e.Message));
            //}
            Logger.Error("System", e.ToString());
        }
    }
}
