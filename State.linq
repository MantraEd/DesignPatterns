<Query Kind="Program" />

void Main()
{

//The state pattern is a design pattern that allows an object to completely change its behavior depending upon its current internal state. By substituting classes within a defined context, the state object appears to change its type at run-time.

//This design pattern allows you to alter the behavior of an object as a response to changes of its internal state. It allows to change behavior at run-time without changing the interface used to access the object. This change is hidden in the context of this object. This pattern is very useful when creating software state machines, where the functionality of an object changes fundamentally according to its state.

    var player = new DVDPlayer();

    player.PressPlayButton();
    player.PressMenuButton();
    player.PressPlayButton();
    player.PressPlayButton();
    player.PressMenuButton();
    player.PressPlayButton();
    player.PressPlayButton();   
    
}
public class MenuState:DVDPlayerState
{
    public MenuState()
    {
        Console.WriteLine("MENU");
    }

    public override void PlayButtonPressed(DVDPlayer player)
    {
        Console.WriteLine("  Next Menu Item Selected");
    }

    public override void MenuButtonPressed(DVDPlayer player)
    {
        player.State = new StandbyState();
    }
}

public class MoviePausedState:DVDPlayerState
{
    public MoviePausedState()
    {
        Console.WriteLine("MOVIE PAUSED");
    }

    public override void PlayButtonPressed(DVDPlayer player)
    {
        player.State = new MoviePlayingState();
    }

    public override void MenuButtonPressed(DVDPlayer player)
    {
        player.State = new MenuState();
    }
}

public class MoviePlayingState:DVDPlayerState
{
    public MoviePlayingState()
    {
        Console.WriteLine("MOVIE PLAYING");
    }
 
    public override void PlayButtonPressed(DVDPlayer player)
    {
        player.State = new MoviePausedState();
    }

    public override void MenuButtonPressed(DVDPlayer player)
    {
        player.State = new MenuState();
    }
}

public class StandbyState:DVDPlayerState
{
    public StandbyState()
    {
        Console.WriteLine("STANDBY");
    }

    public override void PlayButtonPressed(DVDPlayer player)
    {
        player.State = new MoviePlayingState();
    }

    public override void MenuButtonPressed(DVDPlayer player)
    {
        player.State = new MenuState();
    }
}
 
public class DVDPlayer
{
    private DVDPlayerState _state;

    public DVDPlayer()
    {
        _state = new StandbyState();
    }

    public DVDPlayer(DVDPlayerState state)
    {
        _state = state;
    }

    public void PressPlayButton()
    {
        _state.PlayButtonPressed(this);
    }

    public void PressMenuButton()
    {
        _state.MenuButtonPressed(this);
    }

    public DVDPlayerState State
    {
        get { return _state; }
        set { _state = value; }
    }
}

public abstract class DVDPlayerState
{
public abstract void PlayButtonPressed(DVDPlayer player);

public abstract void MenuButtonPressed(DVDPlayer player);
}
