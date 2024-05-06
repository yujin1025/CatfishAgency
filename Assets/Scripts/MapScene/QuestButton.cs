using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class QuestButton : MonoBehaviour
{
    //Camera _mainCam = null;
    public GameMgr gameMgr;
    public QuestManager QuestManager;
    public GameObject scanObject;
    public GameObject ChoiceDialog;
    Vector3 MousePosition;
    float MaxDistance = 15f;

    public Image FirstImage;
    public Sprite Img1;
    public Sprite Img2;
    public Sprite Img3;
    public Sprite Img4;
    public Sprite Img5;

    private RectTransform rectImg;

    void Update()
    {
        ListenInput();
    }

    void ScanButton()
    {
        ObjData objData = scanObject.GetComponent<ObjData>();
        Debug.Log(scanObject.name);

        if (gameMgr.isFind)
        {
            if (objData.id == 0) gameMgr.ButtonAgency();
            else gameMgr.ButtonAfterFind();
        }
        else if (objData.id==6000 || objData.id == 7000 || objData.id == 8000 || objData.id == 9000 || objData.id == 10000 || objData.id == 11000 || objData.id == 12000 )
        {
            gameMgr.Action(scanObject, objData.id / 1000);
        }
        else if (objData.id==0)
        {
            gameMgr.getIDNumber(scanObject, objData.id / 1000);
            gameMgr.ButtonAgency();
        }
        else
        {
            ChangeImg();
            ChoiceDialog.SetActive(true);
            gameMgr.getIDNumber(scanObject, objData.id / 1000);
        }

        
    }

    private void ListenInput()
    {
        if (gameMgr.isAction) return;

        if (Input.GetMouseButtonDown(0))
        {
            MousePosition = Input.mousePosition;
            MousePosition = Camera.main.ScreenToWorldPoint(MousePosition);
            
            RaycastHit2D hit = Physics2D.Raycast(MousePosition, transform.forward, MaxDistance);
            Debug.DrawRay(MousePosition, transform.forward * 10, Color.red, 0.3f);
            if (hit)
            {
                if (hit.collider.gameObject.name.Contains("QuestButton")) {
                    scanObject = hit.collider.gameObject;
                    ScanButton();
                }
            }

        }
    }

    public void ChangeImg()
    {
        ObjData objData = scanObject.GetComponent<ObjData>();
        rectImg = FirstImage.GetComponent<RectTransform>();
        Debug.Log("이미지 번호 " + objData.id);

        if (objData.id == 1000)
        {
            FirstImage.sprite = Img1;
            rectImg.anchoredPosition = new Vector2(-420, 116);
            rectImg.sizeDelta = new Vector2(500, 500);
        }

        else if (objData.id == 2000)
        {
            FirstImage.sprite = Img2;
            rectImg.anchoredPosition = new Vector2(-517, 183);
            rectImg.sizeDelta = new Vector2(600, 600);
        }

        else if (objData.id == 3000)
        {
            FirstImage.sprite = Img3;
            rectImg.anchoredPosition = new Vector2(-430, 106);
            rectImg.sizeDelta = new Vector2(600, 600);
        }

        else if (objData.id == 4000)
        {
            FirstImage.sprite = Img4;
            rectImg.anchoredPosition = new Vector2(-384, 127);
            rectImg.sizeDelta = new Vector2(600, 600);
        }

        else if (objData.id == 5000)
        {
            FirstImage.sprite = Img5;
            rectImg.anchoredPosition = new Vector2(-318, 119);
            rectImg.sizeDelta = new Vector2(500, 500);
        }
    }
}
