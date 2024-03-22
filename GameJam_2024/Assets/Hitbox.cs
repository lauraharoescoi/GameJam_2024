using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    public FactoryScript factory;

    private void Start()
    {
        factory = GameObject.FindGameObjectWithTag("FactoryLogic").GetComponent<FactoryScript>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.E)){
            // Personatje - 3 mineral
            factory.addMineral();
        }
        
    }
}
