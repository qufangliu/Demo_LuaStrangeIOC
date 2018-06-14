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
 * @class strange.extensions.context.impl.Context
 * 
 * A Context is the entry point to the binding framework.
 * 
 * Extend this class to create the binding context suitable 
 * for your application.
 * 
 * In a typical Unity3D setup, extend MVCSContext and instantiate 
 * your extension from the ContextView.
 */

using strange.extensions.context.api;
using strange.framework.impl;

namespace strange.extensions.context.impl
{
    public class Context:Binder, IContext
    {
        /// In a multi-Context app, this represents the first Context to instantiate.
        public static IContext context;

        /// If false, the `Launch()` method won't fire.
        public bool autoStartup;

        public Context():this( ContextStartupFlags.AUTOMATIC )
        { }

        public Context( ContextStartupFlags flags )
        {
            context = this;
            addCoreComponents();
            autoStartup = (flags & ContextStartupFlags.MANUAL_LAUNCH) != ContextStartupFlags.MANUAL_LAUNCH;
            if( (flags & ContextStartupFlags.MANUAL_MAPPING) != ContextStartupFlags.MANUAL_MAPPING )
            {
                Start();
            }
        }

        public Context( bool autoMapping )
            :this( (autoMapping) ? ContextStartupFlags.MANUAL_MAPPING : ContextStartupFlags.MANUAL_LAUNCH | ContextStartupFlags.MANUAL_MAPPING )
        { }

        /// Override to add componentry. Or just extend MVCSContext.
        virtual protected void addCoreComponents()
        { }

        /// Override to instantiate componentry. Or just extend MVCSContext.
        virtual protected void instantiateCoreComponents()
        { }

        /// Call this from your Root to set everything in action.
        virtual public IContext Start()
        {
            instantiateCoreComponents();
            mapBindings();
            postBindings();
            if( autoStartup )
                Launch();
            return this;
        }

        /// The final method to fire after mappings.
        /// If autoStartup is false, you need to call this manually.
        virtual public void Launch()
        { }

        /// Override to map project-specific bindings
        virtual protected void mapBindings()
        { }

        /// Override to do things after binding but before app launch
        virtual protected void postBindings()
        { }

        /// Retrieve a component from this Context by generic type
        virtual public object GetComponent <T>()
        {
            return null;
        }


        /// Retrieve a component from this Context by generic type and name
        virtual public object GetComponent <T>( object name )
        {
            return null;
        }

        /// Register a View with this Context
        virtual public void AddView( object view )
        {
            //Override in subclasses
        }

        /// Remove a View from this Context
        virtual public void RemoveView( object view )
        {
            //Override in subclasses
        }

        /// Enable a View from this Context
        virtual public void EnableView( object view )
        {
            //Override in subclasses
        }

        /// Disable a View from this Context
        virtual public void DisableView( object view )
        {
            //Override in subclasses
        }
    }
}