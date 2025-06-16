using UnityEngine;
using UnityEngine.Events;

namespace VoidSignals
{
    /// <summary>
    /// Base component: subclass it for any payload type
    /// </summary>
    public abstract class TypedSignalListener<T, S, UE> : MonoBehaviour
        where S : GenericSignal<T>
        where UE : UnityEvent<T>
    {

        [Tooltip("ScriptableObject signal with payload")]
        public S signal;
        [Tooltip("Event to fire when signal raises")]
        public UE onSignal;

        private void OnEnable() => signal?.Register(OnRaised);
        private void OnDisable() => signal?.Unregister(OnRaised);
        private void OnRaised(T value) => onSignal?.Invoke(value);
    }
}
