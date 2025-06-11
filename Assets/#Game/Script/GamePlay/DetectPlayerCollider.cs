using UnityEngine;

public class DetectPlayerCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            PlayerController player = collider.gameObject.GetComponent<PlayerController>();
            
            if (player != null)
                player.TakeDamage();
        }
    }
}
