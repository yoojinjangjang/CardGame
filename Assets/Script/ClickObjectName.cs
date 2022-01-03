using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickObjectName : MonoBehaviour
{
    public int touchCnt = 0;// ��ġ�� ī�� �� , �ܺ� ���� ����
    int Cardcnt = 0; //�̹��� ���� ��ȣ
    public int CorrCnt = 0; // ���� �� , �ܺ� ���� ���� 

    public bool wrong; //Ʋ����� true
    public bool correct; //���� ��� true

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
            // �г��� Ȱ��ȭ�� �ȵǾ������� ��ġ ī�� ����
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero); // ���콺�� ��ġ �ľ�
           
            //Debug.Log(hit.transform.gameObject.name); //��ġ�� ������Ʈ �̸� ���
             

            child = hit.transform.gameObject;
            string hit_name = child.name; // �̸� ����

            if (hit_name== "Card" | hit_name == "New Sprite")
            {
                Debug.Log(hit_name);
     
                img[Cardcnt] = getSprite(); //��ġ�� ī���� �̹��� �̸��� �޾ƿ�
                Cardcnt += 1; //�̹��� ��ȣ 0�� 1
                touchCnt += 1; //��ġ�� �� 
            

            }
            if (touchCnt == 2 ) { //�̹��� ��ȣ 0,1��� ä������
                
                if (img[0].sprite.name != img[1].sprite.name)
                {  //��ī�尡 ����������
                    
                    Invoke("disappear", 4); //4�ʵڿ� ������� �Լ� ����
                    
                }
                else if (img[0] == img[1]){ //������ ī�� Ŭ���� (����)
                    touchCnt -= 1;
                    
                }
                else if(img[0].sprite.name == img[1].sprite.name)
                {
                    Invoke("make_touch_0", 4); //�׸��� ���� ��� 4�ʵڿ� touch �� 0���� ����
                    
   
                }
 
               Cardcnt = 0;//��ġ�� ī�� 0���� �ٽ� �ٲٱ�
               
            }

        }



    }
    SpriteRenderer getSprite() //��������Ʈ ��������.
    {
        
        if (child.name == "Card") //��ġ�� �ڽ��� card �ϰ��
        {
            child_1 = child.transform.Find("New Sprite").gameObject; //���� ��ü �޾ƿ���
            
        }
        else if(child.name == "New Sprite")
        { 
            child_1 = child;
            
        } //�ƴѰ�� ����

        
        SpriteRenderer spriteR = child_1.GetComponent<SpriteRenderer>(); //sprite������Ʈ �޾ƿ���
        
        return spriteR;

    }
    void disappear() //�������
    {
        img[0].transform.parent.gameObject.SetActive(false);
        img[1].transform.parent.gameObject.SetActive(false);

        touchCnt = 0;//��ġ�� ī��� 0���� �����
        wrong = true;

    }

    void make_touch_0() //��ġ ���� 0���� ����� �Լ�
    {
        touchCnt = 0;
        CorrCnt += 1; // ���� �� 1 ���� 
        correct = true;


        GameObject empty1 = Instantiate(preFab); // ���� ī�忡 ���� ��ġ�� �������Ͽ�
        // ������������ �տ� �÷������ν� ��ġ�� ������. 
        GameObject empty2 = Instantiate(preFab);
        empty1.transform.position = img[0].transform.position;
        empty2.transform.position = img[1].transform.position;


    }
}
