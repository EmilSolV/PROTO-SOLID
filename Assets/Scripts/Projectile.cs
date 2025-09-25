using UnityEngine;

public class Projectile : MonoBehaviour, IShootable
{
    public float speed = 10f;
    public AudioClip hitSound; // sonido de impacto

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    public void Shoot(Vector3 direction)
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = direction * speed;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Reproducir sonido de impacto
        if (hitSound != null)
        {
            audioSource.PlayOneShot(hitSound);
        }

        Destroy(gameObject, 0.1f); // destruimos con peque�o delay para que se escuche el sonido
    }
}
