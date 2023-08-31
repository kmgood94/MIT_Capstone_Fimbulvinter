using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Item : MonoBehaviour
{
    public enum InteractionType {None, PickUp, Examine};
    public InteractionType type;
    
    private void Reset()
    {
        GetComponent<Collider2D>().isTrigger = true;
        gameObject.layer = 7;
    }

    public void Interact()
    {
        switch(type)
        {
            case InteractionType.PickUp:
                //Add object to inventory.
                FindObjectOfType<InteractionSystem>().PickUpItem(gameObject);
                //Delete object.
                gameObject.SetActive(false);
                break;

            case InteractionType.Examine:
                Debug.Log("EXAMINE");
                break;

            default:
                Debug.Log("NULL ITEM");
                break;
        }
    }
}
