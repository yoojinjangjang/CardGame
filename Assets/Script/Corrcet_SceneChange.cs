using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Corrcet_SceneChange : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip doneAC;
    int CorrCnt = 0;
    bool isEnable = true;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
        

    }

    void Update()
    {
        CorrCnt = this.GetComponent<ClickObjectName>().CorrCnt;

        if (CorrCnt == 2 && SceneManager.GetActiveScene().name == "EasyPage")
        {   if (isEnable == true)
            {
                this.audioSource.clip = doneAC;
                this.audioSource.Play();
                isEnable = false;
            }
            Invoke("load", 2);


            }
            if (CorrCnt == 4 && SceneManager.GetActiveScene().name == "NormalPage")
        {

            if (isEnable == true)
            {
                this.audioSource.clip = doneAC;
                this.audioSource.Play();
                isEnable = false;
            }
            Invoke("load", 2);

        }
        if (CorrCnt == 7 && SceneManager.GetActiveScene().name == "HardPage")
        {

            if (isEnable == true)
            {
                this.audioSource.clip = doneAC;
                this.audioSource.Play();
                isEnable = false;
            }
            Invoke("load", 2);

        }
       
        
    }
    void load()
    {
        SceneManager.LoadScene("GameOver");
    }
}
