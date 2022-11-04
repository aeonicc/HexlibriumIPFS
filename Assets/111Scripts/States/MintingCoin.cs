using System.Numerics;
using Cysharp.Threading.Tasks;
using Hexlibrium;
using MoralisUnity;
using Nethereum.Hex.HexTypes;
using Pixelplacement;
using TMPro;
using UnityEngine;
//using UnityEngine.InputSystem;

namespace HEXLIBRIUM
{
  
    public class MintingCoin : State
    {
        [Header("Hexagon Contract Data")]
        public static string ContractAddress = "0xB19a0E6B3f5783B69A647B4e1489B726bBE3f32d"; 
        public static string ContractAbi = "[{\"inputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"constructor\"},{\"anonymous\":false,\"inputs\":[{\"indexed\":true,\"internalType\":\"address\",\"name\":\"owner\",\"type\":\"address\"},{\"indexed\":true,\"internalType\":\"address\",\"name\":\"spender\",\"type\":\"address\"},{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"value\",\"type\":\"uint256\"}],\"name\":\"Approval\",\"type\":\"event\"},{\"anonymous\":false,\"inputs\":[{\"indexed\":true,\"internalType\":\"address\",\"name\":\"from\",\"type\":\"address\"},{\"indexed\":true,\"internalType\":\"address\",\"name\":\"to\",\"type\":\"address\"},{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"value\",\"type\":\"uint256\"}],\"name\":\"Transfer\",\"type\":\"event\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"owner\",\"type\":\"address\"},{\"internalType\":\"address\",\"name\":\"spender\",\"type\":\"address\"}],\"name\":\"allowance\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"spender\",\"type\":\"address\"},{\"internalType\":\"uint256\",\"name\":\"amount\",\"type\":\"uint256\"}],\"name\":\"approve\",\"outputs\":[{\"internalType\":\"bool\",\"name\":\"\",\"type\":\"bool\"}],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"account\",\"type\":\"address\"}],\"name\":\"balanceOf\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"decimals\",\"outputs\":[{\"internalType\":\"uint8\",\"name\":\"\",\"type\":\"uint8\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"spender\",\"type\":\"address\"},{\"internalType\":\"uint256\",\"name\":\"subtractedValue\",\"type\":\"uint256\"}],\"name\":\"decreaseAllowance\",\"outputs\":[{\"internalType\":\"bool\",\"name\":\"\",\"type\":\"bool\"}],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint256\",\"name\":\"amount\",\"type\":\"uint256\"}],\"name\":\"getCoin\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"spender\",\"type\":\"address\"},{\"internalType\":\"uint256\",\"name\":\"addedValue\",\"type\":\"uint256\"}],\"name\":\"increaseAllowance\",\"outputs\":[{\"internalType\":\"bool\",\"name\":\"\",\"type\":\"bool\"}],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"name\",\"outputs\":[{\"internalType\":\"string\",\"name\":\"\",\"type\":\"string\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"symbol\",\"outputs\":[{\"internalType\":\"string\",\"name\":\"\",\"type\":\"string\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"totalSupply\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"to\",\"type\":\"address\"},{\"internalType\":\"uint256\",\"name\":\"amount\",\"type\":\"uint256\"}],\"name\":\"transfer\",\"outputs\":[{\"internalType\":\"bool\",\"name\":\"\",\"type\":\"bool\"}],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"from\",\"type\":\"address\"},{\"internalType\":\"address\",\"name\":\"to\",\"type\":\"address\"},{\"internalType\":\"uint256\",\"name\":\"amount\",\"type\":\"uint256\"}],\"name\":\"transferFrom\",\"outputs\":[{\"internalType\":\"bool\",\"name\":\"\",\"type\":\"bool\"}],\"stateMutability\":\"nonpayable\",\"type\":\"function\"}]";
        
        [Header("Components")]
        //[SerializeField] private Player player;
        private StateMachineManager _stateMachineManager;
        //private GameInput _gameInput;
        
        [Header("UI")]
        [SerializeField] private TextMeshProUGUI statusText;

        public GameObject gameObjCoin;
        public GameCoin gameCoin;

        [SerializeField] private int q = 100;
        
        #region UNITY_LIFECYCLE

        private void OnEnable()
        {
            _stateMachineManager = GetComponentInParent<StateMachineManager>(); // We assume we are under GameManager

            // _gameInput = new GameInput();
            // _gameInput.PickingUp.Enable();
            // _gameInput.PickingUp.Cancel.performed += CancelTransaction;
            //
            // player.input.EnableInput(false);
            
            // PickUpRune(dappManager.currentRune.amount);
            PickUpCoin(q);
        }

        private void OnDisable()
        {
            // _gameInput.PickingUp.Disable();
            // _gameInput.PickingUp.Cancel.performed -= CancelTransaction;
        }

        #endregion
        

        #region PRIVATE_METHODS

        private async void PickUpCoin(int qq)
        {
            statusText.text = "Please confirm transaction in your wallet";
        
            var result = await GetCoin(qq);

            if (result is null)
            {
                statusText.text = "Transaction failed";
                //LastActiveState();
                return;
            }
        
            statusText.text = "Transaction completed!";
            //Destroy(dappManager.currentRune.gameObject); // We don't need this item anymore
            Destroy(gameCoin); // We don't need this item anymore
            //LastActiveState();
        }
        
        private async UniTask<string> GetCoin(int qq)
        {
            BigInteger amountValue = new BigInteger(qq);
            
            object[] parameters = {
                amountValue.ToString("x")
            };

            // Set gas estimate
            HexBigInteger value = new HexBigInteger(0);
            HexBigInteger gas = new HexBigInteger(0);
            HexBigInteger gasPrice = new HexBigInteger(0);

            string resp = await Moralis.ExecuteContractFunction(ContractAddress, ContractAbi, "getCoin", parameters, value, gas, gasPrice);

            return resp;
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