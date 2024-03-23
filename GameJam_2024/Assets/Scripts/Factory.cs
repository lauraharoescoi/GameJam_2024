using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryScript : MonoBehaviour
{
    private int minerals;
    private bool processing;
    
    public float processingTime;
    private float timer;

    public GameObject metalObject;

    public void Start()
    {
        processing = false;
    }

    public void Update()
    {
        process();
    }
    public void addMinerals()
    {
        if(!processing)
        {
            minerals += 1;
        }
        
        if(minerals == 3)
        {
            processing = true;
        }
    }

    public void process()
    {
        if(processing)
        {
            if(timer < processingTime)
            {
                timer += Time.deltaTime;
                GetComponent<SpriteRenderer>().color = Color.red;
            }
            else
            {
                timer = 0;
                minerals = 0;
                processing = false;
                GetComponent<SpriteRenderer>().color = Color.white;
                Vector2 spawnPosition = new Vector2(2.39f, 0.12f);
                Instantiate(metalObject, spawnPosition, Quaternion.identity);
        
            }
        }
    }

    



}
