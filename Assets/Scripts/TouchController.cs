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
    [SerializeField] Rigidbody weapon;
    Vector2 startPoint;
    Vector2 endPoint;
    [SerializeField] float maxDis;
    Vector2 dis;

    public void OnBeginDrag(PointerEventData eventData)
    {
    }

    public void OnDrag(PointerEventData eventData)
    {
        endPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dis = endPoint - startPoint;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
    }

    public void OnPointerClick(PointerEventData eventData)
    {

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        startPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        endPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
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
        weapon.AddForce(dis*500);
    }
}
