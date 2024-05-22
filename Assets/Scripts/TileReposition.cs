using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileReposition : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Area"))
            return;

        Vector3 playerPos = GameManager.instance.player.transform.position;
        Vector3 tilePos = transform.position;
        float diffX = Mathf.Abs(playerPos.x - tilePos.x);
        float diffY = Mathf.Abs(playerPos.y - tilePos.y);

        Vector3 playerDir = GameManager.instance.player.inputV;
        float dirX = playerDir.x < 0 ? -1 : 1;
        float dirY = playerDir.y < 0 ? -1 : 1;

        switch (transform.tag)
        {
            case "Ground":
                if (diffX > diffY)
                {
                    transform.Translate(Vector3.right * dirX * 80);
                }
                else if (diffY > diffX)
                {
                    transform.Translate(Vector3.up * dirY * 80);
                }
                break;
            case "Enemy":
                break;
        }
    }
}
