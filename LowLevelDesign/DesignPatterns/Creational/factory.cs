using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LowLevelDesign.DesignPatterns.Creational.Factory
{
    // An App that presents docs to the user

    // the two components required may be
    // DocumentHandler, Document -> Both abstract class / interfaces

    public interface IDocument
    {
        public void Open();
        public string Name{ get; set; }

    }

    abstract class IDocumentHander
    {
        public abstract IDocument CreateDocument(string name);
        public void OpenDocument(IDocument doc)
        {
            doc.Open();
        }

    }   

    class PDF : IDocument
    {
        public void Open()
        {
            Console.WriteLine($"Opening PDF : {Name}.pdf");
        }

        public PDF(string? name)
        {
            Console.WriteLine($"Creating PDF : {name}.pdf");
            Name = name;
        }

        public string? Name{ get; set; }
    }

    // Resposible for handling PDF documents, will create them as required
    class PDFHandler : IDocumentHander
    {
        public override IDocument CreateDocument(string name)
        {
            return new PDF(name);
        }
    }



}
