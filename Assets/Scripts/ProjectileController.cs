using System;
using System.Collections;
using Scripts;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    private bool hasExitedOwner;
    public float lifespanInSeconds = 5f;
    private Rigidbody2D rigidbody2D;
    private Animator animator;
    private static readonly int Explode = Animator.StringToHash("Explode");
    private AudioSource audioSource;
    public AudioClip laserClip, explosionClip;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && hasExitedOwner)
        {
            other.TryGetComponent(out PlayerController playerController);
            playerController.TakeDamage(1);
            rigidbody2D.velocity = Vector2.zero;
            animator.SetTrigger(Explode);
        }
        if (other.CompareTag("Ground"))
        {
            rigidbody2D.velocity = Vector2.zero;
            animator.SetTrigger("Explode");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") &&
            other.gameObject.GetInstanceID() == gameObject.transform.parent.gameObject.GetInstanceID())
        {
            hasExitedOwner = true;
        }
    }

    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.PlayOneShot(laserClip);
        StartCoroutine(ExecuteAfterTime(lifespanInSeconds));
    }
    
    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
 
        rigidbody2D.velocity = Vector2.zero;
        animator.SetTrigger(Explode);
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    public void PlayExplosionSound()
    {
        audioSource.pitch = 3f;
        audioSource.volume = .3f;
        audioSource.PlayOneShot(explosionClip);
        //audioSource.pitch = 1;
    }
}
