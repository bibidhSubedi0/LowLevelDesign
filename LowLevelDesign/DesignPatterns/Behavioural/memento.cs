using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



/*
                +------------------------------------------+
                |     Caretaker                            |
                +------------------------------------------+
                | - mementos: List<TextEditorMemento>      |
                +------------------------------------------+
                | + addMemento(m: TextEditorMemento): void |
                | + getMemento(i: int): TextEditorMemento  |
                +------------------------------------------+
                         < > // Caretaker has mememto, but memento can exsist without caretaker    
                          |
                          |
                          ▼
                +-----------------------------------------------+
                | TextEditorMemento                             |   << Memento >>
                +-----------------------------------------------+
                | - title: string                               |
                | - content: string                             |
                | - config: string                              |
                +-----------------------------------------------+
                | + getTitle(): string                          |
                | + getContent(): string                        |
                | + getConfig(): string                         |
                +-----------------------------------------------+
                          ▲
                          |
                          |
                          | Orgin
                +-----------------------------------------------+
                |    TextEditor                                 |   << Originator >>
                +-----------------------------------------------+
                | - title: string                               |
                | - content: string                             |
                | - config: string                              |
                +-----------------------------------------------+
                | + createMemento(): TextEditorMemento          |
                | + restoreMemento(m: TextEditorMemento): void  |
                | + showState(): void                           |
                +-----------------------------------------------+
 
 */

namespace LowLevelDesign.DesignPatterns.Behavioural
{
    public interface ITextEditorMemento { }
    internal class TextEditorMemento : ITextEditorMemento
    {
        private string _title;
        private string _content;
        private string _configString;

        public TextEditorMemento(string title, string content, string configString)
        {
            _title = title;
            _content = content;
            _configString = configString;
        }
        public string getTitle()
        {
            return _title;
        }
        public string getContent()
        {
            return _content;
        }
        public string getConfig()
        {
            return _configString;
        }


    }

    class TextEditor // Originator
    {
        private string _title;
        private string _content;
        private string _configString;


        public ITextEditorMemento createMemento() => new TextEditorMemento(_title, _content, _configString);
        public void restoreMemento(ITextEditorMemento m)
        {
            TextEditorMemento mem = (TextEditorMemento)m;
            _title = mem.getTitle();
            _content = mem.getContent();
            _configString = mem.getConfig();
        }
        public void showState()
        {
            Console.WriteLine("Current State:");
            Console.WriteLine(_title);
            Console.WriteLine(_content);
            Console.WriteLine(_configString);
        }
        public void setState(string title, string content, string configString)
        {
            _title = title;
            _content = content;
            _configString = configString;
        }

    }

    class CareTaker
    {
        private Stack<ITextEditorMemento> _mementoList;
        public CareTaker()
        {
            _mementoList = new Stack<ITextEditorMemento>();
        }
        public void addMemento(ITextEditorMemento memento) => _mementoList.Push(memento);
        public ITextEditorMemento getLastMemento() => _mementoList.Pop();

    }

    /*
        In C++, we’d often handle this by making TextEditor a friend class of TextEditorMemento, 
        giving it exclusive access to internal state while preserving encapsulation from everyone else.
        In C#, however, there’s no direct equivalent of the friend mechanism.

     */
}






/*

You must save state information somewhere so that you can restore objects to their previous states. 
But objects normally encapsulate some or all of their state, making it inaccessible to other objects and impossible to save externally. 
Exposing this state would violate encapsulation, which can compromise the application's reliability and extensibility.
  
  
  
  
  
A memento is an object that stores a snapshot of the internal state of another object—the memento's originator.
  
  
  
  
  
  
  
  
Imagine designing a Text Editor (or any system where the user can change state).
Users can:
    Add a title to doc
    write some text
    change the formatting

UML:
    
    --------
    Editor
    --------
    title: string
    prevTitle:Queue<string>
    content:string
    prevContent:Queue<string>
    Format:List<string>
    preFormat:Queue<List<string>>
    --------

Problem:
    1. Every time we add a new field eg autjhor, date etc, we have to keep
       string lists of preve states
    2. How will we implement undo?
       If the user changed title then changed content, then pressed undo, we have no idea what user last did, of these 3 actions
    3. We will need to makee all of them public which breaks encapuslation
    



Solution:
The Memento pattern allows you to capture and restore an object’s internal state without exposing its internal structure.
It’s mainly used to implement undo/redo, rollback, or history tracking features — while maintaining encapsulation.


Common Use Cases
Undo/Redo systems (text editors, drawing apps).
Version control / checkpoints.
Game save and load features.
Transaction rollback systems.


|   Component    |   Role                                                            |
| -------------- | ----------------------------------------------------------------- |
|   Originator   | The main object whose state we want to save/restore.              |
|   Memento      | Stores the internal state of the Originator (immutable snapshot). |
|   Caretaker    | Manages mementos — decides when to save or restore states.        |


+-------------------+       +-------------------+       +-------------------+
|     Caretaker     |-----> |     Memento       | <-----|    Originator     |
|-------------------|       |-------------------|       |-------------------|
| - mementos: Stack |       | + GetState()      |       | - state: string   |
| + SaveState()     |       |                   |       | + SetState()      |
| + Undo()          |       |                   |       | + Save()          |
+-------------------+       +-------------------+       | + Restore()       |
                                                       +-------------------+
For our problem


----------
Editor : O
----------
title:string
content:string
----------
createState()
saveState()

.
.
.
v

---------
EditorState : M
title:string
content:string
----------

^
|
|
|
^
v
----------
History : C
----------
states:List
editor:Editor
----------
backup()
undo()
----------

 */