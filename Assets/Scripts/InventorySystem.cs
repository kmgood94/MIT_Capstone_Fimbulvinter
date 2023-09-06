using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySystem : MonoBehaviour
{
    [Header("General Fields")]
    public bool isOpen = false;
    public List<GameObject> items = new List<GameObject>();
    [Header("UI")]
    public GameObject ui_Window;
    public GameObject graphicUi;
    public Image[] itemsImages;
    [Header("UI Item Description")]
    public GameObject ui_DescriptionWindow;
    public Image descriptionImage;
    public TextMeshProUGUI descriptionTitle;
    public TextMeshProUGUI descriptionDescription;

    private void Start()
    {
        Update_UI();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleInventory();
        } 
    }

    void ToggleInventory()
    {
        isOpen = !isOpen;
        ui_Window.SetActive(isOpen);
        graphicUi.SetActive(!isOpen);
        Update_UI();

        if(isOpen == true)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }

    }
    
    public void PickUp(GameObject item)
    {
        items.Add(item);
        Update_UI();
    }

    void Update_UI()
    {
        HideAll();

        for(int i = 0; i < items.Count; i++)
        {
            itemsImages[i].sprite = items[i].GetComponent<SpriteRenderer>().sprite;
            itemsImages[i].gameObject.SetActive(true);
        }
    }

    void HideAll()
    {
        foreach(var i in itemsImages) 
        {
            i.gameObject.SetActive(false);
            HideDescription();
        }
    }

    public void ShowDescription(int id)
    {
        descriptionImage.sprite = itemsImages[id].sprite;
        descriptionTitle.text = items[id].name;
        descriptionDescription.text = items[id].GetComponent<Item>().descriptionText;
        descriptionImage.gameObject.SetActive(true);
        descriptionTitle.gameObject.SetActive(true);
        descriptionDescription.gameObject.SetActive(true);

    }

    public void HideDescription()
    {
        descriptionImage.gameObject.SetActive(false);
        descriptionTitle.gameObject.SetActive(false);
        descriptionDescription.gameObject.SetActive(false);
    }

    public void Consume(int id)
    {
        if(items[id].GetComponent<Item>().type == Item.ItemType.Consumable)
        {
            items[id].GetComponent<Item>().consumeEvent.Invoke();
            Destroy(items[id], 0.1f);
            items.RemoveAt(id);
            Update_UI();

        }
    }

}
