using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Audio : MonoBehaviour
{
    AudioSource audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
        this.audioSource.Stop();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.GetComponent<ClickObjectName>().correct == true)
        {
            this.audioSource.Play();
            this.GetComponent<ClickObjectName>().correct = false;
        }

    }
}
