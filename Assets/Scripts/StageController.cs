using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class StageController : MonoBehaviour
{
    public static StageController Instance { get; set; }

    public bool IsWaitingForSkinOptions;

    private void Awake()
    {
        Instance = this;
    }


    public void Restart()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }
}
