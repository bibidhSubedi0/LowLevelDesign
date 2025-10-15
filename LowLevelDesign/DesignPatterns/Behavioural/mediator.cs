using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace LowLevelDesign.DesignPatterns.Behavioural.Mediator
{
    interface IMediator
    {
        void Notify(UIControl sender, string ev);
        void Register(UIControl component);
    }

    class LoginBoxMediator : IMediator
    {
        private Dictionary<string, UIControl> components = new();

        public void Register(UIControl component)
        {
            Console.WriteLine(component.Name + " Registered");
            components[component.Name] = component;
            component.SetMediator(this);
        }


        public void Notify(UIControl sender, string ev)
        {
            // Some business logic
            Console.WriteLine(sender.Name + " : Changed");
            if (sender is TextBox) {

                if (!string.IsNullOrWhiteSpace((components["Username"] as TextBox).Content) && !string.IsNullOrWhiteSpace((components["Password"] as TextBox).Content))
                    (components["LoginButton"] as Button).Enabled = true;
            }

        }
    }

    abstract class UIControl
    {
        public string Name;
        protected IMediator _mediator;
        //public UIControl(IMediator med) => _mediator = med;
        public void SetMediator(IMediator med) => this._mediator = med;
        public UIControl(string name)
        {
            this.Name = name;
        }
    }
    
    class TextBox : UIControl
    {
        private string _content="";
        public string Content
        {
            get {  return _content; }
            set {
                _content = value;
                _mediator.Notify(this, _content);
            }
        }

        public TextBox(string name) : base(name) { }


    }

    class Button : UIControl
    {
        private bool _enabled;
        public bool Enabled
        {
            get { return _enabled; }
            set
            {
                _enabled = value;
                _mediator.Notify(this, _enabled.ToString());
            }
        }

        public Button(string name) : base(name) { }

    }
}

/*
The Mediator pattern defines an object that encapsulates how a set of objects interact.
It promotes loose coupling by preventing objects from referring to each other explicitly,
and lets you vary their interaction independently.

When many objects in a system need to communicate, they often become tightly coupled (each knows about the others).
This creates:

Hard-to-maintain code
Complex interdependencies
Difficult extension or reuse


| Role                     | Description                                                                      | Example             |
| ------------------------ | -------------------------------------------------------------------------------- | ------------------- |
|   Mediator (interface)   | Defines communication contract                                                   | `IMediator`         |
|   ConcreteMediator       | Implements the coordination logic                                                | `DialogBoxMediator` |
|   Colleague (abstract)   | Defines a base for UI components that use the mediator                           | `UIControl`         |
|   ConcreteColleague      | Individual controls (Button, TextBox, Checkbox, etc.) that talk through mediator | `TextBox`, `Button` |

          +------------------+
          |     IMediator    |
          |------------------|
          | + Notify(sender) |
          +--------▲---------+
                   |
        +----------+----------+
        | ConcreteMediator    |
        +---------------------+
        | - coordinates objs  |
        +----------▲----------+
                   |
                   +--------------+
                                  |
+-----------+               +-----------+
| UIControl |               | TextBox   |
|-----------|               |-----------|
| mediator  |<--------------| Button    |
+-----------+               +-----------+


🔁 Flow of Communication

A colleague changes its internal state.
It calls mediator.Notify(this, event).
The mediator decides what other colleagues should react and updates them.
The colleagues never talk directly to each oth

When to Use

✅ Use the Mediator pattern when:

A set of objects communicate in complex but well-defined ways.
You want to re-use components without re-wiring their interactions.
You want to simplify or centralize control flow between objects.
The system has a “spaghetti mesh” of inter-object communication.




Pros
Loose coupling – colleagues don’t depend on each other.
Simplified maintenance – interaction logic is centralized.
Reusability – easier to reuse colleagues in different contexts.
Single point of control for complex collaboration logic.

Cons
Mediator can become too complex as it takes on too much responsibility (“God object”).
Harder to trace interactions when everything routes through the mediator.
 */