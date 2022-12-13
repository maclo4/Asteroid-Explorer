using System.Collections;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    private bool hasExitedOwner;
    public float lifespanInSeconds = 5f;
    private Rigidbody2D rigidbody2D;
    private Animator animator;
    [SerializeField] public BoxCollider2D boxCollider2D, boxTriggerCollider2D;
    private static readonly int Explode = Animator.StringToHash("Explode");
    private AudioSource audioSource;
    public AudioClip laserClip, explosionClip;
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && hasExitedOwner)
        {
            other.TryGetComponent(out PlayerController playerController);
            playerController.TakeDamage(1);
            animator.SetTrigger(Explode);
        }
        if (other.CompareTag("Ground"))
        {
            animator.SetTrigger(Explode);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") &&
            other.gameObject.GetInstanceID() == gameObject.transform.parent.gameObject.GetInstanceID())
        {
            Physics2D.IgnoreCollision(boxCollider2D, other, false);
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
    }

    public void DisableCollisionBox()
    {
        rigidbody2D.velocity = Vector2.zero;
        boxCollider2D.enabled = false;
        boxTriggerCollider2D.enabled = false;
    }
}
