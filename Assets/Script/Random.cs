using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random : MonoBehaviour
{
    public static Sprite[] Spr; // 이미지 불러올 스프라이트 리스트  


    public static GameObject[] child = new GameObject[4];  //첫번째 자식 리스트
    public static GameObject[] gchild = new GameObject[4]; //두번째 자식 리스트
    public static GameObject[] ggchild = new GameObject[4];  //세번쨰 자식 리스트
    public static SpriteRenderer[] spriteR = new SpriteRenderer[4]; //세번째 자식이 가지고 있는 스프라이트접근 위한 리스트

    List<int> rand = new List<int>();  //이미지 랜덤 변수
    List<int> card_rand = new List<int>(); //카드 랜덤 변수

    public void ShuffleList<T>(List<T> list) //셔플 함수 ( 중복 제거 )
    {
        int random1;
        int random2;

        T tmp;

        for (int index = 0; index < list.Count; ++index)
        {
            random1 = UnityEngine.Random.Range(0, list.Count);
            random2 = UnityEngine.Random.Range(0, list.Count);

            tmp = list[random1];
            list[random1] = list[random2];
            list[random2] = tmp;
        }
    }



    void Start()
    {

        Spr = Resources.LoadAll<Sprite>("Images"); //이미지 폴더에서 이미지들 불러오기
        for (int i = 0; i <= Spr.Length - 1; i++)  
        {
            rand.Add(i);
        }

        for (int i = 0; i < 4; i++) 
        {
            card_rand.Add(i);
        }

        ShuffleList(rand); //카드와 이미지 변수 랜덤 셔플
        ShuffleList(card_rand);


        for (int i = 0; i < 4; i++) 
        {
           
            
            
            child[i] = transform.Find("CardCover" + i.ToString()).gameObject; //첫번째 자식 불러오기
            
            //gchild[i] = child[i].transform.Find("Card"+(i+1).ToString()).gameObject; //두번째 자식 불러오기
            gchild[i] = child[i].transform.GetChild(0).gameObject;
           
            ggchild[i] = gchild[i].transform.GetChild(0).gameObject; //세번쨰 자식 불러오기 
            
            spriteR[i] = ggchild[i].GetComponent<SpriteRenderer>();  //세번째 자식의 render 컴포넌트 불러오기
            
        }



        for(int i = 0; i < 4; i=i+2) 
        {  

            spriteR[card_rand[i]].sprite = Spr[rand[i]];  //두 장의 카드(스프라이트)에 동일한 이미지 삽입
            spriteR[card_rand[i+1]].sprite = Spr[rand[i]];
            
        }

    }

    void Update()
    {
        
        
    }


}

















