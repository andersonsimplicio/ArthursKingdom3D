using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
   [SerializeField] int life = 100;
   [SerializeField] Player player;
   [SerializeField] bool isDead;


   public bool IsDead
   {
        get{ return isDead;}
        set{ isDead = value;}
   }

   private int attackHit = Animator.StringToHash("Hit");
   private int dieHash = Animator.StringToHash("Die");

    private void Awake()
    {
        player = GetComponent<Player>();
    }


    public void TakeDamege(int damage){ 
        life-=damage;

        if(life <= 0){
            Death();
        }
        else{
            //Toma Hit
            player.Animator.SetTrigger(attackHit);
        }

   }
   void Death(){
         player.Animator.SetTrigger(dieHash);
         player.isPause = true;
         player._playerHeath.isDead = true;
    }
}
