using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Nrasix.SimpleTabSystem
{
    public class Tab : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] public GameObject _panel;

        private BaseTabEffect _effectToTab;

        public event Action<Tab> OnClickButton;

        public virtual void Initialize()
        {
            _effectToTab = GetComponent<BaseTabEffect>();
            UnselectTab();
        }

        public virtual void SelectTab()
        {
            _panel.SetActive(true);
            _effectToTab?.ApplySelectEffect();
        }

        public virtual void UnselectTab()
        {
            _panel.SetActive(false);
            _effectToTab?.ApplyDeselectEffect();
        }

        public void OnPointerClick(PointerEventData eventData) => OnClickButton?.Invoke(this);
    }
}