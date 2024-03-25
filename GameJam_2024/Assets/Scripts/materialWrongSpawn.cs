using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class materialWrongSpawn : MonoBehaviour
{
    public MaterialBehavior spawner;

    void Start()
    {
        spawner = GameObject.FindGameObjectWithTag("MineralSpawner").GetComponent<MaterialBehavior>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Factory") || collision.CompareTag("Rocket"))
        {
            spawner.pickMaterial();
            Destroy(this.gameObject);
            spawner.SpawnObject();
        }
    }


}
