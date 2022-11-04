using System.Numerics;
using Cysharp.Threading.Tasks;
using Hexlibrium;
using MoralisUnity;
using Nethereum.Hex.HexTypes;
using Pixelplacement;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

using System;
using System.Collections;
using System.Numerics;
using Cysharp.Threading.Tasks;
using MoralisUnity;
using Nethereum.Hex.HexTypes;
using TMPro;
using UnityEngine;
using WalletConnectSharp.Unity;
// using State = Pixelplacement.State;

using Pixelplacement;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using WalletConnectSharp.Unity;

//using UnityEngine.InputSystem;

using System.IO;
using Newtonsoft.Json;

using System;
using System.Collections;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Triggers;
using UnityEngine;
using TMPro;

using MoralisUnity;
using MoralisUnity.Platform.Objects;
using MoralisUnity.Platform.Queries;
using Nethereum.Hex.HexTypes;
using UnityEngine.SceneManagement;


namespace HEXLIBRIUM
{
    public class MoriaGatesEvent : MoralisObject
    {
        public int result { get; set; }
        
        public MoriaGatesEvent() : base("MoriaGatesEvent") {}
    }
    public class GetRandomNumber : State
    {
        [Header("WalletConnect")] 
        [SerializeField] private WalletConnect walletConnect;
        
        [Header("Hexagon Contract Data")]
   
        // public static string contractAddress = " 0x6844af9F78F9FEc9739b219054883d98F95cBE1D";
        // public static string contractAbi = "[{\"inputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"constructor\"},{\"inputs\":[],\"name\":\"getRandomNumber\",\"outputs\":[{\"internalType\":\"bytes32\",\"name\":\"requestId\",\"type\":\"bytes32\"}],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"owner\",\"outputs\":[{\"internalType\":\"address payable\",\"name\":\"\",\"type\":\"address\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"bytes32\",\"name\":\"\",\"type\":\"bytes32\"}],\"name\":\"randomMap\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"randomResult\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"bytes32\",\"name\":\"requestId\",\"type\":\"bytes32\"},{\"internalType\":\"uint256\",\"name\":\"randomness\",\"type\":\"uint256\"}],\"name\":\"rawFulfillRandomness\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"\",\"type\":\"address\"}],\"name\":\"requestMap\",\"outputs\":[{\"internalType\":\"bytes32\",\"name\":\"\",\"type\":\"bytes32\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"userProvidedSeed\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"userRandomNumber\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"withdrawLink\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"}]";
        //transact = 0x289166e850fdb5728351fe27bcc387d7abda4a1e4ea23866c22b0385fa374f2d

        public static string contractAddress = "0x26ACEf3c0D1cA4b0186b5E28d3cD03805243bfb3";
        public static string contractAbi = "[{\"inputs\":[{\"internalType\":\"address\",\"name\":\"have\",\"type\":\"address\"},{\"internalType\":\"address\",\"name\":\"want\",\"type\":\"address\"}],\"name\":\"OnlyCoordinatorCanFulfill\",\"type\":\"error\"},{\"anonymous\":false,\"inputs\":[{\"indexed\":true,\"internalType\":\"uint256\",\"name\":\"requestId\",\"type\":\"uint256\"},{\"indexed\":true,\"internalType\":\"uint256\",\"name\":\"result\",\"type\":\"uint256\"}],\"name\":\"DiceLanded\",\"type\":\"event\"},{\"anonymous\":false,\"inputs\":[{\"indexed\":true,\"internalType\":\"uint256\",\"name\":\"requestId\",\"type\":\"uint256\"},{\"indexed\":true,\"internalType\":\"address\",\"name\":\"roller\",\"type\":\"address\"}],\"name\":\"DiceRolled\",\"type\":\"event\"},{\"anonymous\":false,\"inputs\":[{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"d5Value\",\"type\":\"uint256\"}],\"name\":\"RandomNumber\",\"type\":\"event\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"consumerAddress\",\"type\":\"address\"}],\"name\":\"addConsumer\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"receivingWallet\",\"type\":\"address\"}],\"name\":\"cancelSubscription\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint256\",\"name\":\"requestId\",\"type\":\"uint256\"},{\"internalType\":\"uint256[]\",\"name\":\"randomWords\",\"type\":\"uint256[]\"}],\"name\":\"rawFulfillRandomWords\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"consumerAddress\",\"type\":\"address\"}],\"name\":\"removeConsumer\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"rollDice\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"requestId\",\"type\":\"uint256\"}],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint256\",\"name\":\"amount\",\"type\":\"uint256\"}],\"name\":\"topUpSubscription\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint256\",\"name\":\"amount\",\"type\":\"uint256\"},{\"internalType\":\"address\",\"name\":\"to\",\"type\":\"address\"}],\"name\":\"withdraw\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint64\",\"name\":\"subscriptionId\",\"type\":\"uint64\"}],\"stateMutability\":\"nonpayable\",\"type\":\"constructor\"},{\"inputs\":[],\"name\":\"callNumberResult\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"d5Value\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"player\",\"type\":\"address\"}],\"name\":\"house\",\"outputs\":[{\"internalType\":\"string\",\"name\":\"\",\"type\":\"string\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"\",\"type\":\"address\"}],\"name\":\"s_results\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"}],\"name\":\"s_rollers\",\"outputs\":[{\"internalType\":\"address\",\"name\":\"\",\"type\":\"address\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"ss_results\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"}],\"stateMutability\":\"view\",\"type\":\"function\"}]";
        
        
        [Header("Components")]
        private StateMachineManager _stateMachineManager;
        //private GameInput _gameInput;

        [SerializeField] public Button button;
        [SerializeField] public TextMeshProUGUI statusText;
        [SerializeField] public TextMeshProUGUI numberText;
        [SerializeField] public Image getImage;
        [SerializeField] public Image setImage;

        [SerializeField] private int valueID = 1;

        private BigInteger _tokenID;
        
        private MoralisQuery<MoriaGatesEvent> _getEventsQuery;
        private MoralisLiveQueryCallbacks<MoriaGatesEvent> _queryCallbacks;
        
        public static GetRandomNumber instance;

        public int randomNumberResult;

        private void Awake()
        {
            instance = this;
        }

        private void OnEnable()
        {
            _stateMachineManager = GetComponentInParent<StateMachineManager>(); // We assume we are under GameManager
            
            SubscribeToDatabaseEvents();
            
            PickUpDice(valueID);
            
            button.gameObject.SetActive(true);
        }

        private void OnDisable()
        {
           
        }

        public void Update()
        {
            numberText.text = randomNumberResult.ToString();
        }

        private async void SubscribeToDatabaseEvents()
        {
            _getEventsQuery = await Moralis.GetClient().Query<MoriaGatesEvent>();
            _queryCallbacks = new MoralisLiveQueryCallbacks<MoriaGatesEvent>();

            _queryCallbacks.OnUpdateEvent += HandleContractEventResponse;

            MoralisLiveQueryController.AddSubscription<MoriaGatesEvent>("MoriaGatesEvent", _getEventsQuery, _queryCallbacks);
        }
        
        public void HandleContractEventResponse(MoriaGatesEvent newEvent, int requestId)
        {
            
            //if (!_listening) return;

            // You will find this a bit different from the video. It's a quality improvement for Editor testing. Functionality continues in ShowResponsePanel() :)
            //if (Application.isEditor)
            //{
                //_responseResult = newEvent.result;
                //_responseReceived = true;

                //return;
            //}

            //ShowResponsePanel(newEvent.result);

            randomNumberResult  = newEvent.result;
            Debug.Log(randomNumberResult);
        }

        #region PRIVATE_METHODS

        private async void PickUpDice(int vID)
        {
            statusText.text = "Please confirm transaction in your wallet";
            var result = await RollDice(vID);

            if (result is null)
            {
                statusText.text = "Transaction failed";
                //LastActiveState();
                return;
            }
        
            statusText.text = "Transaction completed!";
            Debug.Log(result);
            //numberText = tokenID.ToString();
            // nameLabel.text = _gameManager.currentMetaverseItem.metadataObject.name;
            // descriptionLabel.text = _gameManager.currentMetaverseItem.metadataObject.description;
            // imageLabel.sprite = _gameManager.currentMetaverseItem.spriteRenderer.sprite;
        }
        
        private async UniTask<string> RollDice(int vID)
        {
            _tokenID = new BigInteger(vID);
            
            object[] parameters = {
                //_tokenID.ToString("x")
            };

            //int.Parse(contractAbi);

            // Set gas estimate
            HexBigInteger value = new HexBigInteger(0);
            HexBigInteger gas = new HexBigInteger(0);
            HexBigInteger gasPrice = new HexBigInteger(0);

            string resp = await Moralis.ExecuteContractFunction(contractAddress, contractAbi, "rollDice", parameters, value, gas, gasPrice);

            
            string json = JsonConvert.SerializeObject(contractAbi);
            
            //Data data = JsonConvert.DeserializeObject<Data>(json);
            
            // string json = JsonConvert.SerializeObject(new Data());
            // Data data = JsonConvert.DeserializeObject<Data>(json);
            
            // using (StreamReader sr = new StreamReader(contractAbi))
            // {
            //     sr.GetHashCode();
            //     // string line;
            //     // // Read and display lines from the file until the end of
            //     // // the file is reached.
            //     // while ((line = sr.ReadLine()) != null)
            //     // {
            //     //     Console.WriteLine(line);
            //     // }
            // }
            
            Debug.Log(json);

            return resp;
        }

        public void CopyContractAddress()
        {
            //numberText = contractAddress.CopyToClipboard();
            walletConnect.OpenMobileWallet();
        }

        public void CopyTokenId()
        {
            //tokenID.CopyToClipboard();
            walletConnect.OpenMobileWallet();
        }

        #endregion
        
        
        #region INPUT_SYSTEM_HANDLERS

        // private async void CancelTransaction(InputAction.CallbackContext obj)
        // {
        //     // Check out what we're doing to "cancel" the transaction:
        //     // https://ethereum.stackexchange.com/questions/31298/is-it-possible-to-cancel-a-transaction
        //     
        //     BigInteger amountValue = new BigInteger(0);
        //     
        //     object[] parameters = {
        //         amountValue.ToString("x")
        //     };
        //     
        //     HexBigInteger value = new HexBigInteger(0);
        //     HexBigInteger gas = new HexBigInteger(0);
        //     HexBigInteger gasPrice = new HexBigInteger(1); //Higher than "GetItem" transaction
        //     
        //     string resp = await Moralis.ExecuteContractFunction(GameManager.RuneContractAddress, GameManager.RuneContractAbi, "getExperience", parameters, value, gas, gasPrice);
        //     
        //     LastActiveState();
        // }

        #endregion
    }   
}