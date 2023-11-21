using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rig;
    public bool launching;


    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
        rig.isKinematic = true;
    }
    private void Update()
    {
        if(launching && rig.IsSleeping())
        {
            // next player
            Destroy(this.gameObject);
        }
    }

    public void Launch (Vector2 direction)
    {
        rig.isKinematic = false;
        // TODO: make speed dependent on draggin the mouse
        rig.AddForce(direction * 5, ForceMode2D.Impulse);
        launching = true;
    }
}
