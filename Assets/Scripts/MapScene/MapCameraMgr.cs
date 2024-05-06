using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

//카메라 중앙에 오브젝트 고정
public class MapCameraMgr : MonoBehaviour
{
    
    public GameObject Cat;  //A라는 GameObject변수 선언
    public Vector3 filtered_coord;
    public Camera camera_;
    public float cameraMoveSpeed;
    float limit_x;
    float limit_y;
    Transform AT;

    void Start ()
    {
        limit_x = Map.back_x - (camera_.orthographicSize * camera_.aspect);
        limit_y = Map.back_y - camera_.orthographicSize;
        AT = Cat.transform;
        Vector3 camera_coord = AT.position;
        camera_coord.z = transform.position.z;
        if (AT.position.x >= limit_x)
            camera_coord.x = limit_x;
        else if (AT.position.x <= -limit_x)
            camera_coord.x = -limit_x;
        if (AT.position.y >= limit_y)
            camera_coord.y = limit_y;
        else if (AT.position.y <= -limit_y)
            camera_coord.y = -limit_y;
        transform.position = camera_coord;
    }
    void FixedUpdate ()
    {
        Vector3 camera_coord = AT.position;
        camera_coord.z = transform.position.z;
        if (AT.position.x >= limit_x)
            camera_coord.x = limit_x;
        else if (AT.position.x <= -limit_x)
            camera_coord.x = -limit_x;
        if (AT.position.y >= limit_y)
            camera_coord.y = limit_y;
        else if (AT.position.y <= -limit_y)
            camera_coord.y = -limit_y;
        transform.position = Vector3.Lerp(transform.position, camera_coord, Time.deltaTime * cameraMoveSpeed);
    }
    
}
