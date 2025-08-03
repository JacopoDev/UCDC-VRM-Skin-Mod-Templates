using System;
using System.Collections.Generic;
using UCDC_Mod_Api.Models;
using UnityEngine;

namespace Skin_Face_Expressions_Mod
{
    [Serializable]
    public class Expression
    {
        public List<BlendShapeMorph> blendshapes = new List<BlendShapeMorph>();
    }

    public class BlendShapeSelector : MonoBehaviour
    {
        public SkinnedMeshRenderer selectedMesh;

        [Header("Expressions")]
        public Expression happy = new Expression();     // Initialize so it’s never null
        public Expression sad = new Expression();
        public Expression angry = new Expression();
        public Expression surprised = new Expression();
        public Expression flirty = new Expression();
    }
}