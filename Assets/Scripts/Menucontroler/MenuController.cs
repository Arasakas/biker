using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public enum PanelType
{
    None,
    Main,
    Option,
    Credits,
}
public class MenuController : MonoBehaviour
{
    [Header("Panels")]

    [SerializeField]
    private List<MenuPanel> panelsList = new List<MenuPanel>();

    private Dictionary<PanelType, MenuPanel> panelsDict = new Dictionary<PanelType, MenuPanel>();

    private GameManager manager;

    private void Start()
    {
        manager = GameManager.instance;

        foreach (var _panel in panelsList)
        {
            if (_panel) panelsDict.Add(_panel.GetPanelType(), _panel);
        }

        OpenOnePanel(PanelType.Main);
    }

    private void OpenOnePanel(PanelType _type)
    {
        foreach (var _panel in panelsList)
        {
            _panel.ChangeState(false);

            if (_type != PanelType.None)
                panelsDict[_type].ChangeState(true);
        }
    }

    public void OpenPanel(PanelType _type)
    {
        OpenOnePanel(_type);
    }

    public void ChangeScene(string _sceneName)
    {
        manager.ChangeScene(_sceneName);
    }

    public void Quit()
    {
        manager.Quit();
    }
}
