using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class ZombiePool : MonoBehaviour
{
    public GameObject zombiePrefab;

    private GameObject[] zombiePool;
    private Vector2 objectPoolPosition = new Vector2(-15, -25);
    private int poolMaxSize = 10;
    private float spawnRate = 3f;
    private float timeSinceLastSpawn;
    private int currentZombie = 0;

    // Start is called before the first frame update
    void Start()
    {
        timeSinceLastSpawn = 0f;
        zombiePool = new GameObject[poolMaxSize];
        for(int i = 0; i < poolMaxSize; i++ )
        {
            zombiePool[i] = (GameObject)Instantiate(zombiePrefab, objectPoolPosition, Quaternion.identity);

        }
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;
        if(timeSinceLastSpawn >= spawnRate && currentZombie < poolMaxSize)
        {
            timeSinceLastSpawn = 0f;
            float xSpawnPos = Random.Range(-15f, 10f);

            zombiePool[currentZombie].transform.position = new Vector2(xSpawnPos, 15f);
            currentZombie++;
            /* if(currentZombie >= poolMaxSize)
            {
                currentZombie = 0;
            }*/
        }
    }
}
