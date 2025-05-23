using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private readonly int moveX = Animator.StringToHash("MoveX");
    private readonly int moveY = Animator.StringToHash("MoveY");
    private readonly int moving = Animator.StringToHash("Moving"); 
    private readonly int dead = Animator.StringToHash("Dead");
    private readonly int revive = Animator.StringToHash("Revive");
    private readonly int attacking = Animator.StringToHash("Attacking");

    public Animator animator;

    private bool hasPlayedDeadAnimation = false; // Control para la animación de Dead

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Método para mostrar la animación de muerte solo una vez
    public void ShowDeadAnimation()
    {
        if (!hasPlayedDeadAnimation) // Solo se ejecuta si no ha sido reproducida
        {
            animator.SetTrigger(dead); // Dispara la animación de Dead
            hasPlayedDeadAnimation = true; // Marca que ya se reprodujo
        }
    }

    public void SetMovingAnimation(bool value)
    {
        animator.SetBool(moving, value); // Cambia entre la animación de movimiento e idle
    }

    public void SetMoveAnimation(Vector2 dir)
    {
        animator.SetFloat(moveX, dir.x);
        animator.SetFloat(moveY, dir.y);
    }

    public void SetAttackAnimation(bool value)
{
    animator.SetBool (attacking, value);
}

    public void ResetPlayer()
    {
        SetMoveAnimation(Vector2.down); // Muestra la animación de idle mirando hacia abajo
        animator.SetTrigger(revive); // Dispara la animación de revive
        hasPlayedDeadAnimation = false; // Resetea el control para que se pueda reproducir la animación de Dead de nuevo
    }
}
