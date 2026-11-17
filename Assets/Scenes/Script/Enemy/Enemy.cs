using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
   [Header("Debug (Apenas Leitura)")] 
   [SerializeField] private int currentLifeDebug;
   [SerializeField] int initalLite = 100;
   [SerializeField] protected int damage;
   [SerializeField] GameObject hitFx;
   [SerializeField] private Vector3 alturaHit;
   [SerializeField] protected Animator animator;
   [SerializeField] Renderer enemyRenderer;
   [SerializeField] protected Collider collider;
   [SerializeField] protected Rigidbody rigidbody;
   private static readonly int attackHit = Animator.StringToHash("Hit");
     
   protected  EnemyHealth Health {get; private set;}
   protected int life=> Health !=null ? Health.CurrentLife:initalLite;

   public virtual void Awake(){
      Health = new EnemyHealth(initalLite);
      Health.OnDamaged +=HandleDamaged;
      Health.OnDied += Death;   
   }

   protected virtual void Start(){
      alturaHit = new Vector3(0,1f,0);
   }  

   public void Move(){
        
   }
   public virtual void HandleDamaged(){
      currentLifeDebug = Health.CurrentLife; 
      if(animator!=null)  animator.SetTrigger(attackHit);

      if (hitFx != null){
         GameObject hitEffect = Instantiate(hitFx,transform.position + alturaHit ,transform.rotation);
         Destroy(hitEffect,1f);         
      }
      if(Player.Instance !=null) Player.Instance.ShakeCamera();
      if(enemyRenderer !=null) StartCoroutine(HitFlash());
   }

   
   public void OnHit(int damageAmount)
   {
      Debug.Log($"[Enemy] Recebi {damageAmount} de dano. Vida antes: {Health.CurrentLife}");
      Health.TakeDamage(damageAmount);
      Debug.Log($"[Enemy] Vida depois: {Health.CurrentLife}");
   }
    public void OnDead()
    {
        
    }
    public virtual void Death()
    {
       
    }
    public virtual void Attack(){
        
    }


    IEnumerator HitFlash(){
      
        enemyRenderer.material.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        enemyRenderer.material.color = Color.white;
        yield return new WaitForSeconds(0.2f);
        enemyRenderer.material.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        enemyRenderer.material.color = Color.white;
    }
}
