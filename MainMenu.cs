using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void LoadRocketGame()
   {
       SceneManager.LoadScene("RocketMenu");
   }

   public void LoadDefenderGame()
   {
       SceneManager.LoadScene("DefenderMenu");
   }
}
