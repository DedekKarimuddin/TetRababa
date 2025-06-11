namespace Game.Skill
{
    using UnityEngine;
    public class EagleStrikeSkill : BaseSkill
    {
        [SerializeField] private GameObject shadowPrefab;
        [SerializeField] private float flyTime = 1f;
        [SerializeField] private float dropDelay = 2f;
        [SerializeField] private float diveSpeed = 10f;
        [SerializeField] private float rotationSpeed = 5f;
        [SerializeField] private bool isDiving = false;
        BossController boss => GameManager.Instance.Boss;

        Vector3 targetPosition;
        GameObject shadowInstance;

        public override void ExecuteAttack(Transform target)
        {
            targetPosition = target.position;

            shadowInstance = Instantiate(shadowPrefab, targetPosition, Quaternion.identity);
            boss.gameObject.transform.position = shadowInstance.transform.position + Vector3.up * 10f;

            isDiving = true;
            Invoke(nameof(StopEagle), duration);
        }

        private void StopEagle()
        {
            Destroy(this.gameObject);

        }

        void DiveTowardTarget()
        {
            Vector3 direction = (targetPosition - boss.transform.position).normalized;

            boss.transform.position += direction * diveSpeed * Time.deltaTime;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            Quaternion targetRotation = Quaternion.Euler(0, 0, angle);
            boss.transform.rotation = Quaternion.Lerp(boss.transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);

            if (Vector3.Distance(boss.transform.position, targetPosition) < 0.5f)
            {
                isDiving = false;
                Destroy(shadowInstance);
            }
        }


        private void Update()
        {
            if (isDiving)
                DiveTowardTarget();
        }
    }

}
