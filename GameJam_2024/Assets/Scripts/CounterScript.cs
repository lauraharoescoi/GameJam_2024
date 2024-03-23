using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CounterScript : MonoBehaviour
{
    private int minerals;
    public Text factoryCounter;

    private void Start()
    {
        minerals = 0;
        factoryCounter.text = "0/3";
    }
    public void addFactoryMineral()
    {
        if(minerals < 3)
        {
            minerals++;
            factoryCounter.text = minerals.ToString() + "/3";
        }

    }

    public void resetFactoryMineral()
    {
        Start();
    }
}
