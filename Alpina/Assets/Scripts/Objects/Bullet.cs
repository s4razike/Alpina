using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float lifetime = 2f;
    private Vector2 direction;
    private bool directionSet = false;

    public int dano = 10;

    void Start()
    {
        Destroy(gameObject, lifetime); // Destruye la bala después de cierto tiempo
    }

    public void SetDirection(Vector2 dir)
    {
        direction = dir.normalized;
        directionSet = true;
    }

    void Update()
    {
        if (directionSet)
        {
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            // Buscar si tiene un script con la función RecibirDanio
            BossAtackPatern bossAttackPattern = collision.GetComponent<BossAtackPatern>();
            if (bossAttackPattern != null)
            {
                bossAttackPattern.RecibirDanio(dano);
            }

            Destroy(gameObject); // Destruir la bala al impactar
        }
    }
}
