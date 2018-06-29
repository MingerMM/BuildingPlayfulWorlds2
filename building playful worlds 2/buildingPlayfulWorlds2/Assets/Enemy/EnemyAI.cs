using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyAI : MonoBehaviour {

    public Transform[] patrolPoints;
    public float speed;

    Transform currentPatrolPoint;
    int currentPatrolIndex;

    public Transform target;
    public float chaseRange;
    float distanceToTarget;
    float animationRange;

    public Animator anim;

    public float deathRange;

    void Start () {
        currentPatrolIndex = 0;
        currentPatrolPoint = patrolPoints[currentPatrolIndex];
        //transform.Rotate(Vector3(0f, 0f, 180f));
	}
	
	void Update () {

        //check afstand om te kijken of kan gaan chasen
        distanceToTarget = Vector3.Distance(transform.position, target.position);

        if (distanceToTarget < chaseRange)
        {

            //chase
            Vector3 targetDirection = target.position - transform.position;
            float angleChase = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg - 90f; //hoek
            Quaternion quat = Quaternion.AngleAxis(angleChase, Vector3.forward);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, quat, 180f);  //rotation
            transform.Translate(Vector3.up * Time.deltaTime * speed);   //draai

            anim.SetFloat("animationRange", 1);

        }

        else
        {
            transform.Translate(Vector3.down * Time.deltaTime * speed);
            //check on te kijken of eerste waypoint bereikt heeft.
            if (Vector3.Distance(transform.position, currentPatrolPoint.position) < .1f)
            {
                if (currentPatrolIndex + 1 < patrolPoints.Length)
                {
                    currentPatrolIndex++;
                }
                else
                {
                    currentPatrolIndex = 0;
                }
                currentPatrolPoint = patrolPoints[currentPatrolIndex];
            }

            Vector3 patrolPointDir = currentPatrolPoint.position - transform.position;
            //zorgt dat enemy draait in richting van lopen
            float angle = Mathf.Atan2(patrolPointDir.y, patrolPointDir.x) * Mathf.Rad2Deg + 90f;

            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 180f);

        }

       if (distanceToTarget < deathRange)
        {
            SceneManager.LoadScene("gameovermenu");
        } 
	}
}
