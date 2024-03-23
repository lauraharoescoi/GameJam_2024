using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryScript : MonoBehaviour
{
    public int minerals;
    public bool waiting;
    public bool processing;
    
    public float waitTime;
    public float timer;

    public void Start()
    {
        waiting = true;
        processing = false;
        
    }

    public void Update()
    {
        process();
    }
    public void addMinerals()
    {
        minerals += 1;
        if(minerals == 3)
        {
            processing = true;
        }
    }

    public void process()
    {
        if(processing)
        {
            if(timer < waitTime)
            {
                timer += Time.deltaTime;
            }
            else
            {
                timer = 0;
                processing = false;
                waiting = true;
                //generar metall
            }
        }
    }

    



}
