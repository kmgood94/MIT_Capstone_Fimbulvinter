using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    Vector2 playerInitPosition;
    void Start()
    {
        playerInitPosition = FindObjectOfType<Lif>().transform.position;
    }
    public void Restart()
    {
        SceneManager.LoadScene("Gameplay1_Forest1");
        FindObjectOfType<Lif>().ResetPlayer();
        FindObjectOfType<Lif>().transform.position = playerInitPosition;
        Time.timeScale = 1;
    }




}
