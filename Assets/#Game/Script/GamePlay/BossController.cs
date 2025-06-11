using Game.Skill;
using System.Collections;
using UnityEngine;

public class BossController : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float hoverHeight = 5f;
    [SerializeField] private float moveRadius = 10f;
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float hoverSpeed = 2f;
   
    [Header("Attack")]
    [SerializeField] private Transform firePoint;
    [SerializeField] private float attackCooldown = 5f;
    [SerializeField] private string[] arrSkill;

    private Vector3 centerPosition;
    private float moveTimer;


    private bool isAttack = false;
    private float attackTimer = 0f;

    private Transform player1 => GameManager.Instance.Player1.gameObject.transform;
    private Transform player2 => GameManager.Instance.Player2.gameObject.transform;

    public Transform FirePoint => firePoint;

    void Start()
    {
        centerPosition = GetPlayersCenter();
    }

    void Update()
    {
        if (player1 == null || player2 == null)
            return;

        if (!isAttack)
            MoveDynamically();

        // Handle Fire Flame attack
        attackTimer += Time.deltaTime;
        if (!isAttack && attackTimer >= attackCooldown)
        {
           
          StartCoroutine(Attack());
            attackTimer = 0f;
        }
      
    }

    private  IEnumerator  Attack()
    {
        isAttack = true;

        Transform targetPos = GetPlayerTarget();
     
        Quaternion targetRotation = Quaternion.LookRotation(targetPos.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);

        BaseSkill skill = Instantiate(GameManager.Instance.GetSkill(arrSkill[Random.Range(0,arrSkill.Length)]), firePoint.position, firePoint.rotation, firePoint) as BaseSkill;

        skill.ExecuteAttack(targetPos);

        yield return new WaitForSeconds(skill.Duration);

     
        isAttack = false;
        attackTimer = 0;
        attackCooldown = 5;
    }


    void MoveDynamically()
    {
        centerPosition = GetPlayersCenter();

        moveTimer += Time.deltaTime * moveSpeed;

        float x = Mathf.Cos(moveTimer) * moveRadius;
        float z = Mathf.Sin(moveTimer * 0.7f) * moveRadius;

        float y = hoverHeight + Mathf.Sin(Time.time * hoverSpeed);

        Vector3 targetPosition = centerPosition + new Vector3(x, y, z);

        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * moveSpeed);
        transform.LookAt(centerPosition);
    }

    Vector3 GetPlayersCenter()
    {
        if (!player1.gameObject.activeInHierarchy)
            return player2.position;
        else if (!player2.gameObject.activeInHierarchy)
            return player1.position;

        return (player1.position + player2.position) / 2f;
    }

    Transform GetPlayerTarget()
    {
        if (!player1.gameObject.activeInHierarchy)
            return player2;
        else if (!player2.gameObject.activeInHierarchy)
            return player1;

        int random = Random.Range(0,2);

        switch(random)
        {
            case 0:
                return player1;

            case 1:
                return player2;
        }

        return player1;

        
    }
}
