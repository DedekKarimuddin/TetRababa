namespace Game.Skill
{

    using UnityEngine;

    public class RocketBehavior : MonoBehaviour
    {
        public Transform target;
        public float speed = 10f;
        public bool isThrowable = false;
        public GameObject explosionEffect;

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
            if (!isReturning && !isThrowable)
            {
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