using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBase : MonoBehaviour
{
    [HideInInspector]
    public Canvas canvas;

    public void Show()
    {
        canvas = UIManager.Instance.mainCanvas;

        GameObject obj = Instantiate(gameObject, UIManager.Instance.mainCanvas.transform);
        obj.name = obj.name.Replace("(Clone)", "");

        UIManager.Instance.UI_Obj_List.Add(obj.GetComponent<UIBase>());
    }

    public void Hide()
    {
        UIManager.Instance.UI_Obj_List.Remove(this);

        Destroy(gameObject);
    }
}
