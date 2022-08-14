using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HarmonyLib;
using UnityEngine;

namespace AnyRoadOutsideConnectionsRevisited {
    public delegate void PrefabEventHandler<in T>(T prefab) where T : NetInfo;

    [HarmonyPatch(typeof(NetInfo), "InitializePrefab")]
    internal static class Patch {
        private static void Postfix(NetInfo __instance) {
            Manager.PostInitialization(__instance);
        }

    }
}
