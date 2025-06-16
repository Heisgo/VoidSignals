using System;
using System.Linq;
using UnityEngine;

namespace VoidSignals
{

    /// <summary>
    /// Signal without any payload. Handy for generic "ping" events.
    /// Raise it and all subscribers get the memo.
    /// </summary>
    [CreateAssetMenu(menuName = "VoidSignals/VoidSignal")]
    public class VoidSignal : SignalBase
    {
        /// <summary>
        /// Subscribe to this bad boy
        /// </summary>
        public void Register(Action callback)
        {
            AddListener(callback);
        }

        /// <summary>
        /// Unsubscribe, cuz cleanup matters
        /// </summary>
        public void Unregister(Action callback)
        {
            RemoveListener(callback);
        }

        /// <summary>
        /// Fire off the signal. Cleanup dead listeners first
        /// </summary>
        public void Raise()
        {
            Cleanup();
            foreach (Action callback in _listeners.OfType<Action>())
                callback?.Invoke();
        }
    }
}
