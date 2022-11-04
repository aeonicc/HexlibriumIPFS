using System.Numerics;
using Cysharp.Threading.Tasks;
using Hexlibrium;
using MoralisUnity;
using Nethereum.Hex.HexTypes;
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

using System.IO;
using Unity.VisualScripting;
using State = Pixelplacement.State;

//using UnityEngine.InputSystem;

namespace HEXLIBRIUM
{
    public class RandomNumberEvent : MoralisObject
    {
        public int d5Value { get; set; }
        
        public int result { get; set; }
        
        public RandomNumberEvent() : base("RandomNumberEvent") {}
    }

    public class MintingRandomNumber : State
    {
        
        //2 elevado a 64 é igual a 18.446.744.073.709.551.616
        //public uint d5Value;
        
        [Header("WalletConnect")] 
        [SerializeField] private WalletConnect walletConnect;
        
        [Header("Hexagon Contract Data")]
   
        // public static string contractAddress = " 0x6844af9F78F9FEc9739b219054883d98F95cBE1D";
        // public static string contractAbi = "[{\"inputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"constructor\"},{\"inputs\":[],\"name\":\"getRandomNumber\",\"outputs\":[{\"internalType\":\"bytes32\",\"name\":\"requestId\",\"type\":\"bytes32\"}],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"owner\",\"outputs\":[{\"internalType\":\"address payable\",\"name\":\"\",\"type\":\"address\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"bytes32\",\"name\":\"\",\"type\":\"bytes32\"}],\"name\":\"randomMap\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"randomResult\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"bytes32\",\"name\":\"requestId\",\"type\":\"bytes32\"},{\"internalType\":\"uint256\",\"name\":\"randomness\",\"type\":\"uint256\"}],\"name\":\"rawFulfillRandomness\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"\",\"type\":\"address\"}],\"name\":\"requestMap\",\"outputs\":[{\"internalType\":\"bytes32\",\"name\":\"\",\"type\":\"bytes32\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"userProvidedSeed\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"userRandomNumber\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"withdrawLink\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"}]";
        //transact = 0x289166e850fdb5728351fe27bcc387d7abda4a1e4ea23866c22b0385fa374f2d

        public static string contractAddress = "0x26ACEf3c0D1cA4b0186b5E28d3cD03805243bfb3";
        public static string contractAbi = "[{\"inputs\":[{\"internalType\":\"address\",\"name\":\"have\",\"type\":\"address\"},{\"internalType\":\"address\",\"name\":\"want\",\"type\":\"address\"}],\"name\":\"OnlyCoordinatorCanFulfill\",\"type\":\"error\"},{\"anonymous\":false,\"inputs\":[{\"indexed\":true,\"internalType\":\"uint256\",\"name\":\"requestId\",\"type\":\"uint256\"},{\"indexed\":true,\"internalType\":\"uint256\",\"name\":\"result\",\"type\":\"uint256\"}],\"name\":\"DiceLanded\",\"type\":\"event\"},{\"anonymous\":false,\"inputs\":[{\"indexed\":true,\"internalType\":\"uint256\",\"name\":\"requestId\",\"type\":\"uint256\"},{\"indexed\":true,\"internalType\":\"address\",\"name\":\"roller\",\"type\":\"address\"}],\"name\":\"DiceRolled\",\"type\":\"event\"},{\"anonymous\":false,\"inputs\":[{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"d5Value\",\"type\":\"uint256\"}],\"name\":\"RandomNumber\",\"type\":\"event\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"consumerAddress\",\"type\":\"address\"}],\"name\":\"addConsumer\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"receivingWallet\",\"type\":\"address\"}],\"name\":\"cancelSubscription\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint256\",\"name\":\"requestId\",\"type\":\"uint256\"},{\"internalType\":\"uint256[]\",\"name\":\"randomWords\",\"type\":\"uint256[]\"}],\"name\":\"rawFulfillRandomWords\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"consumerAddress\",\"type\":\"address\"}],\"name\":\"removeConsumer\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"rollDice\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"requestId\",\"type\":\"uint256\"}],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint256\",\"name\":\"amount\",\"type\":\"uint256\"}],\"name\":\"topUpSubscription\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint256\",\"name\":\"amount\",\"type\":\"uint256\"},{\"internalType\":\"address\",\"name\":\"to\",\"type\":\"address\"}],\"name\":\"withdraw\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint64\",\"name\":\"subscriptionId\",\"type\":\"uint64\"}],\"stateMutability\":\"nonpayable\",\"type\":\"constructor\"},{\"inputs\":[],\"name\":\"callNumberResult\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"d5Value\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"player\",\"type\":\"address\"}],\"name\":\"house\",\"outputs\":[{\"internalType\":\"string\",\"name\":\"\",\"type\":\"string\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"\",\"type\":\"address\"}],\"name\":\"s_results\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"}],\"name\":\"s_rollers\",\"outputs\":[{\"internalType\":\"address\",\"name\":\"\",\"type\":\"address\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"ss_results\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"}],\"stateMutability\":\"view\",\"type\":\"function\"}]";
        
        //Database Queries
        public MoralisQuery<RandomNumberEvent> _getEventsQuery;
        public MoralisLiveQueryCallbacks<RandomNumberEvent> _queryCallbacks;
        
        [Header("Main Elements")]
        //[SerializeField] private PasswordPanel passwordPanel;
        // [SerializeField] private GameObject correctPanel;
        // [SerializeField] private GameObject incorrectPanel;
        
        [Header("Other")]
        [SerializeField] private TextMeshProUGUI statusLabel;

        //private bool _listening;
        
        // Only for Editor using
        private bool _responseReceived;
        private bool _responseResult;


        //TOPIC=Game_created(address, uint256, uint256)
        
        // def main():
        // load_dotenv()
        // account = accounts.load(os.environ['DEPLOY_ACCOUNT'])
        // GuessNumber.deploy(os.environ['VRF_POLY'],os.environ['LINK_POLY'],os.environ['KEY_HASH_POLY'], 0.0001*(10**18),{'from':account})
        // deployments = len(GuessNumber)
        // print(f"number of deployments {deployments}, address of last deployment {GuessNumber[deployments-1].address}")
        
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

        public string respp;

        private void Awake()
        {
            //var randomNumberEvent = GetComponent<RandomNumberEvent>();
        }

        private void OnEnable()
        {
            _stateMachineManager = GetComponentInParent<StateMachineManager>(); // We assume we are under GameManager
           SubscribeToDatabaseEvents();
           
           button.gameObject.SetActive(true);
        }

        private void OnDisable()
        {
           
        }

        private void Start()
        {
            PickUpDice(valueID);
            
        }

        private void Update()
        {
            //Debug.Log(contractAbi.inputs);
            
            Debug.Log(_getEventsQuery);
            Debug.Log(_queryCallbacks);
            Debug.Log(_responseResult);
            // Debug.Log(d5Value);
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
            
            //numberText = tokenID.ToString();
            //_listening = true;
           
            
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

            // Set gas estimate
            HexBigInteger value = new HexBigInteger(0);
            HexBigInteger gas = new HexBigInteger(0);
            HexBigInteger gasPrice = new HexBigInteger(0);

            respp = await Moralis.ExecuteContractFunction(contractAddress, contractAbi, "callNumberResult", parameters, value, gas, gasPrice);

            //using (StreamReader sr = new StreamReader(contractAbi))
            //{
                
                
                
                // string line;
                // // Read and display lines from the file until the end of
                // // the file is reached.
                // while ((line = sr.ReadLine()) != null)
                // {
                //     Console.WriteLine(line);
                // }
            //}
            //StartCoroutine(DoSomething());

            //string res = resp.
            
            
            // var readOptions = {
            //     contractAddress: '0xc02aaa39b223fe8d0a0e5c4f27ead9083c756cc2',
            //     functionName: 'name',
            //     abi: ABI,
            // };

            // var message = await Moralis.ExecuteContractFunction(callNumberResult);
            // Debug.Log(message);
            
           
            
            return respp;
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
    
        private async void SubscribeToDatabaseEvents()
        {
            _getEventsQuery = await Moralis.GetClient().Query<RandomNumberEvent>();
            _queryCallbacks = new MoralisLiveQueryCallbacks<RandomNumberEvent>();

            _queryCallbacks.OnUpdateEvent += HandleContractEventResponse;
           
            MoralisLiveQueryController.AddSubscription<RandomNumberEvent>("RandomNumberEvent", _getEventsQuery, _queryCallbacks);
            
            
        }
        
   
        
        public void HandleContractEventResponse(RandomNumberEvent newEvent, int requestId)
        {
            var _var = newEvent.result;
            Debug.Log(_var);
            Debug.Log(requestId);
            
            statusLabel.text = _var.ToString();
            
            //return newEvent.d5Value;

        }

        private IEnumerator DoSomething() //bool result
        {
            yield return new WaitForSeconds(5f);
            //var response = CoRollDice();

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