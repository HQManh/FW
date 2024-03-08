using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowe : MonoBehaviour
{
    [SerializeField]
    Transform target;
    Vector3 velocity = Vector3.zero;
    [Range(0, 1)]
    public float smoothTime;
    [SerializeField]
    Vector2 xLimit;
    [SerializeField]
    Vector2 yLimit;
    float size;
    float ratio;
    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        size = cam.orthographicSize;
        ratio = size / (float)Screen.currentResolution.height * (float)Screen.currentResolution.width;
        cam.transform.position = target.position + new Vector3(0f, 0f, -10f);
        GetRestrict();
    }

    private void FixedUpdate()
    {
        Vector3 targetPos = target.position;
        targetPos = new Vector3(Mathf.Clamp(targetPos.x, xLimit.x, yLimit.x), Mathf.Clamp(targetPos.y, xLimit.y, yLimit.y), -10f);
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);
    }

    void GetRestrict()
    {
        var temp = GameObject.FindGameObjectsWithTag("RetrictCam");
        xLimit = temp[0].transform.position;
        yLimit = temp[1].transform.position;
        if(xLimit.x > yLimit.x)
        {
            (xLimit,yLimit) = (yLimit,xLimit);
        }
        xLimit = new(xLimit.x + ratio, xLimit.y + size);
        yLimit = new(yLimit.x -ratio,yLimit.y - size);
        if (xLimit.x > yLimit.x)
        {
            (yLimit.x, xLimit.x) = (xLimit.x, yLimit.x);
        }
    }
}
