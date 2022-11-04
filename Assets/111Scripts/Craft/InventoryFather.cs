using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryFather : MonoBehaviour
{
    [SerializeField] private GameObject inventorySquareTemplate;
    [SerializeField] private GameObject NFTObj;

    private void Start()
    {
        Populate_Inventory();
    }

    public void Populate_Inventory()
    {
        for (var i = 0; i < 6; i++)
        {
            MakeSquare();
        }
    }

    public void MakeSquare()
    { 
        var Square = Instantiate(inventorySquareTemplate, gameObject.transform);
        Instantiate(NFTObj, Square.transform);
    }
}
