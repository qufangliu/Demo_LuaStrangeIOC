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
 * @class strange.extensions.mediation.impl.MediationBinder
 * 
 * Binds Views to Mediators. This is the base class for all MediationBinders
 * that work with GComponents.
 * 
 * Please read strange.extensions.mediation.api.IMediationBinder
 * where I've extensively explained the purpose of View mediation
 */

using System;
using System.Linq;
using FairyGUI;
using UnityEngine;
using strange.extensions.mediation.api;

namespace strange.extensions.mediation.impl
{
	public class MediationBinder : AbstractMediationBinder, IMediationBinder
	{
		public MediationBinder ()
		{
		}

		protected override bool HasMediator(object view, Type mediatorType)
		{
			GameObject obj = GetGameObject( view );
			return obj.GetComponent( mediatorType ) != null;
		}

		public override T GetMediator <T>(object view)
		{
			var obj = GetGameObject( view );
			return obj.GetComponent<T>();
		}

		/// Create a new Mediator object based on the mediatorType on the provided view
		protected override object CreateMediator(object view, Type mediatorType)
		{
			return GetGameObject(view).AddComponent(mediatorType);
		}

		/// Destroy the Mediator on the provided view object based on the mediatorType
		protected override IMediator DestroyMediator(object view, Type mediatorType)
		{
			IMediator mediator = GetGameObject(view).GetComponent(mediatorType) as IMediator;
			if (mediator != null)
				mediator.OnRemove();
			return mediator;
		}

		protected override void ThrowNullMediatorError(Type viewType, Type mediatorType)
		{
			throw new MediationException("The view: " + viewType.ToString() + " is mapped to mediator: " + mediatorType.ToString() + ". AddComponent resulted in null, which probably means " + mediatorType.ToString().Substring(mediatorType.ToString().LastIndexOf(".") + 1) + " is not a GComponent.", MediationExceptionType.NULL_MEDIATOR);
		}

		private GameObject GetGameObject( object view )
		{
			var mono = view as MonoBehaviour;
			if( mono != null )
			{
				return mono.gameObject;
			}
			else
			{
				var component = view as GComponent;
				return component.displayObject.gameObject;
			}
		}
	}
}

