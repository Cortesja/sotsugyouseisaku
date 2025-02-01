using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemManager : MonoBehaviour
{
    private Item item_;
    [SerializeField] private AttackManager attackManager_;
    [SerializeField] private Button UseButton;
    public void UseItem()
    {
        attackManager_.SetSpell(item_);
        attackManager_.SetSpellDmg(item_);
        Player.Instance.SetHasSpell(true);
        InventoryManager.Instance.Remove(item_);
        Destroy(gameObject);
    }

    public void AddItem(Item newItem)
    {
        item_ = newItem;
    }

    public void AddStaff(AttackManager staff)
    {
        attackManager_ = staff;
    }
}
