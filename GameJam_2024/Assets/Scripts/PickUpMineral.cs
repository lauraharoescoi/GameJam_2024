using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PersonatgeScr : MonoBehaviour
{

    private bool hasMineral = false;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Mineral") && !hasMineral)
        {
            Destroy(collision.gameObject);
            //minus one mineral from the counter in the MaterialBehavior script
            MaterialBehavior material = GameObject.Find("Material").GetComponent<MaterialBehavior>();
            material.pickMaterial();
            //change color of the player
            GetComponent<SpriteRenderer>().color = Color.blue;
            hasMineral = true;
        }
        if (collision.CompareTag("Factory") && hasMineral)
        {
            FactoryScript factory = collision.GetComponent<FactoryScript>();
            factory.addMinerals();
            hasMineral = false;
            GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    //if the player has a mineral and colides with the factory, the mineral is delivered


    public bool getHasMineral()
    {
        return hasMineral;
    }

    public void SetHasMineral(bool hasMineral)
    {
        this.hasMineral = hasMineral;
    }
}
