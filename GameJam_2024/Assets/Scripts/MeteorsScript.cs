using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

public class MeteorsScript : MonoBehaviour
{
    // Start is called before the first frame update
    //Create a random object that spawns at a random location
    public GameObject meteor;
    public GameObject dangerSign;
    public GameObject fireMeteor;

    //Create a spawn time for the object
    public float spawnTime;

    public float radiusMeteor;
    public float radiusDangerSign;
    //offset from the center of the sphere
    public Vector2 offset;

    private float limitMeteors = 1;

    private float counter = 0;



    void Start()
    {
        //Set the spawn time to a random value between 5 and 10 seconds
        spawnTime = Time.time + Random.Range(5.0f, 10.0f);
    }

    // Update is called once per frame
    void Update()
    {   
       
        if (Time.time >= spawnTime)
        {
            //Spawn the object
            SpawnObject();
            //Reset the spawn time
            spawnTime = Time.time + Random.Range(5.0f, 10.0f);
        }
    }

    public void SpawnObject()
    {   
        
        //Create a random object at a random location in the perimeter of a circle
        if (counter < limitMeteors)
        {
            var coor = Random.insideUnitCircle.normalized;
            Vector2 spawnPositionMeteor = coor * radiusMeteor + offset;
            Vector2 spawnPositionDanger = coor * radiusDangerSign + offset;
            Instantiate(meteor, spawnPositionMeteor, Quaternion.identity);
            Instantiate(dangerSign, spawnPositionDanger, Quaternion.identity);
            Instantiate(fireMeteor, transform.position, Quaternion.identity);
            counter++;
        }

    }

    public void destroyMeteor()
    {
        counter--;
    }
}

