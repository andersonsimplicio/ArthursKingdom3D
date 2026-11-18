using UnityEngine;
using System;

public class CrabAI{

public bool IsPlayerVisible {get; private set;}
private readonly float detectionRadius;
private readonly float attackRange;
private readonly float attackCoolDown;
private float lastAttackTime;
public event Action OnPlayerSpotted;
public event Action OnAttackTriggered;


public CrabAI(float detectionRadius, float attackRange,float attackCoolDown){
    this.detectionRadius = detectionRadius;
    this.attackRange = attackRange;
    this.attackCoolDown = attackCoolDown;
    this.lastAttackTime = -attackCoolDown;
}

public void Evaluate(float distanceToPlayer, float currentTime){
    if (!IsPlayerVisible){
        if (distanceToPlayer <=detectionRadius){
            IsPlayerVisible = true;
            OnPlayerSpotted?.Invoke();
        }
        return;
    }   
    if(distanceToPlayer <= attackRange && (currentTime - lastAttackTime) >= attackCoolDown && !Player.Instance._playerHeath.IsDead){
            lastAttackTime = currentTime;
            OnAttackTriggered?.Invoke();
    }     
 }
}
