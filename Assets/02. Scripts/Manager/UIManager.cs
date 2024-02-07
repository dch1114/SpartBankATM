using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public Canvas mainCanvas;

    public List<UIBase> UI_List = new List<UIBase>();

    [HideInInspector]
    public List<UIBase> UI_Obj_List = new List<UIBase>();

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void Show(string uiName)
    {
        UIBase ui = UI_List.Find(obj => obj.name == uiName);

        if (ui == null)
            return;

        ui.Show();
    }

    public void Hide(string uiName)
    {
        UIBase ui = UI_List.Find(obj => obj.name == uiName);

        if (ui == null)
            return;

        ui.Hide();
    }
}
