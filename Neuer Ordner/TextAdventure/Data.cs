using System;

namespace TextAdventure
{
    class Data
    {
        
        public Room Cabin = new Room
        {
            Name="Cabin",
            Describtion="",
        };
        public Room Garden = new Room
        {
            Name="Garden",
            Describtion="",
        };
        public Room Basement = new Room
        {
            Name="Basement",
            Describtion="",
        };
        public Room Brightforest = new Room
        {
            Name="Bright Forest",
            Describtion=""
        };
        public Room Darkforest = new Room
        {
            Name="Dark Forest",
            Describtion=""
        };
        public Room Orccamp = new Room
        {
            Name = "Orc Camp",
            Describtion = "",
        };


        public Item Key1 = new Item 
        {
            Name = "Big Key",
            Describtion = "This Key may open a secret door.",
        };
        public Item Key2 = new Item 
        {
            Name = "Small Key",
            Describtion = "This Key may open an hidden Crate.",
        };
        public Item Sword = new Item
        {
            Name = "Sword", 
            Describtion = "",
            Attackdamage = 20,
        };

        public Character Player = new Character
        {
            Isalive = true,
            HealthPoints = 50,
            AttackDamage = 10,
        };
        public Character Oldman = new Character
        {
            Name = "Old man",
            Describtion ="",
            HealthPoints = 100,

        };
    }
}