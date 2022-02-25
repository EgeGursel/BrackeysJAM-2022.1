using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
THIS SCRIPT IS FOR THE BULLET PREFAB TO GO FORWARD WHEN INSTANTIATED AND THEN DESTROY ON IMPACT
ALSO DAMAGE ANY COLLIDED ENEMIES BY ACCESING THEIR <Enemy> SCRIPT
*/

public class Bullet : MonoBehaviour
{
    // REFERENCES
    public int speed;
    public float critChance;
    public int attackDamage; // THE VALUE CAN BE CHANGED VIA REFERENCING IT FROM ANOTHER SCRIPT OR THROUGH THE EDITOR
    private int _attackDamage;
    public ParticleSystem impactPS; // REFERENCE TO THE PARTICLE SYSTEM THAT WILL BE INSTANTIATED WHEN THE BULLET COLLIDES WITH SOMETHING
    private Rigidbody2D _rb; // REFERENCE TO THE BULLET'S RIGIDBODY SO IT CAN MOVE

    void Start()
    {
        // GIVING VALUES TO THE REFERENCES ABOVE
        _rb = GetComponent<Rigidbody2D>();
        // MOVING THE BULLET'S RIGIDBODY2D FORWARD ON START
        _rb.velocity = transform.right * speed;
        _attackDamage = attackDamage;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            float randValue = Random.value;
            if (randValue <= 1 - critChance)
            {
                attackDamage = _attackDamage;
                collision.GetComponent<Enemy>().Damage(attackDamage, Color.yellow);
            }
            else
            {
                attackDamage = _attackDamage * 2;
                collision.GetComponent<Enemy>().Damage(attackDamage, Color.red);
            }
        }
        // INSTANTIATE THE IMPACT PARTICLE SYSTEM ON IMPACT POSITION
        Instantiate(impactPS, transform.position, transform.rotation);

        // PLAYING THE AUDIO WHEN THE BULLET COLLIDES WITH SOMETHING (no sound yet so it's commented out)
        // AudioManager.instance.Play("projectilehit"); 

        // DESTROY THE BULLET AND SHAKE THE CAMERA ON IMPACT
        // CameraShake.Instance.Shake(1, .2f);
        Destroy(gameObject);
    }
}
