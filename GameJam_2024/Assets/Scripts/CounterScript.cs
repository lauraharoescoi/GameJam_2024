using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CounterScript : MonoBehaviour
{
    private int minerals;
    private int metals;
    public Text factoryCounter;
    public Text rocketCounter;

    private void Start()
    {
        minerals = 0;
        metals = 0;
        factoryCounter.text = "0/3";
        rocketCounter.text = "0/3";
    }
    public void addFactoryMineral()
    {
        if(minerals < 3)
        {
            minerals++;
            factoryCounter.text = minerals.ToString() + "/3";
        }

    }
    public void addRocketMetal()
    {
        if(metals < 5)
        {
            metals++;
            rocketCounter.text = metals.ToString() + "/3";
        }
    }

    public void resetFactoryMineral()
    {
        minerals = 0;
        factoryCounter.text = minerals.ToString() + "/3";
    }

    public void resetRocketMetal()
    {
        metals = 0;
        rocketCounter.text = metals.ToString() + "/3";
    }
}
