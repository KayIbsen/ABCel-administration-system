using System;

namespace ABCel.Entities.Classes
{
    public class WorkOrderModel
    {

        public string ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public DateTime DateOfCompletion { get; set; }

    }
}
