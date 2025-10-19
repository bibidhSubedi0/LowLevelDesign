using System;
using System.Collections.Generic;

namespace LowLevelDesign.DesignPatterns.Creational.Builder
{
    // === Product ===
    public class Document
    {
        private List<(string text, string format)> _texts = new();
        private List<(string path, string caption)> _images = new();

        public void AddText(string text, string format)
        {
            _texts.Add((text, format));
        }

        public void AddImage(string path, string caption)
        {
            _images.Add((path, caption));
        }

        public void Show()
        {
            Console.WriteLine("\n--- Rendering Document ---\n");

            Console.WriteLine("Texts:");
            foreach (var (text, format) in _texts)
                Console.WriteLine($"Text: {text} (Format: {format})");

            Console.WriteLine("\nImages:");
            foreach (var (path, caption) in _images)
                Console.WriteLine($"Image: {path} (Caption: {caption})");

            Console.WriteLine("\n--- Document Rendered Successfully ---\n");
        }
    }


    // === Abstract Builder ===
    public abstract class DocumentBuilder
    {
        protected Document document;

        public void CreateNewDocument() => document = new Document();
        public Document GetDocument() => document;

        public abstract void AddText(string text, string format);
        public abstract void AddImage(string path, string caption);
    }




    // === Concrete Builder: PDF ===
    public class PDFDocumentBuilder : DocumentBuilder
    {
        public override void AddText(string text, string format)
        {
            document.AddText(text, format);
        }

        public override void AddImage(string path, string caption)
        {
            document.AddImage(path, caption);
        }
    }



    // === Director ===
    public class DocumentDirector
    {
        private readonly DocumentBuilder builder;

        public DocumentDirector(DocumentBuilder builder)
        {
            this.builder = builder;
        }

        public void ConstructSample()
        {
            builder.CreateNewDocument();
            builder.AddText("Hello, this is a PDF document.", "Bold");
            builder.AddText("It supports multiple text blocks.", "Italic");
            builder.AddImage("path/to/image1.png", "Company Logo");
            builder.AddImage("path/to/image2.png", "Footer Graphic");
        }
    }

}
