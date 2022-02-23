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
    public GameObject damagePopup;
    public ParticleSystem hurtPS;
    private Animator _anim;
    private DamagePopup _damagePopup;

    // ATTACK
    private float curTime = 0;
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
        _damagePopup = damagePopup.GetComponent<DamagePopup>();
    }

    // TAKE DAMAGE
    public void Damage(int damage)
    {
        _currHP -= damage;
        _damagePopup.damage = damage;
        Vector3 popupRot = new Vector3(0, 0, Random.Range(15, -15));
        Instantiate(damagePopup, transform.position, Quaternion.Euler(popupRot));
        if (_currHP <= 0)
        {
            Die();
            return;
        }
        _anim.SetTrigger("Hurt");
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
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (curTime <= 0)
            {
                _playerHealth.TakeDamage(attackDamage);
                curTime = 0.6f;
            }
            else
            {
                curTime -= Time.deltaTime;
            }
        }
    }
}
