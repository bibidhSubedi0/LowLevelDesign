using LowLevelDesign.DesignPatterns.Creational.Singelton;



var logger = Logger.GetLogger();

logger.Log("Fuck this shit mainnn");
Logger.SetInstance(new FileLogger());
logger.Log("Fuckkk file systmess");