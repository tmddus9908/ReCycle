using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryDB : Singleton<InventoryDB>
{
    public List<ObjectManager.RecycleType> obj = new List<ObjectManager.RecycleType>();
    public List<Slot> slots = new List<Slot>();

    public Slot FindSlot()
    {
        int idx = 0;
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].image.sprite == null)
            {
                idx = i;
                break;
            }
        }
        return slots[idx];
    }

    public bool CheckNull()
    {
        bool part = true;
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].image.sprite != null)
                part = false;
            else
                part = true;
        }

        return part;
    }
    public void ChangeSlotImage(Slot slot, Sprite sprite)
    {
        Debug.Log("호출");
        slot.image.sprite = sprite;
    }

    public void ClearSlotImage()
    {
        for (int i = 0; i < slots.Count; i++)
        {
            slots[i].image.sprite = null;
        }
    }
}
