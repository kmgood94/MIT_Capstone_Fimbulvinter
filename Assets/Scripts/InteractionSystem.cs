using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InteractionSystem : MonoBehaviour
{
    [Header("Detection Parameters")]
    public Transform detectionPoint;
    private const float detectionRadius = 0.2f;
    public LayerMask detectionLayer;
    public GameObject detectedObject;
    [Header("Examine Fields")]
    public GameObject examineWindow;
    public GameObject gameInterface;
    public TextMeshProUGUI examineText;
    public bool isExamining = false;
    public bool isInteracting = false;


    // Update is called once per frame
    void Update()
    {
        if(DetectObject())
        {
            if(InteractInput())
            {
                detectedObject.GetComponent<Item>().Interact();
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(detectionPoint.position, detectionRadius);
    }

    bool InteractInput()
    {
        return Input.GetKeyDown(KeyCode.E);
    }

    bool DetectObject()
    {
        Collider2D obj = Physics2D.OverlapCircle(detectionPoint.position, detectionRadius, detectionLayer);
        if(obj==null)
        {
            detectedObject = null;
            return false;
        }
        else
        {
            detectedObject = obj.gameObject;
            return true;
        }

    }


    public void ExamineItem(Item item)
    {
        if(isExamining)
        {
            examineWindow.SetActive(false);
            gameInterface.SetActive(true);
            Time.timeScale = 1;
            isExamining = false; 
            
        }
        else
        {
            examineText.text = item.descriptionText;
            examineWindow.SetActive(true);
            gameInterface.SetActive(false);
            Time.timeScale = 0;
            isExamining = true; 
        }
    }


}
