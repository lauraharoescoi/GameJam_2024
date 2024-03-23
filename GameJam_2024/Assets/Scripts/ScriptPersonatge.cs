using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
   
   private float moving;

    public float moveSpeed;
    // public Transform Personatge;
    public Animator animator;
    // Invocació animator controller
    public SpriteRenderer spriteRenderer;

    public Rigidbody2D body;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        body = GetComponentInChildren<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        RotateRocket();

        animator.SetFloat("Horizontal", Mathf.Abs(-moveSpeed * Input.GetAxis("Horizontal")) * Time.deltaTime);


    }

    void RotateRocket ()
	{
        //TODO: afegir aceleració més tard
		transform.eulerAngles += new Vector3(0, 0, (-moveSpeed * Input.GetAxis("Horizontal")) * Time.deltaTime);
        if ((-moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime) > 0)
        {
            spriteRenderer.flipX = false;
        } else if ((-moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime) < 0) {
            spriteRenderer.flipX = true;
        }
            
     }

        
		// Personatge.localEulerAngles = new Vector3(0, 0, Input.GetAxis("Horizontal") * -30);
	

}
