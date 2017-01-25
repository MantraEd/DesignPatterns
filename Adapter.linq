<Query Kind="Program" />

void Main()
{
	 
	  //The Adapter pattern is used to convert the programming interface of one class into that of another. We use adapters whenever we want unrelated classes to work together in a single program. The concept of an adapter is thus pretty simple: We write a class that has the desired interface and then make it communicate with the class that has a different interface. 

//* Convert the interface of a class into another interface clients expect.

//* Adapter lets classes work together, that could not otherwise because of incompatible interfaces.
	  Console.WriteLine("Eletronic Stuff:");
      IProducts adapterElectronics = new  ElectronicAdapter();
      foreach (string product in adapterElectronics.GetProducts())
      {
        Console.WriteLine(product);
      }
	  
	   Console.WriteLine();
	    Console.WriteLine("Books:");
      IProducts adapterBooks = new  BookAdapter();
      foreach (string product in adapterBooks.GetProducts())
      {
        Console.WriteLine(product);
      }
}




interface IProducts
{
  List<string> GetProducts();
}


public class BookVendorAdaptee
{
   public List<string> GetListOfBooks()
   {
      List<string> products = new List<string>();
      products.Add("Catch 22");
      products.Add("Star Wars");
      products.Add("Mars");
      products.Add("Gone with the Wind");
      return products;
   }
}


class BookAdapter:IProducts
{
   public List<string> GetProducts()
   {
      BookVendorAdaptee adaptee = new BookVendorAdaptee();
      return adaptee.GetListOfBooks();
   }
}

public class ElectronicVendorAdaptee
{
   public List<string> GetListOfEletronics()
   {
      List<string> products = new List<string>();
      products.Add("Gaming Consoles");
      products.Add("Television");
      products.Add("Computer");
      products.Add("Musical Instruments");
      return products;
   }
}


class ElectronicAdapter:IProducts
{
   public List<string> GetProducts()
   {
      ElectronicVendorAdaptee adaptee = new ElectronicVendorAdaptee();
      return adaptee.GetListOfEletronics();
   }
}