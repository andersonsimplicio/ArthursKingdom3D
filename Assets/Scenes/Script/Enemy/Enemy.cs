using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
     [SerializeField] int life;
     [SerializeField] float damage;
     [SerializeField] GameObject hitFx;
     [SerializeField] private Vector3 alturaHit;
     [SerializeField] protected Animator animator;
     [SerializeField] Renderer enemyRenderer;
     [SerializeField] protected Collider collider;
     [SerializeField] protected Rigidbody rigidbody;
     private static readonly int attackHit = Animator.StringToHash("Hit");
     

   public void Start()
   {
      alturaHit = new Vector3(0,1f,0);
   }  

    public void Move(){
        
    }
    public void OnHit(int damage)
    {

         life-=damage;  

         if (life < 25)
         {
            Death();
         }

            animator.SetTrigger(attackHit);
            GameObject hitEffect = Instantiate(hitFx,transform.position + alturaHit ,transform.rotation);
            Player.Instance.ShakeCamera();

            Destroy(hitEffect,1f);
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
