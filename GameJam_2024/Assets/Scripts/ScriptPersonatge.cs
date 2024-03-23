using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
   
   private float moving;

    public float moveSpeed;
    // public Transform Personatge;
    public Animator animator;
    // Invocació animator controller


    void Start()
    {
        animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        RotateRocket();

        if(Input.GetKeyDown(KeyCode.D)) {
            animator.SetFloat("Run", 0);
        } else if(Input.GetKeyDown(KeyCode.A))
        {
            animator.SetFloat("Run", 1);
        }
               
    }

    void RotateRocket ()
	{
        //TODO: afegir aceleració més tard
		transform.eulerAngles += new Vector3(0, 0, (-moveSpeed * Input.GetAxis("Horizontal")) * Time.deltaTime);
		// Personatge.localEulerAngles = new Vector3(0, 0, Input.GetAxis("Horizontal") * -30);
	}

}
