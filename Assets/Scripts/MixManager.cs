using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixManager : MonoBehaviour
{
    public string[] mixRecipe1;
    public string[] mixRecipe2;

    public string keyStack = string.Empty;

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
        string result = null;
        if (PlayManager.Instance.gameMode == 1)
            result = Search1(key);
        else if (PlayManager.Instance.gameMode == 2)
            result = Search2(key);

        if (result == null)
        {
            return;
        }

        float score = 0f;

        if (PlayManager.Instance.gameMode == 1)
        {
            switch (result)
            {
                default:
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
        }

        else if (PlayManager.Instance.gameMode == 2)
        {
            keyStack = $"{keyStack}{result}";
            keyStack = SortKeyStack(keyStack);

            switch (keyStack)
            {
                default:
                    keyStack = string.Empty;
                    break;
                case "1222":
                    score = 30f;
                    break;
                case "1112":
                    score = 30f;
                    break;
            }

            if (keyStack == string.Empty)
            {
                switch (result)
                {
                    default:
                        break;
                    case "11":
                        score = 10f;
                        break;
                    case "22":
                        score = 10f;
                        break;
                    case "12":
                        score = 10f;
                        break;
                }
                keyStack = result;
                MyDebug.Log(keyStack + ": 성공");
            }
            else MyDebug.Log(keyStack + ": 성공");
        }

        PlayManager.Instance.HP += score;

    }


    string Search1(string key)
    {
        foreach(var recp in mixRecipe1)
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

    string Search2(string key)
    {
        foreach (var recp in mixRecipe2)
        {
            if (key == recp)
            {
                return key;
            }
        }

        MyDebug.Log(key + ": 실패");

        return null;
    }

    string SortKeyStack(string key)
    {
        char[] chars = key.ToCharArray();
        List<int> ints = new List<int>();

        foreach(var c in chars)
        {
            ints.Add(int.Parse(c.ToString()));
        }

        ints.Sort(delegate(int a, int b) { return a.CompareTo(b); });

        string result = string.Empty;

        foreach(var i in ints)
        {
            result = $"{result}{i}";
        }

        return result;
    }
}
