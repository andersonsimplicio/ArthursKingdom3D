using UnityEngine;
using System;
public class EnemyHealth
{
   
    public int CurrentLife { get; private set;}
    public bool IsDead { get; private set;}
    private static readonly int htiHash = Animator.StringToHash("Hit");
    private static readonly int dieHash = Animator.StringToHash("Die");

   public event Action OnDamaged;
   public event Action OnDied;

   public EnemyHealth(int initalLite)
    {
        CurrentLife = initalLite;
    }

    public void TakeDamage(int damage)
    {
        if(IsDead) return;

        CurrentLife-=damage;

        if(CurrentLife < 0)
        {
            IsDead = true;
            OnDied?.Invoke();
            return;
        }

        OnDamaged?.Invoke();
    }
}
