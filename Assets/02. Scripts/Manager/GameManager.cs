using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public UserData User;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        UIManager.Instance.Show("PopupBank");
    }

    public void SaveUserData()
    {
        string data = JsonUtility.ToJson(User, true);

        string path = Path.Combine(Application.dataPath, User.Name + ".Json");

        File.WriteAllText(path, data);

        Debug.Log("저장 완료 : " + path);
    }

    public void LoadUserData(string userName)
    {
        string path = Path.Combine(Application.dataPath, userName + ".Json");

        string data = File.ReadAllText(path);

        User = JsonUtility.FromJson<UserData>(data);

        Debug.Log("로드 완료 : " + path);
    }
}
