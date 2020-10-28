using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCrafting : MonoBehaviour
{
    public void ClearS()
    {
        Debug.Log("ClearSCalled");

        // Clear both craft input and output
        foreach (Transform child in transform)
        {
            foreach (Transform subchild in child.transform)
            {
                var childitemslot = subchild.GetComponent<ItemSlot>();

                childitemslot.itemImage.sprite = null;
                childitemslot.currItem = null; 
            }
        }
    }
}
