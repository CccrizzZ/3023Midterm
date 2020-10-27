using System.Collections;
using System.Collections.Generic;
using UnityEngine;



///////////////////////////////////////////////////////
// this is the scriptable object for item            //
///////////////////////////////////////////////////////



[CreateAssetMenu(fileName = "New item", menuName = "ItemManager/New Item")]
public class ItemSO : ScriptableObject
{
    public Sprite itemIcon;
    public string itemName;
}
