using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketScript : MonoBehaviour
{
    private int metals;
    private bool isFinished;
    
    public float processingTime;
    private float timer;


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
		//print in the console the number of metals
		print(metals);

		if (metals == 3) {
			isFinished = true;
		}
    }

}
