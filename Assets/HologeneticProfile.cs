using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cysharp.Threading.Tasks;
using UnityEngine;
using MoralisUnity;
using MoralisUnity.Web3Api.Models;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using JetBrains.Annotations;
using Pixelplacement;
using TMPro;

using UnityEngine.UI;


namespace HEXLIBRIUM
{
    

public class HologeneticProfile : MonoBehaviour
{
    public Action<string> UploadButtonPressed;
    
    [SerializeField] private TMP_InputField nameInput;
    [SerializeField] private TMP_InputField email;
    [SerializeField] private Image image;

    [SerializeField] private TMP_InputField dateInput;
    [SerializeField] private TMP_InputField placeInput;
    [SerializeField] private TMP_InputField timeInput;
    
    [SerializeField] private TMP_InputField status;
    [SerializeField] private Button uploadButton;
    
    private float time;
    private float timeCounter;
    
    // Start is called before the first frame update
    void Start()
    {
        
        var givenDateTime = new DateTime(1995, 8, 26);
        //Console.Log(givenDateTime);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
}