using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
PUT THIS SCRIPT ON ENEMY GAME OBJECTS FOR THEM TO TAKE DAMAGE, ATTACK PLAYER & DIE
*/

public class Enemy : MonoBehaviour
{
    // HEALTH
    public int maxHP;
    private int _currHP;

    // VISUALS
    public ParticleSystem hurtPS;
    private Animator _anim;

    // ATTACK
    public int attackDamage = 20;
    private PlayerHealth _playerHealth;

    // DROP
    public Transform dropPrefab;

    // Start is called before the first frame update
    // GIVING VALUES TO REFERENCES ABOVE
    void Start()
    {
        _currHP = maxHP;
        _anim = GetComponent<Animator>();
        _playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    // TAKE DAMAGE
    public void Damage(int damage)
    {
        _currHP -= damage;
        if (_currHP <= 0)
        {
            Die();
            return;
        }
        _anim.SetTrigger("Damaged");
    }

    // DIE (CALLED IN THE DAMAGE METHOD WHEN CURRENT HP IS LESS THAN OR EQUAL TO 0)
    public void Die()
    {
        // INSTANTIATE PARTICLE SYSTEM
        Instantiate(hurtPS, transform.position, transform.rotation);

        // PLAY DEATH SOUND & DROP ITEM (NOT IMPLEMENTED YET SO COMMENTED OUT)
        // AudioManager.instance.Play("enemydeath");
        // Instantiate(dropPrefab, transform.position, transform.rotation);

        // DESTROY THE ENEMY
        Destroy(gameObject);
    }

    // CHECK COLLIDED OBJECT TAG ON COLLISION AND DAMAGE IT IF IT'S THE PLAYER
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _playerHealth.TakeDamage(attackDamage);
        }
        return;
    }
}
