using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Humanoid
{
    [SerializeField] bool isMove;
    [SerializeField] Animator animator;
    [SerializeField] List<Rigidbody> rigidbodies;
    [SerializeField] List<Collider> colliders;
    [SerializeField] List<Joint> joints;
    [SerializeField] Collider mainCo;
    [SerializeField] Rigidbody mainRi;
    [SerializeField] Material deadM;
    [SerializeField] Vector2 line;
    [SerializeField] float speed;
    Vector3 startPoint;

    private void Awake()
    {
        startPoint = transform.position;
    }

    private void Start()
    {
        if (isMove)
        {
            animator.SetTrigger("IsMove");
            animator.Play("Moving");
            Moving();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
        {
            if (!isDead)
            {
                isDead = true;
                SwitchMode(true);
            }
        }  
    }

    void SwitchMode(bool isDynamic)
    {
        animator.enabled = !isDynamic;
        mainCo.enabled = !isDynamic;
        mainRi.isKinematic = isDynamic;
        foreach(Collider collider in colliders)
        {
            collider.enabled = isDynamic;
        }
        foreach(Rigidbody rigidbody in rigidbodies)
        {
            rigidbody.isKinematic = !isDynamic;
        }
        Dead();
    }

    void Dead()
    {
        var t = GetComponentsInChildren<SkinnedMeshRenderer>();
        foreach(SkinnedMeshRenderer skinnedMesh in t)
        {
            skinnedMesh.material = deadM;
        }
        LeanTween.cancel(gameObject);
        EnemyTracking.Instance.OnDeath();
    }

    void Moving()
    {
        LeanTween.move(gameObject, Vector3.right * line.x + startPoint, 0.5f).setSpeed(speed).setOnComplete(() =>
        {
            gameObject.transform.rotation = Quaternion.Euler(0f,-90f,0f);
            LeanTween.move(gameObject, Vector3.right * line.y + startPoint, 5f).setSpeed(speed).setOnComplete(() =>
            {
                gameObject.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
                    Moving();
                });
            });
        }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(Vector3.right * line.x + transform.position,Vector3.right * line.y + transform.position);
    }
}
