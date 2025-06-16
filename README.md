# Void Signals for Unity
Because decoupling your events shouldn't feel like untangling headphone wires.
This plugin gives you a plug‑and‑play, asset‑driven event system powered by ScriptableObjects -- perfect for menus, triggers, combat systems, or whenever you need a clean "ping" without a hard reference.

## What makes it awesome?
* **Asset‑driven** -- Signals live as SO assets. No more `GetComponent` treasure hunts or Inspector drag‑n‑drops gone rogue.
* **SOLID & Extensible** -- Open for new signal types (just inherit `GenericSignal<T>`), closed for core modifications.
* **Inspector visibility** -- See every registered listener in real time, plus a “Raise Signal (Editor)” button for quick debug.
* **Type‑safe payloads** -- Built‑in `IntSignal`, `BoolSignal`, `FloatSignal`, `StringSignal`, or roll your own custom `GenericSignal<T>`.
* **UnityEvent<T> support** -- Drag callbacks with parameters directly in the Inspector. Zero boilerplate.
* **Auto‑cleanup** -- Nobody likes null‑ref spam. Dead listeners auto‑unsubscribe before dispatch.

## Installing

1. Drop the `VoidSignals` folder into `Assets/Plugins/` (or anywhere inside `Assets`). (You can also use the .unitypackage file)
2. Optionally organize ScriptableObject assets in your own `Resources` or custom folder.
3. Add `using VoidSignals;` (or your namespace) to your scripts when doing code‑driven subscription.
4. You're golden. 🎉

## Quick Start Guide

### 1. Create your signal asset
Right‑click in Project window -> **Create -> VoidSignals -> \[VoidSignal | IntSignal | BoolSignal | …]**
You now have an SO that can broadcast events globally.

### 2. Listen via Inspector (no code required)
1. Add the **VoidSignalListener** (for no‑arg signals) or the specific **IntSignalListener**, **BoolSignalListener**, etc., to any GameObject.
2. Drag your SO asset into the `signal` field.
3. Hook up your method in the `UnityEvent` below. If it's a typed listener, you can drag methods with matching signatures (e.g. `void OnScoreChanged(int newScore)`).

### 3. Fire from code
If you prefer code wiring, it's just as simple:

```csharp
public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private IntSignal onDamageTaken;

    private void OnEnable()  => onDamageTaken.Register(HandleDamage);
    private void OnDisable() => onDamageTaken.Unregister(HandleDamage);

    private void HandleDamage(int amount)
    {
        health -= amount;
    }

    public void TakeDamage(int dmg)
    {
        onDamageTaken.Raise(dmg); // boom -- all listeners get notified
    }
}
```

### 4. Hack & Test in Editor
* **Inspector list**: Open any Signal asset and see every listener listed by script name + method.
* **"Raise Signal (Editor)" button**: Simulate events at edit‑time to verify wiring without hitting Play.

---

## Full Example

```csharp
using UnityEngine;
using VoidSignals;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "VoidSignals/IntSignal")]
public class EnemyCountSignal : IntSignal { }

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private IntSignal onEnemySpawned;

    public void SpawnEnemy()
    {
        // spawn logic...
        onEnemySpawned.Raise( currentEnemyCount );
    }
}

public class UIManager : MonoBehaviour
{
    [SerializeField] private IntSignalListener enemyCountListener;
    [SerializeField] private UnityEngine.UI.Text countText;
    
    private void Awake()
    {
        enemyCountListener.onSignal.AddListener(UpdateUI);
    }

    private void UpdateUI(int count)
    {
        countText.text = $"Enemies: {count}";
    }
}
```

---

## Customize It!

* **New serializers**: Swap JSON for Protobuf by inheriting `GenericSignal<T>` with your own payload logic.
* **Custom SO menus**: Tweak `[CreateAssetMenu]` paths to fit your project’s naming conventions.
* **Advanced cleanup**: Integrate `WeakReference` or domain‑reload hooks if you’re super paranoid.

---

## Why not just raw Actions/UnityEvents?

1. **No hard refs**: events live as assets, not tied to specific GameObjects or scenes.
2. **Global broadcaster**: any system can subscribe/unsubscribe without passing around instances.
3. **Edit‑time debug**: visualize & fire signals without runtime hacks.
4. **Zero null‑ref drama**: auto‑clean keeps your console silent.
5. **One line to extend**: add `Vector3Signal`, `CustomDataSignal`, whatever — without touching core code.

---

## ❤️ Thanks for trying Void Signals!

If it saved you from another tangled event nightmare, drop a ⭐ on GitHub. Built with coffee, sweat, and too many null‑ref bugs fixed. 🚀
