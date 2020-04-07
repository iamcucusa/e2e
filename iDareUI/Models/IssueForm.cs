using System;
namespace iDareUI.Models
{
    public class IssueForm
    {
        public IssueForm()
        {
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public string ObservedInInstrument { get; set; }
        public string System { get; set; }
        public string Category { get; set; }
        public string ExcludedSoftwareVersions { get; set; }
    }
}
