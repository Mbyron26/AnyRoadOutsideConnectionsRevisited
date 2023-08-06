namespace AnyRoadOutsideConnectionsRevisited;

public class OptionPanel : OptionPanelBase<Mod, Config, OptionPanel> {
    public static string Warning => "This mod has been integrated into Network Anarchy. Since you have enabled Network Anarchy mod, this mod is disabled by default. This mod is no longer needed. Unsubscribe is recommended.";
    protected override void AddExtraContainer() { }
    protected override void FillGeneralContainer() {
        OptionPanelHelper.AddGroup(GeneralContainer, "Status");
        if (SingletonManager<Manager>.Instance.IsNetworkAnarchyEnabled) {
            OptionPanelHelper.AddLabel(Warning, null);
        } else {
            OptionPanelHelper.AddLabel("Normal", null);
        }
        OptionPanelHelper.Reset();
    }
}
