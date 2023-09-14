using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
public class Item : MonoBehaviour
{
    public enum InteractionType {None, PickUp, Examine, Interact};
    public enum ItemType {Static, Consumable, Equippable};
    [Header("Attributes")]
    public InteractionType interactType;
    public ItemType type;
    [Header("Examine")]
    public string descriptionText;
    [Header("Custom Event")]
    public UnityEvent customEvent;
    public UnityEvent consumeEvent;
    
    private void Reset()
    {
        GetComponent<Collider2D>().isTrigger = true;
        gameObject.layer = 7;
    }

    public void Interact()
    {
        switch(interactType)
        {
            case InteractionType.PickUp:
                //Add object to inventory.
                FindObjectOfType<InventorySystem>().PickUp(gameObject);
                //Delete object.
                gameObject.SetActive(false);
                break;

            case InteractionType.Examine:
                Debug.Log("EXAMINE");
                //Display examine window.
                //Show image in middle?
                //Write decription text under image.
                FindObjectOfType<InteractionSystem>().ExamineItem(this);
                customEvent.Invoke();
                break;

            case InteractionType.Interact:
                Debug.Log("INTERACT");
                customEvent.Invoke();
                break;

            default:
                Debug.Log("NULL ITEM");
                break;
        }
    }
}
