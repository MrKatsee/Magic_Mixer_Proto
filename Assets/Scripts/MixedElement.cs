using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixedElement : MonoBehaviour
{
    List<int> elements_ID;

    public void Init(int id)
    {
        elements_ID = new List<int>();
        elements_ID.Add(id);
    }

    public void AddElement(int _id)
    {
        for (int i = 0; i < elements_ID.Count; i++)
        {
            if (elements_ID[i] > _id)
            {
                elements_ID.Insert(i, _id);
                return;
            }
        }

        elements_ID.Add(_id);
    }

    public string IDToString()
    {
        string str = string.Empty;

        foreach(var id in elements_ID)
        {
            str = $"{str}{id}";
        }

        return str;
    }

    public int Count()
    {
        return elements_ID.Count;
    }
}
