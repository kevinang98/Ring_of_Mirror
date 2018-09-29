using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KuntiAI : MonoBehaviour
{

    public Transform[] patrolPoints;
    public float speed;
    Transform currentPatrolPoint;
    public bool canMove;
    Transform target;
    public float range;
    Animator animate;

    void Start()
    {
        animate = GetComponent<Animator>();
        animate.SetBool("Detected", false);
        target = GameObject.FindGameObjectWithTag("Player").transform;
        currentPatrolPoint = FindObjectOfType<SpawnKuntilanak>().currentPatrolPoints;
    }

    void Update()
    {
        canMove = FindObjectOfType<Movement>().canWalk;

        if (!canMove)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            return;
        }

        transform.Translate(Vector3.right * Time.deltaTime * speed);
        if (Vector3.Distance(transform.position, currentPatrolPoint.position) < .1f)
        {
            if (FindObjectOfType<SpawnKuntilanak>().currentPatrolIndexs + 1 < patrolPoints.Length)
            {
                FindObjectOfType<SpawnKuntilanak>().currentPatrolIndexs++;
            }
            else
            {
                FindObjectOfType<SpawnKuntilanak>().currentPatrolIndexs = 0;
            }
            currentPatrolPoint = FindObjectOfType<SpawnKuntilanak>().currentPatrolPoints;
        }
        Vector3 patrolPointDir = currentPatrolPoint.position - transform.position;
        float anglePatrol = Mathf.Atan2(patrolPointDir.y, patrolPointDir.x) * Mathf.Rad2Deg - 360f;

        Quaternion q = Quaternion.AngleAxis(anglePatrol, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 180f);

        float distanceTarget = Vector3.Distance(transform.position, target.position);

        if(distanceTarget < range && FindObjectOfType<Movement>().hide == false)
        {
            animate.SetBool("Detected", true);
            Vector3 targetDir = target.position - transform.position;
            float angleChase = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg - 360f;
            Quaternion c = Quaternion.AngleAxis(angleChase, Vector3.forward);
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }else if(distanceTarget > range || FindObjectOfType<Movement>().hide == true)
        {
            animate.SetBool("Detected", false);
        }
    }
}