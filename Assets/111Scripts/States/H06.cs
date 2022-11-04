using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;
using Hexlibrium;

namespace HEXLIBRIUM
{



    public class H06 : State
    {
        private void OnEnable()
        {
            GameObject.FindGameObjectWithTag("MetaverseItem").GetComponent<MetaverseItem>().spriteRenderer.color = Color.white;
            TimeController.instance.ActivateTimeChange();
            
            StateMachineManager.instance.buttonCoin.gameObject.SetActive(true);
            StateMachineManager.instance.buttonCrystal.gameObject.SetActive(true);
            StateMachineManager.instance.buttonHeath.gameObject.SetActive(true);
            StateMachineManager.instance.buttonSolidity.gameObject.SetActive(true);
            StateMachineManager.instance.buttonCronos.gameObject.SetActive(true);
            StateMachineManager.instance.buttonGold.gameObject.SetActive(true);
            BossController.instance.DamageBoss();
            
            
            
            
            
        }

        
    }
}
