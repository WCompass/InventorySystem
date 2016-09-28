using System;

namespace DataObjects
{
    public class BaseDataObject
    {
        public string Description { get; set; }
        public int StatusCode { get; set; }
        public DateTime CreatedTime { get; set; }
        public int CreatedBy { get; set; }

        /*Join*/
        public string CreatedName { get; set; }
    }
}
