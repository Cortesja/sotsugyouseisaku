using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class CurrentSpell_UI : MonoBehaviour
{
    [SerializeField] AttackManager attackManager_;

    private SpellType spellType_;
    [SerializeField] private Sprite fireUiImage_;
    [SerializeField] private Sprite thunderUiImage_;
    [SerializeField] private Sprite waterUiImage_;
    [SerializeField] private Sprite healUiImage_;
    private Image currentSprite_;

    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = GameObject.FindGameObjectWithTag("Player");
        attackManager_ = obj.GetComponentInChildren<AttackManager>();

        if (currentSprite_ == null) { currentSprite_ = GetComponent<Image>(); }

        fireUiImage_ = Resources.Load<Sprite>("OriginalModels/SpellCard/Texture/fire_ui");
        thunderUiImage_ = Resources.Load<Sprite>("OriginalModels/SpellCard/Texture/thunder_ui");
        waterUiImage_ = Resources.Load<Sprite>("OriginalModels/SpellCard/Texture/water_ui");
        healUiImage_ = Resources.Load<Sprite>("OriginalModels/SpellCard/Texture/heal_ui");
    }

    // Update is called once per frame
    void Update()
    {
        spellType_ = attackManager_.GetSpell();
        
        switch (spellType_)
        {
            case SpellType.kFire:
                currentSprite_.sprite = fireUiImage_;
                break;
            case SpellType.kThunder:
                currentSprite_.sprite = thunderUiImage_;
                break;
            case SpellType.kWater:
                currentSprite_.sprite = waterUiImage_;
                break;
            case SpellType.kHeal:
                currentSprite_.sprite = healUiImage_;
                break;
            default:
                currentSprite_.sprite = fireUiImage_;
                break;
        }
    }
}
