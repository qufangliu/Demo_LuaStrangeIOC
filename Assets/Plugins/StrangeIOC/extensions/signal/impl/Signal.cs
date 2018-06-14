/*
 * Copyright 2013 ThirdMotion, Inc.
 *
 *	Licensed under the Apache License, Version 2.0 (the "License");
 *	you may not use this file except in compliance with the License.
 *	You may obtain a copy of the License at
 *
 *		http://www.apache.org/licenses/LICENSE-2.0
 *
 *		Unless required by applicable law or agreed to in writing, software
 *		distributed under the License is distributed on an "AS IS" BASIS,
 *		WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *		See the License for the specific language governing permissions and
 *		limitations under the License.
 */

/**
 * @class strange.extensions.signal.impl.Signal
 * 
 * This is actually a series of classes defining the Base concrete form for all Signals.
 * 
 * Signals are a type-safe approach to communication that essentially replace the
 * standard EventDispatcher model. Signals can be injected/mapped just like any other
 * object -- as Singletons, as instances, or as values. Signals can even be mapped
 * across Contexts to provide an effective and type-safe way of communicating
 * between the parts of your application.
 * 
 * Signals in Strange use the Action Class as the underlying mechanism for type safety.
 * Unity's C# implementation currently allows up to FOUR parameters in an Action, therefore
 * SIGNALS ARE LIMITED TO FOUR PARAMETERS. If you require more than four, consider
 * creating a value object to hold additional values.
 * 
 * Examples:

		//BASIC SIGNAL CREATION/DISPATCH
		//Create a new signal
		Signal signalWithNoParameters = new Signal();
		//Add a listener
		signalWithNoParameters.AddListener(callbackWithNoParameters);
		//This would throw a compile-time error
		signalWithNoParameters.AddListener(callbackWithOneParameter);
		//Dispatch
		signalWithNoParameters.Dispatch();
		//Remove the listener
		signalWithNoParameters.RemoveListener(callbackWithNoParameters);

		//SIGNAL WITH PARAMETERS
		//Create a new signal with two parameters
		Signal<int, string> signal = new Signal<int, string>();
		//Add a listener
		signal.AddListener(callbackWithParamsIntAndString);
		//Add a listener for the duration of precisely one Dispatch
		signal.AddOnce(anotherCallbackWithParamsIntAndString);
		//These all throw compile-time errors
		signal.AddListener(callbackWithParamsStringAndInt);
		signal.AddListener(callbackWithOneParameter);
		signal.AddListener(callbackWithNoParameters);
		//Dispatch
		signal.Dispatch(42, "zaphod");
		//Remove the first listener. The listener added by AddOnce has been automatically removed.
		signal.RemoveListener(callbackWithParamsIntAndString);
 * 
 * @see strange.extensions.signal.api.IBaseSignal
 * @see strange.extensions.signal.impl.BaseSignal
 */

using System;
using System.Collections.Generic;
using System.Linq;

namespace strange.extensions.signal.impl
{
	public interface ISignal
	{
		Delegate listener { get; set; }
		void RemoveAllListeners();
	}

	/// Base concrete form for a Signal with one parameter
	public class Signal : BaseSignal, ISignal
	{
		public event Action<object> Listener = null;
		public event Action<object> OnceListener = null;

		public void AddListener(Action<object> callback)
		{
			Listener = this.AddUnique(Listener, callback);
		}

		public void AddOnce(Action<object> callback)
		{
			OnceListener = this.AddUnique(OnceListener, callback);
		}

		public void RemoveListener(Action<object> callback)
		{
			if (Listener != null)
				Listener -= callback;
		}
		
		public void RemoveOnce( Action<object> callback )
		{
			if( OnceListener != null )
				OnceListener -= callback;
		}
		
		public override List<Type> GetTypes()
		{
			List<Type> retv = new List<Type>();
			retv.Add(typeof(object));
			return retv;
		}
		public void Dispatch(object type1 = null)
		{
			if (Listener != null)
				Listener(type1);
			if (OnceListener != null)
				OnceListener(type1);
			OnceListener = null;
			object[] outv = { type1 };
			base.Dispatch(outv);
		}

		private Action<object> AddUnique(Action<object> listeners, Action<object> callback)
		{
			if (listeners == null || !listeners.GetInvocationList().Contains(callback))
			{
				listeners += callback;
			}
			return listeners;
		}

		public override void RemoveAllListeners()
		{
			Listener = null;
			OnceListener = null;
			base.RemoveAllListeners();
		}
		public Delegate listener
		{
			get { return Listener ?? (Listener = delegate { }); }
			set { Listener = (Action<object>)value; }
		}
	}
}
