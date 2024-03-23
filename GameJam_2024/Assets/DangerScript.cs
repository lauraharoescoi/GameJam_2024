using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerScript : MonoBehaviour
{
    public float growSpeed;
    public float maxTimer;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        float growRate = growSpeed * Time.deltaTime;
        if(timer < maxTimer )
        {
            transform.localScale += new Vector3(growRate, growRate, growRate);
        }   
    }

    public void destroySign()
    {
        Destroy(gameObject);
    }

}
