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
    public AudioSource src;
    public AudioClip shootSound, errorSound, pickSound, factorySound, rocketSound;

    public Animator animator;
    public GameObject newgameObject;

    private GameObject interactableObject = null; // Objeto con el que el personaje puede interactuar

    void Start()
    {
        animator = GetComponent<Animator>();
        newgameObject.SetActive(false);
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && hasMineral)
        {
            Shoot();
            src.clip = shootSound;
            src.Play();
        } else if (Input.GetKeyDown(KeyCode.Space) && !hasMineral)
        {
            src.clip = errorSound;
            src.Play();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            InteractWithObject();
        }

        animator.SetBool("Holding", hasMineral);
        if (hasMineral == false)
        {
            newgameObject.SetActive(false);
        }
        else
        {
            newgameObject.SetActive(true);
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
                src.clip = pickSound;
                src.Play();
            }
            else if (interactableObject.CompareTag("Factory") && hasMineral && !hasMetal)
            {
                print("factory");
                FactoryScript factory = interactableObject.GetComponent<FactoryScript>();
                factory.addMinerals();
                hasMineral = false;
                GetComponent<SpriteRenderer>().sprite = normalSprite;
                src.clip = factorySound;
                src.Play();
            }
            else if (interactableObject.CompareTag("Metal") && !hasMetal && !hasMineral)
            {
                Destroy(interactableObject);
                GetComponent<SpriteRenderer>().sprite = holdingMetalSprite;
                hasMetal = true;
                src.clip = pickSound;
                src.Play();
            }
            else if (interactableObject.CompareTag("Rocket") && hasMetal && !hasMineral)
            {
                RocketScript rocket = interactableObject.GetComponent<RocketScript>();
                rocket.addMetals();
                hasMetal = false;
                GetComponent<SpriteRenderer>().sprite = normalSprite;
                src.clip = rocketSound;
                src.Play();
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

