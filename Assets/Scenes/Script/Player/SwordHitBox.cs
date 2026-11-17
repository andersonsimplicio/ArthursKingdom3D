using UnityEngine;

public class SwordHitBox : MonoBehaviour
{
    [SerializeField] private int damage = 15;
    [SerializeField] private int enemyLayer = 8;

   private void OnTriggerEnter(Collider other)
{
    Debug.Log($"[1] Espada encostou em: {other.name} | Layer do objeto: {other.gameObject.layer}");

    bool isEnemyLayer = other.gameObject.layer == enemyLayer || 
                        (other.attachedRigidbody != null && other.attachedRigidbody.gameObject.layer == enemyLayer);

    if (!isEnemyLayer)
    {
        Debug.LogWarning($"[2] Bloqueado pela Layer! Esperava layer {enemyLayer}, mas veio {other.gameObject.layer}");
        return;
    }

    Enemy enemy = other.GetComponentInParent<Enemy>();
    if (enemy == null)
    {
        Debug.LogError($"[3] Achou a layer certa, mas não encontrou componente Enemy em {other.name} nem nos pais!");
        return;
    }

    Debug.Log($"[4] Sucesso! Aplicando {damage} de dano em {enemy.name}");
    enemy.OnHit(damage);
}
}
