using System.Collections;
using System.Collections.Generic;
using HEXLIBRIUM;
using Pixelplacement;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField] private  GameObject inventory;
    [SerializeField] private  GameObject Crafter;
    [SerializeField] private GameObject Camera;
    [SerializeField] private GameObject Player;
    private CameraDistanceRaycaster CDR;
    private CameraController CC;
    private Mover Mv;
    private AdvancedPlayerController APC;
    
    void Start()
    {
        Mv = Player.GetComponent<Mover>();
        APC = Player.GetComponent<AdvancedPlayerController>();
        CDR = Camera.GetComponent<CameraDistanceRaycaster>();
        CC = Camera.GetComponent<CameraController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            OpenInventory();
        }
        if (Input.GetKeyDown("e"))
        {
            OpenCrafter();
        }
    }
    
    public void OpenInventory()
    {
        if (inventory.activeSelf || Crafter.activeSelf) 
        {
            inventory.SetActive(false);
            Crafter.SetActive(false);
            CC.enabled = true;
            CDR.enabled = true;
           //Mv.enabled = true;
            APC.enabled = true;
        }
        else 
        {
            inventory.SetActive(true);
            CC.enabled = false;
            CDR.enabled = false;
            StartCoroutine(WaitForPlayerToFall());
        }
    }

    public void OpenCrafter()
    {
        if(inventory.activeSelf)
        {
            inventory.SetActive(false);
            Crafter.SetActive(true);
        }
        else
        {
            inventory.SetActive(true);
            Crafter.SetActive(false);
        }
    }
    
    private IEnumerator WaitForPlayerToFall()
    {
        yield return new WaitUntil( (  ) => APC.currentControllerState == AdvancedPlayerController.ControllerState.Grounded);
        yield return new WaitForSeconds(0.2f);
        if (!inventory.activeSelf) yield break;
       //Mv.enabled = false;
        APC.enabled = false;
    }
}
