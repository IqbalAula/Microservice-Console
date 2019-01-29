using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microservice.DataAccess.Model;
using Microservice.DataAccess.Param;

namespace Microservice.Common.Interfaces.Master
{
    public class SupplierRepository : ISupplierRepository
    {
        bool status = false;
        MyContext _context = new MyContext();
        public bool Delete(int? id)
        {
            var result = 0;
            Supplier supplier = Get(id);
            supplier.isDelete = true;
            supplier.DeleteDate = DateTimeOffset.UtcNow.LocalDateTime;
            result = _context.SaveChanges();
            if (result > 0)
            {
                status = true;
                Console.Write("Delete Successfully");
                Console.Read();
            }
            return status;            
        }

        public List<Supplier> Get()
        {
            return _context.Suppliers.Where(x => x.isDelete == false).ToList();
        }

        public Supplier Get(int? id)
        {
            return _context.Suppliers.Find(id);
        }

        public bool Insert(SupplierParam supplierParam)
        {
            var supplier = new Supplier();
            supplier.Name = supplierParam.Name;
            supplier.CreateDate = DateTimeOffset.UtcNow.LocalDateTime;
            supplier.JoinDate = DateTimeOffset.UtcNow.LocalDateTime;
            _context.Suppliers.Add(supplier);
            var result = _context.SaveChanges();
            if (result > 0)
            {
                status = true;
                Console.Write("Insert Successfully");
                Console.Read();
            }
            return status;
        }

        public bool Update(int? id, SupplierParam supplierParam)
        {
            var result = 0;
            var supplier = Get(id);
            supplier.Name = supplierParam.Name;
            supplier.UpdateDate = DateTimeOffset.UtcNow.LocalDateTime;
            _context.Entry(supplier).State = System.Data.Entity.EntityState.Modified;
            result = _context.SaveChanges();
            if (result > 0)
            {
                status = true;
                Console.Write("Update Successfully");
                Console.Read();
            }
            return status;
        }
    }
}
