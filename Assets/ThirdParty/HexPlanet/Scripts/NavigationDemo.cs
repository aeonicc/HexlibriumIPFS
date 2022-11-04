using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NavigationDemo : MonoBehaviour
{
    public BE2_TargetObjectSpacecraft3D Unit;
    
	// Use this for initialization
	void Start ()
    {
        TileHex.OnTileClickedAction += OnTileClicked;
        
        TileHex.OnTranslateAction += OnTranslated;
        
        //BE2_Ins_TranslateToGeodesic.OnTranslateAction += OnTranslated;
	}
	

    public void OnTileClicked(TileHex tile)
    {
        
        if(!Unit.moving)
        {
            Stack<TileHex> path;
            if(Hexsphere.planetInstances[0].navManager.findPath(Unit.currentTile, tile, out path))
            {
                Unit.moveOnPath(path);
                Debug.Log(path.ToString());
            }
        }
    }
    
    public void OnTranslated(TileHex tile)
    {
        Debug.Log("On Tile Clicked");
        if(!Unit.moving)
        {
            Stack<TileHex> path;
            if(Hexsphere.planetInstances[0].navManager.findPath(Unit.currentTile, tile, out path))
            {
                Unit.moveOnPath(path);
            }
        }
    }
}
