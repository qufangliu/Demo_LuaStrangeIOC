using System.Collections;
using System.Collections.Generic;
using Demo.Demo;
using FairyGUI;
using LuaInterface;
using UnityEngine;

public class GameMain : MonoBehaviour {

	// Use this for initialization
	void Start () {
		// cs test
		Debug.Log( "Game Start!!" );
		
		// tolua test
//		string luaStr = "print('log in lua!!')";
//		LuaState luaState = new LuaState();
//		luaState.Start();
//		luaState.DoString( luaStr );
//		luaState.Dispose();
		
		// fairyGUI test
//		UIPackage.AddPackage( "UI/Demo" );
//		GObject uiObj = UIPackage.CreateObject( "Demo", "start" );
//		GRoot.inst.AddChild( uiObj );
		
		// fairyGUI lua test
		LuaState luaState = new LuaState();
		LuaBinder.Bind( luaState );
		luaState.Start();
		luaState.Require( "TestFairyGUI" );
		luaState.Dispose();



	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
