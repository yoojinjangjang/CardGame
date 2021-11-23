using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hard_rand : MonoBehaviour
{
    public static Sprite[] Spr;


    public static GameObject[] child = new GameObject[14]; 
    public static GameObject[] gchild = new GameObject[14]; 
    public static GameObject[] ggchild = new GameObject[14];  
    public static SpriteRenderer[] spriteR = new SpriteRenderer[14]; 

    List<int> rand = new List<int>();  
    List<int> card_rand = new List<int>(); 

    public void ShuffleList<T>(List<T> list) 
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

        Spr = Resources.LoadAll<Sprite>("Images"); 
        for (int i = 0; i <= Spr.Length - 1; i++) 
        {
            rand.Add(i);
        }
        for (int i = 0; i < 14; i++) 
        {
            card_rand.Add(i);
        }
        ShuffleList(rand);
        ShuffleList(card_rand);


        for (int i = 0; i <14; i++) 
        {
            child[i] = transform.Find("CardCover" + i.ToString()).gameObject; //첫번째 자식 불러오기
            
            //gchild[i] = child[i].transform.Find("Card"+(i+1).ToString()).gameObject; //두번째 자식 불러오기
            gchild[i] = child[i].transform.GetChild(0).gameObject;

            ggchild[i] = gchild[i].transform.GetChild(0).gameObject; //세번쨰 자식 불러오기 

            spriteR[i] = ggchild[i].GetComponent<SpriteRenderer>();  //세번째 자식의 render 컴포넌트 불러오기성
        }


        int j = 0;
        for (int i = 0; i < 14; i = i + 2) 
        {   

            spriteR[card_rand[i]].sprite = Spr[rand[j]]; 
            spriteR[card_rand[i + 1]].sprite = Spr[rand[j]];
            
            j += 1;
        }

    }

    void Update()
    {


    }


}

















