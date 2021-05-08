using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laba5.Managers.Stores
{
    public class CreateOrUpdateStoreRequest
    {
        public string Name { get; set; }
        public string TypeStore { get; set; }
        public bool MainStore { get; set; }
        public Guid ProductId { get; set; }
    }
}
