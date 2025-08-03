using UCDC_Mod_Api.ModInterfaces.SkinLocators;
using UnityEngine;

namespace Skin_HeadPats_Mod
{
    public class HeadPatsLocator : MonoBehaviour, IHeadPatLocator
    {
        [SerializeField] private Transform pattingHand;
        [SerializeField] private Transform head;
        [SerializeField] private Transform neck;
        [SerializeField] private Transform headColliderLocation;
        

        public Transform GetHeadPatColliderSpot()
        {
            return headColliderLocation;
        }

        public Transform GetHeadTransform()
        {
            return head;
        }

        public Transform GetNeckTransform()
        {
            return neck;
        }

        public Transform GetPettingHandPlacement()
        {
            return pattingHand;
        }
    }
}
