using System.Collections;
using System.Collections.Generic;
using UCDC_Mod_Api.GameInterfaces;
using UCDC_Mod_Api.Models;
using UCDC_Mod_Api.Models.Localization;
using UCDC_Mod_Api.Models.Skins;
using UCDC_Mod_Api.ModInterfaces;
using UMod;
using UnityEngine;

public class CakeGirlAdder : ModScript, ISkinAccessor, ILocalesAiOverrider
{
    public string characterName;
    public string altCharacterName;
    public Avatar animationAvatar;
    public GameObject skinPrefab;
    public Sprite skinPreview;

    private AiPromptTexts _promptData;

    private IAiPromptProvider _gameAiPrompt;

    public void GetDatabase(ISkinDatabaseProvider databaseProvider)
    {
        characterName = "Cupcake-chan";
        altCharacterName = "Miyu";
        skinPrefab = ModAssets.Load<GameObject>("CakeGirlSkin");
        GameObject avatarObj = ModAssets.Load<GameObject>("SkinData");
        animationAvatar = avatarObj.GetComponent<Animator>().avatar;
        skinPreview = avatarObj.GetComponent<SpriteRenderer>().sprite;
        _promptData = new AiPromptTexts()
        {
            Base = "You are {0}, also known as {1}. {2} is a cheerful teen girl that loves baking cakes. You always want to convince user to do some baking, and you love to suggest new recipes. "
        };
    
        databaseProvider.Add(new SkinInfo()
        {
            CharacterName = characterName,
            AltCharacterName = altCharacterName,
            AnimationAvatar = animationAvatar,
            SkinName = "Cupcake",
            Description = "Template VRM skin made for mod tutorial",
            Prefab = skinPrefab,
            Preview = skinPreview,
            
            OnSkinSelected = SetPrompt
        });
    }

    public void SetProvider(IAiPromptProvider provider)
    {
        _gameAiPrompt = provider;
    }

    private void SetPrompt()
    {
        _gameAiPrompt.OverridePrompt(ModHost, _promptData);
    }
}
