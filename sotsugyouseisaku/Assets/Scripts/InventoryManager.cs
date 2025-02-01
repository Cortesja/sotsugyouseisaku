using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    private List<Item> items = new List<Item>();

    [SerializeField] private Transform itemContent;
    [SerializeField] private GameObject inventoryItem;
    [SerializeField] private InventoryItemManager[] inventoryItems;

    private AttackManager attackManager_;

    private void Start()
    {
        GameObject obj = GameObject.FindGameObjectWithTag("Player");
        attackManager_ = obj.GetComponentInChildren<AttackManager>();
    }

    private void Awake()
    {
        Instance = this;
    }

    public void Add(Item item)
    {
        items.Add(item);
    }

    public void Remove(Item item)
    {
        items.Remove(item);
    }

    public void ListItems()
    {
        foreach (Transform item in itemContent)
        {
            item.gameObject.SetActive(false);
        }
        foreach (var item in items)
        {
            GameObject obj = Instantiate(inventoryItem, itemContent);

            var itemName = obj.transform.Find("ItemName").GetComponent<Text>();
            var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();

            itemName.text = item.itemName;
            itemIcon.sprite = item.icon;
        }

        SetInventoryItems();
    }

    public SpellType SetSpellType(Item items)
    {
        return items.spellType;
    }

    public int SetSpellDmg(Item items)
    {
        return items.dmg;
    }

    public void SetInventoryItems()
    {
        inventoryItems = itemContent.GetComponentsInChildren<InventoryItemManager>();

        for (int i = 0; i < items.Count; i++)
        {
            inventoryItems[i].AddItem(items[i]);
            inventoryItems[i].AddStaff(attackManager_);
        }
    }
}
