using UnityEngine;
using UnityEngine.UI;

namespace Nrasix.SimpleTabSystem
{
    [RequireComponent(typeof(Image))]
    public class TabImage : Tab
    {
        [SerializeField] private Color _selectedColor;
        [SerializeField] private Color _unselectedColor;

        private Image _image;

        public override void Initialize()
        {
            base.Initialize();
            _image = GetComponent<Image>();
        }

        public override void SelectTab()
        {
            base.SelectTab();
            _image.color = _selectedColor;
        }

        public override void UnselectTab()
        {
            base.UnselectTab();
            _image.color = _unselectedColor;
        }
    }
}