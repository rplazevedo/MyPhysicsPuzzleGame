using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLauncher : MonoBehaviour
{
    public Transform playerStartPos;
    public Player player;
    private bool holdingPlayer;

    private Camera cam;

    public static PlayerLauncher instance;

    private void Awake()
    {
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            return;
        }
        if (InputDown() && player.launching == false)
        {
            Vector3 touchWorldPosition;

            if(Input.touchCount > 0)
            {
                touchWorldPosition = cam.ScreenToWorldPoint(Input.touches[0].position);
            }
            else
            {
                touchWorldPosition = cam.ScreenToWorldPoint(Input.mousePosition);
            }
            touchWorldPosition.z = 0;

            if(Vector3.Distance(touchWorldPosition, player.transform.position) <= 3.0f)
            {
                holdingPlayer = true;
            }
        }

        if(InputUp() && holdingPlayer)
        {
            holdingPlayer = false;
            player.Launch(playerStartPos.position - player.transform.position);
        }

        if (holdingPlayer && player.launching == false)
        {
            Vector3 newPos;

            if(Input.touchCount>0) 
            {
                newPos = cam.ScreenToWorldPoint(Input.touches[0].position);
            }
            else
            {
                newPos = cam.ScreenToWorldPoint(Input.mousePosition);
            }

            newPos.z = 0;
            player.transform.position = newPos;
        }
    }

    bool InputDown()
    {
        // check for touch input
        if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began) 
        {
            return true;
        }
        else if (Input.GetMouseButtonDown(0))
        {
            return true;
        }

        return false;
    }
    bool InputUp()
    {
        // check for touch input
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Ended)
        {
            return true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            return true;
        }

        return false;
    }
}
