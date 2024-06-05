using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameCheckPoint : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (transform.position.x > 0)
        {
            // Minigame.Instance.vec.x *= -1;
            GetComponentInParent<Minigame>().vec.x *= -1;
        }
        else
        {
            // Minigame.Instance.vec.x *= -1;            
            GetComponentInParent<Minigame>().vec.x *= -1;
        }
    }
}
