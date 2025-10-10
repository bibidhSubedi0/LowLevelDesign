using LowLevelDesign.DesignPatterns.Behavioural.Iterator;

BookCollection library = new BookCollection(); // std::vector<int> vec = {10,20,...,100};

library.AddBook(new Book("1984"));
library.AddBook(new Book("Dune"));
library.AddBook(new Book("Foundation"));


for (var itr = library.Begin(); itr != library.End(); itr++)
{
    Console.WriteLine(itr.Current.Title);
}