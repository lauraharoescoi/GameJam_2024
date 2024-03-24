using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketScript : MonoBehaviour
{
    private int metals;
    private bool isFinished;
    
    public float processingTime;
    private float timer;
    public CounterScript textCounter;
    //Audio
    public AudioSource src;
    public AudioClip sfx1;


    public void Start()
    {
        isFinished = false;
    }

    public void Update()
    {
        if(isFinished) {
			//acabar joc
		}
    }
    public void addMetals()
    {
        metals += 1;
        textCounter.addRocketMetal();
        //Audio
        src.clip = sfx1;
        src.Play();

        if (metals == 3) {
			isFinished = true;
		}
    }

}
