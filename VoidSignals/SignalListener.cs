using UnityEngine;

namespace VoidSignals
{
    /// <summary>
    /// Attach this to any MonoBehaviour to hook up to ScriptableObject signals
    /// Auto handles subscribe/unsub if you're lazy (like me)
    /// </summary>
    public class SignalListener : MonoBehaviour
    {
        [Tooltip("The signal asset you're listening to")] // Switch to TooltipExtended if you're using my 'VoidAttributes' plugin ;D
        public VoidSignal signal;

        [Tooltip("Event to invoke when the signal fires")] // Switch to TooltipExtended if you're using my 'VoidAttributes' plugin ;D
        public UnityEngine.Events.UnityEvent onSignal;

        private void OnEnable() => signal?.Register(InvokeEvent);
        private void OnDisable() => signal?.Unregister(InvokeEvent);
        private void InvokeEvent() => onSignal?.Invoke();
    }
}
