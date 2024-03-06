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
}
