using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Normal_rand : MonoBehaviour
{
    public static Sprite[] Spr;


    public static GameObject[] child = new GameObject[8]; //ù���� �ڽ�
    public static GameObject[] gchild = new GameObject[8]; //�ι��� �ڽ�
    public static GameObject[] ggchild = new GameObject[8];  //������ �ڽ�
    public static SpriteRenderer[] spriteR = new SpriteRenderer[8]; // ������ �ڽ��� �̹��� ��������Ʈ

    List<int> rand = new List<int>();  //������ ���� ����
    List<int> card_rand = new List<int>(); //ī���� ���� ����

    public void ShuffleList<T>(List<T> list) //���� ���� �Լ�(�ߺ�����)
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

        Spr = Resources.LoadAll<Sprite>("Images"); //�̹��� �ҷ�����
        for (int i = 0; i <= Spr.Length - 1; i++) //������ ���� ���� ����
        {
            rand.Add(i);
        }
        for (int i = 0; i < 8; i++) //ī���� ���� ���� ����
        {
            card_rand.Add(i);
        }
        ShuffleList(rand); //ī��� ���� �������� ����
        ShuffleList(card_rand);


        for (int i = 0; i < 8; i++) //�� ī���� �ڽĵ��� ��������Ʈ �ҷ����� 
        {
            child[i] = transform.Find("CardCover" + i.ToString()).gameObject; //ù��° �ڽ� �ҷ�����
            
            //gchild[i] = child[i].transform.Find("Card"+(i+1).ToString()).gameObject; //�ι�° �ڽ� �ҷ�����
            gchild[i] = child[i].transform.GetChild(0).gameObject;

            ggchild[i] = gchild[i].transform.GetChild(0).gameObject; //������ �ڽ� �ҷ����� 

            spriteR[i] = ggchild[i].GetComponent<SpriteRenderer>();  //����° �ڽ��� render ������Ʈ �ҷ����⼺

        }



        for (int i = 0; i < 8; i = i + 2) //�ι� �ݺ�
        {   //�ΰ��� ī�忡 ������ �̹��� ����� ����
            spriteR[card_rand[i]].sprite = Spr[rand[i]];  //�� ī�忡 ���� �̹��� ���
            spriteR[card_rand[i + 1]].sprite = Spr[rand[i]];
        }

    }

    void Update()
    {


    }


}

















