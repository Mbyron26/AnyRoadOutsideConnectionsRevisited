using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HarmonyLib;

namespace AnyRoadOutsideConnectionsRevisited {
    internal static class Patcher {
        private const string HARMONYID = @"com.mbyron26.AnyRoadOutsideConnectionsRevisited";
        internal static void EnablePatches() {
            Harmony harmony = new Harmony(HARMONYID);
            harmony.PatchAll();
        }
        internal static void DisablePatches() {
            Harmony harmony = new Harmony(HARMONYID);
            harmony.UnpatchAll(HARMONYID);
            Manager.Reset();
        }
    }
}
