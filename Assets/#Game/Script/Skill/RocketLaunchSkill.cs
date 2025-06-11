namespace Game.Skill
{
    using UnityEngine;

    public class RocketLaunchSkill : BaseSkill
    {
        [SerializeField] private GameObject rocketPrefab;
        [SerializeField] private float trackingTime = 2f;
     
        BossController boss => GameManager.Instance.Boss;
        private Transform currentTarget;

        public override void ExecuteAttack(Transform target)
        {
            currentTarget = target;
            Invoke(nameof(LaunchRockets), trackingTime);
            Invoke(nameof(StopRocket), duration);
        }
        private void StopRocket()
        {
            Destroy(this.gameObject);

        }

        private void LaunchRockets()
        {
            for (int i = 0; i < 3; i++)
            {
                GameObject rocket = Instantiate(rocketPrefab,   boss.FirePoint.position, Quaternion.identity);
                RocketBehavior rb = rocket.GetComponent<RocketBehavior>();
                rb.target = currentTarget;
                rb.isThrowable = (i == 2); 
            }
        }
    }

}
