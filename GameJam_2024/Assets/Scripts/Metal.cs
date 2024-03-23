using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metal : MonoBehaviour
{
    // Start is called before the first frame update
    public float radius;
    //offset from the center of the sphere
    public Vector2 offset;

    public GameObject metalObject;
    void Start()
    {
        //set rotation to z: -97.465
        transform.Rotate(97, 0, -97.465f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
