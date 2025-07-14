using System;
using Nrasix.SimpleTabSystem.Effect;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Nrasix.SimpleTabSystem
{
    public class Tab : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private GameObject _panel;
        [SerializeField] private bool _interactable = true;

        private BaseTabEffect[] _effectToTab;
        private int _countEffects;

        public bool Interactable
        {
            get => _interactable;
            set
            {
                _interactable = value;

                for (int i = 0; i < _countEffects; i++)
                {
                    _effectToTab[i].InteractableEffect(value);
                }
            }
        }

        public event Action<Tab> OnClickButton;

        public void Initialize()
        {
            _effectToTab = GetComponents<BaseTabEffect>();
            _countEffects = _effectToTab.Length;
            OnInitialize();
            UnselectTab();
        }

        public void SelectTab()
        {
            _panel.SetActive(true);

            for (int i = 0; i < _countEffects; i++)
            {
                _effectToTab[i].SelectedEffect();
            }

            OnSelectTab();
        }

        public void UnselectTab()
        {
            _panel.SetActive(false);

            for (int i = 0; i < _countEffects; i++)
            {
                _effectToTab[i].DeselectedEffect();
            }

            OnUnselectTab();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (!Interactable)
                return;

            OnClickButton?.Invoke(this);
        }

        public virtual void OnInitialize() { }
        public virtual void OnSelectTab() { }
        public virtual void OnUnselectTab() { }
    }
}