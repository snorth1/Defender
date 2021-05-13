using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIHandler : MonoBehaviour
{
    public void LoadDefenderMenu()
    {
        SceneManager.LoadScene("DefenderMenu");
    }

    public void LoadRocketMenu()
    {
        SceneManager.LoadScene("RocketMenu");
    }
  
}
