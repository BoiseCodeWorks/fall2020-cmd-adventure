using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;

namespace ConsoleAdventure.Project.Models
{
  public class Room : IRoom
  {
    public Room(string name, string description)
    {
      Name = name;
      Description = description;
      Items = new List<Item>();
      Exits = new Dictionary<string, IRoom>();

    }

    public string Name { get; set; }
    public string Description { get; set; }
    public List<Item> Items { get; set; }
    public Dictionary<string, IRoom> Exits { get; set; }
    //"east" : room2
    //"north" : room3

    public IRoom Move(string direction)
    {
      if (Exits.ContainsKey(direction))
      {
        return Exits[direction];
      }
      return this;
    }

    public void AddRoomConnection(IRoom room, string direction)
    {
      Exits.Add(direction, room);
    }

    public string GetTemplate()
    {
      string connections = "";
      foreach (var room in Exits)
      {
        connections += room.Key + " ";
      }
      string items = "";
      Items.ForEach(i => items += $"{i.Name} - {i.Description}");

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
     public string UseItem(Item itemName)
    {
        return "item has little effect here";
    }
  }
}