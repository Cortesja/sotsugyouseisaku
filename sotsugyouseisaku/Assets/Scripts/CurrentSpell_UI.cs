using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class CurrentSpell_UI : MonoBehaviour
{
    [SerializeField] private AttackManager attackManager_;

    private SpellType spellType_;
    [SerializeField] private Sprite fireUiImage_;
    [SerializeField] private Sprite thunderUiImage_;
    [SerializeField] private Sprite waterUiImage_;
    [SerializeField] private Sprite healUiImage_;
    [SerializeField] private Sprite defaultUiImage_;

    private Image uiImage_;

    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = GameObject.FindGameObjectWithTag("Player");
        attackManager_ = obj.GetComponentInChildren<AttackManager>();

        // Get the Image component attached to this GameObject
        uiImage_ = GetComponent<Image>();
        if (uiImage_ == null)
        {
            Debug.LogError("❌ No Image component found on " + gameObject.name);
        }
    }

    private void Awake()
    {
        fireUiImage_ = Resources.Load<Sprite>("fire_ui");
        thunderUiImage_ = Resources.Load<Sprite>("thunder_ui");
        waterUiImage_ = Resources.Load<Sprite>("water_ui");
        healUiImage_ = Resources.Load<Sprite>("heal_ui");
        defaultUiImage_ = Resources.Load<Sprite>("default_ui");
    }

    // Update is called once per frame
    void Update()
    {
        if (attackManager_ == null || uiImage_ == null) return;

        if (Player.Instance.GetHasSpell()) { spellType_ = attackManager_.GetSpell(); } else
        {
            spellType_ = SpellType.kNumOfSpells;
        }

        switch (spellType_)
        {
            case SpellType.kFire:
                uiImage_.sprite = fireUiImage_;
                break;
            case SpellType.kThunder:
                uiImage_.sprite = thunderUiImage_;
                break;
            case SpellType.kWater:
                uiImage_.sprite = waterUiImage_;
                break;
            case SpellType.kHeal:
                uiImage_.sprite = healUiImage_;
                break;
            default:
                uiImage_.sprite = defaultUiImage_;
                break;
        }
    }
}
