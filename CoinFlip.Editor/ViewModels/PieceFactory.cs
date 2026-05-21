using System;
using System.Windows.Input;
using CoinFlip.Engine.Interfaces;
using CoinFlip.Engine.Pieces;

namespace CoinFlip.Editor.ViewModels;


public class ConversationFactory(MainWindowViewModel window) : ICommand
{
    private MainWindowViewModel window = window;

    public event EventHandler? CanExecuteChanged;

    public bool CanExecute(object? parameter)
    {
        return true;
    }

    public void Execute(object? parameter)
    {
        window.CurrentPiece?.Children.Add(new Conversation() { Description = "Conversation" });
    }
}

public class OptionFactory(MainWindowViewModel window) : ICommand
{
    private MainWindowViewModel window = window;

    public event EventHandler? CanExecuteChanged;

    public bool CanExecute(object? parameter)
    {
        return true;
    }

    public void Execute(object? parameter)
    {
        window.CurrentPiece?.Children.Add(new Option() { Description = "Option" });
    }
}