using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (PlayerLauncher.instance.player == null) return;
        
        if(collision.relativeVelocity.magnitude > 2 && PlayerLauncher.instance.player.launching == true)
        {
            GameManager.instance.DestroyEnemy(this);
        }
    }
}
