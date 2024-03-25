using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RocketScript : MonoBehaviour
{
    private int metals;
    public bool isFinished;
    
    public float processingTime;
    private float timer;
    public int maxMetals;
    public CounterScript textCounter;
    public GameObject launchRocket;
    public GameObject personatge;
    public GameObject metalPhoto;
    public GameObject mineralPhoto;
    public GameObject text1;
    public GameObject text2;

    public float moveSpeed = 1;
    public GameObject winText;


    public void Start()
    {
        isFinished = false;
        launchRocket = GameObject.FindGameObjectWithTag("launchRocket");
        personatge = GameObject.FindGameObjectWithTag("Player");
        text1 = GameObject.FindGameObjectWithTag("Text1");
        text2 = GameObject.FindGameObjectWithTag("Text2");
        mineralPhoto = GameObject.FindGameObjectWithTag("MineralPhoto");
        metalPhoto = GameObject.FindGameObjectWithTag("MetalPhoto");
        winText.SetActive(false);
    }

    public void Update()
    {
        if(isFinished) {
            this.GetComponent<SpriteRenderer>().enabled = false;
            personatge.SetActive(false);
            text1.SetActive(false);
            text2.SetActive(false);
            mineralPhoto.SetActive(false);
            metalPhoto.SetActive(false);

            Vector3 src = launchRocket.transform.position;
            Vector3 dst = new Vector3(-0.05f, 4.41f, 0);
            launchRocket.transform.position = Vector3.MoveTowards(src, dst, moveSpeed * Time.deltaTime);
            //wait for rocket to reach destination
            if (launchRocket.transform.position == dst)
            {
                winText.SetActive(true);
            }
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
