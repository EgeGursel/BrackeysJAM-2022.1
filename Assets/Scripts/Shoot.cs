using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// PUT THIS SCRIPT ON WEAPON GAME OBJECTS SO THEY SHOOT 

public class Shoot : MonoBehaviour
{
    public GameObject bulletPrefab;

    // COOLDOWN LENGTH BETWEEN SHOTS CAN BE CHANGED IN THE INSPECTOR / BY SCRIPT
    public float cooldown;
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

    // ATTACK COOLDOWN HAS TO BE OVER BEFORE THE ATTACK METHOD CAN BE CALLED
    IEnumerator AttackCooldown()
    {
        attackCD = false;
        yield return new WaitForSeconds(cooldown);
        attackCD = true;
    }
    private void Attack()
    {
        // ONLY ATTACK IF COOLDOWN IS OVER
        if (!attackCD) return;
        {
            // PLAY WEAPON SHOT SOUND (NOT IMPLEMENTED YET SO COMMENTED OUT)
            // AudioManager.instance.Play("rangedattack");

            /* 
            INSTANTIATE BULLET, 
            SET ITS POSITION AND ROTATION IN ACCORDANCE TO THE BARREL OBJECT 
            ANIMATE THE WEAPON, START THE WEAPON COOLDOWN
            */
            Instantiate(bulletPrefab, _barrel.position, _barrel.rotation);
            _anim.SetTrigger("Shoot");
            StartCoroutine(AttackCooldown());
        }
    }
}
