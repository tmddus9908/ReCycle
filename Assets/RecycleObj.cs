using UnityEngine;

public class RecycleObj : MonoBehaviour
{
    public ObjectManager.RecycleType type;

    private void Awake()
    {
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
}
