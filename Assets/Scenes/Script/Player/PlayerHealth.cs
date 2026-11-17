using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
   [SerializeField] int life = 100;

   private int attackHit = Animator.StringToHash("Hit");
   private int dieHash = Animator.StringToHash("Die");
   public void TakeDamege(int damage){
        Debug.Log("Player tomou dano!");   
        life-=damage;

        if(life <= 0){
            Death();
        }
        else{
            //Toma Hit
            Player.Instance.Animator.SetTrigger(attackHit);
        }

   }
   void Death(){
         Player.Instance.Animator.SetTrigger(dieHash);
    }
}
