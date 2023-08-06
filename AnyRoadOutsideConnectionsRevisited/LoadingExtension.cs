namespace AnyRoadOutsideConnectionsRevisited;
using ICities;

public class LoadingExtension : ModLoadingExtension<Mod> {
    public override void Created(ILoading loading) {
        if (loading.currentMode == AppMode.AssetEditor || loading.currentMode == AppMode.MapEditor) {
            return;
        }
        SingletonManager<Manager>.Instance.Reset();
    }
}
