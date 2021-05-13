using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileLabeler : MonoBehaviour
{
   private Waypoint waypoint;
   [SerializeField] private Bank bank;

   private MeshRenderer meshRenderer;
 
  void Awake()
    {
        waypoint = GetComponent<Waypoint>();

        meshRenderer = gameObject.GetComponentInChildren<MeshRenderer>();
    }

    private void Start() 
    {
        bank = GameObject.FindObjectOfType<Bank>();        
    }
    

    private void OnMouseOver() 
    {      
        if(waypoint.IsPlaceable)
        {
            meshRenderer.material.SetColor("_Color", Color.cyan); 
            Debug.Log("Called");               
        }   
    }
    

}
