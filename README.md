# Castle Gates Connect to Embrasures

Vanilla's multi-tile doors and gates (including Vanilla Factions Expanded - Medieval 2's castle doors/gates) only accept a wall on their ends if that wall has Full fillage. Embrasure walls (e.g. Medieval Overhaul's DankPyon_CastleWallEmbrasures, Fortifications - Medieval's FT_CastleWallEmbrasures) use Partial fillage so pawns can see and shoot through them, which makes the door report "Must be connected to walls on both sides to function" and stop sealing.

This patches the vanilla wall check (DoorUtility.EncapsulatingWallAt) so any impassable, roof-holding, non-door building - i.e. embrasure walls - also counts as an encapsulating wall. The embrasures keep their Partial fillage, so the see/shoot-through property is fully preserved. Works generically with any mod's embrasure walls; does nothing if none are present.

---

A RimWorld 1.6 mod by wishRobber.
