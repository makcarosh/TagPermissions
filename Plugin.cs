using Rocket.API;
using Rocket.API.Collections;
using Rocket.Core;
using Rocket.Core.Logging;
using Rocket.Core.Plugins;
using Rocket.Unturned;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Permissions;
using Rocket.Unturned.Player;
using SDG.Unturned;
using Steamworks;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using static Rocket.Unturned.Events.UnturnedEvents;

namespace TagPerm
{
    public class Plugin : RocketPlugin<PluginCfg>
    {
        protected override void Load()
        {
            U.Events.OnPlayerConnected += OnPlayerConnected;
            Logger.Log("[TagPerm] Plugin loaded");
        }

        protected override void Unload()
        {
            U.Events.OnPlayerConnected -= OnPlayerConnected;
            Logger.Log("[TagPerm] Plugin unloaded");
        }

        private void OnPlayerConnected(UnturnedPlayer player)
        {
        var config = Configuration.Instance;
        string name = player.CharacterName;
        List<string> tags = Configuration.Instance.servertag;

        
        string foundTag = tags?.FirstOrDefault(tag =>
        !string.IsNullOrWhiteSpace(tag) &&
        name.IndexOf(tag, StringComparison.OrdinalIgnoreCase) >= 0);
            var trans = Translations.Instance;
            if (foundTag != null)
            {
                // тег найден
                R.Permissions.AddPlayerToGroup(config.group, new RocketPlayer(player.Id));
                UnturnedChat.Say(player, Translate("message"));
            }
            else 
            {
                R.Permissions.RemovePlayerFromGroup(config.group, player);
            }
        }

        public override TranslationList DefaultTranslations => new TranslationList
        {
            { "message", "Вам выдали награду за приписку в нике :>" }
        };
    }
}