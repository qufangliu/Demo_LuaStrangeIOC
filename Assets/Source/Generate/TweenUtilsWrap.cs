﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class TweenUtilsWrap
{
	public static void Register(LuaState L)
	{
		L.BeginStaticLibs("TweenUtils");
		L.RegFunction("TweenFloat", TweenFloat);
		L.RegFunction("TweenVector2", TweenVector2);
		L.RegFunction("TweenVector3", TweenVector3);
		L.RegFunction("SetEase", SetEase);
		L.RegFunction("OnComplete", OnComplete);
		L.RegFunction("SetDelay", SetDelay);
		L.RegFunction("SetLoops", SetLoops);
		L.RegFunction("SetTarget", SetTarget);
		L.EndStaticLibs();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int TweenFloat(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 4);
			float arg0 = (float)LuaDLL.luaL_checknumber(L, 1);
			float arg1 = (float)LuaDLL.luaL_checknumber(L, 2);
			float arg2 = (float)LuaDLL.luaL_checknumber(L, 3);
			LuaFunction arg3 = ToLua.CheckLuaFunction(L, 4);
			DG.Tweening.Tweener o = TweenUtils.TweenFloat(arg0, arg1, arg2, arg3);
			ToLua.PushObject(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int TweenVector2(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 4);
			UnityEngine.Vector2 arg0 = ToLua.ToVector2(L, 1);
			UnityEngine.Vector2 arg1 = ToLua.ToVector2(L, 2);
			float arg2 = (float)LuaDLL.luaL_checknumber(L, 3);
			LuaFunction arg3 = ToLua.CheckLuaFunction(L, 4);
			DG.Tweening.Tweener o = TweenUtils.TweenVector2(arg0, arg1, arg2, arg3);
			ToLua.PushObject(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int TweenVector3(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 4);
			UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 1);
			UnityEngine.Vector3 arg1 = ToLua.ToVector3(L, 2);
			float arg2 = (float)LuaDLL.luaL_checknumber(L, 3);
			LuaFunction arg3 = ToLua.CheckLuaFunction(L, 4);
			DG.Tweening.Tweener o = TweenUtils.TweenVector3(arg0, arg1, arg2, arg3);
			ToLua.PushObject(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetEase(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			DG.Tweening.Tweener arg0 = (DG.Tweening.Tweener)ToLua.CheckObject<DG.Tweening.Tweener>(L, 1);
			DG.Tweening.Ease arg1 = (DG.Tweening.Ease)ToLua.CheckObject(L, 2, typeof(DG.Tweening.Ease));
			TweenUtils.SetEase(arg0, arg1);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnComplete(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 2)
			{
				DG.Tweening.Tweener arg0 = (DG.Tweening.Tweener)ToLua.CheckObject<DG.Tweening.Tweener>(L, 1);
				LuaFunction arg1 = ToLua.CheckLuaFunction(L, 2);
				TweenUtils.OnComplete(arg0, arg1);
				return 0;
			}
			else if (count == 3)
			{
				DG.Tweening.Tweener arg0 = (DG.Tweening.Tweener)ToLua.CheckObject<DG.Tweening.Tweener>(L, 1);
				LuaFunction arg1 = ToLua.CheckLuaFunction(L, 2);
				object arg2 = ToLua.ToVarObject(L, 3);
				TweenUtils.OnComplete(arg0, arg1, arg2);
				return 0;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: TweenUtils.OnComplete");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetDelay(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			DG.Tweening.Tweener arg0 = (DG.Tweening.Tweener)ToLua.CheckObject<DG.Tweening.Tweener>(L, 1);
			float arg1 = (float)LuaDLL.luaL_checknumber(L, 2);
			TweenUtils.SetDelay(arg0, arg1);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetLoops(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 2)
			{
				DG.Tweening.Tweener arg0 = (DG.Tweening.Tweener)ToLua.CheckObject<DG.Tweening.Tweener>(L, 1);
				int arg1 = (int)LuaDLL.luaL_checknumber(L, 2);
				TweenUtils.SetLoops(arg0, arg1);
				return 0;
			}
			else if (count == 3)
			{
				DG.Tweening.Tweener arg0 = (DG.Tweening.Tweener)ToLua.CheckObject<DG.Tweening.Tweener>(L, 1);
				int arg1 = (int)LuaDLL.luaL_checknumber(L, 2);
				bool arg2 = LuaDLL.luaL_checkboolean(L, 3);
				TweenUtils.SetLoops(arg0, arg1, arg2);
				return 0;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: TweenUtils.SetLoops");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetTarget(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			DG.Tweening.Tweener arg0 = (DG.Tweening.Tweener)ToLua.CheckObject<DG.Tweening.Tweener>(L, 1);
			object arg1 = ToLua.ToVarObject(L, 2);
			TweenUtils.SetTarget(arg0, arg1);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}
}

