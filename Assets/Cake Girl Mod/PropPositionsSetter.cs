using System.Collections;
using System.Collections.Generic;
using UCDC_Mod_Api.Models;
using UCDC_Mod_Api.Models.Skins;
using UCDC_Mod_Api.ModInterfaces.SkinLocators;
using UnityEngine;

namespace Cake_Girl_Mod
{
    public class PropPositionsSetter : MonoBehaviour, IPropsLocator, IHeadPatLocator
    {
        [Header("Head pats locations")]
        [SerializeField] private Transform headPatHandLocation;
        [SerializeField] private Transform headTransform;
        [SerializeField] private Transform neckTransform;
        [SerializeField] private Transform headpatColliderSpot;
        
        [Header("Props locations")]
        [SerializeField] private List<Transform> propLocations;
        [SerializeField] private List<PropPositionOffset> offsets;
        
        private List<PropPlacementInfo> _propOffsets;
    
        private readonly string[] _builtInPropNames = new []
        {
            "Global.GamePad",
            "Global.HeadPhones",
            "Global.Phone",
            "Global.Glasses",
            "Global.Clipboard",
        };
    
        public Dictionary<EPropsLocation, Transform> GetPropsLocations()
        {
            Dictionary<EPropsLocation, Transform> dict = new Dictionary<EPropsLocation, Transform>()
            {
                { EPropsLocation.TopHead, propLocations[(int)EPropsLocation.TopHead] },
                { EPropsLocation.LeftHand, propLocations[(int)EPropsLocation.LeftHand] },
                { EPropsLocation.RightHand, propLocations[(int)EPropsLocation.RightHand] },
            };
            
            return dict;
        }
    
        public List<PropPlacementInfo> GetPropRootOverrides()
        {
            if (_propOffsets != null) return _propOffsets;
            
            _propOffsets = new List<PropPlacementInfo>();
            for (var index = 0; index < offsets.Count; index++)
            {
                var offset = offsets[index];
                _propOffsets.Add(new PropPlacementInfo()
                {
                    PropName = _builtInPropNames[index],
                    Position = offset.Position,
                    Rotation = offset.Rotation,
                    Scale = offset.Scale
                });
            }
            return _propOffsets;
        }
    
        public Transform GetHeadPatColliderSpot()
        {
            return headpatColliderSpot;
        }
    
        public Transform GetHeadTransform()
        {
            return headTransform;
        }
    
        public Transform GetNeckTransform()
        {
            return neckTransform;
        }
    
        public Transform GetPettingHandPlacement()
        {
            return headPatHandLocation;
        }
    }
}
