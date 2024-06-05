using UnityEngine;

public class MiniGameRange : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        GetComponentInParent<Minigame>().conclude = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        GetComponentInParent<Minigame>().conclude = false;
    }
}
