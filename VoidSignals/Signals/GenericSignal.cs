using System;
using System.Linq;
using UnityEngine;

namespace VoidSignals
{
    /// <summary>
    /// Generic payload signal. >>!!Extend for int, bool, string, etc.!!<<
    /// Single source of truth: don't repeat code.
    /// </summary>
    public abstract class GenericSignal<T> : SignalBase
    {
        /// <summary>Register your listener.</summary>
        public void Register(Action<T> callback)
        {
            AddListener(callback);
        }
        /// <summary>Unregister when you're done.</summary>
        public void Unregister(Action<T> callback)
        {
            RemoveListener(callback);
        }
        /// <summary>Raise it with a payload.</summary>
        public void Raise(T payload)
        {
            Cleanup();
            foreach (var del in _listeners.OfType<Action<T>>())
            {
                del.Invoke(payload);
            }
        }
    }
}
