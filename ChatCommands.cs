using Oxide.Core.Libraries.Covalence;
using System.Collections.Generic;

using Oxide.Core;
using System;
namespace Oxide.Plugins
{
    [Info("ChatCommands", "Blase", "1")]
    [Description("Chat Commands")]
    public class ChatCommands : RustPlugin
    {
       

/*        private void Broadcast(string key, params object[] args)
        {
            foreach (var player in players.Connected)
                player.Message(key);
        }*/
        private void OnPlayerChat(ConsoleSystem.Arg arg)
        {
             string message = arg.GetString(0, "text");
            if (message.ToLower() == "!players" ||  message.ToLower() == "!online"){
                timer.Once((float)0.2, () => {
                    string msg = "Online Players: "+ BasePlayer.activePlayerList.Count;
                    PrintToChat(msg);
                    Puts(msg);
                });
        }
        
             else if (message.ToLower() == "!total"){
                timer.Once((float)0.2, () => {
                    string msg = "Online Players: " + BasePlayer.activePlayerList.Count;
                    msg += " Sleeping: " + BasePlayer.sleepingPlayerList.Count;
                    PrintToChat(msg);
                    Puts(msg);
                });
     }


    }
}
}
