using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    
    [SerializeField] int maxHitPoints= 5;
    
     int currenthitPoints = 0;

    [SerializeField] int difficultyRamp= 1;
    Enemy enemy;

    void OnEnable(){
        currenthitPoints = maxHitPoints;

    }
    void Start(){
        enemy = GetComponent<Enemy>();
    }

    void OnParticleCollision(GameObject other) {
        
        ProcessHit();
    }

   void ProcessHit()
    {
        currenthitPoints--;
        if (currenthitPoints <=0){
             gameObject.SetActive(false);
             maxHitPoints += difficultyRamp;
             enemy.RewardGold();
        }
    }
}
