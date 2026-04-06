using System;

namespace DesignPatternChallenge.src.Models;

public abstract class MenuSystem
{
    public string Title { get; }
    public string Icon { get; }
    public bool IsActive { get; set;}

    protected MenuSystem(string title, string icon)
    {
        Title = title;
        Icon = icon;
        IsActive = true;
    }

    public abstract void Render(int ident = 0);

    public abstract int CountItems();
}
