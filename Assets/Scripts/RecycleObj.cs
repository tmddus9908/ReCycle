using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class RecycleObj : MonoBehaviour
{
    public ObjectManager.RecycleType type;

    private void Awake()
    {
        var enumValues = Enum.GetValues(enumType: typeof(ObjectManager.RecycleType));
        type = (ObjectManager.RecycleType)enumValues.GetValue(Random.Range(0, enumValues.Length));

        if (type == ObjectManager.RecycleType.Metal)
        {
            int i = Random.Range(0, ObjectManager.Instance.metalObjectSprite.Length);
            this.gameObject.GetComponent<SpriteRenderer>().sprite = ObjectManager.Instance.metalObjectSprite[i];
        }
        else if (type == ObjectManager.RecycleType.Glass)
        {
            int i = Random.Range(0, ObjectManager.Instance.glassObjectSprite.Length);
            this.gameObject.GetComponent<SpriteRenderer>().sprite = ObjectManager.Instance.glassObjectSprite[i];
        }
        else if (type == ObjectManager.RecycleType.Paper)
        {
            int i = Random.Range(0, ObjectManager.Instance.paperObjectSprite.Length);
            this.gameObject.GetComponent<SpriteRenderer>().sprite = ObjectManager.Instance.paperObjectSprite[i];
        }
        else if (type == ObjectManager.RecycleType.Plastic)
        {
            int i = Random.Range(0, ObjectManager.Instance.plasticObjectSprite.Length);
            this.gameObject.GetComponent<SpriteRenderer>().sprite = ObjectManager.Instance.plasticObjectSprite[i];
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        InventoryDB.Instance.obj.Add(this.type);
        Slot slot = InventoryDB.Instance.FindSlot();
        
        if (InventoryDB.Instance.CheckNull())
            InventoryDB.Instance.ChangeSlotImage(slot, this.GetComponent<SpriteRenderer>().sprite);
        else
            return;
        
        Destroy(this.gameObject);
    }
}
