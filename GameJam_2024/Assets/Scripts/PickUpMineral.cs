using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PersonatgeScr : MonoBehaviour
{

    private bool hasMineral = false;
    private bool hasMetal = false;
    //sprite of the player with a mineral
    public Sprite holdingMineralSprite;
    public Sprite holdingMetalSprite;
    public Sprite normalSprite;
    

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = normalSprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Mineral") && !hasMineral && !hasMetal)
        {
            Destroy(collision.gameObject);
            MaterialBehavior material = GameObject.Find("Material").GetComponent<MaterialBehavior>();
            material.pickMaterial();
            GetComponent<SpriteRenderer>().sprite = holdingMineralSprite;

            hasMineral = true;
        }
        if (collision.CompareTag("Factory") && hasMineral && !hasMetal)
        {
            FactoryScript factory = collision.GetComponent<FactoryScript>();
            factory.addMinerals();
            hasMineral = false;
            GetComponent<SpriteRenderer>().sprite = normalSprite;
        }
        if (collision.CompareTag("Metal") && !hasMetal && !hasMineral)
        {
            Destroy(collision.gameObject);
            GetComponent<SpriteRenderer>().sprite = holdingMetalSprite;
            hasMetal = true;
        }
        if (collision.CompareTag("Rocket") && hasMetal && !hasMineral)
        {
            RocketScript rocket = collision.GetComponent<RocketScript>();
            rocket.addMetals();
            hasMetal = false;
            GetComponent<SpriteRenderer>().sprite = normalSprite;
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
