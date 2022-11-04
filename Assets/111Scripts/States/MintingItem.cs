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
  
    // Class which takes care to mint an ERC-721 token
    public class MintingItem : State
    {
        [Header("Hexagon Item Contract Data")]
        public static string ContractAddress = "0x9FC6988a3dE6F4b245D10d088C6Ed01d35A87790"; //erc721 NFT
        public static string ContractAbi = "[{\"inputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"constructor\"},{\"anonymous\":false,\"inputs\":[{\"indexed\":true,\"internalType\":\"address\",\"name\":\"owner\",\"type\":\"address\"},{\"indexed\":true,\"internalType\":\"address\",\"name\":\"approved\",\"type\":\"address\"},{\"indexed\":true,\"internalType\":\"uint256\",\"name\":\"tokenId\",\"type\":\"uint256\"}],\"name\":\"Approval\",\"type\":\"event\"},{\"anonymous\":false,\"inputs\":[{\"indexed\":true,\"internalType\":\"address\",\"name\":\"owner\",\"type\":\"address\"},{\"indexed\":true,\"internalType\":\"address\",\"name\":\"operator\",\"type\":\"address\"},{\"indexed\":false,\"internalType\":\"bool\",\"name\":\"approved\",\"type\":\"bool\"}],\"name\":\"ApprovalForAll\",\"type\":\"event\"},{\"anonymous\":false,\"inputs\":[{\"indexed\":true,\"internalType\":\"address\",\"name\":\"from\",\"type\":\"address\"},{\"indexed\":true,\"internalType\":\"address\",\"name\":\"to\",\"type\":\"address\"},{\"indexed\":true,\"internalType\":\"uint256\",\"name\":\"tokenId\",\"type\":\"uint256\"}],\"name\":\"Transfer\",\"type\":\"event\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"to\",\"type\":\"address\"},{\"internalType\":\"uint256\",\"name\":\"tokenId\",\"type\":\"uint256\"}],\"name\":\"approve\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"owner\",\"type\":\"address\"}],\"name\":\"balanceOf\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint256\",\"name\":\"tokenId\",\"type\":\"uint256\"}],\"name\":\"getApproved\",\"outputs\":[{\"internalType\":\"address\",\"name\":\"\",\"type\":\"address\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"string\",\"name\":\"tokenURI\",\"type\":\"string\"}],\"name\":\"getItem\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"}],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"owner\",\"type\":\"address\"},{\"internalType\":\"address\",\"name\":\"operator\",\"type\":\"address\"}],\"name\":\"isApprovedForAll\",\"outputs\":[{\"internalType\":\"bool\",\"name\":\"\",\"type\":\"bool\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"name\",\"outputs\":[{\"internalType\":\"string\",\"name\":\"\",\"type\":\"string\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint256\",\"name\":\"tokenId\",\"type\":\"uint256\"}],\"name\":\"ownerOf\",\"outputs\":[{\"internalType\":\"address\",\"name\":\"\",\"type\":\"address\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"from\",\"type\":\"address\"},{\"internalType\":\"address\",\"name\":\"to\",\"type\":\"address\"},{\"internalType\":\"uint256\",\"name\":\"tokenId\",\"type\":\"uint256\"}],\"name\":\"safeTransferFrom\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"from\",\"type\":\"address\"},{\"internalType\":\"address\",\"name\":\"to\",\"type\":\"address\"},{\"internalType\":\"uint256\",\"name\":\"tokenId\",\"type\":\"uint256\"},{\"internalType\":\"bytes\",\"name\":\"data\",\"type\":\"bytes\"}],\"name\":\"safeTransferFrom\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"operator\",\"type\":\"address\"},{\"internalType\":\"bool\",\"name\":\"approved\",\"type\":\"bool\"}],\"name\":\"setApprovalForAll\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"bytes4\",\"name\":\"interfaceId\",\"type\":\"bytes4\"}],\"name\":\"supportsInterface\",\"outputs\":[{\"internalType\":\"bool\",\"name\":\"\",\"type\":\"bool\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"symbol\",\"outputs\":[{\"internalType\":\"string\",\"name\":\"\",\"type\":\"string\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint256\",\"name\":\"tokenId\",\"type\":\"uint256\"}],\"name\":\"tokenURI\",\"outputs\":[{\"internalType\":\"string\",\"name\":\"\",\"type\":\"string\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"from\",\"type\":\"address\"},{\"internalType\":\"address\",\"name\":\"to\",\"type\":\"address\"},{\"internalType\":\"uint256\",\"name\":\"tokenId\",\"type\":\"uint256\"}],\"name\":\"transferFrom\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"}]";
        
    
        [Header("Components")]
        //[SerializeField] private Player player;
        private StateMachineManager _stateMachineManager;
        //private GameInput _gameInput;
        
        [Header("UI")]
        [SerializeField] private TextMeshProUGUI statusText;


        #region UNITY_LIFECYCLE

        private void OnEnable()
        {
            _stateMachineManager = GetComponentInParent<StateMachineManager>(); // We assume we are under GameManager

            // _gameInput = new GameInput();
            // _gameInput.PickingUp.Enable();
            // _gameInput.PickingUp.Cancel.performed += CancelTransaction;
            //
            // player.input.EnableInput(false);
            
            //PickUp(dappManager.currentGameItem.metadataUrl);
        }

        private void OnDisable()
        {
            // _gameInput.PickingUp.Disable();
            // _gameInput.PickingUp.Cancel.performed -= CancelTransaction;
        }

        #endregion
        

        #region PRIVATE_METHODS

        private async void PickUp(string metadataUrl)
        {
            statusText.text = "Please confirm transaction in your wallet";
        
            var result = await GetItem(metadataUrl);

            if (result is null)
            {
                statusText.text = "Transaction failed";
                LastActiveState();
                return;
            }
        
            statusText.text = "Transaction completed!";
            //Destroy(_gameManager.currentGameItem.gameObject); // We don't need this item anymore
            LastActiveState();
        }
        
        private async UniTask<string> GetItem(string metadataUrl)
        {
            object[] parameters = {
                metadataUrl
            };

            // Set gas estimate
            HexBigInteger value = new HexBigInteger(0);
            HexBigInteger gas = new HexBigInteger(0);
            HexBigInteger gasPrice = new HexBigInteger(0);

            string resp = await Moralis.ExecuteContractFunction(ContractAddress, ContractAbi, "getItem", parameters, value, gas, gasPrice);

            return resp;
        }

        #endregion
        
        
        #region INPUT_SYSTEM_HANDLERS

        // private async void CancelTransaction(InputAction.CallbackContext obj)
        // {
        //     // Check out what we're doing to "cancel" the transaction:
        //     // https://ethereum.stackexchange.com/questions/31298/is-it-possible-to-cancel-a-transaction
        //     
        //     object[] parameters = {
        //         "wrong metadata to cancel previous transaction"
        //     };
        //     
        //     HexBigInteger value = new HexBigInteger(0);
        //     HexBigInteger gas = new HexBigInteger(0);
        //     HexBigInteger gasPrice = new HexBigInteger(100); //Higher than "GetItem" transaction
        //     
        //     string resp = await Moralis.ExecuteContractFunction(GameManager.GameItemContractAddress, GameManager.GameItemContractAbi, "getItem", parameters, value, gas, gasPrice);
        //     
        //     LastActiveState();
        // }

        #endregion
    }   
}
