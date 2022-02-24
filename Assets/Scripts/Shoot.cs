using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// PUT THIS SCRIPT ON WEAPON GAME OBJECTS SO THEY SHOOT 

public class Shoot : MonoBehaviour
{
    public GameObject bulletPrefab;

    // COOLDOWN LENGTH BETWEEN SHOTS CAN BE CHANGED IN THE INSPECTOR / BY SCRIPT
    public float cooldownBetweenShots;
    public bool fullAuto;
    private float _lastFired;
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
        if (!fullAuto)
        {
            if (Input.GetButtonDown("Fire1") && attackCD)
            {
                AttackOnce();
            }
        }
        else
        {
            if (Input.GetButton("Fire1") && attackCD)
            {
                StartCoroutine(Spray());
            }
        }
    }

    // ATTACK COOLDOWN HAS TO BE OVER BEFORE THE ATTACK METHOD CAN BE CALLED
    IEnumerator AttackCooldown()
    {
        attackCD = false;
        yield return new WaitForSeconds(cooldownBetweenShots);
        attackCD = true;
    }
    private void AttackOnce()
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
    private IEnumerator Spray()
    {
        attackCD = false;
        Instantiate(bulletPrefab, _barrel.position, _barrel.rotation);
        _anim.SetTrigger("Shoot"); 
        yield return new WaitForSeconds(cooldownBetweenShots);
        attackCD = true;
    }

}
