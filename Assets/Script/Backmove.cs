using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Backmove : MonoBehaviour {


	public GameObject exitPanel;
	// Use this for initialization
	void Start () {
		exitPanel.SetActive(false);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnMouseDown()
    {
		
		exitPanel.SetActive(true);
		Time.timeScale = 0;
		
    }
	public void NoQuit()
    {
		Time.timeScale = 1;
		exitPanel.SetActive(false);
	}
	public void YesQuit()
	{
		SceneManager.LoadScene("MainPage");
		Time.timeScale = 1;
	}
}
