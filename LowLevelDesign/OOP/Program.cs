using LowLevelDesign.OOP;
using LowLevelDesign.OOP.Checout;
using LowLevelDesign.OOP.Payment;

var userManager = new UserManager(new EmailServiceCP());
userManager.RegisterUser("bibidh@example.com");

// Swap to SMS without modifying UserManager
userManager = new UserManager(new SMSServiceCP());
userManager.RegisterUser("9742533809");