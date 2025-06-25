using UnityEngine;
using UnityEngine.UI;

namespace Nrasix.SimpleTabSystem.Effect
{
    public class TabColorEffect : BaseTabEffect
    {
        [SerializeField] protected Graphic _component;
        [SerializeField] private Color _selectedColor = Color.white;
        [SerializeField] private Color _deselectedColor = Color.gray;
        [SerializeField] private Color _disabledColor = Color.gray;

        public override void SelectedEffect() => _component.color = _selectedColor;
        public override void DeselectedEffect() => _component.color = _deselectedColor;

        public override void InteractableEffect(bool value)
        {
            var resultColor = value ? Color.white : _disabledColor;

            if (_component is not null)
            {
                _component.CrossFadeColor(resultColor, 0f, true, true);
            }
        }
    }
}