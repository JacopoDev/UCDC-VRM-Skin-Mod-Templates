using System.Collections;
using System.Collections.Generic;
using UCDC_Mod_Api.GameInterfaces;
using UCDC_Mod_Api.Models;
using UCDC_Mod_Api.ModInterfaces;
using UMod;
using UnityEngine;

public class HeadpatsSkinAdder : ModScript, ISkinAccessor
{
        public Avatar animationAvatar;
        public GameObject skinPrefab;
        public Sprite skinPreview;

        public void GetDatabase(ISkinDatabaseProvider databaseProvider)
        {
            skinPrefab = ModAssets.Load<GameObject>("CakeGirl6");
            GameObject avatarObj = ModAssets.Load<GameObject>("SkinData");
            animationAvatar = avatarObj.GetComponent<Animator>().avatar;
            skinPreview = avatarObj.GetComponent<SpriteRenderer>().sprite;
        
        
            databaseProvider.Add(new SkinInfo()
            {
                AnimationAvatar = animationAvatar,
                SkinName = "Cake Girl6",
                Description = "Template VRM skin made for mod tutorial",
                Prefab = skinPrefab,
                Preview = skinPreview
            });
        }
}
