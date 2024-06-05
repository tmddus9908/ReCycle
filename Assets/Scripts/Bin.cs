using UnityEngine;

public class Bin : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (InventoryDB.Instance.obj.Count >= 1)
        {
            Player.Instance.miniGame.SetActive(true);
            Player.Instance.miniGame.GetComponent<Minigame>().RandomPosition();
            Player.Instance.miniGame.GetComponent<Minigame>().RandomScale();
        }
        else if(InventoryDB.Instance.obj.Count < 1)
            return;
    }
}
