using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI displayBalance;
    [SerializeField] TextMeshProUGUI endScreen;
    [SerializeField] private int lastSceneIndexDefender = 12;
    [SerializeField] private int winningSum = 1000;
    [SerializeField] private int startingBalance = 150;
    [SerializeField] private int currentBalance;
    public int CurrentBalance { get { return currentBalance;} }

    private int score;

    void Awake() 
    {
        currentBalance = startingBalance;
        UpdateDisplay();
    }

    public void Deposit(int amountIn)
    {
        int absValue = Mathf.Abs(amountIn);
        currentBalance += absValue;
        score += absValue;
        UpdateDisplay();
        if(currentBalance > winningSum)
        {
            HandleGameOver();
        }
    }

    public void Withdraw(int amountIn)
    {
        currentBalance -= Mathf.Abs(amountIn);

        if(currentBalance < 0)
        {
            HandleGameOver();
        }
        
        UpdateDisplay();
    }

    public void UpdateDisplay()
    {
        displayBalance.text = "Gold: £" + currentBalance + "\tTarget: £" + winningSum;
    }

    public void HandleGameOver()
    {
        endScreen.enabled = true;
        displayBalance.enabled = false;

        Time.timeScale = 0.1f;  

        if(currentBalance < winningSum)
        {        
            
            endScreen.text = "Unlucky! you earned: £" + score + "\nRestart in 5 Seconds..";   
            Invoke("ReloadLevel", 0.5f);       
        }
        else
        {          
            endScreen.text = "Well Done! you earned: £" + score + "\nNext level in 5 Seconds.."; 
            Invoke("NextLevel", 0.5f);
        }
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void NextLevel()
    {
        Time.timeScale = 1f;
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;        

        //Debug.Log("Scene Count:" + SceneManager.sceneCount);
        //Debug.Log("last Scene:" + lastSceneIndexDefender);

        if(nextSceneIndex <= SceneManager.sceneCountInBuildSettings && nextSceneIndex <= lastSceneIndexDefender)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            //Debug.Log("Wrong");
            SceneManager.LoadScene("DefenderMenu");
        }
    }

    public bool CalculateAffordable(int costIn)
    {
        if(currentBalance - costIn < 0)
        {
            return false;
        }

        return true;
    }

}
