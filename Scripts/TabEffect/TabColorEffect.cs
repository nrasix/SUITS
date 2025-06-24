using UnityEngine;
using UnityEngine.UI;

public class TabColorEffect : BaseTabEffect
{
    [SerializeField] protected Graphic _component;
    [SerializeField] private Color _selectedColor = Color.white;
    [SerializeField] private Color _deselectedColor = Color.gray;

    public override void ApplySelectEffect() => _component.color = _selectedColor;
    public override void ApplyDeselectEffect() => _component.color = _deselectedColor;
}