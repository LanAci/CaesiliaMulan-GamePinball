using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class BumperController : MonoBehaviour
{
    public Collider bola;

    public float multiplier;

    public Color color;

    private Renderer pog;

    private Animator animator;

    public AudioManager audioManager;

    public VFXManager VFXManager;

    public ScoreManager scoreManager;

    public float score;

    private void Start()
    {
        pog = GetComponent<Renderer>();

        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider == bola)
        {
            Rigidbody bolaRig = bola.GetComponent<Rigidbody>();
            bolaRig.velocity *= multiplier;

            Debug.Log("jder");

            animator.SetTrigger("Hit");

            audioManager.PlaySFX(collision.transform.position);

            VFXManager.PlayVFX(collision.transform.position);

            scoreManager.AddScore(score);
        }

    }

    private void Update()
    {
        pog.material.color = color;

    }
}
