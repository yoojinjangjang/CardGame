using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Normal_rand : MonoBehaviour
{
    public static Sprite[] Spr;


    public static GameObject[] child = new GameObject[8]; //첫번쨰 자식
    public static GameObject[] gchild = new GameObject[8]; //두번쨰 자식
    public static GameObject[] ggchild = new GameObject[8];  //세번쨰 자식
    public static SpriteRenderer[] spriteR = new SpriteRenderer[8]; // 세번쨰 자식의 이미지 스프라이트

    List<int> rand = new List<int>();  //사진의 랜덤 변수
    List<int> card_rand = new List<int>(); //카드의 랜덤 변수

    public void ShuffleList<T>(List<T> list) //랜덤 셔플 함수(중복없이)
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

        Spr = Resources.LoadAll<Sprite>("Images"); //이미지 불러오기
        for (int i = 0; i <= Spr.Length - 1; i++) //사진의 랜덤 변수 생성
        {
            rand.Add(i);
        }
        for (int i = 0; i < 8; i++) //카드의 랜덤 변수 생성
        {
            card_rand.Add(i);
        }
        ShuffleList(rand); //카드와 사진 랜덤변수 셔플
        ShuffleList(card_rand);


        for (int i = 0; i < 8; i++) //각 카드의 자식들의 스프라이트 불러오기 
        {
            child[i] = transform.Find("CardCover" + i.ToString()).gameObject; //첫번째 자식 불러오기
            
            //gchild[i] = child[i].transform.Find("Card"+(i+1).ToString()).gameObject; //두번째 자식 불러오기
            gchild[i] = child[i].transform.GetChild(0).gameObject;

            ggchild[i] = gchild[i].transform.GetChild(0).gameObject; //세번쨰 자식 불러오기 

            spriteR[i] = ggchild[i].GetComponent<SpriteRenderer>();  //세번째 자식의 render 컴포넌트 불러오기성

        }



        for (int i = 0; i < 8; i = i + 2) //두번 반복
        {   //두개의 카드에 동일한 이미지 출력을 위해
            spriteR[card_rand[i]].sprite = Spr[rand[i]];  //두 카드에 같은 이미지 출력
            spriteR[card_rand[i + 1]].sprite = Spr[rand[i]];
        }

    }

    void Update()
    {


    }


}

















