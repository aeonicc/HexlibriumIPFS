using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;
using Hexlibrium;

namespace HEXLIBRIUM
{
    

public class H00 : State
{
      private void OnEnable()
      {
          StateMachineManager.instance.OnStateEnteredHandler(this.gameObject);
          
           StateMachineManager.instance.playerCamera.gameObject.SetActive(true);
           StateMachineManager.instance.boardCamera.gameObject.SetActive(false);
           
           StateMachineManager.instance.theFiveButtons.gameObject.SetActive(false);
           
           StateMachineManager.instance.buttonCoin.gameObject.SetActive(true);
           StateMachineManager.instance.buttonCrystal.gameObject.SetActive(true);
           StateMachineManager.instance.buttonHeath.gameObject.SetActive(true);
           StateMachineManager.instance.buttonSolidity.gameObject.SetActive(true);
           StateMachineManager.instance.buttonCronos.gameObject.SetActive(true);
           StateMachineManager.instance.buttonGold.gameObject.SetActive(true);
      }
}
}