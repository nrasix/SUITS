using UnityEngine;

namespace Nrasix.SimpleTabSystem.Effect
{
    public abstract class BaseTabEffect : MonoBehaviour
    {
        public abstract void SelectedEffect();
        public abstract void DeselectedEffect();

        public virtual void InteractableEffect(bool value) {}
    }
}