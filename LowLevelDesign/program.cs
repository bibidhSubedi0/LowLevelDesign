using LowLevelDesign.DesignPatterns.Creational.Factory;

IDocumentHander handler = new PDFHandler();

IDocument newdoc =  handler.CreateDocument("DocName");

handler.OpenDocument(newdoc);
