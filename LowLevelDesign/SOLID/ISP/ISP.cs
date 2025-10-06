using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LowLevelDesign.SOLID.ISP
{
    internal interface ISP
    {
    }
}


/*

“Clients should not be forced to depend on interfaces they do not use.”


“Fat Interface” Problem
+---------------------+
|      IWorker        |
+---------------------+
| + Work()            |
| + Eat()             |
| + Sleep()           |
+---------------------+
       ▲       ▲
       |       |
       |       |
+--------------+--------------+
| HumanWorker  |  RobotWorker |
+--------------+--------------+


// One big interface
public interface IWorker
{
    void Work();
    void Eat();
    void Sleep();
}

public class HumanWorker : IWorker
{
    public void Work() => Console.WriteLine("Human working...");
    public void Eat() => Console.WriteLine("Human eating...");
    public void Sleep() => Console.WriteLine("Human sleeping...");
}

// A Robot also has to implement Eat() and Sleep() even if it doesn’t need them
public class RobotWorker : IWorker
{
    public void Work() => Console.WriteLine("Robot working...");

    public void Eat() => throw new NotImplementedException();    // ❌ Useless
    public void Sleep() => throw new NotImplementedException();  // ❌ Useless
}

 

+-----------+    +------------+    +-------------+
| IWorkable |    | IFeedable  |    | ISleepable  |
+-----------+    +------------+    +-------------+
| + Work()  |    | + Eat()    |    | + Sleep()   |
+-----------+    +------------+    +-------------+
      ▲                ▲                 ▲
      |                |                 |
      |                |                 |
+---------------------+------------------+
|      HumanWorker    |  RobotWorker     |
+---------------------+------------------+
| Work(), Eat(),      | Work()           |
| Sleep()             |                  |
+---------------------+------------------+



public interface IWorkable
{
    void Work();
}

public interface IFeedable
{
    void Eat();
}

public interface ISleepable
{
    void Sleep();
}

// Human implements all relevant behaviors
public class HumanWorker : IWorkable, IFeedable, ISleepable
{
    public void Work() => Console.WriteLine("Human working...");
    public void Eat() => Console.WriteLine("Human eating...");
    public void Sleep() => Console.WriteLine("Human sleeping...");
}

// Robot implements only what it needs
public class RobotWorker : IWorkable
{
    public void Work() => Console.WriteLine("Robot working...");
}




🟩 9. Cheat Sheet

Keep interfaces focused & minimal.
Group logically related methods together.
Avoid “fat” or “god” interfaces.
Use role-based interfaces to keep code flexible.
Watch out for empty implementations — a common smell of ISP violation


 */