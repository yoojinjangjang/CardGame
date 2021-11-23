using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Change : MonoBehaviour {

	// Use this for initialization
	void Start () {
 
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SceneChange()
    {
        GameObject objectName = EventSystem.current.currentSelectedGameObject;
        string name = objectName.GetComponentInChildren<Text>().text;
        
        if (name == "Hard")
        {
            SceneManager.LoadScene("HardPage");
        }
        if (name == "Easy")
        {
            SceneManager.LoadScene("EasyPage");

        }
        if (name == "Normal")
        {
            SceneManager.LoadScene("NormalPage");
           
        }
        if (name == "Replay")
        {
            SceneManager.LoadScene("MainPage");
        }

    }
}
