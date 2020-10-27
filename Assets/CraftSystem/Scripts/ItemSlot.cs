using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;



///////////////////////////////////////////////////////
// this script mounts on the item slot prefab        //
///////////////////////////////////////////////////////





public class ItemSlot : MonoBehaviour, IDropHandler, IPointerDownHandler, IPointerUpHandler, IDragHandler
{

    

    public ItemSO currItem;

    public Image itemImage;
    public RectTransform itemTransform;

    private CanvasGroup cg;
    public Canvas canvas;



    // Start is called before the first frame update
    void Start()
    {
        cg = GetComponent<CanvasGroup>();
        UpdateSlotData();
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    public void UpdateSlotData()
    {
        if (currItem != null)
        {
            itemImage.sprite = currItem.itemIcon;
        }
        else
        {
            itemImage.sprite = null; 
        }

        itemTransform.anchoredPosition = Vector3.zero; 

    }






    public void OnDrop(PointerEventData eventData)
    {


        // if this slot is empty and the dragged item's image is not null
        // drop it into the slot
        if (currItem == null && itemImage.sprite != null)
        {
            itemTransform.anchoredPosition = eventData.position / canvas.scaleFactor;
        }
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        cg.blocksRaycasts = false;
        
        // Debug.Log(itemImage.sprite);

    }



    public void OnPointerUp(PointerEventData eventData)
    {
        
        
        
        
        bool foundSlot = false;


        
        foreach (GameObject overObj in eventData.hovered)
        {
            if (overObj != gameObject)
            {

                if (overObj.GetComponent<ItemSlot>())
                {

                    // If not hoverd over craft output
                    if (overObj.GetComponent<ItemSlot>().transform.parent.name != "CraftOutput")
                    {
                        // get the hovered object' itemslot component
                        ItemSlot itemSlot = overObj.GetComponent<ItemSlot>();


                        // swap current Itemslot and hovered itemslot
                        ItemSO prevItem = currItem;
                        currItem = itemSlot.currItem;
                        itemSlot.currItem = prevItem;



                        // Debug.Log(itemSlot.itemImage.sprite);
                        
                        // Set position and refresh
                        itemSlot.itemTransform.anchoredPosition = Vector3.zero;
                        itemSlot.UpdateSlotData();

                        // prevent duplication
                        UpdateSlotData();

                        // Clear all item in craft panel
                        if (transform.parent.name == "CraftOutput")
                        {
                            Debug.Log("ClearAllCraftingSlots");
                            ClearAllCraftingSlot();
                        }

                        foundSlot = true;
                    }

                }
            }
        }


        // if not dragged into slot reset position
        if (!foundSlot)
        {
            itemTransform.anchoredPosition = Vector3.zero;
        }

        // when pointer is up set block raycast to true
        cg.blocksRaycasts = true;
    }


    public void OnDrag(PointerEventData eventData)
    {

        if (currItem != null)
        {
            itemTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
    }


    // Call clear method inside craft panel
    public void ClearAllCraftingSlot()
    {
        GameObject cr = GameObject.Find("Crafting");
        ClearCrafting cc = cr.GetComponent<ClearCrafting>();
        cc.ClearS();
    }


}
