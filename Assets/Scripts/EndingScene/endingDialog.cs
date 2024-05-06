using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class endingDialog : MonoBehaviour
{

    [SerializeField]
    private Speaker1[] speakers; //캐릭터들의 UI 배열
    [SerializeField]
    private DialogData1[] dialogs; //대사 목록 배열
    [SerializeField]
    private bool isAutoStart = true; //자동 시작 여부
    private bool isFirst = true; //최초 1회만 호출하기 위한 변수
    private int currentDialogIndex = -1; //현재 대사 순번
    private int currentSpeakerIndex = 0; //현재  말을 하는 화자(Speaker)의 speakers 배열 순번
    private float typingSpeed = 0.05f; //타이핑 재생 속도
    private bool isTypingEffect = false; //타이핑 재생중인지

    public AudioSource TypingSound;
    public AudioSource NextPage;

    public ShowScript ShowScript;

    private void Awake()
    {
        Setup();
    }


    //모든 게임 오브젝트 비활성화, 캐릭터 이미지는 보이도록 설정

    private void Setup()
    {
        for (int i = 0; i < speakers.Length; ++i)
        {
            SetActiveObjects(speakers[i], false);
        }
    }

    public bool UpdateDialog()
    {
        int pointerID;

#if UNITY_EDITOR
        pointerID = -1; //PC나 유니티 상에서는 -1

#elif UNITY_ANDROID

        pointerID = 0;  // 휴대폰이나 이외에서 터치 상에서는 0 

#endif

        // 대사 분기가 시작될 때 1회만 호출
        if (isFirst == true)
        {
            Setup();
            // 자동 재생(isAutoStart=true)으로 설정되어 있으면 첫 번째 대사 재생
            if (isAutoStart) SetNextDialog();

            isFirst = false;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject(pointerID) == false && ShowScript.isShown == true)
            {
                // 텍스트 타이핑 효과를 재생중일때 마우스 왼쪽 클릭하면 타이핑 효과 종료
                if (isTypingEffect == true)
                {
                    isTypingEffect = false;

                    // 타이핑 효과를 중지하고, 현재 대사 전체를 출력한다
                    StopCoroutine("OnTypingText");
                    speakers[currentSpeakerIndex].textDialogue.text = dialogs[currentDialogIndex].dialogue;
                    // 대사가 완료되었을 때 출력되는 커서 활성화
                    speakers[currentSpeakerIndex].objectArrow.SetActive(true);
                    // 타이핑 소리 중지
                    TypingSound.Stop();
                    return false;
                }

                // 대사가 남아있을 경우 다음 대사 진행
                if (dialogs.Length > currentDialogIndex + 1)
                {
                    NextPage.Play();
                    SetNextDialog();
                }
                // 대사가 더 이상 없을 경우 모든 오브젝트를 비활성화하고 true 반환
                else
                {
                    // 현재 대화에 참여했던 모든 캐릭터, 대화 관련 UI를 보이지 않게 비활성화
                    for (int i = 0; i < speakers.Length; ++i)
                    {
                        SetActiveObjects(speakers[i], false);
                    }

                    return true;
                }
            }

        }
        return false;
    }


    private void SetNextDialog()
    {
        //이전 화자의 대화 관련 오브젝트 비활성화
        SetActiveObjects(speakers[currentSpeakerIndex], false);
        //다음 대사 진행
        currentDialogIndex++;
        //현재 화자 순번 설정
        currentSpeakerIndex = dialogs[currentDialogIndex].speakerIndex;
        //현재 화자의 대화관련 오브젝트 활성화
        SetActiveObjects(speakers[currentSpeakerIndex], true);
        //현재 화자 이름 텍스트 설정
        speakers[currentSpeakerIndex].textName.text = dialogs[currentDialogIndex].name;
        TypingSound.Play();
        StartCoroutine("OnTypingText");
    }

    private void SetActiveObjects(Speaker1 speaker, bool visible)
    {
        speaker.imageDialog.gameObject.SetActive(visible);
        speaker.textName.gameObject.SetActive(visible);
        speaker.textDialogue.gameObject.SetActive(visible);
        speaker.ColorDialog.SetActive(visible);
        speaker.objectArrow.SetActive(false);

    }

    private IEnumerator OnTypingText()
    {
        int index = 0;
        isTypingEffect = true;
        while (index < dialogs[currentDialogIndex].dialogue.Length)
        {
            speakers[currentSpeakerIndex].textDialogue.text = dialogs[currentDialogIndex].dialogue.Substring(0, index + 1);
            index++;
            yield return new WaitForSeconds(typingSpeed);
        }

        isTypingEffect = false;
        speakers[currentSpeakerIndex].objectArrow.SetActive(true);
        // 타이핑 소리 중지
        TypingSound.Stop();
    }
}

[System.Serializable]
public struct Speaker1
{
    public Image imageDialog; //대화창 Image UI
    public Text textName; //대화중인 캐릭터 이름
    public GameObject ColorDialog;
    public Text textDialogue; //현재 대사 
    public GameObject objectArrow; //대사 완료됐을때 출력되는 커서
}

[System.Serializable]
public struct DialogData1
{
    public int speakerIndex; //speakers 배열 순번
    public string name; //캐릭터 이름
    [TextArea(3, 5)]
    public string dialogue; //대사
}