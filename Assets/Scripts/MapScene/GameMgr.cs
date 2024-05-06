using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMgr : MonoBehaviour
{
    public TalkMgr talkMgr; //대화매니저
    public QuestManager questManager;
    public GameObject Quest; //대화창 UI
    public Image portraitImg1;
    public Image portraitImg2;
    public Text TalkText; 
    public bool isAction; //상태 저장용 변수
    public GameObject scanObject; //스캔한 오브젝트
    public GameObject player;
    public int talkIndex;
    private int buttonNum;
    public GameObject ColorDialog1; //이름표 색깔 main cat
    public GameObject ColorDialog2; // fish 
    public Text Name1;
    public Text Name2;
    public TypeEffect typeEffect;
    public Text ScriptText;
    public GameObject Choices;
    public bool isFind;
    public GameObject Character_left;
    public GameObject Character_right;
    public GameObject TmpName;
    public Text TmpNameText;
    public AudioSource matchSFX;
    public AudioSource DoorOpen;
    public AudioSource Ring;

    private RectTransform rectImg1;
    private RectTransform rectImg2;

    void Start()
    {
        //GameLoad();
        //nextPage = gameObject.GetComponent<AudioSource>();
    }

    public int getIDNumber(GameObject scanObj, int tmpButtonNum)
    {
        if (tmpButtonNum >= 0) buttonNum = tmpButtonNum;
        isAction = true;
        return buttonNum;
    }

    public void Action (GameObject scanObj, int tmpButtonNum)
    {
        if (tmpButtonNum >= 0) buttonNum = tmpButtonNum;
        scanObject = scanObj;
        ObjData objData = scanObject.GetComponent<ObjData>();
        Debug.Log(objData.id);
        if (objData.id == 0 && !isFind && talkIndex == 0) {
            //Debug.Log("??");
            ButtonAgency();
            return;
        }
        Talk(objData.id);
        //대화가 모두 끝나야 액션이 끝나도록
        Quest.SetActive(isAction);
        Choices.SetActive(false);
    }

    public void Talk(int id)
    {
        Debug.Log("TalkIn");
        //Set Talk Data
        if (typeEffect.isAnim) {
            typeEffect.SetMsg("");
            return;
        }

        int questTalkIndex = questManager.GetQuestTalkIndex(id);
        string talkData = talkMgr.GetTalk(id+questTalkIndex, talkIndex);

        if (talkData == "false") return;

        //End Talk
        if (talkData == null)
        {
            Debug.Log(questManager.CheckQuest(id)); //퀘스트 창 없애기 && 퀘스트 체크
            //isAction = false;
            talkIndex = 0;
            ScriptText.text = "";
            return;
        }

        //Continue Talk
        if (talkData.IndexOf(":") == -1) // :가 없으면
        {
            ScriptText.text += "밀루 : " + talkData.Split(':')[0] + "\n";
            typeEffect.SetMsg(talkData);
            portraitImg1.color = new Color(1, 1, 1, 0);
            portraitImg2.color = new Color(1, 1, 1, 1);

            Name1.text = "밀루";
            ColorDialog1.SetActive(true);
            ColorDialog2.SetActive(false);
        }

        else // 대사 : 이름색깔 : 이름 : 왼쪽이미지
        {
            rectImg1 = portraitImg1.GetComponent<RectTransform>(); //물고기(왼쪽)
            rectImg2 = portraitImg2.GetComponent<RectTransform>(); //메인고양이(오른쪽)

            ScriptText.text += talkData.Split(':')[2] + " : " + talkData.Split(':')[0] + "\n";

            //TalkText.text = talkData.Split(':')[0]; //구분자로 문장을 나눠줌  0: 대사 1:portraitIndex 2: 이름
            typeEffect.SetMsg(talkData.Split(':')[0]);

            //Show Portrait
            portraitImg1.sprite = talkMgr.GetPortrait(id, int.Parse(talkData.Split(':')[3]));

            portraitImg1.color = new Color(1, 1, 1, 1);
            portraitImg2.color = new Color(1, 1, 1, 1);

            Name2.text = talkData.Split(':')[2];



            if (int.Parse(talkData.Split(':')[3]) == 0) //부리
            {
                rectImg1.anchoredPosition = new Vector2(-420, 116);
                rectImg1.sizeDelta = new Vector2(500, 500);

            }

            else if (int.Parse(talkData.Split(':')[3]) == 1) //겨루
            {
                rectImg1.anchoredPosition = new Vector2(-517, 183);
                rectImg1.sizeDelta = new Vector2(600, 600);
            }

            else if (int.Parse(talkData.Split(':')[3]) == 2) //미리내
            {
                rectImg1.anchoredPosition = new Vector2(-430, 106);
                rectImg1.sizeDelta = new Vector2(600, 600);
            }

            else if (int.Parse(talkData.Split(':')[3]) == 3) //니묘
            {
                rectImg1.anchoredPosition = new Vector2(-384, 127);
                rectImg1.sizeDelta = new Vector2(600, 600);
            }

            else if (int.Parse(talkData.Split(':')[3]) == 4) //뻐끔
            {
                rectImg1.anchoredPosition = new Vector2(-318, 119);
                rectImg1.sizeDelta = new Vector2(500, 500);
            }

            else if(int.Parse(talkData.Split(':')[3])==6)
            {
                portraitImg2.sprite = talkMgr.GetPortrait(id, int.Parse(talkData.Split(':')[3]));
                portraitImg1.color = new Color(1, 1, 1, 0);
                rectImg2.anchoredPosition = new Vector2(-12, -16);
                rectImg2.sizeDelta = new Vector2(1400, 1400);
            }

            if (int.Parse(talkData.Split(':')[1]) == 5) //밀루
            {
                ColorDialog1.SetActive(true);
                ColorDialog2.SetActive(false);

                Name1.text = "밀루";
            }


            else if (int.Parse(talkData.Split(':')[1]) == 6) //겨루+부리(첫번째 물고기)
            {
                portraitImg1.color = new Color(1, 1, 1, 0);

                ColorDialog1.SetActive(true);
                ColorDialog2.SetActive(false);

                Name1.text = "밀루";
            }

            else if (int.Parse(talkData.Split(':')[1]) == -1)
            {
                portraitImg1.color = new Color(1, 1, 1, 0);
                ColorDialog1.SetActive(true);
                ColorDialog2.SetActive(false);

                Name1.text = "밀루";
            }

            else
            {
                ColorDialog1.SetActive(false);
                ColorDialog2.SetActive(true);

                Name2.text = talkData.Split(':')[2];
            }

        }

        isAction = true;
        talkIndex++; //액션키를 누를때마다 늘어남
        //nextPage.Play();
    }

    /*
    public void GameSave()
    {
        PlayerPrefs.SetFloat("PlayerX", player.transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", player.transform.position.y);
        PlayerPrefs.SetFloat("QustId", questManager.questId);
        PlayerPrefs.SetFloat("QustActionIndex", questManager.questActionIndex);
        PlayerPrefs.Save();
    }
    
    public void GameLoad()
    {
        if (!PlayerPrefs.HasKey("PlayerX"))
            return;
         
        float x = PlayerPrefs.GetFloat("PlayerX");
        float y = PlayerPrefs.GetFloat("PlayerY");
        int questId = PlayerPrefs.GetInt("QustId");
        int questActionIndex = PlayerPrefs.GetInt("QustActionIndex");

        player.transform.position = new Vector3(x, y, 0);
        questManager.questId = questId;
        questManager.questActionIndex = questActionIndex;    
    }*/

    public void GameExit()
    {
        //GameSave(); 이렇게 하니깐 quit가 안됨,,,ㅜ

        Application.Quit();
    }

    public int getButtonNumber() {
        return buttonNum;
    }

    public void ButtonAgency() {
        if (isFind) {
            matchSFX.Play();
            DoorOpen.Play();
            Ring.Play();
            Debug.Log("????");
            isAction = true;
            Quest.SetActive(true);
            isFind = false;
            Action(scanObject, buttonNum);
        }
        else {
            if (Quest.activeSelf) {
                if (typeEffect.isAnim) {
                    typeEffect.SetMsg("");
                    return;
                }
                isAction = false;
                Character_left.SetActive(true);
                Character_right.SetActive(true);
                Quest.SetActive(false);
                //ScriptText.text = "";
                TmpName.SetActive(false);
                TmpNameText.text = "";
            }
            else {
                Quest.SetActive(true);
                Character_left.SetActive(false);
                Character_right.SetActive(false);
                typeEffect.SetMsg("아직 중개소로 돌아가면 안돼.");
                //ScriptText.text = "밀루 : 아직 중개소로 돌아가면 안돼.";
                TmpName.SetActive(true);
                TmpNameText.text = "밀루";
            }
        }
    }

    public void PanelAfterFind() {
        if (Quest.activeSelf) {
            if (typeEffect.isAnim) {
                typeEffect.SetMsg("");
                return;
            }
            isAction = false;
            Character_left.SetActive(true);
            Character_right.SetActive(true);
            Quest.SetActive(false);
            //ScriptText.text = "";
            TmpName.SetActive(false);
            TmpNameText.text = "";
        }
    }

    public void ButtonAfterFind() {
        isAction = true;
        Quest.SetActive(true);
        Character_left.SetActive(false);
        Character_right.SetActive(false);
        typeEffect.SetMsg("중개소로 돌아가자!");
        TmpName.SetActive(true);
        TmpNameText.text = "밀루";
    }
}