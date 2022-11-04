using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;
using Hexlibrium;

namespace HEXLIBRIUM
{
    public class H08 : State
    {
        public void OnEnable()
        {
            StateMachineManager.instance.playerCamera.gameObject.SetActive(false);
            StateMachineManager.instance.boardCamera.gameObject.SetActive(true);
            StateMachineManager.instance.theFiveButtons.gameObject.SetActive(true);
            
            StateMachineManager.instance.buttonCoin.gameObject.SetActive(true);
            StateMachineManager.instance.buttonCrystal.gameObject.SetActive(true);
            StateMachineManager.instance.buttonHeath.gameObject.SetActive(true);
            StateMachineManager.instance.buttonSolidity.gameObject.SetActive(true);
            StateMachineManager.instance.buttonCronos.gameObject.SetActive(true);
            StateMachineManager.instance.buttonGold.gameObject.SetActive(true);
           
            
           
            StartCoroutine(Lines());
        }
        public static IEnumerator Lines()
        {
            yield return new WaitForSeconds(2f);
            H_Lines.instance.currentLine = H_Lines.LinesPhase.h0;
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
            yield return new WaitForSeconds(2f);
            H_Lines.instance.currentLine = H_Lines.LinesPhase.h7;

        }
    }
}
