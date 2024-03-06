using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchController : Singleton<TouchController>,
    IPointerDownHandler,
    IPointerClickHandler,
    IPointerUpHandler,
    IDragHandler,
    IBeginDragHandler,
    IEndDragHandler
{
    [SerializeField] Transform direction;
    [SerializeField] Rigidbody weapon;
    [SerializeField] float power;
    Vector2 startPoint;
    Vector2 endPoint;
    [SerializeField] float maxDis;
    Vector2 dis;
    float fixDT;

    private void Start()
    {
        fixDT = Time.fixedDeltaTime;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
    }

    public void OnDrag(PointerEventData eventData)
    {
        direction.gameObject.SetActive(true);
        direction.position = weapon.position;
        Time.timeScale = 0.1f;
        Time.fixedDeltaTime *= 0.1f;
        endPoint = Input.mousePosition;
        dis = endPoint - startPoint;
        var te = Vector2.SignedAngle(Vector2.right, dis);
        direction.rotation = Quaternion.Euler(0f, 0f, te);
        var t = dis.magnitude;
        if(t > maxDis)
        {
            direction.localScale = Vector3.one;
        }
        else
        {
            direction.localScale = Vector3.one / maxDis * t;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        startPoint = Input.mousePosition;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        direction.gameObject.SetActive(false);
        Time.timeScale = 1f;
        Time.fixedDeltaTime = fixDT;
        endPoint = Input.mousePosition;
        dis = endPoint - startPoint;
        float t = dis.magnitude;
        if (t > maxDis)
        {
            dis = dis / t * maxDis;
        }
        var te = Vector2.SignedAngle(Vector2.up, dis);
        weapon.rotation = Quaternion.Euler(0f, 0f, te);
        weapon.velocity = Vector3.zero;
        weapon.angularVelocity = Vector3.zero;
        weapon.AddForce(dis*power);
    }
}
