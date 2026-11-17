using UnityEngine;

public class Crab : Enemy
{
    [SerializeField] float detectionRadius = 1f;
    [SerializeField] float attackRange = 1.5f;
    [SerializeField] float attackCoolDown = 2f;
    [SerializeField] float rotationSpeed = 1f;
    [SerializeField] GameObject AlertCanva;
    [SerializeField] float distance;
    [SerializeField] EnemyDamageHitBox clawHitBox;

    private static readonly int dieHash = Animator.StringToHash("Die");
    private static readonly int attackHash = Animator.StringToHash("Attack");

    private CrabAI ai;

    public override void Awake()
    {
        base.Awake();
        ai = new CrabAI(detectionRadius, attackRange, attackCoolDown);
        ai.OnPlayerSpotted += ShowAlert;
        ai.OnAttackTriggered += Attack;
    }

    protected override void Start()
    {
        base.Start();
        if (clawHitBox != null) clawHitBox.Damage = damage;
    }

    private void Update()
    {
        if (Player.Instance == null) return;

        distance = Vector3.Distance(transform.position, Player.Instance.transform.position);
        
        if (ai.IsPlayerVisible)
        {
            RotationTowarsPlayer();
        }

        // O Update apenas entrega os dados atuais para o cérebro decidir
        ai.Evaluate(distance, Time.time);
    }

    private void ShowAlert()
    {
        Debug.Log("Viu o Jogador");
        if (AlertCanva == null) return;

        GameObject alert = Instantiate(AlertCanva, transform.position + new Vector3(-2f, 1f, -2f), transform.rotation);
        if (Camera.main != null) alert.transform.forward = Camera.main.transform.forward;
        Destroy(alert, 2f);
    }

    private void RotationTowarsPlayer()
    {
        Vector3 direction = (Player.Instance.transform.position - transform.position).normalized;
        direction.y = 0f;
        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

    public override void Attack()
    {
        if (animator != null) animator.SetTrigger(attackHash);
    }

    public override void Death()
    {
        Debug.Log("Inimigo Morreu!!!");
        base.Death();
        if (animator != null) animator.SetTrigger(dieHash);
        enabled = false;
        if (rigidbody != null) rigidbody.useGravity = false;
        if (collider != null) collider.enabled = false;
    }

    private void OnDrawGizmosSelected()
    {
        // Raio de detecção/visão (Amarelo)
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);

        // Raio de alcance do ataque (Vermelho)
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

}