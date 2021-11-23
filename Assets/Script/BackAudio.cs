using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackAudio : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource backAudio;
    void Start()
    {
        backAudio = this.GetComponent<AudioSource>();
        backAudio.loop = true;
        backAudio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
