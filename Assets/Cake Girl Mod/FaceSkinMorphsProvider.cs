using UCDC_Mod_Api.Models;
using UCDC_Mod_Api.ModInterfaces.SkinLocators;
using UnityEngine;

namespace Cake_Girl_Mod
{
    public class FaceSkinMorphsProvider : MonoBehaviour, IExpressionsLocator
    {
        [SerializeField] private Cake_Girl_Mod.BlendShapeSelector blendShapes;
        
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
