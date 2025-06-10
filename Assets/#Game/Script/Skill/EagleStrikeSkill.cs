namespace Game.Skill
{
    using UnityEngine;
    public class EagleStrikeSkill : BaseSkill
    {
        [SerializeField] private GameObject shadowPrefab;
        [SerializeField] private GameObject bossModel;
        [SerializeField] private float flyTime = 1f;
        [SerializeField] private float dropDelay = 2f;
        private GameObject shadowInstance;

        public override void ExecuteAttack(Transform target)
        {
            Vector3 targetPosition = target.position;

            // Disappear Boss
            bossModel.SetActive(false);

            // Spawn Shadow
            shadowInstance = Instantiate(shadowPrefab, targetPosition, Quaternion.identity);

            Invoke(nameof(DropFromSky), dropDelay);
        }

        private void DropFromSky()
        {
            bossModel.transform.position = shadowInstance.transform.position + Vector3.up * 10f;
            bossModel.SetActive(true);
            // Optionally play impact effect
            Destroy(shadowInstance);
        }
    }

}
