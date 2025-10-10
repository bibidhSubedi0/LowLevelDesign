using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LowLevelDesign.DesignPatterns.Behavioural.Iterator
{
    class Book
    {
        public string Title { get; }
        public Book(string title) => Title = title;
    }

    interface IBookIterator
    {
        // Serves no purpose here, just for the sake of that fuckass book
    }

    interface IBookAggregate
    {
        BookIterator Begin();
        BookIterator End();
    }

    class BookCollection : IBookAggregate
    {
        private List<Book> _books = new List<Book>();
        public void AddBook(Book book) => _books.Add(book);
        public List<Book> GetBooks() => _books;
        
        public BookIterator Begin() => new BookIterator(this);
        public BookIterator End() => new BookIterator(this, _books.Count());
    }

    class BookIterator : IBookIterator
    {
        private BookCollection _collection;
        private int _index;
        public BookIterator(BookCollection collection, int index = 0)
        {
            _collection = collection;
            _index = index;
        }

        public Book? Current =>
            _index < _collection.GetBooks().Count
            ? _collection.GetBooks()[_index]
            : null;

        public static BookIterator operator ++(BookIterator b)
        {
            b._index++;
            return b;
        }
        public static bool operator ==(BookIterator b1, BookIterator b2)
        {
            if (ReferenceEquals(b1, b2)) return true;
            if (b1 is null || b2 is null) return false;
            return b1._collection == b2._collection && b1._index == b2._index;
        }
        public static bool operator !=(BookIterator b1, BookIterator b2)
        {
            return !(b1 == b2);
        }
        public override bool Equals(object obj)
        {
            if (obj is not BookIterator other) return false;
            return _collection == other._collection && _index == other._index;
        }
        public override int GetHashCode() => HashCode.Combine(_collection, _index);


    }

}




/*
Provide a way to access the elements of an aggregate object sequentially without exposing its underlying representation


class BookCollection
{
    private List<string> _books = new List<string>();

    public void AddBook(string name) => _books.Add(name);

    public List<string> GetBooks() => _books;
}

var library = new BookCollection();
library.AddBook("1984");
library.AddBook("Dune");

foreach (var b in library.GetBooks())
    Console.WriteLine(b);

This works, but it’s exposing the internal structure (List<string>) of BookCollection.


Also one of the main points is that,
Chaning the internals of an object should not affect its consumers





| Design Decision                 | Options                                 | Trade-off                                     |
| ------------------------------- | --------------------------------------- | --------------------------------------------- |
|   Who controls iteration?       | External (client) / Internal (iterator) | External = flexible; Internal = simple        |
|   Where is traversal defined?   | Iterator / Aggregate                    | Iterator = flexible; Aggregate = encapsulated |
|   Robustness                    | Copy or register iterators              | Safe but expensive or complex                 |
|   Extra ops                     | `Previous()`, `SkipTo()`                | More power, more complexity                   |
|   Polymorphism                  | Use abstract base classes               | Heap allocation + cleanup overhead            |
|   Access rights                 | Friend / Protected                      | Efficiency vs encapsulation                   |
|   Composite structures          | External vs Internal vs Cursor          | Recursive or stack-based traversal            |
|   Null iterator                 | Always done                             | Simplifies tree traversal                     |


 */