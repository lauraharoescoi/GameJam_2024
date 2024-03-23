using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    public FactoryScript factory;
    public SpriteRenderer pers;

    private void Start()
    {
        factory = GameObject.FindGameObjectWithTag("FactoryLogic").GetComponent<FactoryScript>();
        pers = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>();
     
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if (Input.GetKeyDown(KeyCode.E) /* && character has mineral */){

            // Personatje - 3 mineral
            if(factory.waiting)
            {
                factory.addMinerals();
            }
        }
        
    }
}
