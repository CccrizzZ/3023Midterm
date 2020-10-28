using System.Collections;
using System.Collections.Generic;
using UnityEngine;




///////////////////////////////////////////////////////
// this script is mounted on the crafting panel      //
///////////////////////////////////////////////////////




public class RecipeManager : MonoBehaviour
{

    // craft table rows
    public ItemSlot[] topRow = new ItemSlot [3];
    public ItemSlot[] midRow = new ItemSlot [3];
    public ItemSlot[] bottomRow = new ItemSlot [3];


    // list of craft table slot list
    private List<ItemSlot[]> CraftTableSlots = new List<ItemSlot[]>();

    // One Dimention List
    private List<ItemSlot> OneDCraftTableSlots = new List<ItemSlot>();
    


    // output item slot
    [Space(10)]
    public ItemSlot outputSlot;


    // single recipe
    private List<RecipeSO> recipes = new List<RecipeSO>();
   
   
    // list of all recipe
    public List<ItemSO[]> allRecipeSlots = new List<ItemSO[]>();





    List<ItemSO> temp = new List<ItemSO>();

    // Start is called before the first frame update
    void Start()
    {
        // add all rows to craft table slot list
        CraftTableSlots.Add(topRow);
        CraftTableSlots.Add(midRow);
        CraftTableSlots.Add(bottomRow);


        foreach (ItemSlot islot in topRow)
        {
            OneDCraftTableSlots.Add(islot);
        }
        foreach (ItemSlot islot2 in midRow)
        {
            OneDCraftTableSlots.Add(islot2);
        }
        foreach (ItemSlot islot3 in bottomRow)
        {
            OneDCraftTableSlots.Add(islot3);
        }
        

        Debug.Log(OneDCraftTableSlots.Count);






        // load all resources from folder
        recipes.AddRange(Resources.LoadAll<RecipeSO>("Recipes/"));


        // go through all recipes
        foreach(RecipeSO recipe in recipes)
        {
            // store recipe into the recipe list
            allRecipeSlots.Add(recipe.topRow);
            allRecipeSlots.Add(recipe.midRow);
            allRecipeSlots.Add(recipe.bottomRow);
            



            // for (int x = 0; x < recipe.oneDSlotlist.Count; x++)
            // {
            //     Debug.Log(recipe.oneDSlotlist[x]);
                
            // }
            
            // Debug.Log(recipe.output);
        }
    
    
    
    
    
    }



    // Update is called once per frame
    void Update()
    {

        // foreach (ItemSlot slotss in OneDCraftTableSlots)
        // {
        //     temp.Add(slotss.currItem);
        // }
        // go through all recipes
        foreach(RecipeSO recipe in recipes)
        {

            // flag for placement
            bool correctPlacement = true;
            
            // for (int i = 0; i < CraftTableSlots.Count; i++)
            // {
            //     for (int j = 0; j < CraftTableSlots[i].Length; j++)
            //     {
            //         Debug.Log(CraftTableSlots[i][j].name + "------" + CraftTableSlots[i][j].itemImage.sprite);



            //     }
            // }



            // for (int i = 0; i < 8; i++)
            // {
                
            //     // Debug.Log(OneDCraftTableSlots[i].name + "-----" + OneDCraftTableSlots[i].itemImage.sprite);

            //     if (recipe.oneDSlotlist[i] &&  OneDCraftTableSlots[i] != null)
            //     {
            //         if(recipe.oneDSlotlist[i].itemIcon != OneDCraftTableSlots[i].itemImage.sprite)
            //         {
            //             // Debug.Log(9999);
            //             correctPlacement = false;
    
            //         }
            //     }
            // }
            


            // if (recipe.oneDSlotlist.Equals(temp))
            // {
            //     Debug.Log(99999);
            //     correctPlacement = true;

            // }
            // else
            // {
            //     Debug.Log(0000);
            // }
            





            // go through all crafting row and column
            for (int r = 0; r < 3; r++)
            {
                for (int c = 0; c < allRecipeSlots[r].Length; c++)
                {
                    // if item in the recipe list is not null
                    if (allRecipeSlots[r][c] != null)
                    {
                        // if item in the craft table is not null
                        if (CraftTableSlots[r][c].currItem != null)
                        {
                            // if the recipe different from 
                            if (allRecipeSlots[r][c].itemName != CraftTableSlots[r][c].currItem.itemName)
                            {
                                correctPlacement = false;
                                continue;
                            }
                        }
                        else
                        {
                            correctPlacement = false;
                            continue;
                        }
                    }
                    else
                    {
                        if (CraftTableSlots[r][c].currItem != null)
                        {
                            correctPlacement = false;
                            continue;
                        }
                    }
                }
            }



            // if placement matches, set the output to recipe output
            if (correctPlacement)
            {
                outputSlot.currItem = recipe.output;
                outputSlot.UpdateSlotData();
                break;
            }
            else
            {
                outputSlot.currItem = null;
                outputSlot.UpdateSlotData();
            }


        }
    }
}
