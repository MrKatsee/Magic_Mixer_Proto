using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyDebug : MonoBehaviour
{
    private void Start()
    {
        debug = GameObject.Find("Debug").GetComponent<Text>();
    }

    public static Text debug;

    public static void Log(object o)
    {
        debug.text = o.ToString();
    }
}
