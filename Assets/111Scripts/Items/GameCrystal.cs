using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Hexlibrium;
using UnityEngine;
using UnityEngine.UI;
using HEXLIBRIUM;


namespace HEXLIBRIUM
{
    public class GameCrystal : MonoBehaviour
    {
        public static Action<bool, GameCrystal> CollisionDetected;

        public int crystalAmount = 1;
        public bool isFullHeal;

        public GameObject pickupEffect;

        public int soundToPlay;

        // [SerializeField] public Image getImage;
        // [SerializeField] public Image setImage;
        // [SerializeField] public Button button;

        private static bool currentBool = false;
        
        public static GameCrystal instance;

        public bool deployed;
        
        

        // Start is called before the first frame update
        void Start()
        {
            instance = this;
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter(Collider other)
        {
            // getImage.gameObject.SetActive(true);
            // button.interactable = true;
            if (other.tag == "Player" && !deployed)
            {
                UIManager.instance.RedGreen(true, "green");
            }
        }

        private void OnTriggerStay(Collider other)
        {
            // if (!other.CompareTag("Player")) return;
            //
            // CollisionDetected?.Invoke(false, this);
            
      
            //currentBool = true;
            
            
            // if (UIManager.currentBool == true && other.CompareTag("Player") )
            // {
                
            if (other.CompareTag("Player") )
            {
                Debug.Log("1");
                //StateMachineManager.instance.OnStateEnteredHandler(this.gameObject);

                if (GameManager.instance.currentCrystals < 12)
                {
                    
                    Debug.Log("2");
                    // getImage.gameObject.SetActive(false);
                    // button.interactable = false;
                    
                    UIManager.instance.RedGreen(false, "green");
                    Debug.Log("3");

                    Destroy(gameObject);
                    InventoryManager.instance.AddCrystal(crystalAmount);
                    Debug.Log("4");


                    // if (isFullHeal)
                    // {
                    //     InventoryManager.instance.ResetHealth();
                    // }
                    // else
                    // {
                    //     // InventoryManager.instance.AddCrystal(crystalAmount);
                    //     InventoryManager.instance.AddCrystal(gameObject);
                    // }

                    Instantiate(pickupEffect, transform.position, transform.rotation);
                    AudioManager.instance.PlaySFX(soundToPlay);
                }
                
                if(GameManager.instance.currentCrystals == 12)
                {
                    StateMachineManager.instance.ChangeState("H03");
                }

                UIManager.currentBool = false;
            }
            
       
        }
        
        private void OnTriggerExit(Collider other)
        {
            // if (!other.CompareTag("Player")) return;
            //
            // CollisionDetected?.Invoke(false, this);
            
            // getImage.gameObject.SetActive(false);
            // button.interactable = false;

            if (other.tag == "Player" && !deployed)
            {


                // getImage.gameObject.SetActive(false);
                // button.interactable = false;

                UIManager.instance.RedGreen(false, "green");
            }
        }

  

 
    }
}