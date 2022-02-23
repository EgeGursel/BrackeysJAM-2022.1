using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public ParticleSystem hurtPS;
    public int maxHP;
    private int _currHP;
    private Animator _anim;

    // Start is called before the first frame update
    void Start()
    {
        _currHP = maxHP;
        _anim = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        _currHP -= damage;
        Debug.Log("Player HP: " + _currHP);
        if (_currHP <= 0)
        {
            Die();
            return;
        }
        CameraShake.Instance.Shake(1.1f, .2f);
        _anim.SetTrigger("Hurt");
    }
    private void Die()
    {
        // INSTANTIATE PARTICLE SYSTEM
        Instantiate(hurtPS, transform.position, transform.rotation);

        // PLAY DEATH SOUND
        // AudioManager.instance.Play("playerdeath");

        // DESTROY PLAYER
        gameObject.SetActive(false);
    }

}
