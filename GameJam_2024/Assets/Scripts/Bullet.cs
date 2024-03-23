using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MeteorMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float lifeTime = 3f;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifeTime);
    }
    private void FixedUpdate()
    {
        rb.velocity = transform.up * moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("meteor") && collision.gameObject.activeSelf)
        {
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
    }

}
