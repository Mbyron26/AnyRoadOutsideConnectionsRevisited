using ICities;
using CitiesHarmony.API;

namespace AnyRoadOutsideConnectionsRevisited {
    public class Mod : IUserMod {
        private const string m_modName = "Any Road Outside Connections Revisited";
        private const string m_modVersion = "1.0";
        private const string m_modDesc = "Allows you to use any road for external connection.";
        public string Name => m_modName + " " + m_modVersion;
        public string Description => m_modDesc;
        public void OnEnabled() {
            HarmonyHelper.DoOnHarmonyReady(Patcher.EnablePatches);
        }
        public void OnDisabled() {
            if (HarmonyHelper.IsHarmonyInstalled) Patcher.DisablePatches();
        }
    }


    public class LoadingExtension : LoadingExtensionBase {
        public override void OnCreated(ILoading loading) {
            base.OnCreated(loading);
            if (loading.currentMode == AppMode.AssetEditor || loading.currentMode == AppMode.MapEditor) {
                return;
            }
            Manager.Reset();
        }

        public override void OnReleased() {
            base.OnReleased();
        }
    }
}
