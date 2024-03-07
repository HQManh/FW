using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Coloring : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI text;

    public void SetNum(int t)
    {
        text.text = t.ToString();
    }
}
