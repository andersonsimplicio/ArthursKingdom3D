using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
   [SerializeField] int life = 100;
   [SerializeField] Player player;
   [SerializeField] bool isDead;
   [SerializeField] GameObject gameOverPanel;


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
   public void RestartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);        
   } 
   void Death(){
         player.Animator.SetTrigger(dieHash);
         player.isPause = true;
         player._playerHeath.isDead = true;
         StartCoroutine(DelayeGameOver());
    }
    IEnumerator DelayeGameOver()
    {
        yield return new WaitForSeconds(1.0f);
        gameOverPanel.SetActive(true);
    }
}
