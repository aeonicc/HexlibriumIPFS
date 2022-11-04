using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NavigationManager : MonoBehaviour {

	public List<TileHex> worldTiles;
	public LineRenderer pathRenderer;

	public void setWorldTiles(List<TileHex> tiles){
		worldTiles = tiles;
	}

	public bool findPath(TileHex start, TileHex end, out Stack<TileHex> pathStack){
		pathStack = new Stack<TileHex> ();
		if (!start.navigable || !end.navigable) {
			return false;
		}
		//Check if the connected region which start is in also contains end
		if (!DFS (start).Contains (end)) {
			return false;
		}

		//Find the shortest path between two tiles using Dijkstra's algorithm
		List<TileHex> unvisited = new List<TileHex> ();
		Dictionary<TileHex, int> distanceMap = new Dictionary<TileHex, int> ();
		Dictionary<TileHex, TileHex> previousNode = new Dictionary<TileHex, TileHex> ();
		int altPathLength;

		foreach (TileHex tile in worldTiles) {
			if(tile.navigable){
				distanceMap.Add(tile, int.MaxValue);
				previousNode.Add(tile, null);
				unvisited.Add(tile);
			}
		}
		distanceMap [start] = 0;
		bool found = false;
		//MAIN LOOP
		while (unvisited.Count > 0 && !found) {
			//Get tile with min distance from source
			int d = int.MaxValue;
			TileHex closest = null;
			foreach(TileHex u in unvisited){
				if(distanceMap[u] < d){
					d = distanceMap[u];
					closest = u;
				}
			}
			//Mark this tile as visited by removing it from the unvisited list.
			unvisited.Remove(closest);
			//If no tile was found, then there is no possible path
			if(closest == null){
				return false;
			}
			foreach(TileHex v in closest.neighborTiles){
				if(v.navigable && unvisited.Contains(v)){
					//altPathLength = distanceMap[closest] + 1;
					altPathLength = distanceMap[closest] + v.pathCost;
					if(altPathLength < distanceMap[v]){
						distanceMap[v] = altPathLength;
						previousNode[v] = closest;
					}
					if(v == end){
						//Target tile found
						found = true;
						break;
					}
				}
			}
		}
		//Build a stack of vectors of the shortest path
		TileHex pathV = end;
		while(previousNode[pathV] != null){
			pathStack.Push(pathV);
			pathV = previousNode[pathV];
		}
		pathStack.Push (pathV);
		return true;
	}

	public void drawPath(Stack<TileHex> pathStack){
		if (pathStack == null) {
			return;
		}
		pathRenderer.enabled = true;
		int i = 0;
		pathRenderer.positionCount = pathStack.Count;
		while (pathStack.Count > 0) {
			pathRenderer.SetPosition(i, pathStack.Pop().center);
			i++;
		}
	}

	public List<TileHex> DFS(TileHex start){
		List<TileHex> connectedRegion = new List<TileHex> ();
		Stack<TileHex> s = new Stack<TileHex> ();
		s.Push (start);
		while (s.Count > 0) {
			TileHex t = s.Pop();
			if(!connectedRegion.Contains(t)){
				connectedRegion.Add (t);
				foreach(TileHex v in t.neighborTiles){
					if(v.navigable){
						s.Push(v);
					}
				}
			}
		}
		return connectedRegion;
	}
}
