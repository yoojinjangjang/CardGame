using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    
    public int chance;
    bool wrong;
    public GameObject obj;
    public GameObject[] heart;
    int i;

    AudioSource audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        chance = 3;
        i = 0;
        audioSource = this.GetComponent<AudioSource>();
        audioSource.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
        wrong = obj.GetComponent<ClickObjectName>().wrong;
        if (wrong)
        {
            audioSource.Play();
            chance -= 1;
            Destroy(heart[i++]);
            
            obj.GetComponent<ClickObjectName>().wrong = false;
        }
        if (chance == 0)
        {
            Invoke("game_over", 1);

        }
    }
    void game_over()
    {
        SceneManager.LoadScene("GameOver");
    }
}
