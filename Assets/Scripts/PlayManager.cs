using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayManager : MonoBehaviour
{
    public static PlayManager Instance { get; set; } = null;

    public GameObject[] elementPrefabs;

    float min_X = -2.5f;
    float max_X = 2.5f;
    float min_Y = -3f;
    float max_Y = 3f;

    float pos_Offset = -1.5f;

    float elementSize = 0.5f;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        GameStart();
    }

    public void GameStart()
    {
        StartCoroutine(SpawnElementRoutine());
        StartCoroutine(HPRoutine());
    }

    public void GameStop()
    {
        StopAllCoroutines();
        UIManager.Instance.GameOver();
    }

    IEnumerator SpawnElementRoutine()
    {
        while (true)
        {
            float regenCoolDown = 1f / SettingManager.regenSpd;
            int randInt = (int)Random.Range(0f, elementPrefabs.Length - 0.01f);

            RespawnElement(elementPrefabs[randInt]);

            yield return new WaitForSeconds(regenCoolDown);
        }
    }

    void RespawnElement(GameObject element)
    {
        Vector2 spawnPos = new Vector2(Random.Range(min_X, max_X), Random.Range(min_Y, max_Y) + pos_Offset);
        while (!CheckPos(spawnPos))
        {
            spawnPos = new Vector2(Random.Range(min_X, max_X), Random.Range(min_Y, max_Y) + pos_Offset);
        }

        Element temp = Instantiate(element, spawnPos, Quaternion.identity).GetComponent<Element>();
        temp.transform.localScale = new Vector3(elementSize, elementSize, 1f);
        temp.Init_Element();
    }

    bool CheckPos(Vector2 vec)
    {
        if (Physics2D.OverlapBox(vec, new Vector2(SettingManager.elementSize * 1.5f, SettingManager.elementSize * 1.5f), 0f) == null) return true;
        return false;
    }

    private float hp;
    public float HP {
        get
        {
            return hp;
        }

        set
        {
            hp = value;
            if (hp > max_HP) hp = max_HP;

            UIManager.Instance.HPUpdate(hp / max_HP);
        }
    }


    const float max_HP = 100f;

    IEnumerator HPRoutine()
    {
        HP = max_HP;

        while(hp > 0f)
        {
            HP -= SettingManager.hpDecrease;

            yield return new WaitForSeconds(1f);
        }

        GameStop();
    }

}
