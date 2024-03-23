using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    public GameObject planet;  
    Rigidbody2D rb;
    public float gravityForce;
    public float grafityDistance;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        planet = GameObject.Find("Planet");
        
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector2.Distance(planet.transform.position, transform.position);
        Vector2 v = planet.transform.position - transform.position;

        rb.AddForce(v.normalized * gravityForce / (dist / grafityDistance));
    }
}
