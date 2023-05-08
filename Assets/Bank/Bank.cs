using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{   
    [SerializeField] int startingbalance=150;
    [SerializeField] int currentBalance;

    [SerializeField] TextMeshProUGUI displayBalance;

    public int CurrentBalance{
        get{
            return currentBalance;
        }
    }
    void UpdateDisplay(){
        displayBalance.text = "Gold: "+ currentBalance;
    }
    
    void Awake() {
        currentBalance = startingbalance;
        UpdateDisplay();
    }

    public void Deposit(int amount){
        currentBalance +=Mathf.Abs(amount);
        UpdateDisplay();
    }

     public void Withdraw(int amount){
        currentBalance -=Mathf.Abs(amount);
        UpdateDisplay();
        if(currentBalance <0){
            ReloadScene();
        }
    }

     void ReloadScene() {
        
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
