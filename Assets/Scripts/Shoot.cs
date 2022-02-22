using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    private Transform _barrel;
    private Animator _anim;
    private bool attackCD = true;
    void Start()
    {
        _anim = GetComponent<Animator>();
        _barrel = transform.Find("Barrel");
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
        }
    }
    IEnumerator AttackCooldown()
    {
        attackCD = false;
        yield return new WaitForSeconds(0.4f);
        attackCD = true;
    }
    private void Attack()
    {
        // ATTACK
        if (attackCD)
        {
            // AudioManager.instance.Play("rangedattack");
            Instantiate(bulletPrefab, _barrel.position, _barrel.rotation);
            _anim.SetTrigger("Shoot");
            StartCoroutine(AttackCooldown());
        }
    }
}
