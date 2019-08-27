using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; set; } = null;

    private void Awake()
    {
        Instance = this;
    }

    public Image hp_Image;

    public void HPUpdate(float fillAmount)
    {
        hp_Image.fillAmount = fillAmount;
    }

    public GameObject[] SetList;
    public GameObject SettingCanvas;

    public void SettingClicked()
    {
        SettingCanvas.SetActive(true);

        foreach(var s in SetList)
        {
            switch(s.name)
            {
                case "RegenSpd":
                    s.transform.GetChild(0).GetComponent<InputField>().text = SettingManager.regenSpd.ToString();
                    break;
                case "DeactivateTime":
                    s.transform.GetChild(0).GetComponent<InputField>().text = SettingManager.deactivateTime.ToString();
                    break;
                case "FlyingTime":
                    s.transform.GetChild(0).GetComponent<InputField>().text = SettingManager.flyingTime.ToString();
                    break;
                case "FlyingSpd":
                    s.transform.GetChild(0).GetComponent<InputField>().text = SettingManager.flyingSpd.ToString();
                    break;
                case "ElementSize":
                    s.transform.GetChild(0).GetComponent<InputField>().text = SettingManager.elementSize.ToString();
                    break;
                case "HPDecrease":
                    s.transform.GetChild(0).GetComponent<InputField>().text = SettingManager.hpDecrease.ToString();
                    break;
            }
        }
        
        Time.timeScale = 0f;
    }

    public void SettingApplied()
    {
        SettingCanvas.SetActive(false);

        foreach (var s in SetList)
        {
            switch (s.name)
            {
                case "RegenSpd":
                    SettingManager.regenSpd = float.Parse(s.transform.GetChild(0).GetComponent<InputField>().text);
                    break;
                case "DeactivateTime":
                    SettingManager.deactivateTime = float.Parse(s.transform.GetChild(0).GetComponent<InputField>().text);
                    break;
                case "FlyingTime":
                    SettingManager.flyingTime = float.Parse(s.transform.GetChild(0).GetComponent<InputField>().text);
                    break;
                case "FlyingSpd":
                    SettingManager.flyingSpd = float.Parse(s.transform.GetChild(0).GetComponent<InputField>().text);
                    break;
                case "ElementSize":
                    SettingManager.elementSize = float.Parse(s.transform.GetChild(0).GetComponent<InputField>().text);
                    break;
                case "HPDecrease":
                    SettingManager.hpDecrease = float.Parse(s.transform.GetChild(0).GetComponent<InputField>().text);
                    break;
            }
        }

        Time.timeScale = 1f;
    }

    public void ResetButtonClicked()
    {
        SettingManager.Init_Setting();

        foreach (var s in SetList)
        {
            switch (s.name)
            {
                case "RegenSpd":
                    s.transform.GetChild(0).GetComponent<InputField>().text = SettingManager.regenSpd.ToString();
                    break;
                case "DeactivateTime":
                    s.transform.GetChild(0).GetComponent<InputField>().text = SettingManager.deactivateTime.ToString();
                    break;
                case "FlyingTime":
                    s.transform.GetChild(0).GetComponent<InputField>().text = SettingManager.flyingTime.ToString();
                    break;
                case "FlyingSpd":
                    s.transform.GetChild(0).GetComponent<InputField>().text = SettingManager.flyingSpd.ToString();
                    break;
                case "ElementSize":
                    s.transform.GetChild(0).GetComponent<InputField>().text = SettingManager.elementSize.ToString();
                    break;
                case "HPDecrease":
                    s.transform.GetChild(0).GetComponent<InputField>().text = SettingManager.hpDecrease.ToString();
                    break;
            }
        }
    }

    public void RestartButtonClicked()
    {
        GameOverCanvas.SetActive(false);
        PlayManager.Instance.GameStart();
        //SettingManager.Init_Setting();
    }

    public GameObject GameOverCanvas;

    public void GameOver()
    {
        GameOverCanvas.SetActive(true);
    }
}
