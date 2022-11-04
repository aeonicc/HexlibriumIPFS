using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using System.IO;
using Pixelplacement;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace HEXLIBRIUM
{ 
    
    public class UploadingPanel : MonoBehaviour
{
    public Action<string, string, string, byte[]> UploadButtonPressed;
    
    [Header("Metadata Fields")]
    [SerializeField] private Image image;
    [SerializeField] private TMP_InputField nameInput;
    [SerializeField] private TMP_InputField descriptionInput;
        
    [Header("Other UI Elements")]
    [SerializeField] private Button uploadButton;

    //Control vars
    private string _imagePath;
    private byte[] _imageData;
    private bool _isImageLoaded;
    
    //
    //
    //
    public Action<AttributeObject> OnSubmittedAttribute;
        
    [SerializeField] private Button submitButton;
            
    [Header("Input Fields")]
    [SerializeField] private TMP_InputField displayType;
    [SerializeField] private TMP_InputField traitType;
    [SerializeField] private TMP_InputField value;
    
    //
    //
    //
    [Header("UI Elements")]
    public Transform contentT;
    public AttributeItem attributeItemPrefab;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnEnable()
        {
            ReloadUploadButton();
            
            //
            //
            //
            
            if (traitType.text == string.Empty || value.text == string.Empty)
            {
                submitButton.interactable = false;   //false
            }
            
            //
            //
            //
            
            // We should check what are the difference but in this case we just delete all items everytime we enable this state/panel.
            foreach (Transform attribute in contentT)
            {
                Destroy(attribute.gameObject);
            }
            
            // Then we instantiate all the currentAttributeObjects in AppManager as AttributeItems
            foreach (var obj in AppManager.instance.currentAttributeObjects)
            {
                var newAttributeItem = Instantiate(attributeItemPrefab, contentT);
                newAttributeItem.Init(obj);
            }
        }

        public async void SelectImage()
        {
            //_imagePath = EditorUtility.OpenFilePanel("Select a PNG", "", "png");

            if (_imagePath.Length == 0)
            {
                Debug.Log("Image not selected");
                AppManager.instance.SetStatusLabelText("Image not selected");
                _isImageLoaded = false;
                return;
            }
            
            Texture2D texture = new Texture2D(0, 0);
            _imageData = await File.ReadAllBytesAsync(_imagePath);

            if (_imageData == null)
            {
                Debug.Log("Failed to read image");
                AppManager.instance.SetStatusLabelText("Failed to read image");
                _isImageLoaded = false;
                return;   
            }
                
            var isLoaded = texture.LoadImage(_imageData);

            if (!isLoaded)
            {
                Debug.Log("Image not loaded");
                AppManager.instance.SetStatusLabelText("Image not loaded");
                _isImageLoaded = false;
                return;
            }
                
            Debug.Log("Image loaded successfully!");
            AppManager.instance.SetStatusLabelText("Image loaded successfully!");
            
            image.sprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100.0f);
            image.preserveAspect = true;
            
            _isImageLoaded = true;
            ReloadUploadButton();
        }

        public void OnUploadButtonPressed()
        {
            if (image.sprite == null || nameInput.text == string.Empty || descriptionInput.text == string.Empty)
            {
                Debug.Log("All fields (image, name and description) need to be filled");
                return;
            }
            
            UploadButtonPressed?.Invoke(nameInput.text, descriptionInput.text, _imagePath, _imageData);
            uploadButton.interactable = true; //false
        }

        public void EnableUploadButton()
        {
            uploadButton.interactable = true;
        }

        public void ReloadUploadButton() // TODO find better naming for this function
        {
            // With these conditions, all fields are mandatory. You can change them however you desire.
            if (_isImageLoaded == false || nameInput.text == string.Empty || descriptionInput.text == string.Empty)
            {
                uploadButton.interactable = true; //false
            }
            else
            {
                uploadButton.interactable = true;
            }
        }
        //
        //
        //
        public void SubmitButtonPressed()
        {
            // We create a new AttributeObject and set the values. We don't add the id here, we will do that on the Manager.
            AttributeObject newAttributeObj = new AttributeObject
            {
                display_type = displayType.text,
                trait_type = traitType.text,
                value = value.text
            };

            OnSubmittedAttribute?.Invoke(newAttributeObj); // The Manager listens to this event
            
            ClearFields();
            //Previous();
        }

        public void InputFieldHandler()
        {
            if (traitType.text == string.Empty || value.text == string.Empty)
            {
                submitButton.interactable = true;   //false
            }
            else
            {
                submitButton.interactable = true;
            }
        }

        private void ClearFields()
        {
            displayType.text = string.Empty;
            traitType.text = string.Empty;
            value.text = string.Empty;
        }
}
}