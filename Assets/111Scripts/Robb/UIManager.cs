using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

using System;
using System.Collections.Generic;
using System.Linq;
using MoralisUnity;
using MoralisUnity.Web3Api.Models;
using UnityEngine;
using UnityEngine.UI;

using System.Collections;
using Cysharp.Threading.Tasks.Triggers;
using Hexlibrium;
using MoralisUnity;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace HEXLIBRIUM
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager instance;

        public Image blackScreen;
        public float fadeSpeed = 2f;
        public bool fadeToBlack, fadeFromBlack;
        
        public Text healthText;
        public Image healthImage;

        public Button crystalButton;
        public TextMeshProUGUI crystalText;
        public Image crystalImage;


        public Button coinButton;
        public TextMeshProUGUI coinText;
        public Image coinGetImage;
        public Image coinSetImage;
        public TextMeshProUGUI mintCoinText;
        
        public Button yinyangButton;
        public TextMeshProUGUI yinyangText;
        public Image yinyangGetImage;
        public Image yinyangSetImage;
        public TextMeshProUGUI mintyinyangText;
        
        public Button powerButton;
        public TextMeshProUGUI powerText;
        public Image powerGetImage;
        public Image powerSetImage;
        public TextMeshProUGUI mintkeyText;
        
        public TextMeshProUGUI timeText;
        
        public GameObject pauseScreen, optionsScreen;
        public Slider musicVolSlider, sfxVolSlider;
        public string levelSelect, mainMenu;

        private StateMachineManager _stateMachineManager;
        private GameCoin gameCoin;
        
        public static bool currentBool = false;

        //
        public Button button;
        public Image redButton;
        public Image greenButton;
        
        
        
        //inventory
        [Header("UI Elements")]
        
        // //[SerializeField] private GameObject itemPrefab;
        // [SerializeField] private GridLayoutGroup itemsGrid;

        private int _currentItemsCount;
        
        // //inventory panel
        // [SerializeField] public string itemInput;
        // [SerializeField] public string itemDescriptionInput;
        // [SerializeField] public Sprite imageInput;
        //inventory panel
        // [SerializeField] private TextMeshProUGUI itemName;
        // [SerializeField] private TextMeshProUGUI itemDescription;
        // [SerializeField] private Image itemImage;

        // private MetaverseItem currentMetaverseItem;
        // private GameExp currentExp;
        //
        private void Awake()
        {
            instance = this;
            
            //gameCoin = GetComponent<GameCoin>();
        }

        // Start is called before the first frame update
        void Start()
        {
            coinButton.interactable = false;
        }

        // Update is called once per frame
        void Update()
        {
            if (fadeToBlack)
            {
                blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b,
                    Mathf.MoveTowards(blackScreen.color.a, 1f, fadeSpeed * Time.deltaTime));

                if (blackScreen.color.a == 1f)
                {
                    fadeToBlack = false;
                }
            }

            if (fadeFromBlack)
            {
                blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b,
                    Mathf.MoveTowards(blackScreen.color.a, 0f, fadeSpeed * Time.deltaTime));

                if (blackScreen.color.a == 0f)
                {
                    fadeFromBlack = false;
                }
            }
            
            // GameItem.CollisionDetected += ShowItemPanel;
            // GameExp.CollisionDetected += ShowExpPanel;
            // MetaverseItem.CollisionDetected += ShowMetaverseItemPanel;
            //GameCoin.CollisionDetected += ShowCoinPanel;
        }

        public void Resume()
        {
            GameManager.instance.PauseUnpause();
        }

        public void OpenOptions()
        {
            optionsScreen.SetActive(true);
        }

        public void CloseOptions()
        {
            optionsScreen.SetActive(false);
        }

        public void LevelSelect()
        {
            SceneManager.LoadScene(levelSelect);
            Time.timeScale = 1f;
        }

        public void MainMenu()
        {
            SceneManager.LoadScene(mainMenu);
            Time.timeScale = 1;
        }

        public void SetMusicLevel()
        {
            AudioManager.instance.SetMusicLevel();
        }

        public void SetSFXLevel()
        {
            AudioManager.instance.SetSFXLevel();
        }
        
        public void Fill(string itmName, string itmDesc, Sprite itmSprite)
        {
            // itemName.text = itmName;
            // itemDescription.text = itmDesc;
            // itemImage.sprite = itmSprite;
        }
        
        // private void ShowItemPanel(bool collided, GameItem collidedItem)
        // {
        //     if (collided)
        //     {
        //         Fill(collidedItem.metadataObject.name, collidedItem.metadataObject.description, collidedItem.spriteRenderer.sprite);
        //         gameObject.SetActive(true);
        //
        //         currentGameItem = collidedItem;
        //     }
        //     else
        //     {
        //         gameObject.SetActive(false);
        //     }
        // }
        //
        // private void ShowExpPanel(bool collided, GameExp collidedExp)
        // {
        //     if (collided)
        //     {
        //         Fill(collidedExp.title, "x" + collidedExp.amount, collidedExp.spriteRenderer.sprite);
        //         gameObject.SetActive(true);
        //
        //         currentExp = collidedExp;
        //     }
        //     else
        //     {
        //         gameObject.SetActive(false);
        //     }
        // }
        //
        // private void ShowMetaverseItemPanel(bool collided, MetaverseItem collidedMetaverseItem)
        // {
        //     if (collided)
        //     {
        //         Fill(collidedMetaverseItem.title, "x" + collidedMetaverseItem.amount, collidedMetaverseItem.spriteRenderer.sprite);
        //         gameObject.SetActive(true);
        //
        //         currentMetaverseItem = collidedMetaverseItem;
        //     }
        //     else
        //     {
        //         gameObject.SetActive(false);
        //     }
        // }
        
        private void ShowCoinPanel(bool collided, GameCoin collidedGameCoin)
        {
            if (collided)
            {
                //Fill(collidedGameCoin.title, "x" + collidedGameCoin.amount, collidedGameCoin.spriteRenderer.sprite);
                gameObject.SetActive(true);
        
                //currentMetaverseItem = collidedMetaverseItem;
            }
            else
            {
                gameObject.SetActive(false);
            }
        }

        public void ActivateButton()
        {
           
            coinButton.interactable = true;
            coinGetImage.gameObject.SetActive(true);
            coinText.gameObject.SetActive(true);
            
        }
        
        public void TriggerBool()
        {
            Debug.Log("activated trigger bool");
            if (!currentBool)
            {
                currentBool = true;
            }
            
        }

        public void TriggerBoolNegative()
        {
            if (currentBool)
            {
                currentBool = false;
            }
        }

        public void RedGreen(bool active, string redGreen)
        {
            Debug.Log("RedGreen Activated");
            switch (redGreen)
            {
                case "green":
                    greenButton.gameObject.SetActive(active);
                    break;
                case "red":
                    redButton.gameObject.SetActive(active);
                    break;
            }
            
            button.interactable = active;
        }
        
  
        
        

    }

}