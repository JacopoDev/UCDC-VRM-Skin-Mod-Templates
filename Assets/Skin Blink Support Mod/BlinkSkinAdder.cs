using UCDC_Mod_Api.GameInterfaces;
using UCDC_Mod_Api.Models;
using UCDC_Mod_Api.ModInterfaces;
using UMod;
using UnityEngine;

namespace Skin_Blink_Support_Mod
{
    public class BlinkSkinAdder : ModScript, ISkinAccessor
    {
        public Avatar animationAvatar;
        public GameObject skinPrefab;
        public Sprite skinPreview;
    
        public void GetDatabase(ISkinDatabaseProvider databaseProvider)
        {
            skinPrefab = ModAssets.Load<GameObject>("CakeGirl3");
            GameObject avatarObj = ModAssets.Load<GameObject>("SkinData");
            animationAvatar = avatarObj.GetComponent<Animator>().avatar;
            skinPreview = avatarObj.GetComponent<SpriteRenderer>().sprite;
        
        
            databaseProvider.Add(new SkinInfo()
            {
                AnimationAvatar = animationAvatar,
                SkinName = "Cake Girl3",
                Description = "Template VRM skin made for mod tutorial",
                Prefab = skinPrefab,
                Preview = skinPreview
            });
        }
    }
}
