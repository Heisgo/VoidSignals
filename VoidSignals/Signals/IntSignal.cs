using UnityEngine;

namespace VoidSignals
{
    /// <summary>Concrete int-based signal.</summary>
    [CreateAssetMenu(menuName = "VoidSignals/IntSignal")]
    public class IntSignal : GenericSignal<int> { }

    // u can add more types (e.g., floatSignal, stringSignal [...])
}
