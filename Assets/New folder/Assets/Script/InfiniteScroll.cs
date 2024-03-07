using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Pool;
using UnityEngine.UI;

public class Infinite : MonoBehaviour, IEndDragHandler, IDragHandler
{
    [SerializeField] ScrollRect scrollRect;
    [SerializeField] Coloring poolObject;
    [SerializeField] int amount;
    [SerializeField] int max;
    [SerializeField] float spacing;
    [SerializeField] Vector2 boundDown;
    [SerializeField] Vector2 boundUp;
    [SerializeField] RectTransform lastItem;
    [SerializeField] RectTransform firstItem;
    int currentNum;
    bool isUp;
    [SerializeField]
    List<Coloring> pooledObject = new();
    RectTransform content;


    private void Awake()
    {
        Application.targetFrameRate = 60;
        content = scrollRect.content;
        PoolObject();
    }

    private void Start()
    {
        lastItem = content.GetChild(scrollRect.content.childCount - 1).GetComponent<RectTransform>();
        firstItem = content.GetChild(0).GetComponent<RectTransform>();
    }

    public void Check()
    {
        if(lastItem.transform.position.y >= boundUp.y && currentNum <= max)
        {
            isUp = false;
        }
        else
        {
            isUp = true;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (isUp)
        {
            UpdateScrollUp();
        }
        else UpdateScrollDown();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isUp)
        {
            UpdateScrollUp();
        }
        else UpdateScrollDown();
    }

    void UpdateScrollDown()
    {
        for(int i=0;i< amount; i++)
        {
            var t = pooledObject[0].GetComponent<RectTransform>();
            if (t.transform.position.y >= boundDown.x && currentNum <= max)
            {
                t.transform.localPosition = lastItem.transform.localPosition + new Vector3(0f, -spacing * (i + 1), 0f);
                pooledObject[0].SetNum(currentNum);
                t.SetAsLastSibling();
                currentNum++;
                pooledObject.RemoveAt(0);
                pooledObject.Add(t.GetComponent<Coloring>());
            }
            else
            {
                lastItem = content.GetChild(scrollRect.content.childCount - 1).GetComponent<RectTransform>();
                firstItem = content.GetChild(0).GetComponent<RectTransform>();
                return;
            }
        }
    }

    void UpdateScrollUp()
    {
        int a = 1;
        for(int i= amount - 1; i >= 0; i--)
        {
            var t = pooledObject[amount-1].GetComponent<RectTransform>();
            if(t.transform.position.y <= boundUp.x)
            {
                t.transform.localPosition = firstItem.transform.localPosition + new Vector3(0f,spacing * a, 0f);
                a++;
                pooledObject[amount - 1].SetNum(currentNum-amount);
                t.SetAsFirstSibling();
                currentNum--;
                pooledObject.RemoveAt(amount - i);
                pooledObject.Insert(0, t.GetComponent<Coloring>());
            }
            else
            {
                firstItem = content.GetChild(0).GetComponent<RectTransform>();
                lastItem = content.GetChild(scrollRect.content.childCount - 1).GetComponent<RectTransform>();
                return;
            }
        }
    }

    void PoolObject()
    {
        for (int i = 0; i < amount; i++)
        {
            var t = Instantiate(poolObject, content);
            var rect= t.GetComponent<RectTransform>();
            rect.localPosition = new Vector3(rect.localPosition.x,rect.localPosition.y+ -spacing * i,0f);
            t.SetNum(currentNum);
            currentNum++;
            pooledObject.Add(t);
        }
    }
}
