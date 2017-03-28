﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public abstract class MenuBase : MonoBehaviour, IMenu {

    #region Properties
    public Player CurrentPlayer { get; set; }
    private List<ISelectable> _currentSelectables = new List<ISelectable>();
    /// <summary>
    /// 
    /// </summary>
    public List<ISelectable> CurrentSelectables {
        get { return _currentSelectables; }
        set { _currentSelectables = value; }
    }
    /// <summary>
    /// Lista momentanea che salva gli ISelectable scelti nella fase precedente del menu
    /// </summary>
    List<ISelectable>  _firstSaveList= new List<ISelectable>();
    public List<ISelectable> FirstSaveList
    {
        get {return _firstSaveList; }
        set { _firstSaveList = value; }
    }
    private List<ISelectable> _selections = new List<ISelectable>();
    /// <summary>
    /// 
    /// </summary>
    public List<ISelectable> Selections {
        get { return _selections; }
        set { _selections = value; }
    }

    /// <summary>
    /// Se necessario contiene il primo livello di selectables.
    /// </summary>
    protected List<ISelectable> firstLevelSelections { get; set; }
    #endregion

    #region ViewProperties
    bool IsVisible = false;
    
    #endregion

    #region View

    private void Start() {
        Show(false);
    }

    public GameObject ButtonPrefab;
    public Transform MenuItemsContainer;

    /// <summary>
    /// Esegue il refresh della lista degli oggetti visibi del menù.
    /// </summary>
    public void RefreshItemList() {
        if (!IsVisible)
            return;
        foreach (SelectableButton button in GetComponentsInChildren<SelectableButton>()) {
            DestroyObject(button.gameObject);
        } 

        foreach (ISelectable item in CurrentSelectables) {
            CreateMenuItem(item);
        }
    }
    /// <summary>
    /// Crea un nuovo MenuItem per i button
    /// </summary>
    /// <param name="_item"></param>
    protected virtual void CreateMenuItem(ISelectable _item) {
        GameObject newGO = Instantiate(ButtonPrefab, MenuItemsContainer);
        SelectableButton newButton = newGO.GetComponent<SelectableButton>();
        newButton.SetData(_item);
        newButton.onClick.AddListener(() => this.AddSelection(newButton.SelectionData));
    }

    /// <summary>
    /// Abilita o disabilita la visualizzazione del menù.
    /// </summary>
    /// <param name="_show"></param>
    public void Show(bool _show) {
        IsVisible = _show;
        MenuItemsContainer.gameObject.SetActive(IsVisible);
    }

    #endregion

    /// <summary>
    /// Inizializza il menù.
    /// </summary>
    /// <param name="_player"></param>
    public void Init(Player _player, List<ISelectable> _firstLevelSelections = null) {
        CurrentPlayer = _player;
        if (_firstLevelSelections != null)
            firstLevelSelections = _firstLevelSelections;
        Show(true);
        LoadSelections();
    }

    public abstract void DoAction();

    public abstract void LoadSelections();
}
