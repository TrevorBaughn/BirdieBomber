using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public List<GameObject> spawnableObjects;
    private GameObject objectToSpawn;
    public float timeBetweenSpawns;
    public bool isSpawnedAtStart;
    private GameObject spawnedObject;
    private float spawnCountdown;

    // Start is called before the first frame update
    void Start()
    {
        if (isSpawnedAtStart)
        {
            objectToSpawn = spawnableObjects[Random.Range(0, spawnableObjects.Count - 1)];
            spawnedObject = Instantiate(objectToSpawn,
                            transform.position + new Vector3(transform.position.x,
                                                             objectToSpawn.GetComponent<SpriteRenderer>().bounds.size.y / 2,
                                                             transform.position.z),
                            transform.rotation);
        }
        spawnCountdown = timeBetweenSpawns;
    }

    // Update is called once per frame
    void Update()
    {
            spawnCountdown -= Time.deltaTime;
            //spawn new thing
            if(spawnCountdown <= 0 && timeBetweenSpawns >= 0) //negative means one-time spawn
            {
                objectToSpawn = spawnableObjects[Random.Range(0, spawnableObjects.Count)];
                spawnedObject = Instantiate(objectToSpawn, 
                                transform.position + new Vector3(0,
                                                                 objectToSpawn.GetComponent<SpriteRenderer>().bounds.size.y / 2,
                                                                 0),
                                transform.rotation);
                spawnCountdown = timeBetweenSpawns;

                //organize hierarchy
                spawnedObject.gameObject.transform.parent = this.transform;
            }
    }
}
