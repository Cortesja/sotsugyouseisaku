using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class CurrentSpell_UI : MonoBehaviour
{
    [SerializeField] AttackManager attackManager_;

    private SpellType spellType_;
    private Sprite fireUiImage_;
    private Sprite thunderUiImage_;
    private Sprite waterUiImage_;
    private Sprite currentSprite_;

    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = GameObject.FindGameObjectWithTag("Player");
        attackManager_ = obj.GetComponentInChildren<AttackManager>();

        fireUiImage_ = Resources.Load<Sprite>("OriginalModels/SpellCard/Texture/fire_ui");
        thunderUiImage_ = Resources.Load<Sprite>("OriginalModels/SpellCard/Texture/thunder_ui");
        waterUiImage_ = Resources.Load<Sprite>("OriginalModels/SpellCard/Texture/water_ui");
    }

    // Update is called once per frame
    void Update()
    {
        spellType_ = attackManager_.GetSpell();

        switch (spellType_)
        {
            case SpellType.kFire:
                currentSprite_ = fireUiImage_;
                break;
            case SpellType.kThunder:
                currentSprite_ = thunderUiImage_;
                break;
            case SpellType.kWater:
                currentSprite_ = waterUiImage_;
                break;
            default:
                currentSprite_ = fireUiImage_;
                break;
        }
    }
}
