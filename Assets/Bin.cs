using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bin : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        InventoryDB.Instance.obj.Clear();
        InventoryDB.Instance.ClearSlotImage();
    }
}
