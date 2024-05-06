using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestHint : MonoBehaviour
{
    public Text Hint;

    
    void Start()
    {
        if (GameManager.instance.questID == 10)
            Hint.text = "밤산책이라… 어두운 곳을 찾아가 볼까?";
        else if (GameManager.instance.questID == 20)
            Hint.text = "강해 보이는 친구라면 운동을 열심히 하려나?";
        else if (GameManager.instance.questID == 30)
            Hint.text = "얌전하고 안기 좋은 친구는 폭신폭신할 것 같아.";
        else if (GameManager.instance.questID == 40)
            Hint.text = "햇빛이 잘 드는 곳으로 가볼까?";
        else if (GameManager.instance.questID == 50)
            Hint.text = "꼬마 친구들은 어디서 노는 것을 좋아할까?";
    }
    
    void Update()
    {
        if (GameManager.instance.questID == 10)
            Hint.text = "밤산책이라… 어두운 곳을 찾아가 볼까?";
        else if (GameManager.instance.questID == 20)
            Hint.text = "강해 보이는 친구라면 운동을 열심히 하려나?";
        else if (GameManager.instance.questID == 30)
            Hint.text = "얌전하고 안기 좋은 친구는 폭신폭신할 것 같아.";
        else if (GameManager.instance.questID == 40)
            Hint.text = "햇빛이 잘 드는 곳으로 가볼까?";
        else if (GameManager.instance.questID == 50)
            Hint.text = "꼬마 친구들은 어디서 노는 것을 좋아할까?";
    }

}
