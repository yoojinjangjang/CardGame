using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickObjectName : MonoBehaviour
{
    public int touchCnt = 0;// 터치한 카드 수 , 외부 참조 가능
    int Cardcnt = 0; //이미지 저장 번호
    public int CorrCnt = 0; // 맞은 수 , 외부 참조 가능 

    public bool wrong; //틀린경우 true
    public bool correct; //맞을 경우 true

    public GameObject preFab;
    public SpriteRenderer[] img = new SpriteRenderer[2];
    GameObject child;
    GameObject child_1;
    public GameObject exitPanel;
    GameObject obj;

  

    void Start()
    {
        obj = this.transform.GetChild(0).gameObject;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetMouseButtonDown(0) && exitPanel.activeSelf == false && touchCnt <=1
            && (obj.GetComponent<Practice>().count >= obj.GetComponent<Practice>().hide_time)) 
            // 패널이 활성화가 안되었을떄만 터치 카드 조사
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero); // 마우스의 위치 파악
           
            //Debug.Log(hit.transform.gameObject.name); //터치한 오브젝트 이름 출력
             

            child = hit.transform.gameObject;
            string hit_name = child.name; // 이름 저장

            if (hit_name== "Card" | hit_name == "New Sprite")
            {
                Debug.Log(hit_name);
     
                img[Cardcnt] = getSprite(); //터치한 카드의 이미지 이름을 받아옴
                Cardcnt += 1; //이미지 번호 0과 1
                touchCnt += 1; //터치한 수 
            

            }
            if (touchCnt == 2 ) { //이미지 번호 0,1모두 채웠을때
                
                if (img[0].sprite.name != img[1].sprite.name)
                {  //두카드가 같지않으면
                    
                    Invoke("disappear", 4); //4초뒤에 사라지는 함수 실행
                    
                }
                else if (img[0] == img[1]){ //동일한 카드 클릭시 (예외)
                    touchCnt -= 1;
                    
                }
                else if(img[0].sprite.name == img[1].sprite.name)
                {
                    Invoke("make_touch_0", 4); //그림이 같을 경우 4초뒤에 touch 수 0으로 갱신
                    
   
                }
 
               Cardcnt = 0;//터치한 카드 0개로 다시 바꾸기
               
            }

        }



    }
    SpriteRenderer getSprite() //스프라이트 가져오기.
    {
        
        if (child.name == "Card") //터치한 자식이 card 일경우
        {
            child_1 = child.transform.Find("New Sprite").gameObject; //하위 객체 받아오기
            
        }
        else if(child.name == "New Sprite")
        { 
            child_1 = child;
            
        } //아닌경우 유지

        
        SpriteRenderer spriteR = child_1.GetComponent<SpriteRenderer>(); //sprite컴포넌트 받아오기
        
        return spriteR;

    }
    void disappear() //사라지기
    {
        img[0].transform.parent.gameObject.SetActive(false);
        img[1].transform.parent.gameObject.SetActive(false);

        touchCnt = 0;//터치한 카드수 0으로 만들기
        wrong = true;

    }

    void make_touch_0() //터치 수를 0으로 만드는 함수
    {
        touchCnt = 0;
        CorrCnt += 1; // 맞은 수 1 증가 
        correct = true;


        GameObject empty1 = Instantiate(preFab); // 맞춘 카드에 대한 터치를 막기위하여
        // 프리팹을만들어서 앞에 올려둠으로써 터치를 제한함. 
        GameObject empty2 = Instantiate(preFab);
        empty1.transform.position = img[0].transform.position;
        empty2.transform.position = img[1].transform.position;


    }
}
