namespace AnyRoadOutsideConnectionsRevisited;
using HarmonyLib;
using System.Reflection;

public class NetInfoPatch {
    public static MethodInfo GetOriginalInitializePrefab() => AccessTools.Method(typeof(NetInfo), nameof(NetInfo.InitializePrefab));
    public static MethodInfo GetInitializePrefabPostfix() => AccessTools.Method(typeof(NetInfoPatch), nameof(InitializePrefabPostfix));
    private static void InitializePrefabPostfix(NetInfo __instance) => SingletonManager<Manager>.Instance.PostInitialization(__instance);
}
