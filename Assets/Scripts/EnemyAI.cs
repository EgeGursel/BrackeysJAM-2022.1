using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// EVERYTHING ABOUT ENEMY MOVEMENT IS IN THIS SCRIPT

public class EnemyAI : MonoBehaviour
{
    public LayerMask collidableLayer;
    public float roamMoveSpeed;
    public float agroMoveSpeed;
    public float agroRange;
    private float _moveSpeed;
    private Transform _player;
    private Vector3 _startPos;
    private Vector3 _roamPos;
    private Vector3 _targetPos;
    private Rigidbody2D _rb;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _startPos = transform.position;
        _roamPos = GetRoamPos();
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, _player.position) < agroRange)
        {
            _moveSpeed = agroMoveSpeed;
            _targetPos = _player.position;
        }
        else
        {
            _moveSpeed = roamMoveSpeed;
            _targetPos = _roamPos;
            if (Vector2.Distance(transform.position, _roamPos) < 0.2f)
            {
                _roamPos = GetRoamPos();
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, _targetPos, _moveSpeed * Time.deltaTime);

        Vector3 diff = (_targetPos - transform.position).normalized;
        float rotationZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
    }

    private Vector3 GetRoamPos()
    {
        return _startPos + new Vector3(Random.Range(-1, 1), Random.Range(-1, 1)).normalized * Random.Range(3, 8);
    }
}
