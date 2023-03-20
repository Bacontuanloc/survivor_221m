using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Char
{
    public class MovementJoystick : MonoBehaviour
    {
        public GameObject joystick;
        public GameObject joystickBG;
        public Vector2 joystickVec;
        public Vector2 joystickTouchPos;
        public Vector2 joystickOriginPos;
        private float joystickRadius;

        private void Start()
        {
            joystickOriginPos = joystickBG.transform.position;
            joystickRadius = joystickBG.GetComponent<RectTransform>().sizeDelta.y / 4;
        }

        public void PointerDown()
        {
            joystick.transform.position = Input.mousePosition;
            joystickBG.transform.position = Input.mousePosition;
            joystickTouchPos = Input.mousePosition;
        }

        public void PointerUp()
        {
            joystickVec = Vector2.zero;

            joystick.transform.position = joystickOriginPos;
            joystickBG.transform.position = joystickOriginPos;
        }

        public void Drag(BaseEventData baseEventData)
        {
            PointerEventData pointerEventData = baseEventData as PointerEventData;
            Vector2 dragPos = pointerEventData.position;
            joystickVec = (dragPos - joystickTouchPos).normalized;

            float joystickDist = Vector2.Distance(dragPos, joystickTouchPos);

            if (joystickDist < joystickRadius)
            {
                joystick.transform.position = joystickTouchPos + joystickVec * joystickDist;
            }

            else
            {
                joystick.transform.position = joystickTouchPos + joystickVec * joystickRadius;
            }
        }
    }
}
