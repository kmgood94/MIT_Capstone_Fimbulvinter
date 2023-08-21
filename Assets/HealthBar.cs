using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{ 
public Image imgHealthBar;
private int damage = 5;

    // Update is called once per frame
    void Update()
    { if (Input.GetKeyDown(KeyCode.H)) {
        imgHealthBar.fillAmount = imgHealthBar.fillAmount - (damage * 0.01f);
    }
        
    }
}
