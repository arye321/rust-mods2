using Oxide.Core.Libraries.Covalence;
using System.Collections.Generic;
using Oxide.Core;
using System;

namespace Oxide.Plugins
{
    [Info("DeathMessages", "Blase", "1")]
    [Description("Death Messages")]
    public class DeathMessages : RustPlugin
    {
       
        string GetPlayerNameFromID( ulong player_id )
        {
            foreach( BasePlayer player in BasePlayer.activePlayerList )
            {
                if( player.userID == player_id )
                    return player.displayName;
            }
            foreach( BasePlayer player in BasePlayer.sleepingPlayerList )
            {
                if( player.userID == player_id )
                    return player.displayName;
            }
            
            return "Somebody";
        }

            private void OnEntityDeath(BaseCombatEntity victimEntity, HitInfo info)
        {
              if (victimEntity.lastAttacker == null ||info.Initiator == null || victimEntity == null)
                return;

         //  if (info.Initiator.ShortPrefabName == "player"){
                if(victimEntity.name.Contains("player")){

                    var victim = victimEntity as BasePlayer;
                    string victimName = GetPlayerNameFromID( victim.userID );
                    Puts("info DamageType :"+victimEntity.lastDamage);


                    if (info.Initiator is BaseAnimalNPC  ){
                        if (info.Initiator is BaseAnimalNPC){
                             string murderer =  info.Initiator.ShortPrefabName;



                            string msg = victimName+" was killed by an Animal ";

                            if (murderer == "wolf"){
                                msg += "(Wolf)";
                            }
                            else if(murderer == "boar"){
                                msg += "(Boar)";
                            }
                            else if(murderer == "chicken"){
                                msg += "(Chicken! wtf)";
                            }
                            else if(murderer == "bear"){
                                msg += "(Bear)";
                            }
                            else if(murderer == "horse"){
                                msg += "(Horse! wat)";
                            }
                            else if(murderer == "stag"){
                                msg += "(Stag! a bambi ?!)";
                            }
                            
                            Puts (msg);
                            PrintToChat(msg);
                            
                        }
                        return;
                    }
                    if( info.Initiator.name.Contains("player")  ){
                    


                         var killer = victimEntity.lastAttacker as BasePlayer;

                        if( victim.userID != killer.userID ){

                         string murderer = GetPlayerNameFromID( killer.userID );
                         
                        // var killerPlayer = info?.Initiator?.ToPlayer();
                         string msg = victimName+" was killed by "+murderer;
                         Puts (msg);
                         PrintToChat(msg);
                         //PrintToChat(victimName );  
                        }

                    }
                }  
        }
    
}
}
