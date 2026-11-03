using UnityEngine;

public class EnemyDamageHitBox : MonoBehaviour{
    [SerializeField] private int damage=15;
    [SerializeField] private int enemyLayer = 8; 

    public int Damage
    {
        set{ damage = value; }
        get{ return damage; }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<PlayerHealth>().TakeDamege(damage);
        }
    }
}
