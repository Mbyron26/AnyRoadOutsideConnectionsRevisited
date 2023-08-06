global using MbyronModsCommon;
namespace AnyRoadOutsideConnectionsRevisited;
using ICities;
using System;
using System.Collections.Generic;

public class Mod : ModPatcherBase<Mod, Config> {
    public override string ModName { get; } = "Any Road Outside Connections Revisited";
    public override ulong StableID => 2847163882;
    public override string Description => "Allows you to use any road for external connection.";
    public override BuildVersion VersionType => BuildVersion.StableRelease;
    public override void IntroActions() {
        ExternalLogger.OutputPluginsList();
        if (SingletonManager<Manager>.Instance.IsNetworkAnarchyEnabled) {
            MessageBox.Show<OneButtonMessageBox>().Init(ModName, OptionPanel.Warning);
        }
    }
    protected override void SettingsUI(UIHelperBase helper) => OptionPanelManager<Mod, OptionPanel>.SettingsUI(helper);
    public override List<ConflictModInfo> ConflictMods { get; set; } = new() {
        new ConflictModInfo(883332136, @"Any Road Outside Connections", true),
    };

    protected override void PatchAction() => AddPostfix(NetInfoPatch.GetOriginalInitializePrefab(), NetInfoPatch.GetInitializePrefabPostfix());

    public override List<ModChangeLog> ChangeLog => new() {
        new ModChangeLog(new Version(1, 1), new(2023, 8, 6), new List<LogString> {
            new(LogFlag.Updated, "Updated mod common."),
            new(LogFlag.Updated, "Updated NuGet CitiesHarmony.API to 2.2"),
            new(LogFlag.Updated, "Updated compatibility check to automatically disable mod features, and will automatically warn to unsubscribe from this mod and use Network Anarchy instead."),
        }),
    };
}
