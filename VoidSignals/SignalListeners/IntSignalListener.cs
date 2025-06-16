using UnityEngine;
using UnityEngine.Events;

namespace VoidSignals
{
    /// <summary>Listener for IntSignal in Inspector.</summary>
    [AddComponentMenu("VoidSignals/IntSignalListener")]
    public class IntSignalListener : TypedSignalListener<int, IntSignal, UnityEvent<int>> { }

    // Add more listeners (float, string [...]) as you add more signals
}
