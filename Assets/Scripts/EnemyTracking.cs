using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyTracking : MonoBehaviour
{
    public static EnemyTracking Instance;
    int numOfEnemy;
    [SerializeField] Image enemyUI;
    List<Image> enemyImages = new();
    [SerializeField] Sprite deathUI;
    [SerializeField] AudioClip deathAudio;

    private void Awake()
    {
        Instance = this;
        numOfEnemy = GameObject.FindObjectsOfType<Enemy>().Length;
        SetUp();
    }
    
    void SetUp()
    {
        for(int  i = 0; i < numOfEnemy;i++)
        {
            var temp = Instantiate(enemyUI, transform);
            enemyImages.Add(temp);
        }
    }

    public void OnDeath()
    {
        enemyImages[^numOfEnemy].sprite = deathUI;
        numOfEnemy --;
        if(numOfEnemy == 0)
        {
            CanvasController.Instance.EndPlay();
        }
    }
}
