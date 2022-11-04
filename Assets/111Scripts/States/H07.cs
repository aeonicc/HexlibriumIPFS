using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;
using Hexlibrium;

namespace HEXLIBRIUM
{


    public class H07 : State
    {
        // Start is called before the first frame update
        void OnEnable()
        {
            StateMachineManager.instance.buttonCoin.gameObject.SetActive(true);
            StateMachineManager.instance.buttonCrystal.gameObject.SetActive(true);
            StateMachineManager.instance.buttonHeath.gameObject.SetActive(true);
            StateMachineManager.instance.buttonSolidity.gameObject.SetActive(true);
            StateMachineManager.instance.buttonCronos.gameObject.SetActive(true);
            StateMachineManager.instance.buttonGold.gameObject.SetActive(true);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
