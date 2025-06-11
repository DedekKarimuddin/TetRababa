namespace Game.Skill
{

    using UnityEngine;

    public class RocketBehavior : MonoBehaviour
    {
        [SerializeField] private float speed = 10f;
        [SerializeField] private GameObject explosionEffect;

        public Transform target { get; set; }
        public bool isThrowable { get; set; }

        private bool isReturning = false;

        void Update()
        {
            if (target != null && !isReturning)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }
        }

        void OnTriggerEnter(Collider other)
        {
            if (!isReturning && !isThrowable && other.gameObject.CompareTag("Player"))
            {
                PlayerController player = other.gameObject.GetComponent<PlayerController>();

                if (player != null)
                    player.TakeDamage();
                Explode();

            }
        }

        public void ReturnToSender(Transform boss)
        {
            isReturning = true;
            target = boss;
        }

        private void Explode()
        {
            if (explosionEffect != null)
                Instantiate(explosionEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

}