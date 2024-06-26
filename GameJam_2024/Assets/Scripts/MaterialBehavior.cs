using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    //Create a random object that spawns at a random location
    public GameObject randomObject;

    //Create a spawn time for the object
    public float spawnTimeInitial;
    private float spawnTime;

    public float radius;
    //offset from the center of the sphere
    public Vector2 offset;

    private float limitMinerals = 5;

    private float counter = 0;
    

    void Start()
    {
        //Set the spawn time to a random value between 5 and 10 seconds
        spawnTime = Time.time + Random.Range(spawnTimeInitial - 2.0f, spawnTimeInitial + 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= spawnTime)
        {
            //Spawn the object
            SpawnObject();
            //Reset the spawn time
            spawnTime = Time.time + Random.Range(spawnTimeInitial - 2.0f, spawnTimeInitial + 2.0f);
        }
    }

    public void SpawnObject()
    {
        //Create a random object at a random location in the perimeter of a circle
        if (counter < limitMinerals)
        {
            Vector2 spawnPosition = Random.insideUnitCircle.normalized * radius + offset;
            Instantiate(randomObject, spawnPosition, Quaternion.identity);
            counter++;
        }

    }

    public void pickMaterial()
    {
        counter--;
    }
}
