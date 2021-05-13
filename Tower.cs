using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private int cost = 35;

    public int Cost{ get{ return cost;}}

    public bool CreateTower(Tower towerIn, Vector3 positionIn)
    {
        Bank bank = FindObjectOfType<Bank>();

        if(bank == null)
        {
            return false;
        }
        
        if(bank.CurrentBalance >= cost)
        {
            Instantiate(towerIn, positionIn, Quaternion.identity);
            bank.Withdraw(cost);
            return true;
        }

        return false;
        
    }

  
}
