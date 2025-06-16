using System.Collections.Generic;
using System;
using UnityEngine;

namespace VoidSignals
{

    /// <summary>
    /// Base class for all signals. Handles listener registration and cleanup.
    /// Think of it like the godfather of this event system, chilling in the SO (scriptable object) world
    /// </summary>
    public abstract class SignalBase : ScriptableObject
    {
        // Holds all listener callbacks, we auto-clean dead ones
        protected readonly List<Delegate> _listeners = new();

        /// <summary>
        /// Core add listener. Change this (and the RemoveListener) to protected if you won't use it on code (just in the inspector) if you wanna more security 
        /// </summary>
        public void AddListener(Delegate listener)
        {
            if (_listeners.Contains(listener)) return;
            _listeners.Add(listener);
        }

        /// <summary>
        /// Core remove listener. No ghost listeners hangin' around
        /// </summary>
        public void RemoveListener(Delegate listener)
        {
            _listeners.Remove(listener);
        }

        /// <summary>
        /// Cleans up null or stale delegates. Call before raising to keep it tidy
        /// </summary>
        protected void Cleanup()
        {
            _listeners.RemoveAll(d => d == null);
        }
    }

}
