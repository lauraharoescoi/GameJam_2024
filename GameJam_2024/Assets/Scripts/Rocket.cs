using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RocketScript : MonoBehaviour
{
    private int metals;
    private bool isFinished;
    
    public float processingTime;
    private float timer;
    public int maxMetals;
    public CounterScript textCounter;
    public GameObject launchRocket;
    public GameObject personatge;
    public GameObject text1;
    public GameObject text2;
    public float moveSpeed = 1;


    public void Start()
    {
        isFinished = false;
        launchRocket = GameObject.FindGameObjectWithTag("launchRocket");
        personatge = GameObject.FindGameObjectWithTag("Player");
        text1 = GameObject.FindGameObjectWithTag("Text1");
        text2 = GameObject.FindGameObjectWithTag("Text2");
        text1.SetActive(true);
        text2.SetActive(true);
        this.GetComponent<SpriteRenderer>().enabled = true;
        personatge.GetComponent<SpriteRenderer>().enabled = true;

    }

    public void Update()
    {
        if(isFinished) {
            this.GetComponent<SpriteRenderer>().enabled = false;
            personatge.GetComponent<SpriteRenderer>().enabled = false;
            text1.SetActive(false);
            text2.SetActive(false);

            Vector2 src = launchRocket.transform.position;
            Vector2 dst = new Vector2(-0.05f, 4.41f);
            launchRocket.transform.position = Vector2.MoveTowards(src, dst, moveSpeed * Time.deltaTime);
        }
    }
    public void addMetals()
    {
        metals += 1;
        textCounter.addRocketMetal();

		if (metals == maxMetals) {
			isFinished = true;
		}
    }

}
