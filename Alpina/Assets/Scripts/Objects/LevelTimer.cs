using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTimer : MonoBehaviour
{
    private float timer = 0f;
    private bool levelEnded = false;

    void Update()
    {
        if (!levelEnded)
        {
            timer += Time.deltaTime;
        }

        
        if (Input.GetKeyDown(KeyCode.T) && !levelEnded)
        {
            levelEnded = true;
            Debug.Log("¡Nivel completado! Tiempo: " + timer.ToString("F2") + " segundos");
        }
    }
}
