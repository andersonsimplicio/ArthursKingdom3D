using UnityEngine;

public class Crab : Enemy
{
    
 [SerializeField] bool isPlayerVisible;
 [SerializeField] float detectionRadius = 1f;
 [SerializeField] float attackRange = 1.5f;
 [SerializeField] float attackCoolDown = 2f;
 [SerializeField] float lastAttackTime;
 [SerializeField] float rotationSpeed = 1f;
 [SerializeField] GameObject AlertCanva;
 [SerializeField] float alertZOffSet = -0f;
[SerializeField] float distance;
 private static readonly int dieHash = Animator.StringToHash("Die");
 private static readonly int attackHash = Animator.StringToHash("Attack");

 
    private void Update(){

        distance = Vector3.Distance(transform.position,Player.Instance.transform.position);
        if (isPlayerVisible == false)
        {
           
            if(distance <= detectionRadius){
                isPlayerVisible = true;
                Debug.Log("Viu o Jogador");
    
                GameObject alert = Instantiate(AlertCanva,transform.position + new Vector3(-2f,1f,-2f),transform.rotation);
                alert.transform.forward = Camera.main.transform.forward;
                Destroy(alert,2f);
            }
          

        }
        else{
            RotationTowarsPlayer();
            if(distance <= attackRange && ((Time.time - lastAttackTime) >= attackCoolDown)){
                Attack();
                lastAttackTime = Time.time;
            }
        }
       
    }

    private void RotationTowarsPlayer()
    {
        Vector3 direction =(Player.Instance.transform.position - transform.position).normalized;
        direction.y = 0f;
        if(direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation,targetRotation,rotationSpeed*Time.deltaTime); 
        }
    }

    public override void Attack(){
         animator.SetTrigger(attackHash);
    }

    public override void Death()
    {
        Debug.Log("Inimigo Morreu!!!");
        animator.SetTrigger(dieHash);
        enabled = false;
        rigidbody.useGravity = false;
        collider.enabled =false;  
    }

    private void OnDrawGizmosSelected(){
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position,detectionRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,attackRange);
    }

}
