using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppendFoundFish : MonoBehaviour
{
    public QuestManager QuestManager;
    public Sprite[] portraitArr;

    public void SetFoundFish() {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = portraitArr[QuestManager.questId/10 - 1];
    }
}
