using DataaAccessLayer.Abstract;
using DataaAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataaAccessLayer.EntityFramework
{
    public class EFCategoryDal:GenericRepository<Category>,ICategoryDal
    {
    }
}
