namespace Game.Skill
{
    using UnityEngine;

    public class RocketLaunchSkill : BaseSkill
    {
        [SerializeField] private GameObject rocketPrefab;
        [SerializeField] private float trackingTime = 2f;
        [SerializeField] private Transform rocketLaunchPoint;

        private Transform currentTarget;

        public override void ExecuteAttack(Transform target)
        {
            currentTarget = target;
            Invoke(nameof(LaunchRockets), trackingTime);
        }

        private void LaunchRockets()
        {
            for (int i = 0; i < 3; i++)
            {
                GameObject rocket = Instantiate(rocketPrefab, rocketLaunchPoint.position, Quaternion.identity);
                RocketBehavior rb = rocket.GetComponent<RocketBehavior>();
                rb.target = currentTarget;
                rb.isThrowable = (i == 2); // Last rocket is throwable
            }
        }
    }

}
