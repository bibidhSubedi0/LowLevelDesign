using LowLevelDesign.DesignPatterns.Creational.Prototype;



Troop BaseTroop = new Troop("Brabarain", 50, "Sword");

Troop fastBrab = (Troop)BaseTroop.Clone();
fastBrab.Name = "Fast Barb";
fastBrab.Weapon = "Boot";

Troop Flyingbabr = (Troop)BaseTroop.Clone();
Flyingbabr.Name = "Flyingbabr";
Flyingbabr.Weapon = "Wings";


fastBrab.Show();
Flyingbabr.Show();