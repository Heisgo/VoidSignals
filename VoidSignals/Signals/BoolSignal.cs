using UnityEngine;

namespace VoidSignals
{
    /// <summary>Concrete bool-based signal.</summary>
    [CreateAssetMenu(menuName = "VoidSignals/BoolSignal")]
    public class BoolSignal : GenericSignal<bool> { }

    // u can add more types (e.g., floatSignal, stringSignal [...])
}

