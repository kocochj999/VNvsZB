using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.InteropServices;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class ZombiePool : MonoBehaviour
{
    public GameObject zombiePrefab;
    public GameObject zombieBossPrefab;

    public GameObject spawn1;
    public GameObject spawn2;
    public GameObject spawn3;
    public GameObject spawn4;
    public GameObject spawn5;
    public GameObject spawn6;
    public GameObject spawn7;
    public GameObject spawn8;
    public GameObject initSpawnPoint;

    private GameObject[] zombiePool;
    private int poolMaxSize = 25;
    private float spawnRate = 2f;
    private float timeSinceLastSpawn;
    private int currentZombie = 0;

    // Start is called before the first frame update
    void Start()
    {
        timeSinceLastSpawn = 0f;
        zombiePool = new GameObject[poolMaxSize];
        for(int i = 0; i < poolMaxSize; i++ )
        {
            zombiePool[i] = (GameObject)Instantiate(zombiePrefab, initSpawnPoint.transform.position, Quaternion.identity);

        }
        zombieBossPrefab = (GameObject)Instantiate(zombieBossPrefab, initSpawnPoint.transform.position, Quaternion.identity);
        
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;
        if(timeSinceLastSpawn >= spawnRate && currentZombie < poolMaxSize)
        {
            timeSinceLastSpawn = 0f;
            zombiePool[currentZombie].transform.position = RandomPosition();
            currentZombie++;
        }
        if(currentZombie == poolMaxSize)
        {
            currentZombie++;
            zombieBossPrefab.transform.position = RandomPosition();

            
        }
    }
    private Vector3 RandomPosition()
    {
        Vector3 spawnPostition = new Vector3(0,0);
        int minPos = 1;
        int maxPos = 8;
        int randomPos = Random.Range(minPos, maxPos);
        
        
        switch(randomPos)
        {
            case 1:
                spawnPostition = spawn1.transform.position;
                break;
            case 2:
                spawnPostition = spawn2.transform.position;
                break;
            case 3:
                spawnPostition = spawn3.transform.position;
                break;
            case 4:
                spawnPostition = spawn4.transform.position;
                break;
            case 5:
                spawnPostition = spawn5.transform.position;
                break;
            case 6:
                spawnPostition = spawn6.transform.position;
                break;
            case 7:
                spawnPostition = spawn7.transform.position;
                break;
            case 8:
                spawnPostition = spawn8.transform.position;
                break;
        }
        return spawnPostition;

    }
}
