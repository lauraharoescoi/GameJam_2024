using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationsBG : MonoBehaviour
{

    public GameObject AllRotate, PlanetsCenter, PlanetsCenter2;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AllRotate.transform.Rotate(0.0f, 0.0f, 0.01f);
        PlanetsCenter.transform.Rotate(0.0f, 0.0f, -0.01f);
        PlanetsCenter2.transform.Rotate(0.0f, 0.0f, -0.008f);
    }
}
