using UnityEngine;

public class Enemy : MonoBehaviour
{
     [SerializeField] int life;
     [SerializeField] float damage;
     [SerializeField] GameObject hitFx;
     [SerializeField] private Vector3 alturaHit;
     [SerializeField] private Animator animator;
     private static readonly int attackHit = Animator.StringToHash("Hit");

   public void Start()
   {
      alturaHit = new Vector3(0,1f,0);
   }  

       public void Move()
    {
        
    }
    public void OnHit()
    {
      animator.SetTrigger(attackHit);
      GameObject hitEffect = Instantiate(hitFx,transform.position + alturaHit ,transform.rotation);
      Destroy(hitEffect,1f);
    }
   public void OnDead()
    {
        
    }
}
