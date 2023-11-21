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
        cam = Camera.main
    }

    // Update is called once per frame
    void Update()
    {
        
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
