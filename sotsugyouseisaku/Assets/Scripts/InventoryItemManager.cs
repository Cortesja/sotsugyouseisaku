using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemManager : MonoBehaviour
{
    Item item_;
    [SerializeField] AttackManager attackManager_;
    [SerializeField] Button UseButton;
    public void UseItem()
    {
        attackManager_.SetSpell(item_);
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
