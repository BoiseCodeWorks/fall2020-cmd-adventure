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
            if(Exits.ContainsKey(direction))
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

            return $@"This is the {Name} it is {Description}
            It has exits to the 
            {connections}";
        }
    }
}