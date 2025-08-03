using System.Collections.Generic;
using UCDC_Mod_Api.ModInterfaces.SkinLocators;
using UnityEngine;

namespace Cake_Girl_Mod
{
    public class RagdollContainer : MonoBehaviour, IRagDollLocator
    {
        [SerializeField] private List<Rigidbody> body;
        [SerializeField] private Transform hip;
        [SerializeField] private Rigidbody rightHand;
    
        public List<Rigidbody> GetBodyParts()
        {
            return body;
        }

        public Transform GetHip()
        {
            return hip;
        }

        public Rigidbody GetHand()
        {
            return rightHand;
        }
    }
}
