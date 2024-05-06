using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Mgr : MonoBehaviour
{
    public GameObject Cat_move;
    public GameObject Cat_walk_left;
    public GameObject Cat_walk_right;
    Color Cat_walk_Color;
    // Start is called before the first frame update
    void Start()
    {
        Cat_move.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
        Cat_walk_left.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
        Cat_walk_right.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
        //Cat_move = GameObject.Find("Cat_move");
        //Cat_walk = GameObject.Find("Cat_walk");
    }

    // Update is called once per frame
    void Update()
    {
        //위 or 왼 or 오 or 아래 누르면
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            Cat_move.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
            Cat_walk_left.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
            Cat_walk_right.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
            //Cat_move.SetActive(false);
            //Cat_walk.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            Cat_move.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
            Cat_walk_left.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
            Cat_walk_right.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
            //Cat_move.SetActive(false);
            //Cat_walk.SetActive(true);
        }

        
        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            Cat_move.GetComponent<SpriteRenderer>().color = new Color(255,255,255,255);
            Cat_walk_left.GetComponent<SpriteRenderer>().color = new Color(255,255,255,0);
            Cat_walk_right.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
            //Cat_move.SetActive(true);
            //Cat_walk.SetActive(false);
        }
    }

    
}
