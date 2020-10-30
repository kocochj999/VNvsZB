using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.InteropServices;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;

public class ZombiePool : MonoBehaviour
{
    public GameObject zombiePrefab;
    public BoxCollider2D leftEdge;
    public BoxCollider2D rightEdge;
    public BoxCollider2D topEdge;
    public BoxCollider2D bottomEdge;

    private GameObject[] zombiePool;
    private Vector2 objectPoolPosition = new Vector2(-20, -35);
    private int poolMaxSize = 20;
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
            zombiePool[currentZombie].transform.position = RandomPosition();
            currentZombie++;
        }
    }
    private Vector2 RandomPosition()
    {
        int minPos = 1;
        int maxPos = 5;
        int randomPos = Random.Range(minPos, maxPos);
        Vector2 spawnPostition = Vector2.zero;
        
        switch(randomPos)
        {
            case 1:
                float ySpawnPosLeft = Random.Range((topEdge.offset.y) - 5, (bottomEdge.offset.y) + 5);
                float xSpawnPosLeft = leftEdge.offset.x + 5;
                spawnPostition = new Vector2(xSpawnPosLeft, ySpawnPosLeft);
                break;
            case 2:
                float ySpawnPosRight = Random.Range(topEdge.offset.y - 5, bottomEdge.offset.y + 5);
                float xSpawnPosRight = rightEdge.offset.x - 5;
                spawnPostition = new Vector2(xSpawnPosRight, ySpawnPosRight);
                break;
            case 3:
                float ySpawnPosTop = topEdge.offset.y - 5;
                float xSpawnPosTop = Random.Range(leftEdge.offset.x + 5, rightEdge.offset.x - 5);
                spawnPostition = new Vector2(xSpawnPosTop, ySpawnPosTop);
                break;
            case 4:
                float ySpawnPosBtm = bottomEdge.offset.y + 5;
                float xSpawnPosBtm = Random.Range(leftEdge.offset.x + 5, rightEdge.offset.x - 5);
                spawnPostition = new Vector2(xSpawnPosBtm, ySpawnPosBtm);
                break;
        }
        return spawnPostition;

        //leftside
        //float ySpawnPosLeft = Random.Range(topEdge.offset.y - 2, bottomEdge.offset.x + 2);
        //float xSpawnPosLeft = leftEdge.offset.x + 2;
        //Vector2 leftPos = new Vector2(xSpawnPosLeft, ySpawnPosLeft);

        //rightside
        
        //Vector2 rightPos = new Vector2(xSpawnPosRight, ySpawnPosRight);

        //topside
        
        //Vector2 topPos = new Vector2(xSpawnPosTop, ySpawnPosTop);

        //bottomside
        
        //Vector2 btmPos = new Vector2(xSpawnPosBtm, ySpawnPosBtm);
    }
}
