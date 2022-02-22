using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float moveSpeed;
    public Transform[] patrolSpots;
    private int _randSpot;
    private float _waitTime;

    // Start is called before the first frame update
    void Start()
    {
        _randSpot = Random.Range(0, patrolSpots.Length);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, patrolSpots[_randSpot].position, moveSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, patrolSpots[_randSpot].position) < 0.2f)
        {
            if (!(_waitTime <= 0))
            {
                _waitTime -= Time.deltaTime;
                return;
            }
            _randSpot = Random.Range(0, patrolSpots.Length);
        }
    }
}
