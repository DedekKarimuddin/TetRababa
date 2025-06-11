namespace Game.Skill
{
    using UnityEngine;

    public class FireFlameSkill : BaseSkill
    {
        [SerializeField] private ParticleSystem flameEffect;
     
        public override void ExecuteAttack(Transform target)
        {
           transform.LookAt(target);

            if (flameEffect != null)
            {
                flameEffect.Play();
                Invoke(nameof(StopFlame), duration);
            }
        }

        private void StopFlame()
        {
            if (flameEffect != null)
            {
                flameEffect.Stop();
                Destroy(this.gameObject);

            }
        }
    }
}