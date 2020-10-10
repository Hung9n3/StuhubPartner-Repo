using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataObject
{
    public class BaseEntityDTO<T>
    {
        [FromRoute]
        public T id { get; set; } = default!;
    }

    public abstract class BaseEntityDTO: BaseEntityDTO<int> 
    {
    }
}
