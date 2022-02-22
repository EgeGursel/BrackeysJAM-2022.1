using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int attackDamage;
    public ParticleSystem impactPS;
    private Rigidbody2D rb;
    private LayerMask _enemyLayer;
    void Start()
    {
        _enemyLayer = LayerMask.GetMask("Enemy");
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * 25;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.IsTouchingLayers(_enemyLayer))
        {
            // collision.GetComponent<Enemy>().Damage(attackDamage);
            Destroy(gameObject);
        }
        Instantiate(impactPS, transform.position, transform.rotation);
        // AudioManager.instance.Play("projectilehit");
        CameraShake.Instance.Shake(1, .2f);
        Destroy(gameObject);
    }
}
