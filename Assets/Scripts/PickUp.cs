using UnityEngine;

public class Pickup : MonoBehaviour
{
    public AudioClip pickupSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            AudioSource.PlayClipAtPoint(pickupSound, transform.position);
            GameManager.instance.AddScore(1);
            Destroy(gameObject);
        }
    }
}
