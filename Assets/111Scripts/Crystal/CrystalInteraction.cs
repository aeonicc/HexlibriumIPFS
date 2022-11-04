using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrystalInteraction : MonoBehaviour
{
    [SerializeField] private bool HasBeenCollected = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !HasBeenCollected)
        {
            Collect();
        }
    }

    private void Collect()
    {
        Debug.Log("Player entered crystal");
        HasBeenCollected = true;
    }
}
 