using HarmonyLib;
using RimWorld;
using Verse;

namespace EmbrasureGateFix
{
    [StaticConstructorOnStartup]
    public static class EmbrasureGateFixMod
    {
        static EmbrasureGateFixMod()
        {
            new Harmony("wishRobber.embrasuregatefix").PatchAll();
        }
    }

    // Vanilla DoorUtility.EncapsulatingWallAt only accepts an edifice with Full fillage as a wall.
    // Embrasure walls use Partial fillage (so pawns can see/shoot through), which makes multi-tile
    // doors/gates report "Must be connected to walls on both sides to function" and stop sealing.
    // This postfix also treats any impassable, roof-holding, non-door building as an encapsulating
    // wall, so embrasures qualify while keeping their Partial fillage (and thus their line-of-fire
    // property). Full walls already return true from the original method, so they are unaffected.
    [HarmonyPatch(typeof(DoorUtility), nameof(DoorUtility.EncapsulatingWallAt))]
    public static class Patch_DoorUtility_EncapsulatingWallAt
    {
        public static void Postfix(ref bool __result, IntVec3 cell, Map map)
        {
            if (__result || map == null || !cell.InBounds(map))
            {
                return;
            }

            Building edifice = cell.GetEdifice(map);
            if (edifice == null)
            {
                return;
            }

            ThingDef def = edifice.def;
            if (def != null && def.holdsRoof && def.passability == Traversability.Impassable && !def.IsDoor)
            {
                __result = true;
            }
        }
    }
}
