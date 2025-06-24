using System;
using System.Collections.Generic;
using UnityEngine;

namespace Nrasix.SimpleTabSystem
{
    public class TabSystem : MonoBehaviour
    {
        [SerializeField] private List<Tab> _tabs;

        private Tab _selectedTab;

        public event Action<Tab> OnTabSelected;
        public event Action<int> OnTabSelectedIndexChanged;

        private void Awake() => InitializeTabs();

        private void InitializeTabs()
        {
            for (int i = 0, len = _tabs.Count; i < len; i++)
            {
                var tab = _tabs[i];
                tab.Initialize();
                tab.OnClickButton += OnClickTab;
            }

            OnClickTab(_tabs[0]);
        }

        private void OnClickTab(Tab tab)
        {
            if (_selectedTab != null)
                _selectedTab.UnselectTab();

            _selectedTab = tab;
            _selectedTab.SelectTab();

            OnTabSelected?.Invoke(_selectedTab);
            OnTabSelectedIndexChanged?.Invoke(_tabs.IndexOf(_selectedTab));
        }
    }
}