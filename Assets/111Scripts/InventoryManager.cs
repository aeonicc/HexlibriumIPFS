using System.Collections;
using System.Collections.Generic;
using Hexlibrium;
using UnityEngine;
using UnityEngine.UI;

namespace HEXLIBRIUM
{
    public class InventoryManager : MonoBehaviour
    {
        public static InventoryManager instance;

        public int currentCrystal =0;
        public int maxCrystal =12;

        public float invincibleLength = 2f;
        private float invincCounter;

        public Sprite[] crystalBarImages;

        public int hurtSound;

        public GameCrystal gameCrystal;

        public GameObject objectCrystal;

        private GameObject buttonCrystal;

        private List<GameObject> crystalList;
        //private static List<Object[]> crystalArray;

        private void Awake()
        {
            instance = this;
        }

        // Start is called before the first frame update
        void Start()
        {
            ResetHealth();

            //crystalArray[0][0];
        }

        // Update is called once per frame
        void Update()
        {
            //  if (invincCounter > 0)
            //  {
            //     invincCounter -= Time.deltaTime;
            //
            //     for (int i = 0; i < PlayerController.instance.playerPieces.Length; i++)
            //     {
            //         if (Mathf.Floor(invincCounter * 5f) % 2 == 0)
            //         {
            //             PlayerController.instance.playerPieces[i].SetActive(true);
            //         }
            //         else
            //         {
            //             PlayerController.instance.playerPieces[i].SetActive(false);
            //         }
            //
            //
            //         if (invincCounter <= 0)
            //         {
            //             PlayerController.instance.playerPieces[i].SetActive(true);
            //         }
            //     }
            // }
            
            //GameCrystal.CollisionDetected += ShowGetButton;
        }

        // private void ShowGetButton(bool collided, GameCrystal collidedRune)
        // {
        //     if (collided)
        //     {
        //         Destroy(gameObject);
        //
        //         if (gameCrystal.isFullHeal)
        //         {
        //             InventoryManager.instance.ResetHealth();
        //         }
        //         else
        //         {
        //             InventoryManager.instance.AddHealth(gameCrystal.crystalAmount);
        //         }
        //
        //         // Instantiate(pickupEffect, transform.position, transform.rotation);
        //         // AudioManager.instance.PlaySFX(soundToPlay);
        //         
        //         //runePanel.Fill(collidedRune.title, "x" + collidedRune.amount, collidedRune.spriteRenderer.sprite);
        //         //runePanel.gameObject.SetActive(true);
        //
        //         //_gameManager.currentRune = collidedRune;
        //     }
        //     else
        //     {
        //         //runePanel.gameObject.SetActive(false);
        //     }
        // }
   
            
        // public void DropCrystal()
        // {
        //  
        //     
        //     // if (CollisionDetected?.Invoke(false, this);)
        //     // {
        //         // if (invincCounter <= 0)
        //         // {
        //         currentCrystal--;
        //         Instantiate(objectCrystal, transform.position, transform.rotation);
        //         //AudioManager.instance.PlaySFX(soundToPlay);
        //
        //         if (currentCrystal <= 0)
        //         {
        //             currentCrystal = 0;
        //             //GameManager.instance.Respawn();
        //         }
        //         else
        //         {
        //             PlayerController.instance.Knockback();
        //             invincCounter = invincibleLength;
        //         }
        //
        //         UpdateUI();
        //
        //         AudioManager.instance.PlaySFX(hurtSound);
        //         //}
        //     //}
        // }

        public void ResetHealth()
        {
            //currentCrystal = maxCrystal;

            UIManager.instance.healthImage.enabled = true;

            UpdateUI();
        }

        public void AddCrystal(int amountCrystal)
        {
            
            // public void AddCrystal(GameObject crystal)
            // {
                
                //crystalList.Add(crystal);
                
            //currentCrystal ++;
            //currentCrystal++;
            
            //crystal.SetActive(false);
            GameManager.instance.currentCrystals += amountCrystal;
            currentCrystal += amountCrystal;

            //currentCrystal++;

            if (currentCrystal > maxCrystal)
            {
               
                
                currentCrystal = maxCrystal;

                
            }

            UpdateUI();
        }

        public void UpdateUI()
        {
            UIManager.instance.crystalText.text = currentCrystal.ToString();

            if (currentCrystal is < 13 and >= 0)
            {
                UIManager.instance.crystalImage.sprite = crystalBarImages[currentCrystal];
            }
            else
            {
                UIManager.instance.crystalImage.enabled = false;
            }
            
            /*
            switch (currentCrystal)
            {
                case 12:
                    UIManager.instance.crystalImage.sprite = crystalBarImages[12];
                    break;
                
                case 11:
                    UIManager.instance.crystalImage.sprite = crystalBarImages[11];
                    break;

                case 10:
                    UIManager.instance.crystalImage.sprite = crystalBarImages[10];
                    break;

                case 9:
                    UIManager.instance.crystalImage.sprite = crystalBarImages[9];
                    break;

                case 8:
                    UIManager.instance.crystalImage.sprite = crystalBarImages[8];
                    break;

                case 7:
                    UIManager.instance.crystalImage.sprite = crystalBarImages[7];
                    break;

                case 6:
                    UIManager.instance.crystalImage.sprite = crystalBarImages[6];
                    break;

                case 5:
                    UIManager.instance.crystalImage.sprite = crystalBarImages[5];
                    break;
                
                case 4:
                    UIManager.instance.crystalImage.sprite = crystalBarImages[4];
                    break;

                case 3:
                    UIManager.instance.crystalImage.sprite = crystalBarImages[3];
                    break;

                case 2:
                    UIManager.instance.crystalImage.sprite = crystalBarImages[2];
                    break;

                case 1:
                    UIManager.instance.crystalImage.sprite = crystalBarImages[1];
                    break;

                case 0:
                    UIManager.instance.crystalImage.sprite = crystalBarImages[0];
                    break;

                case -1:
                    UIManager.instance.crystalImage.enabled = false;
                    break;
                
             
            }
            */
        }

        public void PlayerKilled()
        {
            currentCrystal = 0;
            UpdateUI();

            AudioManager.instance.PlaySFX(hurtSound);
        }
    }
}