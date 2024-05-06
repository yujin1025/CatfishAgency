using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkMgr : MonoBehaviour
{
    public GameMgr gameMgr;
    public AppendFoundFish AppendFoundFish;
    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite> portraitData;

    public Sprite[] portraitArr;

    private int RandomInt;
    private string script;

    //public AudioSource matchSFX;
    public AudioSource nextPageSFX;
    public AudioSource doorOpen;
    public AudioSource doorClose;
    public AudioSource Ring;


    void Awake()
    {
        talkData = new Dictionary<int, string[]>(); //초기화
        portraitData = new Dictionary<int, Sprite>();
        GenerateData(); //데이터를 만들어주는 함수
        //matchSFX = gameObject.GetComponent<AudioSource>();
    }

    void GenerateData()
    {
        //대사 생성 (obj id, 대화 )

        talkData.Add(1000, new string[]
        {   
            "안녕하세요, 고양이네 물고기 중개소에서 온 밀루라고 합니다!:5:밀루:0",
            "친구가 될 고양이에게 안내해 드리려고 찾아왔어요.:5:밀루:0",
            "…:0:부리:0",
            "헉.. 사라졌어?!:-1:밀루:0"
        });
        talkData.Add(2000, new string[] 
        {
            "안녕하세요, 고양이네 물고기 중개소에서 온 밀루라고 합니다!:5:밀루:1",
            "친구가 될 고양이에게 안내해 드리려고 찾아왔어요.:5:밀루:1",
            "잘못 찾아왔어.:1:겨루:1"
        });
        talkData.Add(3000, new string[] 
        {
            "안녕하세요, 고양이네 물고기 중개소에서 온 밀루라고 합니다!:5:밀루:2",
            "친구가 될 고양이에게 안내해 드리려고 찾아왔어요.:5:밀루:2",
            "죄송하지만 제가 아닌 것 같아요. 조심히 가세요.:2:미리내:2"
        });
        talkData.Add(4000, new string[] 
        {
            "안녕하세요, 고양이네 물고기 중개소에서 온 밀루라고 합니다!:5:밀루:3",
            "친구가 될 고양이에게 안내해 드리려고 찾아왔어요.:5:밀루:3",
            "물고기 잘못 보셨습니다..:3:니묘:3"
        });
        talkData.Add(5000, new string[] 
        {
            "안녕하세요, 고양이네 물고기 중개소에서 온 밀루라고 합니다!:5:밀루:4",
            "친구가 될 고양이에게 안내해 드리려고 찾아왔어요.:5:밀루:4",
            "어? 그거 나는 아닌데..?:4:뻐끔:4"
        });
        talkData.Add(6000, new string[] { RandomScript() });
        talkData.Add(7000, new string[] { RandomScript() });
        talkData.Add(8000, new string[] { RandomScript() });
        talkData.Add(9000, new string[] { RandomScript() });
        talkData.Add(10000, new string[] { RandomScript() });
        talkData.Add(11000, new string[] { RandomScript() });
        talkData.Add(12000, new string[] { RandomScript() });

        //퀘스트용 대화(obj id + quest id + questIndex(순서번호))

        talkData.Add(1000 + 10, new string[] 
        {
            "안녕하세요, 고양이네 물고기 중개소에서 온 밀루라고 합니다!:5:밀루:0",
            "친구가 될 고양이에게 안내해 드리려고 찾아왔어요.:5:밀루:0",
            "부리님이 맞으신가요?:5:밀루:0",
            "...!:0:부리:0",
            "앗..! 머리 위에 올라타시면 곤란해요..!:6:밀루:6",
            "...:0:부리:6",
            "... 부리님이 맞으신 거죠? 같이 중개소로 돌아가요.:6:밀루:6",
            "…!!:0:부리:6",
            " ...:6:밀루:6",
            "padding:0:padding:0",
            "부리님! 도착했습니다..!:6:밀루:6",//arrive //
            "…!!:0:부리:6"
            //
        });
        talkData.Add(2000 + 20, new string[] 
        {
            "오! 안녕하세요, 고양이네 물고기 중개소에서 온 밀루라고 합니다!:5:밀루:1",
            "친구가 될 고양이에게 안내해 드리려고 찾아왔어요.:5:밀루:1",
            "겨루님이 맞으신가요?:5:밀루:1",
            "잘 찾아왔군, 마침 운동이 끝난 참이야.:1:겨루:1",
            "바로 출발하면 되나?:1:겨루:1",
            "앗 네! 같이 가면 될 것 같아요.:5:밀루:1",
            "걸어가는 거야? 뛰는 건 좀 무리려나?:1:겨루:1",
            "네… 맞다! 그.. 고양이 손님께선 강해 보이는 방법을 배우고 싶으시대요!:5:밀루:1",
            "나 자신을 가꾸고 남을 그렇게 돕는 것도 보람찬 일이지.:1:겨루:1",
            "재미있겠는걸?:1:겨루:1",
            "맞아요! 그러면 같이 돌아가 볼까요?:5:밀루:1",
            "운동은 참 좋은 일이야.:1:겨루:1",
            "네.. 이 길로 오면 돼요..:5:밀루:1",
            "padding:0:padding:0",
            "다 왔습니다! :5:밀루:1",//arrive
            "벌써 다 온 건가? 생각보다 가깝군. 하루치 운동도 안 되겠는걸?:1:겨루:1",//
            "너구나, 강해지고 싶은 고양이가.:1:겨루:1",
            "네.. 금방이에요! 모쪼록 잘 되었으면 좋겠네요.:5:밀루:1",
            "고마워.:1:겨루:1"
            //
        });
        talkData.Add(3000 + 30, new string[] 
        {
            "안녕하세요, 고양이네 물고기 중개소에서 온 밀루라고 합니다!:5:밀루:2",
            "친구가 될 고양이에게 안내해 드리려고 찾아왔어요.:5:밀루:2",
            "미리내님이 맞으신가요?:5:밀루:2",
            "아 네 마.. 맞아요 네, 반갑습니다..:2:미리내:2",
            "같이 중개소로 가요!:5:밀루:2",
            "앞으로 친구가 될 라이님은 주로 집에 계시는 걸 좋아한대요.:5:밀루:2",
            "그런가요? 저도 집에서 책을 읽는 것 좋아해요. 또.. 낮잠도 좋아하고요!:2:미리내:2",
            "두 분께서는 금방 어울리시겠네요!:5:밀루:2",
            "그랬으면 좋겠네요, 쑥스러움을 많이 타는 편이라..:2:미리내:2",
            "괜찮을 거예요, 편하게 생각하세요!:5:밀루:2",
            "padding:0:padding:0",
            "여기 다 왔습니다!:5:밀루:2",//arrive
            "어느새 다 왔네요. 감사합니다, 밀루님.:2:미리내:2",
            "안.. 안녕하세요! 라이님.:2:미리내:2", //
            "아니에요! 나중에 놀러 가도 괜찮을까요? 같이 책 읽고 싶어요!:5:밀루:2",
            "밀루님이라면 환영이에요! 다음에 뵐.. 뵐게요! 감사합니다!:2:미리내:2"
            //
        });
        talkData.Add(4000 + 40, new string[] 
        {
            "안녕하세요, 고양이네 물고기 중개소에서 온 밀루라고 합니다!:5:밀루:3",
            "친구가 될 고양이에게 안내해 드리려고 찾아왔어요.:5:밀루:3",
            "니묘님이 맞으신가요?:5:밀루:3",
            "안녕하세요, 맞습니다.:3:니묘:3",
            "초면에 실례지만 혹시 온탕을 좋아하시나요..?:5:밀루:3",
            "어.. 네.. 좋아합니다, 왜 그러시죠?:3:니묘:3",
            "고양이 손님께서 온탕을 좋아하는 물고기와 친구가 되고 싶으시다고 하셔서요!:5:밀루:3",
            "독특하네요, 어떤 고양이일지 궁금해지네요.:3:니묘:3",
            "저는 너무 평범해서 특별한 친구를 원했거든요. 이름부터 흔하디흔한 니묘라니..:3:니묘:3",
            "저희 부모님은 도대체 어떤 생각을 하신 걸까요..:3:니묘:3",
            "아무튼 보고만 있어도 재미있을 것 같아요.:3:니묘:3",
            "확실히 재미있으신 분인 건 맞을 것 같아요. 잘 어울릴 것 같아요.:5:밀루:3",
            "padding:0:padding:0",
            "벌써 도착했네요!:5:밀루:3",//arrive
            "무척 기대되네요.:3:니묘:3",//
            "아, 이 고양이로군요. 감사합니다.:3:니묘:3"
            //
        });
        talkData.Add(5000 + 50, new string[]
        {
            "안녕하세요, 고양이네 물고기 중개소에서 온 밀루라고 합니다!:5:밀루:4",
            "친구가 될 고양이에게 안내해 드리려고 찾아왔어요.:5:밀루:4",
            "뻐끔님이 맞으신가요?:5:밀루:4",
            "안녕! 어? 밀루 누나다.:4:뻐끔:4",
            "방금 다 놀고 집에 가려고 했는데 하마터면 엇갈릴 뻔했네.:4:뻐끔:4",
            "(휴.. 큰일 날 뻔했다.):5:밀루:4",
            "그랬구나, 지금 고양이 친구가 중개소에서 기다리고 있는데, 같이 갈래?:5:밀루:4",
            "헉! 어떤 고양이 친구야? 나 고양이랑 친구는 처음이라 엄마가 중개소로 신청해 줬는데..:4:뻐끔:4",
            "되게 막 떨린다! 어색할 것 같아..:4:뻐끔:4",
            "나랑 친한 동생이야. 최근에 친했던 친구가 이사를 갔대서 새로운 친구를 사귀고 싶은가 봐!:5:밀루:4",
            "귀엽고 착해. 은근히 장난꾸러기이고. 음.. 꼬리가 특히 뭉툭해서 정말 귀여워. 너랑 잘 어울려!:5:밀루:4",
            "그렇구나, 뭔가 어.. 어색해.. 금방 친해질 수 있겠지..?:4:뻐끔:4",
            "둘 다 놀이터에서 노는 걸 좋아하니 금방 친해질 수 있을 거야. 같이 가보자!:5:밀루:4",
            "어! 같이 가자! 누나!:4:뻐끔:4",
            "맞다. 앞에 부딪히는 거 있으면 말해줘!:4:뻐끔:4",
            "나 되게 조심조심 가야 해..!:4:뻐끔:4",
            "아..맞아 그러네! 조심히 가자!:5:밀루:4",
            "padding:0:padding:0",
            "휴.. 다 왔다. 어, 저기 밖에서 기다리는 고양이야?:4:뻐끔:4",//arrive
            "맞아, 어? 루나가 마중을 다 나왔네. 가서 인사해 봐! 얼른!:5:밀루:4",
            "고마워 누나, 나중에 셋이 같이 놀자! 꼭!:4:뻐끔:4"
            ////
        });

        //Portrait Data
        portraitData.Add(1000 + 0, portraitArr[0]);
        portraitData.Add(1000 + 5, portraitArr[5]);
        portraitData.Add(1000 + 6, portraitArr[6]);
        portraitData.Add(2000 + 1, portraitArr[1]);
        portraitData.Add(2000 + 5, portraitArr[5]);
        portraitData.Add(3000 + 2, portraitArr[2]);
        portraitData.Add(3000 + 5, portraitArr[5]);
        portraitData.Add(4000 + 3, portraitArr[3]);
        portraitData.Add(4000 + 5, portraitArr[5]);
        portraitData.Add(5000 + 4, portraitArr[4]);
        portraitData.Add(5000 + 5, portraitArr[5]);
    }


    //지정된 대화 문장을 반환하는 함수
    public string GetTalk(int id, int talkIndex) //talkIndex => 몇번째 문장을 가져올지
    {
        if(!talkData.ContainsKey(id)){ 
            if (!talkData.ContainsKey(id - id % 10))
                return GetTalk(id - id % 100, talkIndex); //Get First Talk
            else
                return GetTalk(id - id % 10, talkIndex); //Get First Quest Talk
        }
        
        if (talkIndex == talkData[id].Length) //대화 끝
            return null;
        else
        {
            if (id == 1010 && talkIndex == 9 ||
                id == 2020 && talkIndex == 13||
                id == 3030 && talkIndex == 10||
                id == 4040 && talkIndex == 12||
                id == 5050 && talkIndex == 17)
            {
                //matchSFX.Play();
                AppendFoundFish.SetFoundFish();
                gameMgr.isFind = true;
                gameMgr.isAction = false;
                gameMgr.Quest.SetActive(false);
                talkIndex++;
                gameMgr.talkIndex++;
                return "false";
            }
            //DoorOpen(id, talkIndex);
            //DoorClose(id, talkIndex);
            NextPageSFX(talkIndex);
            return talkData[id][talkIndex];
        }
    }

    public void DoorOpen(int id, int talkIndex) {
        if (id == 1010 && talkIndex == 9 ||
            id == 2020 && talkIndex == 14||
            id == 3030 && talkIndex == 12||
            id == 4040 && talkIndex == 13)
        {
            doorOpen.Play();
            Ring.Play();
        }
        // else if (id == 5050 && talkIndex == 13)
        // {
        //     doorOpen.Play();
        //     Invoke("DoorClose", 1.3f);
        // }
    }

    // public void DoorClose(int id, int talkIndex) {
    //     if (id == 1010 && talkIndex == 9 ||
    //         id == 2020 && talkIndex == 15||
    //         id == 3030 && talkIndex == 11||
    //         id == 4040 && talkIndex == 14||
    //         id == 5050 && talkIndex == 13)
    //     {
    //         doorClose.Play();
    //         Invoke("")
    //     }
    // }

    public void NextPageSFX(int talkIndex) {
        if (talkIndex != 0) nextPageSFX.Play();
    }

    //지정된 초상화 스프라이트를 반환하는 함수
    public Sprite GetPortrait(int id, int portraitIndex)
    {
        return portraitData[id + portraitIndex];
    }

    public string RandomScript()
    {
        RandomInt = Random.Range(0, 3);

        if (RandomInt == 0)
            script = "여기는 아닌가 봐... 다른 곳으로 가봐야겠어.";
        else if (RandomInt == 1)
            script = "여긴 아무도 안사네!";
        else if (RandomInt == 2)
            script = "잘못 찾아왔다!";

        return script;
    }

}
