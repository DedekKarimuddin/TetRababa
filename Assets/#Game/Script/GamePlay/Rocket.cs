using System.Collections;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private Transform target;
    private bool canBePickedUp = false;

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
        StartCoroutine(TrackTarget());
    }

    IEnumerator TrackTarget()
    {
        float trackingDuration = 2f;
        float elapsed = 0f;

        while (elapsed < trackingDuration)
        {
            if (target != null)
            {
                transform.LookAt(target);
                transform.position += transform.forward * speed * Time.deltaTime;
            }
            elapsed += Time.deltaTime;
            yield return null;
        }

        canBePickedUp = true;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (canBePickedUp && other.gameObject.CompareTag("Player"))
        {
            // Logic to allow pickup and throw back
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
