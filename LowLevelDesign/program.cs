using LowLevelDesign.DesignPatterns.Behavioural;

TextEditor tx = new TextEditor();
CareTaker ct = new CareTaker();

string t=null, s=null, cf=null;

tx.showState();

// User entered a new title
t = "new title";
ct.addMemento(tx.createMemento()); // before setting new state, save this memento
tx.setState(t, s, cf);
tx.showState();

s = "some body hehe haha";
ct.addMemento(tx.createMemento());
tx.setState(t, s, cf);
tx.showState();


cf = "x:y, a:b, d:3";
ct.addMemento(tx.createMemento());
tx.setState(t, s, cf);
tx.showState();


Console.WriteLine("-----------------------");

Console.WriteLine("User pressed undo\n");
tx.restoreMemento(ct.getLastMemento());
tx.showState();

Console.WriteLine("User pressed undo again\n");
tx.restoreMemento(ct.getLastMemento());
tx.showState();