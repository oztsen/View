using System;

namespace MNSBI2.Core.Models
{
    public class BIView
    {
        public Guid Id { get; set; }
        public string ViewName { get; set; }
        public string DatabaseName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string CustomerKey { get; set; }
        public int? OrderId { get; set; }
        public string ReportName { get; set; }
        public string ViewType { get; set; }
        public string Parameters { get; set; }
        public string SampleCall { get; set; }
    }
}
