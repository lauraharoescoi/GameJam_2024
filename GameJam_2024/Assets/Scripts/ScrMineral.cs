using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrMineral : MonoBehaviour
{
    public Text pickUpText;
    private bool pickUpAllowed;

    private void Start()
    {
        pickUpText.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (pickUpAllowed && Input.GetKeyDown(KeyCode.E))
            PickUp();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player") {
            pickUpText.gameObject.SetActive(true);
            pickUpAllowed = true;
        }
    }
    private void PickUp()
    {
        Destroy(gameObject);
    }
}


