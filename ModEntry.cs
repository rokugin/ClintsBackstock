﻿using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;

namespace ClintsBackstock {
    internal class ModEntry : Mod {

        public override void Entry(IModHelper helper) {
            helper.Events.Player.InventoryChanged += OnInventoryChanged;
            helper.Events.Content.AssetRequested += OnAssetRequested;
            helper.Events.GameLoop.SaveLoaded += OnSaveLoaded;
        }

        private void OnSaveLoaded(object? sender, SaveLoadedEventArgs e) {
            if (Game1.player.daysLeftForToolUpgrade.Value > 0) {
                Game1.player.daysLeftForToolUpgrade.Value = 0;
            }
        }

        private void OnAssetRequested(object? sender, AssetRequestedEventArgs e) {
            if (e.Name.IsEquivalentTo("Strings/StringsFromCSFiles")) {
                e.Edit(asset => {
                    asset.AsDictionary<string, string>().Data["ShopMenu.cs.11474"] = Helper.Translation.Get("crafting-window");
                    asset.AsDictionary<string, string>().Data["Tool.cs.14317"] = Helper.Translation.Get("post-purchase-dialogue");
                });
            }
        }

        private void OnInventoryChanged(object? sender, InventoryChangedEventArgs e) {
            if (Game1.player.daysLeftForToolUpgrade.Value > 0) {
                Game1.player.daysLeftForToolUpgrade.Value = 0;
            }
        }

    }
}
