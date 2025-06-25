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

        public virtual void Initialize()
        {
            _effectToTab = GetComponents<BaseTabEffect>();
            _countEffects = _effectToTab.Length;
            UnselectTab();
        }

        public virtual void SelectTab()
        {
            _panel.SetActive(true);

            for (int i = 0; i < _countEffects; i++)
            {
                _effectToTab[i].SelectedEffect();
            }
        }

        public virtual void UnselectTab()
        {
            _panel.SetActive(false);

            for (int i = 0; i < _countEffects; i++)
            {
                _effectToTab[i].DeselectedEffect();
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (!Interactable)
                return;

            OnClickButton?.Invoke(this);
        }
    }
}