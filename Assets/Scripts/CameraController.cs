using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Player player;

    [SerializeField]
    private float offset = 2.0f;

    public static CameraController instance;

    private void Awake()
    {
        instance = this;
    }

    private void FixedUpdate()
    {
        if(player == null) { return; }

        if(player.launching && player.transform.position.x >= transform.position.x - offset)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(player.transform.position.x + offset, 1, -10), Time.deltaTime * 10 );
        }
    }
}
