using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))] 
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int maxHitPoints = 5;
    
    [Tooltip("Adds amount to enemy hit points when disabled")]
    [SerializeField] private int difficultyRamp = 2;

    private int currentHitPoints = 0;

    Enemy enemy;

    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    void OnEnable()
    {
        currentHitPoints = maxHitPoints;
    }
    private void OnParticleCollision(GameObject other) 
    {        
        ProcessHit();
    }

    public void ProcessHit()
    {
        currentHitPoints--;

        if(currentHitPoints <= 0)
        {
            gameObject.SetActive(false);
            maxHitPoints += difficultyRamp;
            enemy.RewardGold();
        }
    }

}
