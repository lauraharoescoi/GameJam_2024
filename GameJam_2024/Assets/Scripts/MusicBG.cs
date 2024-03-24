using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBG : MonoBehaviour
{
    public AudioSource src;
    // Start is called before the first frame update
    void Start()
    {
        src.Play();

    }

    // Update is called once per frame
    void Update()
    {
        if (!src.isPlaying)
        {
            src.Play();
        }
        
    }
}
