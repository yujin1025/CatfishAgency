using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestManager : MonoBehaviour
{
    public int questId;
    public int questActionIndex; //퀘스트 대화 순서
    Dictionary<int, QuestData> questList;
    public GameObject Quest; //대화창 UI
    public GameMgr gameMgr;
    public GameObject BlockPanel;

    public AudioSource doorOpen;
    public AudioSource doorClose;
    public AudioSource Ring;

    void Awake()
    {
        questId = GameManager.instance.questID;
        questList = new Dictionary<int, QuestData>();
        GenerateData();
    }

    void GenerateData()
    {
        questList.Add(10, new QuestData("물고기1 찾기.", new int[] { 1000 }));
        questList.Add(20, new QuestData("물고기2 찾기.", new int[] { 2000 }));
        questList.Add(30, new QuestData("물고기3 찾기.", new int[] { 3000 }));
        questList.Add(40, new QuestData("물고기4 찾기.", new int[] { 4000 }));
        questList.Add(50, new QuestData("물고기5 찾기.", new int[] { 5000 }));
        questList.Add(60, new QuestData("퀘스트 올 클리어!", new int[] { 0 }));
    }

    //id를 받고 퀘스트 번호를 반환하는 함수
    public int GetQuestTalkIndex(int id)
    {
        return questId + questActionIndex; //퀘스트 번호 + 퀘스트 대화 순서 = 퀘스트 대화 Id
    }

    public string CheckQuest(int id)
    {
        //순서에 맞게 대화했을때만 퀘스트 대화 순서 올림
        //Next Talk Target
        if (id == questList[questId].npcId[questActionIndex])
            questActionIndex++;
        

        //Talk Complete & Next Quest
        if (questActionIndex == questList[questId].npcId.Length) {
            BlockPanel.SetActive(true);
            NextQuest();
            //Quest Name
            return questList[questId].questName;
        }
        //Quest.SetActive(false);
        gameMgr.isAction = false;

        //Quest Name
        return questList[questId].questName;
    }

    void NextQuest()
    {
        GameManager.instance.questID += 10;
        questId = GameManager.instance.questID;
        DataController.Instance.MySaveData.QuestId += 10;
        questActionIndex = 0;
        doorClose.Play();
        Ring.Play();
        // if (questId == 60) {
        //     doorOpen.Play();
        //     Ring.Play();
        //     Invoke("DoorClose", 1.3f);
        // }
        // else {
            doorClose.Play();
            Ring.Play();
            Invoke("NextQuestAfterInvoke", 1f);
        // }
    }

    // void DoorClose() {
    //     doorClose.Play();
    //     Ring.Play();
    //     Invoke("NextQuestAfterInvoke", 1f);
    // }
    void NextQuestAfterInvoke()
    {
        if(questId == 20)
        {
            DataController.Instance.MySaveData.stageNum[1] = true;
            SceneManager.LoadScene("MainScene");
        }

        else if (questId == 30)
        {
            DataController.Instance.MySaveData.stageNum[3] = true;
            SceneManager.LoadScene("MainScene");
        }

        else if (questId == 40)
        {
            DataController.Instance.MySaveData.stageNum[5] = true;
            SceneManager.LoadScene("MainScene");
        }

        else if (questId == 50)
        {
            DataController.Instance.MySaveData.stageNum[7] = true;
            SceneManager.LoadScene("MainScene");
        }

        else if (questId == 60)
        {
            DataController.Instance.MySaveData.stageNum[9] = true;
            SceneManager.LoadScene("EndingScene");
        }

    }
}
