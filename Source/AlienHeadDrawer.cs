﻿using AlienRace;
using FacialStuff;
using UnityEngine;
using Verse;

namespace AlienFaces
{
    public class AlienHeadDrawer : HumanHeadDrawer
    {
        // Vanilla offsets
        public new static readonly float[] HorHeadOffsets = {0f, 0.04f, 0.1f, 0.09f, 0.1f, 0.09f};

        public override void BaseHeadOffsetAt(ref Vector3 offset, bool portrait)
        {
            base.BaseHeadOffsetAt(ref offset, portrait);
            HarmonyPatches.BaseHeadOffsetAtPostfix(this.Pawn.Drawer.renderer, ref offset );
        }

        public override Mesh GetPawnMesh(bool wantsBody, bool portrait)
        {
            return HarmonyPatches.GetPawnMesh(portrait, this.Pawn, wantsBody ? this.BodyFacing : this.HeadFacing,
                                              wantsBody);
        }


        public override Mesh GetPawnHairMesh(bool portrait)
        {
            return HarmonyPatches.GetPawnHairMesh(portrait, this.Pawn, this.HeadFacing, this.Graphics);
        }

        public override void DrawAlienBodyAddons(bool portrait, Vector3 rootLoc, Quaternion quat, bool renderBody, Rot4 rotation)
        {
            HarmonyPatches.DrawAddons(portrait, this.Pawn, rootLoc, quat, rotation);
        }
    }
}