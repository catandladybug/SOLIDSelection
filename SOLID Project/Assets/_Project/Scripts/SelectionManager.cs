﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectionManager : MonoBehaviour
{
   

    private IRayProvider _rayProvider;
    private ISelector _selector;
    private ISelectionResponse _selectionResponse;

    private Transform _currentSelection;

    private void Awake()
    {
        _selectionResponse = GetComponent<ISelectionResponse>();
        _rayProvider = GetComponent<IRayProvider>();
        _selector = GetComponent<ISelector>();

        SceneManager.LoadScene("Environment", LoadSceneMode.Additive);
        SceneManager.LoadScene("UI", LoadSceneMode.Additive);
    }

    private void Update()
    {
        if (_currentSelection != null)
        {
            _selectionResponse.OnDeselect(_currentSelection);
        }

        _selector.Check(_rayProvider.CreateRay());
        _currentSelection = _selector.GetSelection();

        if (_currentSelection != null)
        {
           _selectionResponse.OnSelect(_currentSelection);
        }
    }
}