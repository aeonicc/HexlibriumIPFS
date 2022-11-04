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
using MoralisUnity;
using Nethereum.Hex.HexTypes;
using Pixelplacement;
using TMPro;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using Hexlibrium;
using UnityEngine;
using Pixelplacement;



namespace HEXLIBRIUM
{
    

    public class H05 : State
    {
        private void OnEnable()
        {
            //StateMachineManager.instance.OnStateEnteredHandler(this.gameObject);
            
          
            StateMachineManager.instance.playerCamera.gameObject.SetActive(true);
            StateMachineManager.instance.boardCamera.gameObject.SetActive(false);
            StateMachineManager.instance.theFiveButtons.gameObject.SetActive(false);
        
            StateMachineManager.instance.buttonCoin.gameObject.SetActive(true);
            StateMachineManager.instance.buttonCrystal.gameObject.SetActive(true);
            StateMachineManager.instance.buttonHeath.gameObject.SetActive(true);
            StateMachineManager.instance.buttonSolidity.gameObject.SetActive(true);
            StateMachineManager.instance.buttonCronos.gameObject.SetActive(true);
            StateMachineManager.instance.buttonGold.gameObject.SetActive(true);
        
            //TimeController.instance.ActivateTimeChange();
            //BossController.instance.gameObject.SetActive(false);
        
            //StateMachineManager.instance.Hh04();
            
            
            
            StartCoroutine(CallYinYang());
            
        }
        
        public IEnumerator CallYinYang()
        {
            
            yield return new WaitForSeconds(4f);
            
            //Board.instance.YinYanForm();
            
            //TimeController.instance.ActivateTimeChange();
            
            //GameObject.FindGameObjectWithTag("MetaverseItem").GetComponent<MetaverseItem>().spriteRenderer.color = Color.white;
            
            //DappManager.instance.ChangeState("MintingMetaverseItem");
            //DappManager.instance.MintingMetaverseItem();
            
            StateMachineManager.instance.MintingMetaverseItem();
        }
    }
}

