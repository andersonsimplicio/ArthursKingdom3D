using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
   [SerializeField] int life = 100;
   public void TakeDamege(int damage){
        Debug.Log("Player tomou dano!");   
        life-=damage;

        if(life <= 0){
            Death();
        }
        else{
            //Toma Hit
        }

   }
   void Death(){
        
    }
}
