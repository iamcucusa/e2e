using System;
namespace iDareUI.Models
{
    public class IssueRow
    {
        public bool RuleInWork { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string System { get; set; }
        public string Footprints { get; set; }
        public string ModifiedBy { get; set; }
        public string Modified { get; set; }

        public IssueRow()
        {
        }
    }
}
