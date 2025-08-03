using UCDC_Mod_Api.ModInterfaces.SkinLocators;
using UnityEngine;

namespace Skin_Blink_Support_Mod
{
    public class BlinkParamSetter : MonoBehaviour, IBlinkLocator
    {
        [SerializeField] private SkinnedMeshRenderer leftEyeRenderer;
        [SerializeField] private SkinnedMeshRenderer rightEyeRenderer;
        [Space] 
        [SerializeField] private int leftEyeBlendShapeId;
        [SerializeField] private int rightEyeBlendShapeId;
        [Space] 
        [SerializeField] private float valueToOpenEyes;
        [SerializeField] private int valueToCloseEyes;

    
        public SkinnedMeshRenderer GetLeftEye()
        {
            return leftEyeRenderer;
        }

        public SkinnedMeshRenderer GetRightEye()
        {
            return rightEyeRenderer;
        }

        public int GetEyeCloseBlendIdLeft()
        {
            return leftEyeBlendShapeId;
        }

        public int GetEyeCloseBlendIdRight()
        {
            return rightEyeBlendShapeId;
        }

        public float GetEyeOpenBlendValue()
        {
            return valueToOpenEyes;
        }

        public float GetEyeCloseBlendValue()
        {
            return valueToCloseEyes;
        }
    }
}
