using Harmony;
using UnityEngine;

namespace Sprint
{
    [HarmonyPatch(typeof(PlayerComponent))]
    [HarmonyPatch("Update")]
    internal class PlayerComponent_Update_Patch
    {
        [HarmonyPrefix]
        public static bool Prefix(PlayerComponent __instance)
        {
            if (Configuration.Instance.IsToggleMode && Input.GetKeyDown(KeyCode.LeftShift) && __instance.wgo.is_player)
            {
                int value = MainGame.me.player.GetParam("isSprinting") != 1 ? 1 : 0;
                MainGame.me.player.SetParam("isSprinting", value);
            }
            return true;
        }
    }
}