using System.Collections.Generic;
using console_game_fall20.Project.Models;
using ConsoleAdventure.Project.Interfaces;
using ConsoleAdventure.Project.Models;

namespace ConsoleAdventure.Project
{
  public class GameService : IGameService
  {
    private IGame _game { get; set; }

    public List<string> Messages { get; set; }
    public GameService()
    {
      _game = new Game();
      Messages = new List<string>();
    }
    public void Go(string direction)
    {
      string from = _game.CurrentRoom.Name;
      _game.CurrentRoom = _game.CurrentRoom.Move(direction);
      string to = _game.CurrentRoom.Name;
      if (from == to)
      {
        System.Console.WriteLine("something went wrong/ you cannot go here");
      }
      System.Console.WriteLine($"Traveled to {to} from {from}");
    }
    public void Help()
    {
      throw new System.NotImplementedException();
    }

    public void Inventory()
    {
      throw new System.NotImplementedException();
    }

    public void Look()
    {
      System.Console.WriteLine(_game.CurrentRoom.GetTemplate());
    }

    ///<summary>
    ///Restarts the game 
    ///</summary>
    public void Reset()
    {
      throw new System.NotImplementedException();
    }

    public void Setup(string playerName)
    {
      _game.CurrentPlayer.Name = playerName;
    }
    ///<summary>When taking an item be sure the item is in the current room before adding it to the player inventory, Also don't forget to remove the item from the room it was picked up in</summary>
    public void TakeItem(string itemName)
    {
      if (_game.CurrentRoom.Items.Count == 0)
      {
        System.Console.WriteLine("No items currently in here");
        return;
      }

      for (int i = 0; i < _game.CurrentRoom.Items.Count; i++)
      {
        var item = _game.CurrentRoom.Items[i];
        if (item.Name.ToLower() == itemName.ToLower())
        {
          System.Console.WriteLine($"Picked up {item.Name}");
          _game.CurrentPlayer.Inventory.Add(item);
          _game.CurrentRoom.Items.Remove(item);
          return;
        }
      }

      System.Console.WriteLine("Enter Valid Item");
      return;
    }
    ///<summary>
    ///No need to Pass a room since Items can only be used in the CurrentRoom
    ///Make sure you validate the item is in the room or player inventory before
    ///being able to use the item
    ///</summary>
    public void UseItem(string itemName)
    {
      IRoom room = _game.CurrentRoom;
      if (room is TrapRoom)
      {
        for (int i = 0; i < _game.CurrentPlayer.Inventory.Count; i++)
        {
          var item = _game.CurrentPlayer.Inventory[i];
          if (item.Name.ToLower() == itemName)
          {
            System.Console.WriteLine($"Used youre {item.Name}");
            System.Console.WriteLine(room.UseItem(item));
          }
        }
      }
      else
      {
        System.Console.WriteLine("Item has no use here");
      }
    }
  }
}
