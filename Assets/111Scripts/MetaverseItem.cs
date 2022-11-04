using System;
using System.Collections;
using Hexlibrium;
using UnityEngine;
using Pixelplacement;
using UnityEngine.Networking;

namespace HEXLIBRIUM
{
    public class MetadataMetaverseObject
{
    public string name;
    public string description;
    public string image;
}

[RequireComponent(typeof(SphereCollider))]


public class MetaverseItem : MonoBehaviour
{
        //Ar
    // [Header("Smart Contract Data")]
    public const string contractAddress = "0x45B619296a287b7eFFb73f2FAfDee9a12cE91bCE";
    public const string contractAbi = "[{\"inputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"constructor\"},{\"anonymous\":false,\"inputs\":[{\"indexed\":true,\"internalType\":\"address\",\"name\":\"owner\",\"type\":\"address\"},{\"indexed\":true,\"internalType\":\"address\",\"name\":\"approved\",\"type\":\"address\"},{\"indexed\":true,\"internalType\":\"uint256\",\"name\":\"tokenId\",\"type\":\"uint256\"}],\"name\":\"Approval\",\"type\":\"event\"},{\"anonymous\":false,\"inputs\":[{\"indexed\":true,\"internalType\":\"address\",\"name\":\"owner\",\"type\":\"address\"},{\"indexed\":true,\"internalType\":\"address\",\"name\":\"operator\",\"type\":\"address\"},{\"indexed\":false,\"internalType\":\"bool\",\"name\":\"approved\",\"type\":\"bool\"}],\"name\":\"ApprovalForAll\",\"type\":\"event\"},{\"anonymous\":false,\"inputs\":[{\"indexed\":true,\"internalType\":\"address\",\"name\":\"from\",\"type\":\"address\"},{\"indexed\":true,\"internalType\":\"address\",\"name\":\"to\",\"type\":\"address\"},{\"indexed\":true,\"internalType\":\"uint256\",\"name\":\"tokenId\",\"type\":\"uint256\"}],\"name\":\"Transfer\",\"type\":\"event\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"to\",\"type\":\"address\"},{\"internalType\":\"uint256\",\"name\":\"tokenId\",\"type\":\"uint256\"}],\"name\":\"approve\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"owner\",\"type\":\"address\"}],\"name\":\"balanceOf\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint256\",\"name\":\"tokenId\",\"type\":\"uint256\"}],\"name\":\"getApproved\",\"outputs\":[{\"internalType\":\"address\",\"name\":\"\",\"type\":\"address\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"owner\",\"type\":\"address\"},{\"internalType\":\"address\",\"name\":\"operator\",\"type\":\"address\"}],\"name\":\"isApprovedForAll\",\"outputs\":[{\"internalType\":\"bool\",\"name\":\"\",\"type\":\"bool\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint256\",\"name\":\"tokenId\",\"type\":\"uint256\"},{\"internalType\":\"string\",\"name\":\"tokenURI\",\"type\":\"string\"}],\"name\":\"mintItem\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"name\",\"outputs\":[{\"internalType\":\"string\",\"name\":\"\",\"type\":\"string\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint256\",\"name\":\"tokenId\",\"type\":\"uint256\"}],\"name\":\"ownerOf\",\"outputs\":[{\"internalType\":\"address\",\"name\":\"\",\"type\":\"address\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"from\",\"type\":\"address\"},{\"internalType\":\"address\",\"name\":\"to\",\"type\":\"address\"},{\"internalType\":\"uint256\",\"name\":\"tokenId\",\"type\":\"uint256\"}],\"name\":\"safeTransferFrom\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"from\",\"type\":\"address\"},{\"internalType\":\"address\",\"name\":\"to\",\"type\":\"address\"},{\"internalType\":\"uint256\",\"name\":\"tokenId\",\"type\":\"uint256\"},{\"internalType\":\"bytes\",\"name\":\"data\",\"type\":\"bytes\"}],\"name\":\"safeTransferFrom\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"operator\",\"type\":\"address\"},{\"internalType\":\"bool\",\"name\":\"approved\",\"type\":\"bool\"}],\"name\":\"setApprovalForAll\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"bytes4\",\"name\":\"interfaceId\",\"type\":\"bytes4\"}],\"name\":\"supportsInterface\",\"outputs\":[{\"internalType\":\"bool\",\"name\":\"\",\"type\":\"bool\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"symbol\",\"outputs\":[{\"internalType\":\"string\",\"name\":\"\",\"type\":\"string\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint256\",\"name\":\"tokenId\",\"type\":\"uint256\"}],\"name\":\"tokenURI\",\"outputs\":[{\"internalType\":\"string\",\"name\":\"\",\"type\":\"string\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"from\",\"type\":\"address\"},{\"internalType\":\"address\",\"name\":\"to\",\"type\":\"address\"},{\"internalType\":\"uint256\",\"name\":\"tokenId\",\"type\":\"uint256\"}],\"name\":\"transferFrom\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"}]";
    public const string ipfsMetadataURL = "https://ipfs.moralis.io:2053/ipfs/QmTwF63ydD3VW4WXVcNJSKSWMjjqTCp3eWh9rWN8jXtHLT/Hybe_637994871534015117.json";
    public const string ipfsMetadataImage = "https://ipfs.moralis.io:2053/ipfs/QmauNjxXhyrSiMW9jJQrS41ifN8pjhBq27mHsLFEEnsu63/Hybe";
    
  // Events
    public static Action<MetaverseItem> Ready;
    public MetadataMetaverseObject metadataMetaverseObject;
    
    [Header("IPFS")]
    // private string ipfsMetadataUrl = DappManager.IPFSMetadataURL;
    private string ipfsMetadataUrl = ipfsMetadataURL;
    
    [Header("Components")]
    public SpriteRenderer spriteRenderer;
    public string title;
    public int amount;
    
    // More Components
    private SphereCollider _sphereCollider;
    
    // Control vars
    private Vector3 _initScale;
    private bool _tweenCompleted;
    private bool _imageLoaded;
    
    public static Action<bool, MetaverseItem> CollisionDetected;

    private void Awake()
    {
        // We don't want anything to collide with sphere when just instantiated
        _sphereCollider = GetComponent<SphereCollider>();
        _sphereCollider.enabled = false;
        
        // We also save our initial scale and then we set it to 0. We start from nothing :)
        //_initScale = transform.localScale;
        //transform.localScale = Vector3.zero;
    }
    
   private void OnEnable() //OnEnable
    {
        StartCoroutine(GetMetadataObject(ipfsMetadataUrl));
        
        // We set the target position that we want
        // Vector3 targetPos = new Vector3(transform.localPosition.x, transform.localPosition.y + 0.4f, transform.position.z + 0.3f);
        //Vector3 targetPos = new Vector3(transform.localPosition.x, transform.localPosition.y , transform.position.z );
        
        // We move the item to the target position using Tween. We also scale it to the initial scale
        // Tween.LocalPosition(transform, transform.localPosition, targetPos, 3f, 0, Tween.EaseOut);
        // Tween.LocalScale(transform, _initScale, 3f, 0, Tween.EaseOut, Tween.LoopType.None, null, () =>
        // {
        //     // Now We do it when we have retrieved all data from IPFS
        //     _tweenCompleted = true;
        //     CheckIfReady();
        // });
        _tweenCompleted = true;
        CheckIfReady();
    }

    private void CheckIfReady()
    {
        if (!_tweenCompleted || !_imageLoaded)
        {
            // We are only ready if tween has completed and we have loaded the image sucessfully
            return;
        }
        _sphereCollider.enabled = true;
        Ready?.Invoke(this);
    }
    
    private IEnumerator GetMetadataObject(string metadataUrl)
    {
        // We create a GET UWR passing that JSON URL 
        using UnityWebRequest uwr = UnityWebRequest.Get(metadataUrl);
        
        yield return uwr.SendWebRequest();

        if (uwr.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(uwr.error);
            uwr.Dispose();
        }
        else
        {
            // If successful, we get the JSON content as a string
            var uwrContent = DownloadHandlerBuffer.GetContent(uwr);

            // Finally we need to convert that string to a MetadataObject
            metadataMetaverseObject = JsonUtility.FromJson<MetadataMetaverseObject>(uwrContent);
            //StartCoroutine(GetImageSprite(metadataMetaverseObject.image));

            uwr.Dispose();
        }
    }
    
    private IEnumerator GetImageSprite(string imageUrl)
    {
        using UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(imageUrl);
        
        yield return uwr.SendWebRequest();

        if (uwr.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(uwr.error);
            uwr.Dispose();
        }
        else
        {
            var tex = DownloadHandlerTexture.GetContent(uwr);
                
            // After getting the texture, we create a new sprite using the texture height (or width) to set the sprite's pixels for unit
            spriteRenderer.sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), tex.height);
            
            // When the tween is completed, we enable the collider and we shout WE'RE READY!!
            _imageLoaded = true;
            CheckIfReady();
            
            uwr.Dispose();
        }
    }
        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;
                    
            CollisionDetected?.Invoke(true, this);
        }
                
        private void OnTriggerExit(Collider other)
        {
            if (!other.CompareTag("Player")) return;
                    
            CollisionDetected?.Invoke(false, this);
        }
     
}
}