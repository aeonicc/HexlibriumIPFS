using System;
using UnityEngine;

using UnityEngine;
using Pixelplacement;
using UnityEngine.UI;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Collections;
using HEXLIBRIUM;
using UnityEngine;
using UnityEngine.Networking;

namespace HEXLIBRIUM
{
    
}
public class LootBoxButton : MonoBehaviour
{
    public static Action Triggered;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Triggered?.Invoke();
        }
    }
    
    
}
