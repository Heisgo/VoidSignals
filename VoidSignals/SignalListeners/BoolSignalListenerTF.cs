using UnityEngine;
using UnityEngine.Events;

namespace VoidSignals
{
    [AddComponentMenu("VoidSignals/BoolSignalListener (True/False)")]
    public class BoolSignalListenerTF : MonoBehaviour
    {
        [Tooltip("ScriptableObject signal with bool payload")] // change this to TooltipExtended if you're using VoidAttributes
        public BoolSignal signal;

        [Space, Tooltip("Fires when payload == true")] // change this to TooltipExtended if you're using VoidAttributes
        public UnityEvent onTrue;
        [Tooltip("Fires when payload == false")] // change this to TooltipExtended if you're using VoidAttributes
        public UnityEvent onFalse;

        private void OnEnable() => signal.Register(Handle);
        private void OnDisable() => signal.Unregister(Handle);

        private void Handle(bool value)
        {
            if (value) onTrue.Invoke();
            else onFalse.Invoke();
        }
    }
}