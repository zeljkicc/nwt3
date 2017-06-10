using Projekat3_NWT.Models;
using System.Collections.Generic;

namespace Projekat3_NWT.DAL
{
    public interface IPropertyImageRepository : IRepository<PropertyImage>
    {
        IEnumerable<PropertyImage> GetImagesByPropertyId(long PropertyId);
    }
}