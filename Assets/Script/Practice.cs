using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Practice : MonoBehaviour {

    GameObject showObject;
    public float count;
    public float hide_time = 1.9f;

    public GameObject exitPanel;
    GameObject obj;





    float rotSpeed=0;
    float startTime;

	// Use this for initialization
	void Start () {

        
        showObject = transform.Find("Card").gameObject;
        obj = transform.parent.gameObject;
        startTime = Time.time;
        
	}
	
	// Update is called once per frame
	void Update () {

        count = Mathf.Round((float)(Time.time - startTime)*10)*0.1f; //게임 현재 진행 시간 초(0.1초 단위) 


 
    }
    
    private void FixedUpdate()
    {

        
        if (count == hide_time)
        {
            
            showObject.SetActive(false);
        }
        else if (count >= hide_time)
        {
            
            rotSpeed = rotSpeed * (float)0.97;
            showObject.transform.Rotate(0, rotSpeed, 0);
        }
        
    }
    void OnMouseDown()
    {       // 게임 활성화시 & 터치수가 2 미만 & 해당 객체가 비활성화일때 뒤집기
        
        if (Time.timeScale != 0 &&(obj.GetComponent<ClickObjectName>().touchCnt <=1) &&
            showObject.activeSelf != true) 
        {
            
            showObject.SetActive(true);
            
            
            rotSpeed = 50;
        }
        
        
    }
 
    

 

}
