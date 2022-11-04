using System;
using System.Collections;
using System.Collections.Generic;
using Hexlibrium;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

namespace HEXLIBRIUM
{

    public class Board : MonoBehaviour
    {
        [SerializeField] private GameCrystal gameCrystal;
        [SerializeField] private GameObject objectCrystal;

        // public static bool beforeBool = false;
        // public static bool afterBool = false;

        [SerializeField] public Image getImage;
        [SerializeField] public Image setImage;
        [SerializeField] public Button button;

        public int verifyCrystal;
        public GameObject[] hexTweeve;
        public int hexCounter;

        public int NumberOfBallGenerated;
        
        private bool cooldownButton = true;

        public static Board instance;
        // Start is called before the first frame update

        private void Awake()
        {
            instance = this;
        }

        void Start()
    {
         gameCrystal = objectCrystal.GetComponent<GameCrystal>();
        //gameCrystal = objectCrystal.transform.GetChild(0).GetComponent<GameCrystal>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            // other.gameObject.GetComponent<GameCrystal>().SetImage.gameObject.SetActive(true);
            // other.gameObject.GetComponent<GameCrystal>().button.interactable = true;
        // gameCrystal.SetImage.gameObject.SetActive(true);
        // gameCrystal.button.interactable = true;
        
        // GameObject.FindGameObjectWithTag("Crystal Button").transform.GetChild(1).gameObject.SetActive(true);
        // GameObject.FindGameObjectWithTag("Crystal Button").gameObject.GetComponent<Button>();
        
        // setImage.gameObject.SetActive(true);
        // button.interactable = true;
        
        UIManager.instance.RedGreen(true, "red");
        
        
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (UIManager.currentBool && other.CompareTag("Player"))
        {
            Debug.Log("Current Bool is true");
             if (InventoryManager.instance.currentCrystal > 0 && verifyCrystal <12)
             {
                 Debug.Log("ontriggerstayBoard button activated" );
                 //StartCoroutine(cooldown());
                 //UIManager.instance.TriggerBoolNegative();
                //UIManager.instance.RedGreen(true, "red");
                
                var instance = Instantiate(
                    objectCrystal,
                    hexTweeve[hexCounter].transform.GetChild(0).transform.position ,
                    hexTweeve[hexCounter].transform.GetChild(0).transform.rotation * Quaternion.Euler(90,0,0),
                    hexTweeve[hexCounter].transform.GetChild(0).transform);
                //var instance = Instantiate(objectCrystal, hexTweeve[hexCounter].transform);
                
                instance.GetComponent<GameCrystal>().deployed = false;
                //instance.transform.GetChild(0).GetComponent<GameCrystal>().deployed = false;
                
                InventoryManager.instance.AddCrystal(-1);


                verifyCrystal++;
                hexCounter++;

                if (verifyCrystal == 12)
                {
                    StartCoroutine(Reached12Crystals());
                }
             }

             UIManager.currentBool = false;

        }
        
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            //setImage.gameObject.SetActive(false);
            UIManager.instance.RedGreen(false, "red");
        }
    }
    
    public void YinYanForm()
    {
        TimeController.instance.ActivateTimeChange();
        GameObject.FindGameObjectWithTag("MetaverseItem").GetComponent<MetaverseItem>().spriteRenderer.color = Color.white;
        //DappManager.instance.ChangeState("MintingMetaverseItem");
        //DappManager.instance.MintingMetaverseItem();
    }
    
    private IEnumerator Reached12Crystals()
    {
        NumberOfBallGenerated++;
        verifyCrystal = 0;
        foreach (var Hex in hexTweeve)
        {
            yield return new WaitForSeconds(0.1f);
            Destroy(Hex.transform.GetChild(0).gameObject);
        }
        hexCounter = 0;
        
        Debug.Log("Reached12");
        //StateMachineManager.instance.OnStateEnteredHandler(this.gameObject);
        Debug.Log(this.gameObject);

        StateMachineManager.instance.ChangeState("H04");

        //YinYanForm();
    }
    
 

    private IEnumerator cooldown()
    {
            cooldownButton = false;
            yield return new WaitForSeconds(0.2f); 
            cooldownButton = true;
    }
    // public void TriggerBool()
    // {
    //     if (!UIManager.currentBool)
    //     {
    //         beforeBool = true;
    //     }
    //         
    // }
    
}
}