using System;
using System.Collections;
// using Cysharp.Threading.Tasks;
// using MoralisUnity;
// using Nethereum.Hex.HexTypes;
// using Org.BouncyCastle.Math;
// using UnityEngine;

using System.Numerics;
using Cysharp.Threading.Tasks;
using Hexlibrium;
using MoralisUnity;
using Nethereum.Hex.HexTypes;
using Pixelplacement;
using TMPro;
using UnityEngine;
//using UnityEngine.InputSystem;

using UnityEngine.Networking;

using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;

using MoralisUnity;
using MoralisUnity.Web3Api.Models;

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
    public class MetadataYinYang
    {
        public string name;
        public string description;
        public string image;

    }
    
    public class MetadataYinYangObject
    {
        public string name { get; set; }
        public string description { get; set; }
        public string image { get; set; }

        [CanBeNull] public List<AttributeYinYangObject> attributes { get; set; }
    }

    public class AttributeYinYangObject
    {
        [CanBeNull] public string display_type { get; set; }
        public string trait_type { get; set; }
        public float value { get; set; }
    }
    
    
    public class YinYangItem : MonoBehaviour
    {
        public static Action<bool, YinYangItem> CollisionDetected;
        
        private MetadataYinYang metadataYinYang;
        private MetadataYinYangObject metadataYinYangObject;
        
        public SpriteRenderer spriteRenderer; 
        private int amount = 1;
        public int currentYinYang;
        public string yy = "1";

        //
        // public string title = "Yin Yang";
     
        [Header("YY Contract Data")]
        public const string contractAddress = "0x45B619296a287b7eFFb73f2FAfDee9a12cE91bCE";
        public const string contractAbi = "[{\"inputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"constructor\"},{\"anonymous\":false,\"inputs\":[{\"indexed\":true,\"internalType\":\"address\",\"name\":\"owner\",\"type\":\"address\"},{\"indexed\":true,\"internalType\":\"address\",\"name\":\"approved\",\"type\":\"address\"},{\"indexed\":true,\"internalType\":\"uint256\",\"name\":\"tokenId\",\"type\":\"uint256\"}],\"name\":\"Approval\",\"type\":\"event\"},{\"anonymous\":false,\"inputs\":[{\"indexed\":true,\"internalType\":\"address\",\"name\":\"owner\",\"type\":\"address\"},{\"indexed\":true,\"internalType\":\"address\",\"name\":\"operator\",\"type\":\"address\"},{\"indexed\":false,\"internalType\":\"bool\",\"name\":\"approved\",\"type\":\"bool\"}],\"name\":\"ApprovalForAll\",\"type\":\"event\"},{\"anonymous\":false,\"inputs\":[{\"indexed\":true,\"internalType\":\"address\",\"name\":\"from\",\"type\":\"address\"},{\"indexed\":true,\"internalType\":\"address\",\"name\":\"to\",\"type\":\"address\"},{\"indexed\":true,\"internalType\":\"uint256\",\"name\":\"tokenId\",\"type\":\"uint256\"}],\"name\":\"Transfer\",\"type\":\"event\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"to\",\"type\":\"address\"},{\"internalType\":\"uint256\",\"name\":\"tokenId\",\"type\":\"uint256\"}],\"name\":\"approve\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"owner\",\"type\":\"address\"}],\"name\":\"balanceOf\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint256\",\"name\":\"tokenId\",\"type\":\"uint256\"}],\"name\":\"getApproved\",\"outputs\":[{\"internalType\":\"address\",\"name\":\"\",\"type\":\"address\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"owner\",\"type\":\"address\"},{\"internalType\":\"address\",\"name\":\"operator\",\"type\":\"address\"}],\"name\":\"isApprovedForAll\",\"outputs\":[{\"internalType\":\"bool\",\"name\":\"\",\"type\":\"bool\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint256\",\"name\":\"tokenId\",\"type\":\"uint256\"},{\"internalType\":\"string\",\"name\":\"tokenURI\",\"type\":\"string\"}],\"name\":\"mintItem\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"name\",\"outputs\":[{\"internalType\":\"string\",\"name\":\"\",\"type\":\"string\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint256\",\"name\":\"tokenId\",\"type\":\"uint256\"}],\"name\":\"ownerOf\",\"outputs\":[{\"internalType\":\"address\",\"name\":\"\",\"type\":\"address\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"from\",\"type\":\"address\"},{\"internalType\":\"address\",\"name\":\"to\",\"type\":\"address\"},{\"internalType\":\"uint256\",\"name\":\"tokenId\",\"type\":\"uint256\"}],\"name\":\"safeTransferFrom\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"from\",\"type\":\"address\"},{\"internalType\":\"address\",\"name\":\"to\",\"type\":\"address\"},{\"internalType\":\"uint256\",\"name\":\"tokenId\",\"type\":\"uint256\"},{\"internalType\":\"bytes\",\"name\":\"data\",\"type\":\"bytes\"}],\"name\":\"safeTransferFrom\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"operator\",\"type\":\"address\"},{\"internalType\":\"bool\",\"name\":\"approved\",\"type\":\"bool\"}],\"name\":\"setApprovalForAll\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"bytes4\",\"name\":\"interfaceId\",\"type\":\"bytes4\"}],\"name\":\"supportsInterface\",\"outputs\":[{\"internalType\":\"bool\",\"name\":\"\",\"type\":\"bool\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"symbol\",\"outputs\":[{\"internalType\":\"string\",\"name\":\"\",\"type\":\"string\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint256\",\"name\":\"tokenId\",\"type\":\"uint256\"}],\"name\":\"tokenURI\",\"outputs\":[{\"internalType\":\"string\",\"name\":\"\",\"type\":\"string\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"from\",\"type\":\"address\"},{\"internalType\":\"address\",\"name\":\"to\",\"type\":\"address\"},{\"internalType\":\"uint256\",\"name\":\"tokenId\",\"type\":\"uint256\"}],\"name\":\"transferFrom\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"}]";
        public const string ipfsMetadataURL = "https://ipfs.moralis.io:2053/ipfs/QmTwF63ydD3VW4WXVcNJSKSWMjjqTCp3eWh9rWN8jXtHLT/Hybe_637994871534015117.json";
        public const string ipfsMetadataImage = "https://ipfs.moralis.io:2053/ipfs/QmauNjxXhyrSiMW9jJQrS41ifN8pjhBq27mHsLFEEnsu63/Hybe";
        //
          //power
        // public const string contractAddress = "0x74472B5ab1494115D3e82aC7f878cEB4e7e87847";
        // public const string contractAbi = "[{\"inputs\":[{\"internalType\":\"string\",\"name\":\"name_\",\"type\":\"string\"},{\"internalType\":\"string\",\"name\":\"symbol_\",\"type\":\"string\"}],\"stateMutability\":\"nonpayable\",\"type\":\"constructor\"},{\"anonymous\":false,\"inputs\":[{\"indexed\":true,\"internalType\":\"address\",\"name\":\"owner\",\"type\":\"address\"},{\"indexed\":true,\"internalType\":\"address\",\"name\":\"approved\",\"type\":\"address\"},{\"indexed\":true,\"internalType\":\"uint256\",\"name\":\"tokenId\",\"type\":\"uint256\"}],\"name\":\"Approval\",\"type\":\"event\"},{\"anonymous\":false,\"inputs\":[{\"indexed\":true,\"internalType\":\"address\",\"name\":\"owner\",\"type\":\"address\"},{\"indexed\":true,\"internalType\":\"address\",\"name\":\"operator\",\"type\":\"address\"},{\"indexed\":false,\"internalType\":\"bool\",\"name\":\"approved\",\"type\":\"bool\"}],\"name\":\"ApprovalForAll\",\"type\":\"event\"},{\"anonymous\":false,\"inputs\":[{\"indexed\":true,\"internalType\":\"address\",\"name\":\"from\",\"type\":\"address\"},{\"indexed\":true,\"internalType\":\"address\",\"name\":\"to\",\"type\":\"address\"},{\"indexed\":true,\"internalType\":\"uint256\",\"name\":\"tokenId\",\"type\":\"uint256\"}],\"name\":\"Transfer\",\"type\":\"event\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"to\",\"type\":\"address\"},{\"internalType\":\"uint256\",\"name\":\"tokenId\",\"type\":\"uint256\"}],\"name\":\"approve\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"owner\",\"type\":\"address\"}],\"name\":\"balanceOf\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint256\",\"name\":\"tokenId\",\"type\":\"uint256\"}],\"name\":\"getApproved\",\"outputs\":[{\"internalType\":\"address\",\"name\":\"\",\"type\":\"address\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"owner\",\"type\":\"address\"},{\"internalType\":\"address\",\"name\":\"operator\",\"type\":\"address\"}],\"name\":\"isApprovedForAll\",\"outputs\":[{\"internalType\":\"bool\",\"name\":\"\",\"type\":\"bool\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"name\",\"outputs\":[{\"internalType\":\"string\",\"name\":\"\",\"type\":\"string\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint256\",\"name\":\"tokenId\",\"type\":\"uint256\"}],\"name\":\"ownerOf\",\"outputs\":[{\"internalType\":\"address\",\"name\":\"\",\"type\":\"address\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"from\",\"type\":\"address\"},{\"internalType\":\"address\",\"name\":\"to\",\"type\":\"address\"},{\"internalType\":\"uint256\",\"name\":\"tokenId\",\"type\":\"uint256\"}],\"name\":\"safeTransferFrom\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"from\",\"type\":\"address\"},{\"internalType\":\"address\",\"name\":\"to\",\"type\":\"address\"},{\"internalType\":\"uint256\",\"name\":\"tokenId\",\"type\":\"uint256\"},{\"internalType\":\"bytes\",\"name\":\"data\",\"type\":\"bytes\"}],\"name\":\"safeTransferFrom\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"operator\",\"type\":\"address\"},{\"internalType\":\"bool\",\"name\":\"approved\",\"type\":\"bool\"}],\"name\":\"setApprovalForAll\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"bytes4\",\"name\":\"interfaceId\",\"type\":\"bytes4\"}],\"name\":\"supportsInterface\",\"outputs\":[{\"internalType\":\"bool\",\"name\":\"\",\"type\":\"bool\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"symbol\",\"outputs\":[{\"internalType\":\"string\",\"name\":\"\",\"type\":\"string\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint256\",\"name\":\"tokenId\",\"type\":\"uint256\"}],\"name\":\"tokenURI\",\"outputs\":[{\"internalType\":\"string\",\"name\":\"\",\"type\":\"string\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"from\",\"type\":\"address\"},{\"internalType\":\"address\",\"name\":\"to\",\"type\":\"address\"},{\"internalType\":\"uint256\",\"name\":\"tokenId\",\"type\":\"uint256\"}],\"name\":\"transferFrom\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"}]";
        // public const string ipfsMetadataURL = "https://ipfs.moralis.io:2053/ipfs/QmYoKLbeUNxE3Gue4sQTn8e2ohpgLTKEpbS3UZ2KQsg9jW/StarPower-Up_637930547394574696.json";
    
          
        public static YinYangItem instance;
        
        // Power-Up values
        [HideInInspector] private float boostPercentage = 100;
        [HideInInspector] private float boostDuration = 100;
        private void Awake()
        {
            instance = this;
        }

        public void GetNFT()//OnEnable
        {
            AddYinYang(amount);
            //Destroy(gameObject);
            //PickUpYinYang(1);
                
            MintNFT(ipfsMetadataURL);
            return;
            
            // StartCoroutine(GetMetadataObject(ipfsMetadataURL));
            // StartCoroutine(GetImageSprite(ipfsMetadataImage));
            //
            // StartCoroutine(GetTexture(ipfsMetadataImage)); //ipfsMetadataURL.image
            //Init(tokenId, ipfsMetadataURL);
        }

        //power 
        public void Init(string tokenId, MetadataYinYangObject _metadataYinYangObject)
        {
            
            string myTokenId = tokenId;
            metadataYinYangObject = _metadataYinYangObject;
            
            foreach (var attribute in metadataYinYangObject.attributes)
            {
                if (attribute.display_type == "boost_percentage")
                {
                    if (attribute.trait_type == "Movement")
                    {
                        boostPercentage = attribute.value;   
                    }
                }

                if (attribute.display_type == "boost_number")
                {
                    if (attribute.trait_type == "Duration")
                    {
                        boostDuration = attribute.value;
                    }
                }
            }

        }

        //spriteUI
        private IEnumerator GetTexture(string imageURL)
        {
            using UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(imageURL);
            
            yield return uwr.SendWebRequest();
            
            var tex = DownloadHandlerTexture.GetContent(uwr);
            UIManager.instance.yinyangButton.image.sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new UnityEngine.Vector2(0.5f, 0.5f), tex.height);
                
            //Now we are able to click the button and we will pass the loaded sprite :)
            
            
            UIManager.instance.yinyangButton.image.gameObject.SetActive(true);
            UIManager.instance.yinyangButton.interactable = true;
            
            uwr.Dispose();
        }
        //spriteUI
        //power
        
        
        //Metaverse
        private IEnumerator GetMetadataObject(string metadataURL)
        {
            using UnityWebRequest uwr = UnityWebRequest.Get(ipfsMetadataURL);
            
            yield return uwr.SendWebRequest();
            
            var uwrContent = DownloadHandlerBuffer.GetContent(uwr);

            // Finally we need to convert that string to a MetadataObject
            metadataYinYang = JsonUtility.FromJson<MetadataYinYang>(uwrContent);
            //StartCoroutine(GetImageSprite(metadataMetaverseObject.image));

            uwr.Dispose();
            
            
            
        }

        private IEnumerator GetImageSprite(string imageURL)
        {
            using UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(imageURL);
            yield return uwr.SendWebRequest();
            
            var tex = DownloadHandlerTexture.GetContent(uwr);
            spriteRenderer.sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new UnityEngine.Vector2(0.5f, 0.5f), tex.height);
            
            uwr.Dispose();
        }
        //Metaverse

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                AddYinYang(amount);
                //Destroy(gameObject);
                //PickUpYinYang(1);
                
                MintNFT(ipfsMetadataURL);
                return;
            }
            CollisionDetected?.Invoke(true, this);
        }

        private void OnTriggerStay(Collider other)
        {
            // if (other.CompareTag("Player"))
            // {
            //     //AddYinYang(amount);
            //     //Destroy(gameObject);
            //     
            //     //return;
            // }
            // CollisionDetected?.Invoke(true, this);
        }
        
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player")) return;
            CollisionDetected?.Invoke(false, this);
        }
        
        public void AddYinYang(int yinyangToAdd)
        {
            currentYinYang += yinyangToAdd;
            UIManager.instance.yinyangText.text = "" + currentYinYang;

            // if (currentCoins == 100)
            // {
            //     UIManager.instance.ActivateButton();
            //     //StateMachineManager.instance.MintingCoin();
            // }
        }

        private async void PickUpYinYang()
        {
            var result = await ExecuteMinting(yy);
        }

        private async void MintNFT(string ipfsURL)
        {
            var result = await ExecuteMinting(ipfsURL);
            
            StartCoroutine(GetMetadataObject(ipfsMetadataURL));
            StartCoroutine(GetImageSprite(ipfsMetadataImage));
            
            StartCoroutine(GetTexture(ipfsMetadataImage)); //ipfsMetadataURL.image
            return;
        }

        private async UniTask<string> ExecuteMinting(string metadataUrl)
        {
            
            //coin
            // BigInteger amountValue = new BigInteger(yy);
            //
            // object[] parameters = {
            //     amountValue.ToString("x")
            // };
            //coin
            
            //metaverse
            long currentTime = DateTime.Now.Ticks;
            BigInteger currentTokenId = new BigInteger(currentTime);
        
            object[] parameters = {
                currentTokenId.ToString("x"), // This is the format the contract expects
                metadataUrl
            };
            //metaverse
            
            //power
            // var longTokenId = Convert.ToInt64(tokenId);
            //
            // object[] parameters = {
            //     longTokenId.ToString("x") // This is what the contract expects
            // };
            //power

            HexBigInteger value = new HexBigInteger(0);
            HexBigInteger gas = new HexBigInteger(0);
            HexBigInteger gasPrice = new HexBigInteger(0);

            string resp = await Moralis.ExecuteContractFunction(contractAddress, contractAbi, "mintItem", parameters, value, gas, gasPrice);
           
            return resp;
        }
        
    }   
}
