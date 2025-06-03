using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    [HideInInspector] public bool isShooting = false;
    private bool canShoot = true;
    private SpriteRenderer theSR;
    private Animator anim;
    // Campos para los sonidos
    public AudioClip shootSound; // Sonido de disparo
    private AudioSource audioSource; // Componente AudioSource
    void Start()
    {
        theSR = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>(); // Obtener el componente AudioSource
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && canShoot)
        {
            anim.SetTrigger("IsShooting");
            
        }
    }
     void Shoot()
    {

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
        // Reproducir el sonido de disparo
        if (shootSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(shootSound);
        }
      
        
    }
    public void StopShooting()
    {
        isShooting = false;
        canShoot = true;
    }
}