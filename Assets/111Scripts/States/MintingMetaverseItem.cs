using System;
using System.Collections;
using System.Numerics;
using Cysharp.Threading.Tasks;
using Hexlibrium;
using MoralisUnity;
using Nethereum.Hex.HexTypes;
using TMPro;
using UnityEngine;
using WalletConnectSharp.Unity;
//using State = Pixelplacement.State;
using Unity.VisualScripting;
using State = Pixelplacement.State;

namespace HEXLIBRIUM
{

    public class MintingMetaverseItem : State
    {
        
        //Ar
    // [Header("Smart Contract Data")]
    // public const string ContractAddress = "0x45B619296a287b7eFFb73f2FAfDee9a12cE91bCE";
    // public const string ContractAbi = "[{\"inputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"constructor\"},{\"anonymous\":false,\"inputs\":[{\"indexed\":true,\"internalType\":\"address\",\"name\":\"owner\",\"type\":\"address\"},{\"indexed\":true,\"internalType\":\"address\",\"name\":\"approved\",\"type\":\"address\"},{\"indexed\":true,\"internalType\":\"uint256\",\"name\":\"tokenId\",\"type\":\"uint256\"}],\"name\":\"Approval\",\"type\":\"event\"},{\"anonymous\":false,\"inputs\":[{\"indexed\":true,\"internalType\":\"address\",\"name\":\"owner\",\"type\":\"address\"},{\"indexed\":true,\"internalType\":\"address\",\"name\":\"operator\",\"type\":\"address\"},{\"indexed\":false,\"internalType\":\"bool\",\"name\":\"approved\",\"type\":\"bool\"}],\"name\":\"ApprovalForAll\",\"type\":\"event\"},{\"anonymous\":false,\"inputs\":[{\"indexed\":true,\"internalType\":\"address\",\"name\":\"from\",\"type\":\"address\"},{\"indexed\":true,\"internalType\":\"address\",\"name\":\"to\",\"type\":\"address\"},{\"indexed\":true,\"internalType\":\"uint256\",\"name\":\"tokenId\",\"type\":\"uint256\"}],\"name\":\"Transfer\",\"type\":\"event\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"to\",\"type\":\"address\"},{\"internalType\":\"uint256\",\"name\":\"tokenId\",\"type\":\"uint256\"}],\"name\":\"approve\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"owner\",\"type\":\"address\"}],\"name\":\"balanceOf\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint256\",\"name\":\"tokenId\",\"type\":\"uint256\"}],\"name\":\"getApproved\",\"outputs\":[{\"internalType\":\"address\",\"name\":\"\",\"type\":\"address\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"owner\",\"type\":\"address\"},{\"internalType\":\"address\",\"name\":\"operator\",\"type\":\"address\"}],\"name\":\"isApprovedForAll\",\"outputs\":[{\"internalType\":\"bool\",\"name\":\"\",\"type\":\"bool\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint256\",\"name\":\"tokenId\",\"type\":\"uint256\"},{\"internalType\":\"string\",\"name\":\"tokenURI\",\"type\":\"string\"}],\"name\":\"mintItem\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"name\",\"outputs\":[{\"internalType\":\"string\",\"name\":\"\",\"type\":\"string\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint256\",\"name\":\"tokenId\",\"type\":\"uint256\"}],\"name\":\"ownerOf\",\"outputs\":[{\"internalType\":\"address\",\"name\":\"\",\"type\":\"address\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"from\",\"type\":\"address\"},{\"internalType\":\"address\",\"name\":\"to\",\"type\":\"address\"},{\"internalType\":\"uint256\",\"name\":\"tokenId\",\"type\":\"uint256\"}],\"name\":\"safeTransferFrom\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"from\",\"type\":\"address\"},{\"internalType\":\"address\",\"name\":\"to\",\"type\":\"address\"},{\"internalType\":\"uint256\",\"name\":\"tokenId\",\"type\":\"uint256\"},{\"internalType\":\"bytes\",\"name\":\"data\",\"type\":\"bytes\"}],\"name\":\"safeTransferFrom\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"operator\",\"type\":\"address\"},{\"internalType\":\"bool\",\"name\":\"approved\",\"type\":\"bool\"}],\"name\":\"setApprovalForAll\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"bytes4\",\"name\":\"interfaceId\",\"type\":\"bytes4\"}],\"name\":\"supportsInterface\",\"outputs\":[{\"internalType\":\"bool\",\"name\":\"\",\"type\":\"bool\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"symbol\",\"outputs\":[{\"internalType\":\"string\",\"name\":\"\",\"type\":\"string\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint256\",\"name\":\"tokenId\",\"type\":\"uint256\"}],\"name\":\"tokenURI\",\"outputs\":[{\"internalType\":\"string\",\"name\":\"\",\"type\":\"string\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"from\",\"type\":\"address\"},{\"internalType\":\"address\",\"name\":\"to\",\"type\":\"address\"},{\"internalType\":\"uint256\",\"name\":\"tokenId\",\"type\":\"uint256\"}],\"name\":\"transferFrom\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"}]";
    // public const string ipfsMetadataUrl = "https://ipfs.moralis.io:2053/ipfs/QmUtneguctUFj8zdo3K1NTLDQsvk5DwmJy9anyLM7fnMuT/y.json";
    //
    //image
    //https://ipfs.moralis.io:2053/ipfs/QmShb6ZaiFbfE1tydbmyjzmbmrjcUqyqPUvNRZ27YzeTfP/y
    //data
    //https://ipfs.moralis.io:2053/ipfs/QmUtneguctUFj8zdo3K1NTLDQsvk5DwmJy9anyLM7fnMuT/y.json

    public static MintingMetaverseItem instance;
    
    [Header("WalletConnect")] 
    [SerializeField] private WalletConnect walletConnect;

    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI statusText;
    [SerializeField] private GameObject cancelButton;

    private StateMachineManager _stateMachineManager;
    private BigInteger currentTokenId;
    
    [HideInInspector] public bool isItemMinted;
    [HideInInspector] public string itemTokenId;
    
    [SerializeField] public MetaverseItem metaverseItem;


   private void OnEnable()
   {
       instance = this;
        _stateMachineManager = GetComponentInParent<StateMachineManager>();
    }

    public void Awake() //Awake
    {
        // if (_stateMachineManager is null)
        // {
        //     Debug.LogError("Null. I need the GameManager to work.");
        //     return;
        // }
        //
        if (MetaverseItem.contractAddress == string.Empty || MetaverseItem.contractAbi == string.Empty)
        {
            Debug.LogError("You need the Contract Address AND the ABI to continue!");
            //ChangeState("Viewing");
            return;
        }
        
        // MintNft(dappManager.currentMetaverseItem.ipfsMetadataUrl);
        MintNft(MetaverseItem.ipfsMetadataURL);

        // If we get stuck at the minting process for any reason, we need to be able to leave the state.
        //StartCoroutine(EnableCancelButton());
    }

    private void OnDisable()
    {
        cancelButton.SetActive(false);
    }
    
    // private void GoToViewing(MetaverseItem item)
    // {
    //     currentMetaverseItem = item;
    //    
    // }

    private async void MintNft(string metadataUrl)
    {
        statusText.text = "Please confirm transaction in your MOBILE wallet";
        
        var result = await ExecuteMinting(metadataUrl);

        if (result is null)
        {
            statusText.text = "Transaction failed";
            //dappManager.isItemMinted = false;
            isItemMinted = false;
            
            
            return;
        }
    
        // We tell the GameManager what we minted the item successfully
        statusText.text = "Transaction completed!";
        // dappManager.itemTokenId = _currentTokenId.ToString();
        // dappManager.isItemMinted = true;

        
        
        
        itemTokenId = currentTokenId.ToString();
        isItemMinted = true;
        
        StateMachineManager.instance.ChangeState("H06");
        
    }
    
    private async UniTask<string> ExecuteMinting(string metadataUrl)
    {
        
        // Dummy TokenId based on current time.
        long currentTime = DateTime.Now.Ticks;
        currentTokenId = new BigInteger(currentTime);
        
        object[] parameters = {
            currentTokenId.ToString("x"), // This is the format the contract expects
            metadataUrl
        };

        // Set gas estimate
        HexBigInteger value = new HexBigInteger(0);
        HexBigInteger gas = new HexBigInteger(0);
        HexBigInteger gasPrice = new HexBigInteger(0);
   

        string resp = await Moralis.ExecuteContractFunction(MetaverseItem.contractAddress, MetaverseItem.contractAbi, "mintItem", parameters, value, gas, gasPrice);
        Debug.Log(resp);
        return resp;
    }

    private void OpenMobileWallet()
    {
        walletConnect.OpenMobileWallet();
        
    }
    
    private void OpenConsoleWallet()
    {
        walletConnect.OpenMobileWallet();
        
    }

    private IEnumerator EnableCancelButton()
    {
        yield return new WaitForSeconds(5f);
        
        cancelButton.SetActive(true);
    }

  
}
    
    
    
    

}