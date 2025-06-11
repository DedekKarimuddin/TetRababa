
namespace Game.Skill
{
    using UnityEngine;

    public abstract class BaseSkill : MonoBehaviour
    {
        [SerializeField] protected string id;
        [SerializeField] protected float duration = 0f;

        public float Duration => duration;

        public string ID => id;
        public abstract void ExecuteAttack(Transform target);
    }
}