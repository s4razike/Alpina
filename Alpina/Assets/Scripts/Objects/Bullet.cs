using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float lifetime = 2f;
    private Vector2 direction;
    private bool directionSet = false;

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
}
