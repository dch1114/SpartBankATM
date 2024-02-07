using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupBank : MonoBehaviour
{
    [SerializeField] private Text userName;
    [SerializeField] private Text balance;
    [SerializeField] private Text cash;
    [SerializeField] private GameObject popupError;

    private void Start()
    {
        Refresh();
    }

    public void Deposit(int money)
    {
        if (!GameManager.instance.User.Deposit(money))
        {
            popupError.SetActive(true);
            return;
        }

        Refresh();
    }

    public void Withdraw(int money)
    {
        if (!GameManager.instance.User.Withdraw(money))
        {
            popupError.SetActive(true);
            return;
        }

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
