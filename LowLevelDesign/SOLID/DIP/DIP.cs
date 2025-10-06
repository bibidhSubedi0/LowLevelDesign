using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LowLevelDesign.SOLID.DIP
{
    internal class DIP
    {
    }
}

/*
    “High-level modules should not depend on low-level modules.
    Both should depend on abstractions.”

    “Abstractions should not depend on details.
    Details should depend on abstractions.”

🔑 High-level modules → contain business logic.
🔑 Low-level modules → deal with technical details (like DB, APIs, file I/O).
🔑 Abstractions → interfaces or abstract classes.


+--------------------+
|  ReportService     |
+--------------------+
|  - FileLogger      | <-- High-level depends directly on low-level
+--------------------+
          |
          v
+--------------------+
|    FileLogger      |
+--------------------+

 
// Low-level module
public class FileLogger
{
    public void Log(string message)
    {
        Console.WriteLine($"[FileLog]: {message}");
    }
}

// High-level module
public class ReportService
{
    private readonly FileLogger _logger = new FileLogger(); // ❌ Direct dependency

    public void GenerateReport()
    {
        _logger.Log("Report generated.");
    }
}

ReportService (high-level) depends directly on FileLogger (low-level).
If we switch to DatabaseLogger, we must modify ReportService.
Violates OCP and is hard to test.




        +------------------+
        |     ILogger      | <---- abstraction
        +------------------+
         ^                ^
         |                |
+----------------+   +-------------------+
|  FileLogger    |   |  DatabaseLogger    |
+----------------+   +-------------------+

         ▲
         |
+------------------------+
|     ReportService      | <---- depends on ILogger
+------------------------+



Step 1: Define an Abstraction
public interface ILogger
{
    void Log(string message);
}

Step 2: Implement Low-Level Details
public class FileLogger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine($"[FileLog]: {message}");
    }
}

public class DatabaseLogger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine($"[DBLog]: {message}");
    }
}

Step 3: High-Level Depends on Abstraction

public class ReportService
{
    private readonly ILogger _logger;

    public ReportService(ILogger logger)
    {
        _logger = logger;
    }

    public void GenerateReport()
    {
        _logger.Log("Report generated.");
    }
}

Common signs of violation of DIP
A class instantiates its own dependencies using new.
High-level classes import namespaces of low-level details.
Switching an implementation requires editing the high-level class.
Difficult to test because you can’t inject mocks.

*/