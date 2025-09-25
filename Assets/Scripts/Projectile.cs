using UnityEngine;

public class Projectile : MonoBehaviour, IShootable
{
    public float speed = 10f;
    public AudioClip hitSound;

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
        if (hitSound != null)
        {
            GameObject temp = new GameObject("TempAudio");
            temp.transform.position = transform.position;
            AudioSource audio = temp.AddComponent<AudioSource>();
            audio.PlayOneShot(hitSound);
            Destroy(temp, hitSound.length);
        }

        Destroy(gameObject);
    }
}
