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
    public CounterScript textCounter;

    //Audio
    public AudioSource src;
    public AudioClip sfx1, sfx2;

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
            textCounter.addFactoryMineral();
            MaterialBehavior material = GameObject.Find("Material").GetComponent<MaterialBehavior>();
            material.pickMaterial();


            // GetComponent<MaterialBehavior>().pickMaterial();

            //Audio
            src.clip = sfx1;
            src.Play();
        }
        
        if(minerals == 3)
        {
            processing = true;
            //Audio
            src.clip = sfx2;
            src.Play();
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
                textCounter.resetFactoryMineral();
                Vector2 spawnPosition = new Vector2(1.17f, -2.1f);
                Instantiate(metalObject, spawnPosition, Quaternion.identity);
        
            }
        }
    }

    



}
