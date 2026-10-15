using UnityEngine;

public class SwordHitBox : MonoBehaviour
{
    [SerializeField] private int enemyLayer = 8; 
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == enemyLayer)
        {
            other.GetComponent<Enemy>().OnHit();
        }
    }

}
