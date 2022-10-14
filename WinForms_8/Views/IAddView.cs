﻿namespace WinForms_8.Views;


public interface IAddView
{

    string FirstName { get; }
    string LastName { get; }
    decimal Score { get; }
    DateTime DateOfBirth { get; }

    event EventHandler SaveEvent;
    event EventHandler CancelEvent;

    void ClearTexts();

}