using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Canvas))]

public class MenuPanel : MonoBehaviour
{
    [SerializeField]
    private PanelType type;

    private bool state;
    private Canvas canvas;
    private void Awake()
    {
        canvas = GetComponent<Canvas>();
    }

    //Affiche l'animation
    private void UpdateState()
    {
        canvas.enabled = state;
    }

    public void ChangeState()
    {
        state = !state;
        UpdateState();
    }

    public void ChangeState(bool _state)
    {
        state = _state;
        UpdateState();
    }

    #region Getter
    public PanelType GetPanelType() { return type; }
    #endregion
}
