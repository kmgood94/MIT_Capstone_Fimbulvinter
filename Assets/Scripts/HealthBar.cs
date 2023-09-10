using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{ 
    public Image imgHealthBar;
    public float health;
    public GameObject DeathWindow;



    public void LoseHealth(int value)
    {
        if(health <= 0)
            return;

        health -= value;
        imgHealthBar.fillAmount = health / 100;
        if(health <= 0)
        {
            Debug.Log("YOU DIED");
        }


    }

   private void Update()
   {
   //  if(Input.GetKeyDown(KeyCode.Return))
   //      LoseHealth(25);    
   }
    
}
