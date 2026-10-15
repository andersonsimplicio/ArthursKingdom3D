using UnityEngine;

public class Enemy : MonoBehaviour
{
     [SerializeField] int life;
     [SerializeField] float damage;

       public void Move()
    {
        
    }
    public void OnHit()
    {
        Debug.Log("Acertou !!!!");
    }
   public void OnDead()
    {
        
    }
}
