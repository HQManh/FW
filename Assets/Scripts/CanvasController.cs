using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    public static CanvasController Instance;
    [SerializeField] Button resetButton;
    [SerializeField] CanvasGroup startGroup;
    [SerializeField] CanvasGroup endGroup;
    [SerializeField] Button replayButton;
    [SerializeField] RectTransform cover;

    private void Awake()
    {
        Instance = this;
    }


    void Start()
    {
        resetButton.onClick.AddListener(ResetLevel);
        replayButton.onClick.AddListener(ResetLevel);
    }

    void ResetLevel()
    {
        SceneChange(StageController.Instance.Restart);
    }

    public void OnMusicButton()
    {
        GlobalController.IsMusicOn = !GlobalController.IsMusicOn;
        int t;
        if (GlobalController.IsMusicOn)
        {
            t = 1;
        }
        else t = 0;
        PlayerPrefs.SetInt("IsMusicOn", t);
    }

    public void OnSoundButton()
    {
        GlobalController.IsSoundOn = !GlobalController.IsSoundOn;
        int t;
        if (GlobalController.IsSoundOn)
        {
            t = 1;
        }
        else t = 0;
        PlayerPrefs.SetInt("IsSoundOn", t);
    }

    public void StartPlay()
    {
        LeanTween.alphaCanvas(startGroup, 0f, 0.2f);
        startGroup.blocksRaycasts = false;
        startGroup.interactable = false;
    }

    public void EndPlay()
    {
        LeanTween.alphaCanvas(endGroup, 1f, 0.5f);
        endGroup.blocksRaycasts = true;
        endGroup.interactable = true;
    }

    public void SceneChange(Action callback)
    {
        LeanTween.alpha(cover, 1f, 0.3f).setOnComplete(() =>
        {
            LeanTween.alpha(cover, 0f, 0.3f);
            callback?.Invoke();
        });
    }
}
