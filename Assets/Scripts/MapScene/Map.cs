using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Map : MonoBehaviour
{

    public float Speed;
    public static float back_x;
    public static float back_y;
    float limit_x;
    float limit_y;
    float cat_x;
    float cat_y;

    //Animator anim;
    float h;
    float v;
    Rigidbody2D rigid;
    Animator animator;

    public GameMgr manager;

    public GameObject CatWalkingSFX;
    public AudioSource catWalkingSFX;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        Vector2 back_size = GetSpriteSize(GameObject.Find("Background"));
        //Vector2 cat_size = GetSpriteSize(GameObject.Find("MainCat"));
        Vector2 cat_size = GetSpriteSize(GameObject.Find("Cat_move"));
        back_x = back_size.x / 2;
        back_y = back_size.y / 2;
        cat_x = cat_size.x / 2;
        cat_y = cat_size.y / 2;
        limit_x = back_x - cat_x;
        limit_y = back_y - cat_y;

        catWalkingSFX = CatWalkingSFX.GetComponent<AudioSource>();
    }

    //Sprite 크기 구하는 함수
    public static Vector2 GetSpriteSize(GameObject _target)
    {
        Vector2 worldSize = Vector2.zero;
        if (_target.GetComponent<SpriteRenderer>())
        {
            Vector2 spriteSize = _target.GetComponent<SpriteRenderer>().sprite.rect.size;
            Vector2 localSpriteSize = spriteSize / _target.GetComponent<SpriteRenderer>().sprite.pixelsPerUnit;
            worldSize = localSpriteSize;
            worldSize.x *= _target.transform.lossyScale.x;
            worldSize.y *= _target.transform.lossyScale.y;
        }
        return worldSize;
    }

    void Update()
    {
        //움직이지 않도록
        h = manager.isAction ? 0 : Input.GetAxisRaw("Horizontal"); // 왼쪽 -1 오른쪽 1 출력
        v = manager.isAction ? 0 : Input.GetAxisRaw("Vertical"); // 아래쪽 -1 위쪽 1 출력
        if (h == 0 && v == 0)
        {
            h = GameObject.Find("TouchJoystick").GetComponent<Joystick>().joystickVector.x;
            v = GameObject.Find("TouchJoystick").GetComponent<Joystick>().joystickVector.y;
        }

        //Animator 관련
        if (h != 0 || v != 0)
        {
            if (Mathf.Abs(h) > Mathf.Abs(v))
            {
                if (h > 0) {
                    animator.SetInteger("MainCatAnimationState", 1);
                    if (!catWalkingSFX.isPlaying)  {
                        catWalkingSFX.Play();
                    }
                }
                else if (h < 0) {
                    animator.SetInteger("MainCatAnimationState", 2);
                    if (!catWalkingSFX.isPlaying)  {
                        catWalkingSFX.Play();
                    }
                }
            }
            else
            {
                if (v > 0) {
                    animator.SetInteger("MainCatAnimationState", 4);
                    if (!catWalkingSFX.isPlaying)  {
                        catWalkingSFX.Play();
                    }
                }
                else if (v < 0) {
                    animator.SetInteger("MainCatAnimationState", 3);
                    if (!catWalkingSFX.isPlaying)  {
                        catWalkingSFX.Play();
                    }
                }
            }
        }
        else {
            animator.SetInteger("MainCatAnimationState", 0);
            catWalkingSFX.Stop();
        }
    }


    void FixedUpdate()
    {
        Vector2 object_speed = new Vector2(h, v) * Speed;
        moveCat(object_speed);
    }

    public void moveCat(Vector2 object_speed)
    {
        //맵 중앙화면 성립안되면 화면은 가만히 고양이만 움직이기
        Vector3 cat_coord = transform.position;
        if (transform.position.x >= limit_x)
        {
            object_speed.x = object_speed.x > 0 ? 0 : object_speed.x;
            cat_coord.x = limit_x;
            transform.position = cat_coord;
        }
        else if (transform.position.x <= -limit_x)
        {
            object_speed.x = object_speed.x < 0 ? 0 : object_speed.x;
            cat_coord.x = -limit_x;
            transform.position = cat_coord;
        }

        if (transform.position.y >= limit_y)
        {
            object_speed.y = object_speed.y > 0 ? 0 : object_speed.y;
            cat_coord.y = limit_y;
            transform.position = cat_coord;
        }
        else if (transform.position.y <= -limit_y)
        {
            object_speed.y = object_speed.y < 0 ? 0 : object_speed.y;
            cat_coord.y = -limit_y;
            transform.position = cat_coord;
        }
        rigid.velocity = object_speed;
    }

}
