using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;

using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using HEXLIBRIUM;
using UnityEngine;
using MoralisUnity.Platform.Objects;
//using Unity.VisualScripting;
using StateMachine = Pixelplacement.StateMachine;

using System;
using Cysharp.Threading.Tasks;
using Hexlibrium;
using MoralisUnity;
using Nethereum.Hex.HexTypes;
using Pixelplacement;
using TMPro;
using UnityEngine;


namespace HEXLIBRIUM
{
    public class H04 : State
    {
        private void OnEnable()
        {
            StateMachineManager.instance.OnStateEnteredHandler(this.gameObject);
            
            StateMachineManager.instance.playerCamera.gameObject.SetActive(false);
            StateMachineManager.instance.boardCamera.gameObject.SetActive(true);
            StateMachineManager.instance.theFiveButtons.gameObject.SetActive(true);
            
            StateMachineManager.instance.buttonCoin.gameObject.SetActive(false);
            StateMachineManager.instance.buttonCrystal.gameObject.SetActive(false);
            StateMachineManager.instance.buttonHeath.gameObject.SetActive(false);
            StateMachineManager.instance.buttonSolidity.gameObject.SetActive(false);
            StateMachineManager.instance.buttonCronos.gameObject.SetActive(false);
            StateMachineManager.instance.buttonGold.gameObject.SetActive(false);
            
            StateMachineManager.instance.theBoss.SetActive(true);
            
            //StartCoroutine(Lines());
        }
        
        public static IEnumerator Lines()
        {
            yield return new WaitForSeconds(2f);
            H_Lines.instance.currentLine = H_Lines.LinesPhase.h1;
            
            H_Lines.instance.currentLine = H_Lines.LinesPhase.h2;
            
            H_Lines.instance.currentLine = H_Lines.LinesPhase.h3;
            
            H_Lines.instance.currentLine = H_Lines.LinesPhase.h4;
            
            H_Lines.instance.currentLine = H_Lines.LinesPhase.h5;
            
            H_Lines.instance.currentLine = H_Lines.LinesPhase.h6;
            
            //H_Lines.instance.currentLine = H_Lines.LinesPhase.h0;
        }
    }
}

