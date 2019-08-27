using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixManager : MonoBehaviour
{
    public string[] mixRecipe;

    private void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == "Element")
        {
            Element e = c.GetComponent<Element>();
            string str = e.GetIDString();

            MixMagic(str);

            Destroy(e.gameObject);
        }
    }

    void MixMagic(string key)
    {
        string result = Search(key);

        if (result == null) return;

        float score = 0f;

        switch (result)
        {
            default:
                break;
            case "123":
                score = 20f;
                break;
            case "112":
                score = 20f;
                break;
            case "22":
                score = 10f;
                break;
            case "12":
                score = 10f;
                break;
        }

        PlayManager.Instance.HP += score;

    }


    string Search(string key)
    {
        foreach(var recp in mixRecipe)
        {
            if (key == recp)
            {
                MyDebug.Log(key + ": 성공");

                return key;
            }
        }

        MyDebug.Log(key + ": 실패");

        return null;
    }
}
