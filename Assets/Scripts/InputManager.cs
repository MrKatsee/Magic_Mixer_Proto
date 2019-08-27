using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    Element element;

    Vector2 cursor_Vec;
    Vector2 cur_Pos;
    Vector2 velocity;

    private const float velocity_Coef = 10f;
    // Update is called once per frame
    void Update()
    {
        if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            if (Input.GetMouseButtonUp(0))
            {
                if (element != null)
                {
                    element.onDrag = false;
                    element.timer = SettingManager.deactivateTime - SettingManager.flyingTime;
                    element.gameObject.GetComponent<Rigidbody2D>().velocity = velocity * velocity_Coef;
                }
                element = null;
            }
            else if (Input.GetMouseButton(0))
            {
                cursor_Vec = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                if (element == null)
                {
                    Collider2D c = Physics2D.OverlapPoint(cursor_Vec);
                    if (c != null)
                    {
                        element = c.GetComponent<Element>();
                        if (!element.activated) element = null;     //여기서 가끔 널 레퍼 뜸
                        else
                        {
                            element.onDrag = true;
                            cur_Pos = cursor_Vec;
                        }
                    }
                }
                else
                {
                    Vector2 prev_Pos = cur_Pos;
                    cur_Pos = cursor_Vec;
                    velocity = cur_Pos - prev_Pos;

                    element.transform.position = cursor_Vec;
                }
            }
        }

        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                if (element != null)
                {
                    element.onDrag = false;
                    element.timer = SettingManager.deactivateTime - SettingManager.flyingTime;
                    element.gameObject.GetComponent<Rigidbody2D>().velocity = velocity * velocity_Coef;
                }
                element = null;
            }
            else if (Input.touchCount == 1)
            {
                cursor_Vec = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);

                if (element == null)
                {
                    Collider2D c = Physics2D.OverlapPoint(cursor_Vec);
                    if (c != null)
                    {
                        element = c.GetComponent<Element>();
                        if (!element.activated) element = null;     //여기서 가끔 널 레퍼 뜸
                        else
                        {
                            element.onDrag = true;
                            cur_Pos = cursor_Vec;
                        }
                    }
                }
                else
                {
                    Vector2 prev_Pos = cur_Pos;
                    cur_Pos = cursor_Vec;
                    velocity = cur_Pos - prev_Pos;

                    element.transform.position = cursor_Vec;
                }
            }
        }



    }

}
