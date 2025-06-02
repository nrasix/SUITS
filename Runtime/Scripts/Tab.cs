using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Nrasix.SimpleTabSystem
{
    public class Tab : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] public GameObject _panel;

        public event Action<Tab> OnClickButton;

        public virtual void Initialize() => UnselectTab();
        public virtual void SelectTab() => _panel.SetActive(true);
        public virtual void UnselectTab() => _panel.SetActive(false);
        public void OnPointerClick(PointerEventData eventData) => OnClickButton?.Invoke(this);
    }
}