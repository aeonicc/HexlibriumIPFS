using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
//using UnityEditor.Animations;
using UnityEngine;
//using UnityEngine.WSA;

public class MouseHoverTiles : MonoBehaviour
{
    public static bool lockAll;
    //change blendtree when mouse is over tile
    public bool locked;
    private Animator _blendTree;
    private bool CanChange = true;
    private bool isOver;
    private bool activate;
    private bool cooldown = true;
    private Camera mainCamera;
    [SerializeField] private bool playersTiles;

    [SerializeField] private int TileID;
    
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        _blendTree = gameObject.transform.parent.GetComponent<Animator>();
    }
    
    /*
    void OnDrawGizmosSelected()
    {
        // Draws a 5 unit long red line in front of the object
        Gizmos.color = Color.red;
        Vector3 direction = transform.TransformDirection(Vector3.forward) * 5;
        Gizmos.DrawRay(Input.mousePosition, direction);
    }
    */
    //Get Raycast hit   and check if it is over a tile
    private void FixedUpdate()
    {
        
        //Debug.Log(isOver + " = Is Over");
        //RaycastHit hit;
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //if (Physics.Raycast(ray, out hit) && !locked && !lockAll && playersTiles)
        //{
        //    if (hit.transform.gameObject.CompareTag("Tile " + TileID)&& CanChange)
        //    {
        //        CanChange = false;
        //        Debug.Log("Over Tile");
        //        isOver = true;
         //       SwitchToHoverAnim();
                
        //    }
        //    else if(activate && CanChange)
        //    {
        //        CanChange = false;
        //        Debug.Log("Not Over Tile else if");
        //        StartCoroutine(EndHoverAnim());
        //        isOver = false;
        //    }
        //}
        //else if (!locked&& !lockAll)
        //{
        //    CanChange = false;
        //    Debug.Log("Not Over Tile else");
        //    StartCoroutine(EndHoverAnim());
        //    isOver = false;
        //}
        
        //if mouse is over tile and can change blendtree
        if (isOver && CanChange)
        {
            //change blendtree
            //_blendTree.SetBlendTree(0);
            CanChange = false;
        }
        //if mouse is not over tile and can change blendtree
        else if (!isOver && !CanChange)
        {
            //change blendtree
            //_blendTree.SetBlendTree(1);
            CanChange = true;
        }
        
    }

    public static void LockAll()
    {
        lockAll = !lockAll;
    } 
    IEnumerator EndHoverAnim()
    {
        yield return new WaitForSeconds(0.2f);
        if (!isOver && !locked)
        {
            _blendTree.SetTrigger("SwitchToHoverFatherReverse");
            StartCoroutine(Cooldown());
            activate = true;
            //gameObject.GetComponent<Material>().color = Color.Lerp(gameObject.GetComponent<Material>().color, Color.red, 0.1f);
        }
        else if(!locked && playersTiles)
        {
            _blendTree.ResetTrigger("SwitchToHoverFatherReverse");
        }
    }


    public void SwitchToHoverAnimUninterrupted()
    {
        locked = true;
        _blendTree.SetTrigger("SwitchToHoverFather");
        _blendTree.ResetTrigger("SwitchToHoverFatherReverse");
        activate = false;
    }
    //change value of blendtree when mouse is not over tile
    public void SwitchToHoverAnim()
    {
        if (!activate || !isOver) return;
        _blendTree.SetTrigger("SwitchToHoverFather");
        StartCoroutine(Cooldown());
        activate = false;

    }

    private IEnumerator Cooldown()
    {
        if (cooldown)
        {
            cooldown = false;
            Debug.Log("Cooldown");
            yield return new WaitForSeconds(0.15f);
            CanChange = true;   
            cooldown = true;
        }
    }

    public bool Click_ChooseTile()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit) && hit.transform.gameObject.CompareTag("Tile " + TileID))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

   
}
