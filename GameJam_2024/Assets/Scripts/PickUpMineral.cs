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
        if (collision.CompareTag("Mineral") && (collision.gameObject.activeSelf) && !hasMineral)
        {
            Destroy(collision.gameObject);
            //change color of the player
            GetComponent<SpriteRenderer>().color = Color.blue;
            hasMineral = true;
        }
    }

    public bool getHasMineral()
    {
        return hasMineral;
    }

    public void SetHasMineral(bool hasMineral)
    {
        this.hasMineral = hasMineral;
    }
}
