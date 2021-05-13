using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] private Bank bank;
    [SerializeField] private Tower towerPrefab;
    [SerializeField] private bool isPlaceable;
    private MaterialChanger materialChanger;
    public bool IsPlaceable { get { return isPlaceable;} }

    private void Awake() 
    {
        bank = FindObjectOfType<Bank>();
        materialChanger = GetComponentInChildren<MaterialChanger>();
    }

   private void OnMouseDown()
   {
       if(isPlaceable)
       {                
            bool isPlaced = towerPrefab.CreateTower(towerPrefab, transform.position);               
            isPlaceable = !isPlaced;
       }
   }

   private void OnMouseOver() 
   {
       if(materialChanger != null && materialChanger.ColorChanged == false)
       {    
           if(isPlaceable)     
           {          
               if(bank.CalculateAffordable(35))
                {
                    materialChanger.ColorOver(HoverColorSelector.Placeable);               
                }   
                else
                {
                    materialChanger.ColorOver(HoverColorSelector.OverCost);                    
                }                    
           }
           else
           {
                materialChanger.ColorOver(HoverColorSelector.NotPlaceable);
           }
           materialChanger.ColorChanged = true;
       }
   }

   private void OnMouseExit() 
    {
        if(materialChanger != null)
        {
            materialChanger.ClearColorChange();
            materialChanger.ColorChanged = false;
        }
    }
   
}
