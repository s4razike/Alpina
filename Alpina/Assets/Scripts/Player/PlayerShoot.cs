using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab; 
    public Transform firePoint;

    private SpriteRenderer theSR;

    void Start()
    {
    theSR = GetComponent<SpriteRenderer>();
    }

     void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

   void Shoot(){
    
    GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
    Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), GetComponent<Collider2D>());

    // Usa el flipX del SpriteRenderer para decidir dirección
    Vector2 direction = theSR.flipX ? Vector2.left : Vector2.right;

    bullet.GetComponent<Bullet>().SetDirection(direction);

    // Voltea visualmente la bala si va a la izquierda
    if (direction == Vector2.left)
    {
        Vector3 scale = bullet.transform.localScale;
        scale.x *= -1;
        bullet.transform.localScale = scale;
    }
}
}
