using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public Vector2 joystickVector;
    public RectTransform joystickArea;
    public Camera camera_;
    public GameObject Cat;

    public void OnDrag(PointerEventData eventData)
    {
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(joystickArea, eventData.position, eventData.pressEventCamera, out Vector2 localPoint))
        {
            Vector3 tranformedPosition = camera_.ScreenToWorldPoint(eventData.position);
            Vector2 catPointerVector = new Vector2(tranformedPosition.x - Cat.transform.localPosition.x, tranformedPosition.y - Cat.transform.localPosition.y);
            float joystickNorm = Mathf.Sqrt(Mathf.Pow(catPointerVector.x, 2) + Mathf.Pow(catPointerVector.y, 2));
            if (joystickNorm > 1)
            {
                joystickVector.x = (catPointerVector.x / joystickNorm);
                joystickVector.y = (catPointerVector.y / joystickNorm);
            }
            else
            {
                joystickVector = Vector2.zero;
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        joystickVector = Vector2.zero;
    }
}
