using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
//using OpenCover.Framework.Model;
using Unity.VisualScripting;
using UnityEngine;

public class Crafter_Populator : MonoBehaviour
{
    public Dictionary<string, List<string>> CraftingList = new Dictionary<string, List<string>>();
    [SerializeField] private GameObject craftableObjTabPrefab;
    private ParametersOfTheCrafter _parametersOfTheCrafter;
    private int Counter = 0;
    private ParametersOfTheCrafter instance;
    
    // Start is called before the first frame update
    void Start()
    {
        instance = gameObject.GetComponent<ParametersOfTheCrafter>();
        instance.ItemNeeded = new List<string>{"aa", "bb", "cc"} ;
        instance.ItemNeededAmount = new List<string>{"1", "2", "3"};
        instance.ItemToBeCraftedName = "Helloo";
        var ListVar = new List<string>
            {instance.ItemToBeCraftedName, instance.ItemNeeded.ToString(), instance.ItemNeededAmount.ToString()};
        InstantiateIntoDictionary( ListVar,true);
        instance.ItemNeeded = new List<string>{"aa", "bb", "cc"};
        instance.ItemNeededAmount =  new List<string>{"1", "2", "3"};
        instance.ItemToBeCraftedName = "BleyBlers";
        ListVar = new List<string>
            {instance.ItemToBeCraftedName, instance.ItemNeeded.ToString(), instance.ItemNeededAmount.ToString()};
        InstantiateIntoDictionary( ListVar,true);        instance.ItemNeeded = new List<string>{"aa,", "bb,", "cc"};
        instance.ItemNeededAmount =  new List<string>{"1", "2", "3"};
        instance.ItemToBeCraftedName = "Haguruma";
        ListVar = new List<string>
            {instance.ItemToBeCraftedName, instance.ItemNeeded.ToString(), instance.ItemNeededAmount.ToString()};
        InstantiateIntoDictionary( ListVar,true);        ReadDictionaryAndInstantiate();
    }

    public void InstantiateIntoDictionary(List<string> instance, bool isCraftable)
    {
        CraftingList.Add("Key " + Counter + " " + isCraftable, new List<string>{instance[0], instance[1], instance[2]});
        Counter++;
    }

    public void ReadDictionaryAndInstantiate()
    {
        var crafterCounter = 0;
        foreach (var dict in CraftingList)
        {
            var ItemName = "";
            var ItemNeeded = new List<string>();
            var ItemNeededAmount = new List<string>();
            if (dict.Key.Contains("True"))
            {
                 ItemName = dict.Value[0].ToString();
                 ItemNeeded = dict.Value[1].ToString().Split(";").ToList();
                 ItemNeededAmount = dict.Value[2].ToString().Split(";").ToList();
                InstantiateDictObj(ItemName, ItemNeeded, ItemNeededAmount);
            }
            else
            {
                InstantiateDictObj(ItemName, new List<string>(), new List<string>());
            }
            
            crafterCounter++;
        }
    }

    private void InstantiateDictObj(string Name, List<string> needed, List<string> neededAmount)
    {
        var instance = Instantiate(craftableObjTabPrefab, gameObject.transform);
        instance.name = Name + "Crafter ";
        var Param = instance.GetComponent<ParametersOfTheCrafter>();
        Param.ItemToBeCraftedName = Name;
        Param.ItemNeeded = needed;
        Param.ItemNeededAmount = neededAmount;
    }

}

