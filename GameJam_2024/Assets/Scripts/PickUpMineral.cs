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
    public GameObject bulletPrefab;
    public Transform FiringPoint;

    private GameObject interactableObject = null; // Objeto con el que el personaje puede interactuar

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && hasMineral)
        {
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            InteractWithObject();
        }
    }

    private void InteractWithObject()
    {
        if (interactableObject != null)
        {
            if (interactableObject.CompareTag("Mineral") && !hasMineral && !hasMetal)
            {
                Destroy(interactableObject);
                GetComponent<SpriteRenderer>().sprite = holdingMineralSprite;
                hasMineral = true;
            }
            else if (interactableObject.CompareTag("Factory") && hasMineral && !hasMetal)
            {
                FactoryScript factory = interactableObject.GetComponent<FactoryScript>();
                factory.addMinerals();
                hasMineral = false;
                GetComponent<SpriteRenderer>().sprite = normalSprite;
            }
            else if (interactableObject.CompareTag("Metal") && !hasMetal && !hasMineral)
            {
                Destroy(interactableObject);
                GetComponent<SpriteRenderer>().sprite = holdingMetalSprite;
                hasMetal = true;
            }
            else if (interactableObject.CompareTag("Rocket") && hasMetal && !hasMineral)
            {
                RocketScript rocket = interactableObject.GetComponent<RocketScript>();
                rocket.addMetals();
                hasMetal = false;
                GetComponent<SpriteRenderer>().sprite = normalSprite;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Mineral") || collision.CompareTag("Metal") || collision.CompareTag("Factory") || collision.CompareTag("Rocket"))
        {
            interactableObject = collision.gameObject;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == interactableObject)
        {
            interactableObject = null;
        }
    }

    private void Shoot()
    {
        hasMineral = false;
        Instantiate(bulletPrefab, FiringPoint.position, FiringPoint.rotation);
        GetComponent<SpriteRenderer>().sprite = normalSprite;

        MaterialBehavior material = GameObject.Find("Material").GetComponent<MaterialBehavior>();
        material.pickMaterial();
    }
}

