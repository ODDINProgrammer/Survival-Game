using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<Item> items;
    [SerializeField] private Transform itemsParent;
    [SerializeField] private ItemSlot[] itemSlots;

    public bool AddItem(Item _item)
    {
        if (!isInventoryFull())
        {
            for (int i = 0; i < itemSlots.Length; i++)
            {
                //  IF WE HAVE SIMILAR ITEM AND ITS MAXIMUM STACK IS NOT REACHED ADD TO THE SAME SLOT
                if (itemSlots[i].Item != null && itemSlots[i].Item.ItemName == _item.ItemName && itemSlots[i].Amount < itemSlots[i].Item.MaxStacks)
                {
                    itemSlots[i].Amount++;

                    RefreshUI();

                    return true;
                }
                //  ELSE ADD TO NEW SLOT 
                if (itemSlots[i].Item == null)
                {
                    items.Add(_item);

                    itemSlots[i].Amount++;

                    RefreshUI();

                    return true;
                }
            }
        }
        return false;
    }

    private bool isInventoryFull()
    {
        return items.Count >= itemSlots.Length;
    }

    private void OnValidate()
    {
        if (itemsParent != null)
            itemSlots = itemsParent.GetComponentsInChildren<ItemSlot>();

        RefreshUI();
    }

    private void RefreshUI()
    {
        for (int i = 0; i < items.Count && i < itemSlots.Length; i++)
        {
            if (items[i] != null)
                itemSlots[i].Item = items[i];
            else
                itemSlots[i].Item = null;
        }
    }
}
