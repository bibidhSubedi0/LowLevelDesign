using LowLevelDesign.DesignPatterns.Creational.Builder;

var pdfBuilder = new PDFDocumentBuilder();
var director = new DocumentDirector(pdfBuilder);

// Build the document (using director)
director.ConstructSample();

// Get the built document
Document pdf = pdfBuilder.GetDocument();

// Add more manually if desired
pdf.AddText("WTF", "UpperCase");

// Now render everything
pdf.Show();
