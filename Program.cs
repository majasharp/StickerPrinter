using System.Drawing;
using ESC_POS_USB_NET.Printer;

Console.Write("Enter the name of the Epson TM-T88(X) printer: ");
var printerName = Console.ReadLine();
var printer = new Printer(printerName);

Console.Write("Would you like to test this printer before continuing? Y/n");
if (Console.ReadLine()?.ToLower() == "y")
{
    printer.TestPrinter();
    printer.FullPaperCut();
    printer.PrintDocument();
}

Console.Write("Enter the path to the image: ");
var imagePath = Console.ReadLine();
if (!File.Exists(imagePath))
{
    Console.WriteLine("The image file does not exist. Exiting.");
    return;
}

Console.Write("Enter the number of times to print the image: ");
if (!int.TryParse(Console.ReadLine(), out var printCount) || printCount <= 0)
{
    Console.WriteLine("Invalid number of times to print. Exiting.");
    return;
}

var image = new Bitmap(Image.FromFile(imagePath));
printer.Image(image);
printer.FullPaperCut();
printer.PrintDocument();