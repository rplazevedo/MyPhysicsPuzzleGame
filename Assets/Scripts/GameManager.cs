using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> availablePLayers = new List<GameObject>();
    public List<Enemy> enemies = new List<Enemy>();

    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }


    private void Start()
    {
        SpawnNewPlayer();
    }

    public void SpawnNewPlayer()
    {
        PlayerLauncher.instance.SetNewPLayer(availablePLayers[0]);
        availablePLayers.RemoveAt(0);
    }
    
    public void PlayerFinished()
    {
        SpawnNewPlayer();
    }

    public void DestroyEnemy(Enemy enemy)
    {
        enemies.Remove(enemy);
        Destroy(enemy.gameObject);
    }
}
