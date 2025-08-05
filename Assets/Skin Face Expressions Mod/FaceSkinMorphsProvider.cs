using System.Collections.Generic;
using UCDC_Mod_Api.Models;
using UCDC_Mod_Api.Models.Skins;
using UCDC_Mod_Api.ModInterfaces.SkinLocators;
using UnityEngine;

namespace Skin_Face_Expressions_Mod
{
    public class FaceSkinMorphsProvider : MonoBehaviour, IExpressionsLocator
    {
        [SerializeField] private BlendShapeSelector blendShapes;
        
        public FacialExpressionData GetExpressionData()
        {
            FacialExpressionData blendData = new FacialExpressionData
            {
                expressionMesh = blendShapes.selectedMesh,
                
                Happy = blendShapes.happy.blendshapes,
                Sad = blendShapes.sad.blendshapes,
                Angry = blendShapes.angry.blendshapes,
                Surprised = blendShapes.surprised.blendshapes,
                Flirty = blendShapes.flirty.blendshapes
            };

            return blendData;
        }
    }
}
