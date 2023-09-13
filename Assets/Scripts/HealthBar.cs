using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{ 
    public Image imgHealthBar;
    public float health;
    public GameObject deathWindow;
    public GameObject graphicInterface;
    public Animator lifAnimate;
//    public bool deathAnimationFinished = false;

    
    void Start()
    {
        imgHealthBar.fillAmount = health / 100;
    }
    
    public void LoseHealth(int value)
    {
        if(health <= 0)
            return;

        health -= value;
        imgHealthBar.fillAmount = health / 100;
        lifAnimate.Play("Lif_Archer_Hurt");

        if(health == 0)
        {
           GetComponent<Lif>().speed = 0;
           FindObjectOfType<Lif>().Die();
           deathWindow.SetActive(true);
           graphicInterface.SetActive(false);
            Time.timeScale = 0;
           //lifAnimate.Play("Lif_Archer_Die");
           //if (deathAnimationFinished == true)
           //  OnDieAnimationFinished();
        }
    }
        public void OnDieAnimationFinished()
    {
        deathWindow.SetActive(true);
        graphicInterface.SetActive(false);
        Time.timeScale = 0;
//        deathAnimationFinished = true;
    }


    public void GainHealth(int value)
    {
        if(health == 100)
            return;

        health += value;
        imgHealthBar.fillAmount = health / 100;

    }

   private void Update()
   {
   //  if(Input.GetKeyDown(KeyCode.Return))
   //      LoseHealth(25);    
   }
    
}
