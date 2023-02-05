using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawning : MonoBehaviour
{
    public GameObject goodItem;
    public GameObject badItem;
    public bool secondSpawner;
    public Transform otherSpawner;

    private float goodObjectSpawnChance = 0.7f;

    private float timeTillNextObject;
    private float minSpawnTime = 0.75f; //every 0.5 = 1 sec
    private float maxSpawnTime = 1.25f;

    private float spawnOffset = 150f;

    private float minBorbSpeed = 4f;
    private float maxBorbSpeed = 7f;

    void Awake()
    {
        
        if (secondSpawner)
        {
            transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.nearClipPlane));
        }
        else
        {
            transform.position = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
        }

        timeTillNextObject = Random.Range(minSpawnTime, maxSpawnTime);
    }

    void FixedUpdate()
    {
        timeTillNextObject -= 0.01f;
        if (timeTillNextObject <= 0f)
        {
            GameObject o;
            float randomNumber = Random.Range(0f, 1f);

            if (randomNumber < goodObjectSpawnChance)
            {
                o = Instantiate(goodItem, transform.position, transform.rotation);

            } else
            {
                o = Instantiate(badItem, transform.position, transform.rotation);

            }
            float actualOffset = Random.Range(-spawnOffset, spawnOffset);
            o.transform.position = new Vector3(o.transform.position.x + actualOffset, o.transform.position.y - actualOffset);
            o.GetComponent<Rigidbody2D>().AddForce((otherSpawner.position - transform.position) * Random.Range(minBorbSpeed, maxBorbSpeed));
            timeTillNextObject = Random.Range(minSpawnTime, maxSpawnTime);
        }
    }
}
