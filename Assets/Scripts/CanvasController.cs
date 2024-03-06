using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    [SerializeField] Button resetButton;

    void Start()
    {
        resetButton.onClick.AddListener(ResetLevel);
    }

    void ResetLevel()
    {
        StageController.Instance.Restart();
    }

    public void OnMusicButton()
    {
        if (GlobalController.IsMusicOn)
        {
            GlobalController.IsMusicOn = false;
            PlayerPrefs.SetInt("IsMusicOn", 0);
        }
    }

    public void OnSoundButton()
    {
        if (GlobalController.IsSoundOn)
        {
            GlobalController.IsSoundOn = false;
            PlayerPrefs.SetInt("IsSoundOn", 0);
        }
    }

}
