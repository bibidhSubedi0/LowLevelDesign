using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LowLevelDesign.DesignPatterns.Creational.AbstractFactory
{


    public interface FurnitureFactory
    {
        public Chair GetChair();
        public CoffeeTable GetCoffeeTable();
    }
    class VictorianFurnitureFactory : FurnitureFactory
    {
        public Chair GetChair()
        {
            return new VictorianChair();
        }
        public CoffeeTable GetCoffeeTable()
        {
            return new VictorianCoffeeTable();
        }
    }
    class ModernFurnitureFactory : FurnitureFactory
    {
        public Chair GetChair()
        {
            return new ModernChair();
        }
        public CoffeeTable GetCoffeeTable()
        {
            return new ModernCoffeeTable();
        }
    }
    public interface Chair
    {
        public void ChairChar();
    }
    class VictorianChair: Chair
    {
        public void ChairChar()
        {
            Console.WriteLine("Is a victorian chair");
        }
    }
    class ModernChair : Chair
    {
        public void ChairChar()
        {
            Console.WriteLine("Is a Modern chair");
        }
    }
    public interface CoffeeTable
    {
        public void CoffeeChar();
    }
    class VictorianCoffeeTable : CoffeeTable
    {
        public void CoffeeChar()
        {
            Console.WriteLine("Is a victorian CoffeeTable");
        }
    }
    class ModernCoffeeTable : CoffeeTable
    {
        public void CoffeeChar()
        {
            Console.WriteLine("Is a Modern CoffeeTable");
        }
    }




    class FurnitureShop
    {
        private FurnitureFactory _furnitureFactory;
        private Chair _chair;
        private CoffeeTable _coffeeTable;

        public FurnitureShop(FurnitureFactory furnitureFactory)
        {
            _furnitureFactory = furnitureFactory;
        }

        public void AssembleFurniture()
        {
            _chair = _furnitureFactory.GetChair();
            _coffeeTable = _furnitureFactory.GetCoffeeTable();
        }

        public void ShowFurniture()
        {
            _chair.ChairChar();
            _coffeeTable.CoffeeChar();
        }

    }
}


