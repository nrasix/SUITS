using System;
using System.Collections.Generic;
using UnityEngine;

namespace Nrasix.SimpleTabSystem
{
    public class TabSystem : MonoBehaviour
    {
        [SerializeField] private List<Tab> _tabs;

        private Tab _selectedTab;

        public Tab SelectedTab => _selectedTab;
        public int SelectedTabIndex => _tabs.IndexOf(_selectedTab);

        public IReadOnlyList<Tab> Tabs => _tabs;
        public int CountTabs => _tabs.Count;

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

        private void OnDestroy()
        {
            for (int i = 0, len = _tabs.Count; i < len; i++)
            {
                var tab = _tabs[i];
                tab.OnClickButton -= OnClickTab;
            }
        }

        private void OnClickTab(Tab tab)
        {
            if (_selectedTab != null)
                _selectedTab.UnselectTab();

            SetSelectedTab(tab);

            OnTabSelected?.Invoke(_selectedTab);
            OnTabSelectedIndexChanged?.Invoke(_tabs.IndexOf(_selectedTab));
        }

        public void SetSelectedTab(Tab tab)
        {
            _selectedTab = tab;
            _selectedTab.SelectTab();
        }

        public void SetSelectedTab(int index)
        {
            if(index < 0 || index >= _tabs.Count)
            {
                Debug.LogError($"[TAB SYSTEM] Index {index} is out of range for the tabs list.");
                return;
            }

            if(_tabs[index] is null)
            {
                Debug.LogError($"[TAB SYSTEM] Tab at index {index} is null.");
                return;
            }

            SetSelectedTab(_tabs[index]);
        }

        public void NextTab()
        {
            int nextIndex = (SelectedTabIndex + 1) % _tabs.Count;
            OnClickTab(_tabs[nextIndex]);
        }

        public void PreviousTab()
        {
            int previousIndex = (SelectedTabIndex - 1 + _tabs.Count) % _tabs.Count;
            OnClickTab(_tabs[previousIndex]);
        }
    }
}