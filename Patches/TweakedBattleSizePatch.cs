using HarmonyLib;
using System;
using TaleWorlds.MountAndBlade;
using TaleWorlds.Core;

namespace BannerlordTweaks.Patches
{
    [HarmonyPatch(typeof(MissionAgentSpawnLogic), MethodType.Constructor, new Type[] { typeof(IMissionTroopSupplier[]), typeof(BattleSideEnum) })]
    public class TweakedBattleSizePatch2
    {
        static void Postfix(MissionAgentSpawnLogic __instance, ref int ____battleSize)
        {

            if (BannerlordTweaksSettings.Instance is { } settings && settings.BattleSize > 0)
            {
                ____battleSize = settings.BattleSize;
                DebugHelpers.ColorGreenMessage("Max Battle Size Modified to: " + settings.BattleSize);
            }

            return;
        }

        static bool Prepare() => BannerlordTweaksSettings.Instance is { } settings && settings.BattleSizeTweakEnabled;
    } 
}