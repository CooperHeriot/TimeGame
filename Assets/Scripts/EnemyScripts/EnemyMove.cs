using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    public float speed = 1;

    private NavMeshAgent NM;

    private EnemyShoot ES;
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        NM = GetComponent<NavMeshAgent>();

        ES = GetComponent<EnemyShoot>();

       // target = ES.target;
    }

    // Update is called once per frame
    void Update()
    {
        target = ES.target;

        NM.SetDestination(target.transform.position);

        NM.speed = speed;
    }
}
