using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MeteorMovement : MonoBehaviour
{
    public float moveSpeed = 1;
    public MeteorsScript spawner;
    public DangerScript danger;
    public GameObject fireMeteor;

    // Start is called before the first frame update
    void Start()
    {
        spawner = GameObject.FindGameObjectWithTag("MeteorSpawner").GetComponent<MeteorsScript>();
        danger = GameObject.FindGameObjectWithTag("dangerSign").GetComponent <DangerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 src = this.transform.position;
        Vector2 dst = new Vector2(0, 0);
        transform.position = Vector2.MoveTowards(src, dst, moveSpeed * Time.deltaTime);
        transform.Rotate(Vector3.forward * 2);

        Vector2 directionToCenter = (Vector2.zero + spawner.offset) - src;
        float angle = Mathf.Atan2(directionToCenter.y, directionToCenter.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90)); 

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Planet"))
        {
            Destroy(this.gameObject);
            spawner.destroyMeteor(true);
            danger.destroySign();
        }
        if (collision.CompareTag("Bullet"))
        {
            Destroy(this.gameObject);
            spawner.destroyMeteor(false);
            Destroy(collision.gameObject);
            danger.destroySign();
        }
    }
}
    