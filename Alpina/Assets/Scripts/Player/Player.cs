using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerStats stats;
    public bool hasShield = false;
    private Coroutine shieldCoroutine;

    public void ActivateShield(float duration, int reward)
    {
        if (shieldCoroutine != null) StopCoroutine(shieldCoroutine);
        shieldCoroutine = StartCoroutine(ShieldRoutine(duration, reward));
    }

    private IEnumerator ShieldRoutine(float duration, int reward)
    {
        hasShield = true;
        bool shieldBroken = false;
        float timer = 0f;

        // Aquí puedes activar un efecto visual

        while (timer < duration)
        {
            if (!hasShield)
            {
                shieldBroken = true;
                break;
            }

            timer += Time.deltaTime;
            yield return null;
        }

        hasShield = false;

        // Aquí puedes desactivar el efecto visual

        if (!shieldBroken && stats.Health < stats.MaxHealth)
        {
            stats.Health += reward;
        }
    }

    public void BreakShield()
    {
        hasShield = false;
    }

}
