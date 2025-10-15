using LowLevelDesign.DesignPatterns.Behavioural.Mediator;


TextBox username = new TextBox("Username");
TextBox password = new TextBox("Password");
Button loginButton = new Button("LoginButton");

LoginBoxMediator dialog = new LoginBoxMediator();
dialog.Register(username);
dialog.Register(password);
dialog.Register(loginButton);

// Right now login button
Console.WriteLine(loginButton.Enabled.ToString());

// Entered Username and password
username.Content = "Whatever";

Console.WriteLine(loginButton.Enabled.ToString());

password.Content = "fuckoff";



Console.WriteLine(loginButton.Enabled.ToString());
