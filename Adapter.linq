<Query Kind="Program" />

void Main()
{
	  
      ITarget adapterElectronics = new  ElectronicAdapter();
      foreach (string product in adapterElectronics.GetProducts())
      {
        Console.WriteLine(product);
      }
	  
	  
      ITarget adapterBooks = new  BookAdapter();
      foreach (string product in adapterBooks.GetProducts())
      {
        Console.WriteLine(product);
      }
}




interface ITarget
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


class BookAdapter:ITarget
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


class ElectronicAdapter:ITarget
{
   public List<string> GetProducts()
   {
      ElectronicVendorAdaptee adaptee = new ElectronicVendorAdaptee();
      return adaptee.GetListOfEletronics();
   }
}