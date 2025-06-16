using UnityEngine;
using UnityEngine.Events;

namespace VoidSignals
{
    /// <summary>Listener for BoolSignal in Inspector.</summary>
    [AddComponentMenu("VoidSignals/BoolSignalListener")]
    public class BoolSignalListener : TypedSignalListener<bool, BoolSignal, UnityEvent<bool>> { }

    // Add more listeners (float, string [...]) as you add more signals
}
