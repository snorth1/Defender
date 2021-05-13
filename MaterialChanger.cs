using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HoverColorSelector
{
    Placeable,
    OverCost,
    NotPlaceable,

}

public class MaterialChanger : MonoBehaviour
{
    [SerializeField] Color currentColor;
    public Color CurrentColor{ get{ return currentColor;}}

    private bool colorChanged = false;
    public bool ColorChanged{get{return colorChanged;} set{colorChanged = value;}}

    [SerializeField] Color PlaceableColor;
    [SerializeField] Color OverCostColor;
    [SerializeField] Color NotPlaceableColor;



    public void ColorOver(HoverColorSelector ColorIn)
    {  
        if(!colorChanged)
        {
            Color temp;
            switch(ColorIn)
            {
                case HoverColorSelector.Placeable: temp = PlaceableColor;                        
                        break;
                case HoverColorSelector.OverCost: temp = OverCostColor;                                             
                        break;
                case HoverColorSelector.NotPlaceable: temp = NotPlaceableColor;                        
                        break;
                default: return;
            }
           
            GetComponent<MeshRenderer>().material.color += temp;
            currentColor = temp;                      
        }
    }

    public void ClearColorChange()
    {
        GetComponent<MeshRenderer>().material.color -= currentColor;
    }
 
}
