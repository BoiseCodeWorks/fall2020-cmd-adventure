using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;
using ConsoleAdventure.Project.Models;

namespace console_game_fall20.Project.Models
{
  public class TrapRoom : IRoom
  {
    public TrapRoom(string name, string description)
    {
      Name = name;
      Description = description;
      Items = new List<Item>();
      Exits = new Dictionary<string, IRoom>();
      Unlockable = new Dictionary<Item, string>();
    }

    public string Name { get; set; }
    public string Description { get; set; }
    public List<Item> Items { get; set; }
    public Dictionary<string, IRoom> Exits { get; set; }
    public bool Locked { get; set; } = true;
    public Dictionary<Item, string> Unlockable { get; set; }
    

    public void AddUnlockable(Item item, string afterDesc)
    {
        Unlockable.Add(item, afterDesc);
    }

    public string UseItem(Item itemName)
    {
        if(Unlockable.ContainsKey(itemName))
        {
            Locked = false;
            Description = Unlockable[itemName];
            return Unlockable[itemName];
        }
        return "item has little effect here";
    }

    public void AddRoomConnection(IRoom room, string direction)
    {
      Exits.Add(direction, room);
    }


    public string GetTemplate()
    {
      string items = "";
      Items.ForEach(i => items += $"{i.Name} - {i.Description}");
      if (Locked == true)
      {
        return $@"You wake up in {Name} 
        {Description}
        
        You see
        {items}
        ";
      }
      else
      {
        string connections = "";
        foreach (var room in Exits)
        {
          connections += room.Key + " ";
        }

        if (Items.Count == 0)
        {
          return $@"This is the {Name}
            It is {Description}

            There are no items in this room

            It has exits to the 
            {connections}";
        }
        else
        {
          return $@"This is the {Name}
            It is {Description}

            In this room you find
            {items}

            It has exits to the 
            {connections}";
        };
      }
    }

    public IRoom Move(string direction)
    {
      if (Locked == true)
      {
        return this;
      }
      else
      {
        if (Exits.ContainsKey(direction))
        {
          return Exits[direction];
        }
        return this;

      }
    }
  }
}