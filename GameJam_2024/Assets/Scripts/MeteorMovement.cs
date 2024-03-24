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
    private GameObject explotion;

    // Start is called before the first frame update
    void Start()
    {
        spawner = GameObject.FindGameObjectWithTag("MeteorSpawner").GetComponent<MeteorsScript>();
        danger = GameObject.FindGameObjectWithTag("dangerSign").GetComponent <DangerScript>();
        //explision is a child of the meteor
        explotion = this.transform.GetChild(0).gameObject;
        explotion.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 src = this.transform.position;
        Vector2 dst = new Vector2(0, 0);
        transform.position = Vector2.MoveTowards(src, dst, moveSpeed * Time.deltaTime);
        transform.Rotate(Vector3.forward * 0.3f);

        Vector2 directionToCenter = (Vector2.zero + spawner.offset) - src;
        float angle = Mathf.Atan2(directionToCenter.y, directionToCenter.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90)); 

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Planet"))
        {
            explotion.SetActive(true);
            Destroy(this.gameObject, 0.5f);
            spawner.destroyMeteor(true);
            danger.destroySign();
        }
        if (collision.CompareTag("Bullet"))
        {   
            explotion.SetActive(true);
            Destroy(this.gameObject, 0.5f);
            spawner.destroyMeteor(false);
            Destroy(collision.gameObject);
            danger.destroySign();
        }
    }
}
    