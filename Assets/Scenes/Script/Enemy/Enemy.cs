using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
     [SerializeField] int life;
     [SerializeField] float damage;
     [SerializeField] GameObject hitFx;
     [SerializeField] private Vector3 alturaHit;
     [SerializeField] private Animator animator;
     [SerializeField] Renderer enemyRenderer;
     private static readonly int attackHit = Animator.StringToHash("Hit");

   public void Start()
   {
      alturaHit = new Vector3(0,1f,0);
   }  

  public void Move(){
        
    }
    public void OnHit()
    {
      animator.SetTrigger(attackHit);
      GameObject hitEffect = Instantiate(hitFx,transform.position + alturaHit ,transform.rotation);
      Player.Instance.ShakeCamera();

      Destroy(hitEffect,1f);
    }
   public void OnDead()
    {
        
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
