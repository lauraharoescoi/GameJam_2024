using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed;
    // public Transform Personatge;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotateRocket();
    }

    void RotateRocket ()
	{
        //TODO: afegir aceleració més tard
		transform.eulerAngles += new Vector3(0, 0, (-moveSpeed * Input.GetAxis("Horizontal")) * Time.deltaTime);
		// Personatge.localEulerAngles = new Vector3(0, 0, Input.GetAxis("Horizontal") * -30);
	}


}
