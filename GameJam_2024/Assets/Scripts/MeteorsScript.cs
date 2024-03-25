using System.Collections;
using System.Collections.Generic;
// using UnityEditor.Timeline;
using UnityEngine;

public class MeteorsScript : MonoBehaviour
{
    public GameObject meteor;
    public GameObject dangerSign;
    public SpriteRenderer planet;
    public GameObject gameOver;
    public AudioSource audioSource;
    public GameObject rocket;
    public GameObject personatge;
    public GameObject mask;
    
    public Sprite[] planets;
    private int index;

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
        planet = GameObject.FindGameObjectWithTag("Planet").GetComponent<SpriteRenderer>();
        rocket = GameObject.FindGameObjectWithTag("Rocket");
        personatge = GameObject.FindGameObjectWithTag("Player");
        mask = GameObject.FindGameObjectWithTag("mask");
        index = 0;
        planet.GetComponent<SpriteRenderer>().sprite = planets[index];
        gameOver.SetActive(false);
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
            counter++;
        }

    }

    public void meteorHasntExisted()
    {
        counter--;
    }

    public void destroyMeteor(bool planetDestroyed)
    {
        counter--;
        audioSource.Play();
        if (planetDestroyed && index < planets.Length - 1)
        {
            index++;
            planet.GetComponent<SpriteRenderer>().sprite = planets[index];
        } else if (planetDestroyed && index == planets.Length - 1)
        {
            //game over screen
             if(!rocket.GetComponent<RocketScript>().isFinished){

                gameOver.SetActive(true);
                personatge.GetComponent<SpriteRenderer>().enabled = false;
                mask.GetComponent<SpriteMask>().enabled = false;
                
            }
            

        }
    }
}
