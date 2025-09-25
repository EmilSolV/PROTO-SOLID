using UnityEngine;

public class Shooter : MonoBehaviour, IWeapon
{
    public Transform firePoint;
    public GameObject projectilePrefab;
    public AudioClip shootSound;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    public void Fire()
    {
        if (projectilePrefab == null || firePoint == null) return;

        GameObject obj = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

        Collider projectileCollider = obj.GetComponent<Collider>();
        Collider[] collidersToIgnore = GetComponentsInChildren<Collider>();
        foreach (Collider c in collidersToIgnore)
        {
            Physics.IgnoreCollision(projectileCollider, c);
        }

        IShootable shootable = obj.GetComponent<IShootable>();
        shootable?.Shoot(firePoint.forward);

        if (shootSound != null)
        {
            audioSource.PlayOneShot(shootSound);
        }
    }
}
