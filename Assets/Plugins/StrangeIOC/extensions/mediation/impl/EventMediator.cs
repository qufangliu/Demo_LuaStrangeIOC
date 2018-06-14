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
 * @class strange.extensions.mediation.impl.EventMediator
 * 
 * A Mediator which injects an IEventDispatcher. This is the
 * class for your Mediators to extend if you're using MVCSContext.
 */

using System;
using System.Collections.Generic;
using strange.extensions.context.api;
using strange.extensions.dispatcher.eventdispatcher.api;

namespace strange.extensions.mediation.impl
{
	public class EventMediator : Mediator
	{
		[Inject(ContextKeys.CONTEXT_DISPATCHER)]
		public IEventDispatcher dispatcher{ get; set;}

		private Dictionary<object, List<object>> eventMap = new Dictionary<object, List<object>>();

		/// Add an observer with exactly one argument to this Dispatcher
		public void AddListener( object evt, EventCallback callback )
		{
			MapListener( evt, callback);
			dispatcher.AddListener( evt, callback );
		}

		/// Add an observer with exactly no arguments to this Dispatcher
		public void AddListener( object evt, EmptyCallback callback )
		{
			MapListener( evt, callback);
			dispatcher.AddListener( evt, callback );
		}

		/// Remove a previously registered observer with exactly one argument from this Dispatcher
		public void RemoveListener( object evt, EventCallback callback )
		{
			UnmapListener( evt, callback );
			dispatcher.RemoveListener( evt, callback );
		}

		/// Remove a previously registered observer with exactly no arguments from this Dispatcher
		public void RemoveListener( object evt, EmptyCallback callback )
		{
			UnmapListener( evt, callback );
			dispatcher.RemoveListener( evt, callback );
		}

		/// Send a notification of type eventType and the provided data payload.
		/// In MVCSContext this dispatches an IEvent.
		public void Dispatch( object eventType, object data = null )
		{
			if( data != null )
			{
				dispatcher.Dispatch( eventType, data );
			}
			else
			{
				dispatcher.Dispatch( eventType );
			}
		}

		// Remove all callback from dispatcher
		public void RemoveAllListeners()
		{
			foreach( var pair in eventMap )
			{
				foreach( var call in pair.Value )
				{
					var eventCall = call as EventCallback;
					if( eventCall != null )
					{
						dispatcher.RemoveListener( pair.Key, eventCall );
					}
					else
					{
						dispatcher.RemoveListener( pair.Key, call as EmptyCallback );
					}
				}
			}
			eventMap.Clear();
		}

		public override void OnRemove()
		{
			RemoveAllListeners();
			base.OnRemove();
		}

		private void MapListener( object evt, object callback )
		{
			if( !eventMap.ContainsKey( evt ) )
			{
				eventMap.Add( evt, new List<object>() );
			}
			eventMap[evt].Add( callback );
		}
		private void UnmapListener( object evt, object callback )
		{
			if( eventMap.ContainsKey( evt ) )
			{
				eventMap[evt].Remove( callback );
			}
		}
	}
}

