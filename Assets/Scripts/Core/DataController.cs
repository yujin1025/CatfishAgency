using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;


[System.Serializable]
public class GameData
{
    // 각 챕터의 잠금여부
    public bool[] stageNum = new bool[10];

    public int QuestId;

}

public class DataController : MonoBehaviour
{
    //싱글톤으로 선언
    static GameObject _container;
    static GameObject Container
    {
        get
        {
            return _container;
        }
    }
    static DataController _instance;
    public static DataController Instance
    {
        get
        {
            if (!_instance)
            {
                _container = new GameObject();
                _container.name = "DataController";
                _instance = _container.AddComponent(typeof(DataController)) as DataController;
                DontDestroyOnLoad(_container);
            }
            return _instance;
        }
    }
    

    public GameData MySaveData = new GameData(); // 세이브데이터를 저장할 변수 선언

    //처음부터 버튼 클릭 시
    public void OnClickNewGame()
    {
        //윈도우나 모바일 앱에 게임이 설치된 폴더에 MySaveData.txt 파일 경로
        string filePath = Application.persistentDataPath + "/MySaveData.txt";
        Debug.Log("새 게임");
        if (!File.Exists(filePath))
        {
            Debug.Log("세이브파일 x");
            ResetSaveData(); //세이브데이터 초기화
            Save(); //초기화 세이브 데이터를 파일로 저장
            SceneManager.LoadScene("PrologueScene");
            return;
        }
        else
        {
            Debug.Log("세이브파일 o");
            ResetSaveData();
            Save();
            SceneManager.LoadScene("PrologueScene");
            return;
        }
    }

    //이어하기 버튼 클릭 시
    public void OnClickLoadGame()
    {
        string filePath = Application.persistentDataPath + "/MySaveData.txt";
        Debug.Log("불러오기");
        if (!File.Exists(filePath))
        {
            Debug.Log("세이브 파일x");
            ResetSaveData(); //세이브데이터 초기화
            Save(); //초기화 세이브 데이터를 파일로 저장
            SceneManager.LoadScene("PrologueScene");
            GameManager.instance.questID = 10;
            return;
        }
        else
        {
            Debug.Log("세이브 파일o");
            Load(); //기존 세이브 내용 확인하기 위해서 
            Save();

            if(MySaveData.stageNum[9] == true)
            {
                ResetSaveData(); //세이브데이터 초기화
                Save(); //초기화 세이브 데이터를 파일로 저장
                SceneManager.LoadScene("PrologueScene");
                GameManager.instance.questID = 10;
                return;
            }

            for (int i = 8; i >= 0; i--)
            {
                if (MySaveData.stageNum[i] == true)
                {
                    if (i % 2 == 1)//홀수이면
                    {
                        print(i);
                        SceneManager.LoadScene("MainScene");
                        GameManager.instance.questID = MySaveData.QuestId;
                        return;
                    }

                    else
                    {
                        print(i);
                        SceneManager.LoadScene("MainScene1");
                        GameManager.instance.questID = MySaveData.QuestId;
                        return;
                    }

                }
            }

            if(MySaveData.stageNum[0]==false)
            {
                ResetSaveData(); //세이브데이터 초기화
                Save(); //초기화 세이브 데이터를 파일로 저장
                SceneManager.LoadScene("PrologueScene");
                GameManager.instance.questID = 10;
            }
            return;
        }
    }

    //세이브파일 초기화
    public void ResetSaveData()
    {
        //Debug.Log("세이브 데이터를 초기화");
        for(int i=0;i<=9;i++)
        {
            MySaveData.stageNum[i] = false;
        }
        MySaveData.QuestId = 10;

        /*
        Debug.Log("1-1 " + MySaveData.stageNum[0]);
        Debug.Log("1-2 " + MySaveData.stageNum[1]);
        Debug.Log("2-1 " + MySaveData.stageNum[2]);
        Debug.Log("2-2 " + MySaveData.stageNum[3]);
        Debug.Log("3-1 " + MySaveData.stageNum[4]);
        Debug.Log("3-2 " + MySaveData.stageNum[5]);
        Debug.Log("4-1 " + MySaveData.stageNum[6]);
        Debug.Log("4-2 " + MySaveData.stageNum[7]);
        Debug.Log("5-1 " + MySaveData.stageNum[8]);
        Debug.Log("5-2 " + MySaveData.stageNum[9]);
        Debug.Log(MySaveData.QuestId);*/
    }

    //세이브 데이터를 세이브 파일로
    public void Save()
    {
        string jdata = JsonUtility.ToJson(MySaveData);
        string filePath = Application.persistentDataPath + "/MySaveData.txt";
        File.WriteAllText(filePath, jdata); // 이미 저장된 파일이 있다면 덮어쓰기
        print("저장완료");

        /*
        Debug.Log("1-1 " + MySaveData.stageNum[0]);
        Debug.Log("1-2 " + MySaveData.stageNum[1]);
        Debug.Log("2-1 " + MySaveData.stageNum[2]);
        Debug.Log("2-2 " + MySaveData.stageNum[3]);
        Debug.Log("3-1 " + MySaveData.stageNum[4]);
        Debug.Log("3-2 " + MySaveData.stageNum[5]);
        Debug.Log("4-1 " + MySaveData.stageNum[6]);
        Debug.Log("4-2 " + MySaveData.stageNum[7]);
        Debug.Log("5-1 " + MySaveData.stageNum[8]);
        Debug.Log("5-2 " + MySaveData.stageNum[9]);
        Debug.Log(MySaveData.QuestId);*/
    }

    public void Load()
    {
        string filePath = Application.persistentDataPath + "/MySaveData.txt";
        string jdata = File.ReadAllText(filePath);
        MySaveData = JsonUtility.FromJson<GameData>(jdata);
        print("데이터로드");
    }
}
