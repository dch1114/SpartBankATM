using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupBank : UIBase
{
    [SerializeField] private Text userName;
    [SerializeField] private Text balance;
    [SerializeField] private Text cash;

    private void Start()
    {
        GameManager.instance.LoadUserData("¼®µ¿±¸");
        Refresh();
    }

    public void Deposit(int money)
    {
        if (!GameManager.instance.User.Deposit(money))
        {
            UIManager.Instance.Show("PopupError");
            return;
        }

        GameManager.instance.SaveUserData();

        Refresh();
    }

    public void Withdraw(int money)
    {
        if (!GameManager.instance.User.Withdraw(money))
        {
            UIManager.Instance.Show("PopupError");
            return;
        }

        GameManager.instance.SaveUserData();

        Refresh();
    }

    public void CustomDeposit(InputField inputField)
    {
        Deposit(int.Parse(inputField.text));
    }

    public void CustomWithdraw(InputField inputField)
    {
        Withdraw(int.Parse(inputField.text));
    }

    private void Refresh()
    {
        userName.text = GameManager.instance.User.Name;
        balance.text = GameManager.instance.User.Balance.ToString();
        cash.text = GameManager.instance.User.Cash.ToString();
    }
}
