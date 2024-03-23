using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PersonatgeScr : MonoBehaviour
{
    //variables recollir
    private bool mineralPicked;
    //variables disparar
    public GameObject bulletPrefab;
    public Transform FiringPoint;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && mineralPicked)
        {
            Shoot();
        }

            
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("mineral") && (collision.gameObject.activeSelf) && mineralPicked == false)
        {
            collision.gameObject.SetActive(false);
            mineralPicked = true;

        }
    }


    private void Shoot()
    {
        mineralPicked = false;
        Instantiate(bulletPrefab, FiringPoint.position, FiringPoint.rotation);

        
    }

}
