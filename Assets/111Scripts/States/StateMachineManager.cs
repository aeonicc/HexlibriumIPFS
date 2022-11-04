using System;
using System.Collections;
using System.Collections.Generic;
using HEXLIBRIUM;
using UnityEngine;
using MoralisUnity.Platform.Objects;
using Unity.VisualScripting;
using UnityEngine.UI;
using StateMachine = Pixelplacement.StateMachine;
using Update = UnityEngine.PlayerLoop.Update;
    
namespace Hexlibrium
{
    
    #region DATA_CLASSES

    // public class DatabaseItem : MoralisObject
    // {
    //     public string metadata { get; set; }
    //     public DatabaseItem() : base("DatabaseItem") {}
    // }
    //
    // public class MetadataObject
    // {
    //     public string name;
    //     public string description;
    //     public string image;
    // }

    #endregion
    

public class StateMachineManager : StateMachine
{
    
    public Camera playerCamera;
    public Camera boardCamera;
    public GameObject theFiveButtons;

    public GameObject buttonHeath;
    public GameObject buttonCrystal;
    public GameObject buttonCoin;
    public GameObject buttonSolidity;
    public GameObject buttonCronos;
    public GameObject buttonGold;
    
    public GameObject theBoss;

    public GameObject hLines;

    
    
    public static StateMachineManager instance;
    
   
    
    private void Awake()
    {
        instance = this;
    }

    public void Update()
    {
        // var _time = Time.time;
        // Debug.Log(_time);
        
        // for (int i = 0; i <= 5; i++)
        // {
        //     var io = io++;
        //     Debug.Log(io);
        // }
        
        // var time = DateTime.Now.Ticks;
        // Debug.Log(time);
    }
    public void OnStateEnteredHandler(GameObject stateEntered)
    {
        switch (stateEntered.name)
        {
            case "H00":
         
                break;
                
            case "H01":
           
                break;
                
            case "H002":
         
                break;
                
            case "H03":
        
                break;
                
            case "H04":
              
                break;
            
            case "H05":
                //ChangeState("MintingMetaverseItem");
                break;
                
            case "H06":
                break;
                
            case "H007":
                break;
                
            case "H08":
                break;
                
            case "MiningGold":
                //ChangeState("H00");
                break;
            
            case "MiningCoin":
                break;
                
            case "MiningItem":
                break;
                
            case "MintingMetaverseItem":
                //ChangeState("H00");
                break;
                
            case "MintingPanel":
                break;
                
            case "MintingRandomNumber":
                break;
            
            case "Board":
                //ChangeState("H04");
                break;
            
            case "Match_Handler":
                //ChangeState("H05");
                break;
            
            case "GameCrystal":
                //ChangeState("H02");
                break;
    
        }
    }
        
    public void OnStateExitedHandler(GameObject stateExited)
    {
        switch (stateExited.name)
        {
            case "H00":
                break;
                
            case "H01":
                break;
                
            case "H002":
                break;
                
            case "H03":
                break;
                
            case "H04":
               break;
            
            case "H05":
                break;
                
            case "H06":
                break;
                
            case "H007":
                break;
                
            case "H08":
                break;
                
            case "MiningGold":
                break;
            
            case "MiningCoin":
                break;
                
            case "MiningItem":
                break;
                
            case "MintingMetaverseItem":
                break;
                
            case "MintingPanel":
                break;
                
            case "MintingRandomNumber":
                break;
          
        }
    }


    public void StartGame()
    {
        
        //player.walletAddress.Activate()
        ChangeState("H01");
    }
 
    // public void Hh00()
    // {
    //     ChangeState("H00");
    // }
    //
    // public void Hh01()
    // {
    //     ChangeState("H01");
    // }
    //
    // public void Hh02()
    // {
    //     ChangeState("H02");
    // }
    //
    // public void Hh03()
    // {
    //     ChangeState("H03");
    // }
    //
    // public void Hh04()
    // {
    //     ChangeState("H04");
    // }
    //
    // public void Hh05()
    // {
    //     ChangeState("H05");
    // }
    //
    // public void Hh06()
    // {
    //     ChangeState("H06");
    // }
    //
    // public void Hh07()
    // {
    //     ChangeState("H07");
    // }
    //
    // public void Hh08()
    // {
    //     ChangeState("H08");
    // }

    public void GetRandomNumber()
    {
        ChangeState("GetRandomNumber");
    }

    public void MintingRandomNumber()
    {
        ChangeState("MintingRandomNumber");
    }
    
    public void MiningGold()
    {
        ChangeState("MiningGold");
    }


    public void MintingCoin()
    {
        //player.walletAddress.Deactivate();
        ChangeState("MintingCoin");
    }
    
    public void MintingMetaverseItem()
    {
        Debug.Log("message");
        //player.walletAddress.Deactivate();
        ChangeState("MintingMetaverseItem");
    }


    public void Hh64()
    {
        ChangeState("H64");
    }
    
    //public void GoToAuthenticating()
    //{
    //player.walletAddress.Deactivate();
    //ChangeState("Authenticating");
    //}
    
    //private void RespawnPlayer()
    //{
    //player.gameObject.SetActive(false);
    //player.transform.position = player.initPos;
    //player.gameObject.SetActive(true);
    //}
    
    //private void GoToConsumingPowerUp() //InventoryItem selectedPowerUp
    //{
    // We save the current selected item (NFT PowerUp)
    //currentPowerUp = selectedPowerUp;

    // We change to the state that will take care of the burning transaction
    //ChangeState("ConsumingPowerUp");
    //}
    
    // public void SetCurrentLootBox(GameObject obj)
    // {
    //     //currentLootBox = obj;
    // }
    //
    // public GameObject GetCurrentLootBox()
    // {
    //     if (currentLootBox is null)
    //     {
    //         Debug.Log("No loot box spawned!");
    //         return null;
    //     }
    //     
    //     return currentLootBox;
    // }[
}
}