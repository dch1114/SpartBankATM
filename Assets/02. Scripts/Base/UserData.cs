using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class UserData
{
    public string Name;
    public int Balance;
    public int Cash;

    public UserData(string name, int balance, int cash)
    {
        Name = name;
        Balance = balance;
        Cash = cash;
    }

    public bool Deposit(int money)
    {
        if (Cash < money)
            return false;

        Cash -= money;
        Balance += money;

        return true;
    }

    public bool Withdraw(int money)
    {
        if(Balance < money)
            return false;

        Cash += money;
        Balance -= money;

        return true;
    }
}
