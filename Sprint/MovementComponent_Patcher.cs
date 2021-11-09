using Harmony;
using System.IO;
using UnityEngine;

namespace Sprint
{
    [HarmonyPatch(typeof(MovementComponent))]
    [HarmonyPatch("UpdateMovement")]
    internal class MovementComponent_UpdateMovement_Patch
    {
        [HarmonyPostfix]
        public static void Postfix(MovementComponent __instance)
        {
            string path = @"./QMods/Sprint/config.txt";
            string[] configContents = File.ReadAllLines(path);

            float energyCost = float.Parse(configContents[1].Split('=')[1]);
            float speed = float.Parse(configContents[2].Split('=')[1]);

            if (Configuration.Instance.IsToggleMode)
            {
                HandleToggleMode(__instance, energyCost, speed);
            }
            else
            {
                HandleHoldMode(__instance, energyCost, speed);
            }
        }

        private static void HandleHoldMode(MovementComponent __instance, float energyCost, float speed)
        {
            bool isSprintKey = Input.GetKey(KeyCode.LeftShift);
            if (isSprintKey && __instance.wgo.is_player)
            {
                __instance.SetSpeed(speed);
                MainGame.me.player.energy -= energyCost;
            }
            else if (__instance.wgo.is_player)
            {
                __instance.SetSpeed(LazyConsts.PLAYER_SPEED);
            }
        }

        private static void HandleToggleMode(MovementComponent __instance, float energyCost, float speed)
        {
            if (__instance.wgo.is_player)
            {
                if (MainGame.me.player.GetParam("isSprinting") == 1)
                {
                    __instance.SetSpeed(speed);
                    MainGame.me.player.energy -= energyCost;
                }
                else if (__instance.wgo.is_player)
                {
                    __instance.SetSpeed(LazyConsts.PLAYER_SPEED);
                }
            }
        }
    }
}