using System;
using System.Collections;
using System.Collections.Generic;
using Hexlibrium;
using UnityEngine;
using Pixelplacement;

namespace HEXLIBRIUM
{
    public class H01 : State
    {
        private void OnEnable()
        {
            StateMachineManager.instance.OnStateEnteredHandler(this.gameObject);
            
            StateMachineManager.instance.playerCamera.gameObject.SetActive(true);
            StateMachineManager.instance.boardCamera.gameObject.SetActive(false);
            StateMachineManager.instance.theFiveButtons.gameObject.SetActive(false);

            StateMachineManager.instance.buttonCoin.gameObject.SetActive(false);
            StateMachineManager.instance.buttonCrystal.gameObject.SetActive(false);
            StateMachineManager.instance.buttonHeath.gameObject.SetActive(false);
            StateMachineManager.instance.buttonSolidity.gameObject.SetActive(true);
            StateMachineManager.instance.buttonCronos.gameObject.SetActive(true);
            StateMachineManager.instance.buttonGold.gameObject.SetActive(false);

            StartCoroutine(Lines());
            
            
        }

        public static IEnumerator Lines()
        {
            yield return new WaitForSeconds(2f);
            H_Lines.instance.currentLine = H_Lines.LinesPhase.h1;
            yield return new WaitForSeconds(2f);
            H_Lines.instance.currentLine = H_Lines.LinesPhase.h2;
            yield return new WaitForSeconds(2f);
            H_Lines.instance.currentLine = H_Lines.LinesPhase.h3;
            yield return new WaitForSeconds(2f);
            H_Lines.instance.currentLine = H_Lines.LinesPhase.h4;
            yield return new WaitForSeconds(2f);
            H_Lines.instance.currentLine = H_Lines.LinesPhase.h5;
            yield return new WaitForSeconds(2f);
            H_Lines.instance.currentLine = H_Lines.LinesPhase.h6;
            yield return new WaitForSeconds(10f);
            H_Lines.instance.currentLine = H_Lines.LinesPhase.h0;

        }
    }
    
    
 
}