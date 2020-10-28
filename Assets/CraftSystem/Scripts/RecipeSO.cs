using System.Collections;
using System.Collections.Generic;
using UnityEngine;


///////////////////////////////////////////////////////
// this is the scriptable object for recipe          //
///////////////////////////////////////////////////////


[CreateAssetMenu(fileName = "New recipe", menuName = "ItemManager/New Recipe")]
public class RecipeSO : ScriptableObject
{
    
    public ItemSO[] topRow = new ItemSO [3];
    public ItemSO[] midRow = new ItemSO [3];
    public ItemSO[] bottomRow = new ItemSO [3];

    

    public List<ItemSO> oneDSlotlist = new List<ItemSO>();



    public ItemSO output;



}
