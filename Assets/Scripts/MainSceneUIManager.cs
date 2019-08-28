using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneUIManager : MonoBehaviour
{
    public void LoadFirstScene()
    {
        SceneManager.LoadScene("SampleScene");
        PlayManager.Instance.gameMode = 1;
    }

    public void LoadSecondScene()
    {
        SceneManager.LoadScene("SampleScene2");
        PlayManager.Instance.gameMode = 2;
    }

    public void LoadMainScene()
    {
        SceneManager.LoadScene("Main");
        PlayManager.Instance.gameMode = 0;
        Time.timeScale = 1f;
    }
}
