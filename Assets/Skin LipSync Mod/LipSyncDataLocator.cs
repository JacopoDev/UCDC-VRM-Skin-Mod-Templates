using System;
using System.Collections.Generic;
using UCDC_Mod_Api.Models.Skins;
using UCDC_Mod_Api.ModInterfaces.SkinLocators;
using UnityEngine;

namespace Skin_LipSync_Mod
{
    
    public class LipSyncDataLocator : MonoBehaviour, ILipSyncLocator
    {
        public SkinnedMeshRenderer selectedMesh;

        [Header("Expressions")]
        public BlendShapeMorph aMorph = new BlendShapeMorph();     // Initialize so it’s never null
        public BlendShapeMorph iMorph = new BlendShapeMorph();
        public BlendShapeMorph uMorph = new BlendShapeMorph();
        public BlendShapeMorph eMorph = new BlendShapeMorph();
        public BlendShapeMorph oMorph = new BlendShapeMorph();
        public BlendShapeMorph nMorph = new BlendShapeMorph();
        public BlendShapeMorph noneMorph = new BlendShapeMorph();

        private LipSyncData _data;
        
        public LipSyncData GetLipSyncData()
        {
            if (_data == null)
            {
                _data = new LipSyncData()
                {
                    lipSyncMesh = selectedMesh,
                    a = aMorph,
                    i = iMorph,
                    u = uMorph,
                    e = eMorph,
                    o = oMorph,
                    n = nMorph,
                    none = noneMorph,
                };
            }

            return _data;
        }
    }
}