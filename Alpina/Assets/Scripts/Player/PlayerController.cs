using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    [Header("Audio Clips")]
    public AudioClip jumpSound;
    private AudioSource audioSource;
    private bool isGrounded = true; // Simple grounded check for example
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("PlayerController requires an AudioSource component on the GameObject.");
        }
    }
    void Update()
    {
        // Jump input: Space key
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            Jump();
        }
       
    }
    void Jump()
    {
        // Play jump sound
        if (jumpSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(jumpSound);
        }
        // Example jump logic (can be replaced by your character controller)
        Debug.Log("Player jumped!");
        isGrounded = false;
        // Simulate landing after 1 second for demo purposes
        Invoke(nameof(Land), 1f);
    }
    void Land()
    {
        isGrounded = true;
        Debug.Log("Player landed.");
    }
    
}
