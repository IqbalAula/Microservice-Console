using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microservice.DataAccess.Model;
using Microservice.DataAccess.Param;
using Microservice.Common.Interfaces;
using Microservice.Common.Interfaces.Master;

namespace Microservice.BusinesLogic.Services.Master
{
    public class SupplierService : ISupplierService
    {
        bool status = false;
        ISupplierRepository _supplierRepository = new SupplierRepository();
        public bool Delete(int? id)
        {
            if (_supplierRepository.Get(id) == null)
            {
                Console.WriteLine("Sorry, your data is not found");
                Console.Read();
            }
            else if ( id.ToString() == " ")
            {
                Console.WriteLine("Don't insert white space");
                Console.Read();
            } else
            {
                status = _supplierRepository.Delete(id);
            }            
            return status;
        }

        public List<Supplier> Get()
        {
            return _supplierRepository.Get();
        }

        public Supplier Get(int? id)
        {
            return _supplierRepository.Get(id);
        }

        public bool Insert(SupplierParam supplierParam)
        {
            if (supplierParam.Name.ToString() == " ")
            {
                Console.WriteLine("Don't insert white space");
                Console.Read();
            }
            else
            {
                status = _supplierRepository.Insert(supplierParam);
            }
            return status;
        }

        public bool Update(int? id, SupplierParam supplierParam)
        {
            if (_supplierRepository.Get(id) == null)
            {
                Console.WriteLine("Sorry, your data is not found");
                Console.Read();
            }
            else if (id.ToString() == " ")
            {
                Console.WriteLine("Don't insert white space");
                Console.Read();
            }
            else
            {
                if(supplierParam.Name.ToString() == " ")
                {
                    Console.WriteLine("Don't insert white space");
                    Console.Read();
                }
                else
                {
                    status = _supplierRepository.Update(id, supplierParam);
                }                
            }
            return status;
        }
    }
}
