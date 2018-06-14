using System.Collections;
using System.Collections.Generic;
using LuaInterface;
using UnityEngine;

public class GameMain : MonoBehaviour {

	// Use this for initialization
	void Start () {
		// cs test
		Debug.Log( "Game Start!!" );
		
		// tolua test
		string luaStr = "print('log in lua!!')";
		LuaState luaState = new LuaState();
		luaState.Start();
		luaState.DoString( luaStr );
		luaState.Dispose();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
