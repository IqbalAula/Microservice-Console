using Microservice.BusinesLogic.Services;
using Microservice.BusinesLogic.Services.Master;
using Microservice.DataAccess.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Controller
{
    public class SupplierController
    {
        ISupplierService _supplierService = new SupplierService();
        SupplierParam supplierParam = new SupplierParam();

        public void ManageSupplier()
        {
            var result = 0;
            Console.WriteLine("============== Supplier Data ==============");
            Console.WriteLine("1. Insert");
            Console.WriteLine("2. Update");
            Console.WriteLine("3. Delete");
            Console.WriteLine("4. Retrive");
            Console.WriteLine("===========================================");
            Console.Write("Pilihanmu : ");
            int pil = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("===========================================");
            switch (pil)
            {
                case 1:
                    Console.WriteLine("\tInsert Supplier Data");
                    Console.WriteLine("===========================================");
                    //Bagian ini untuk memasukkan nama
                    Console.Write("Insert Name of Supplier : ");
                    supplierParam.Name = Console.ReadLine();
                    _supplierService.Insert(supplierParam);
                    
                    break;
                case 2:
                    Console.WriteLine("\tUpdate Supplier Data");
                    Console.WriteLine("===========================================");
                    Console.Write("Insert Id to Update Data : ");
                    supplierParam.id = Convert.ToInt16(Console.ReadLine());
                    Console.Write("Insert Name of Supplier : ");
                    supplierParam.Name = Console.ReadLine();
                    _supplierService.Update(supplierParam.id, supplierParam);
                    break;
                case 3:
                    Console.WriteLine("\tDelete Supplier Data");
                    Console.WriteLine("===========================================");
                    Console.Write("Insert Id to Delete Data : ");
                    supplierParam.id = Convert.ToInt16(Console.ReadLine());
                    _supplierService.Delete(supplierParam.id);
                    break;
                case 4:
                    Console.WriteLine("\tRetrive Supplier Data");
                    Console.WriteLine("===========================================");
                    foreach (var view in _supplierService.Get())
                    {
                        Console.WriteLine("Id Supplier   = " + view.Id);
                        Console.WriteLine("Nama Supplier = " + view.Name);
                        Console.WriteLine("Join Date     = " + view.JoinDate);
                    }
                    
                    break;
                default:
                    Console.WriteLine("Something wrong, please try again next time");
                    break;

            }
        }
    }
}
