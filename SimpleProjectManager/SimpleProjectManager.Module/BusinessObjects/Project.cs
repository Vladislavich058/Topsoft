using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SimpleProjectManager.Module.BusinessObjects
{
    [NavigationItem("Planning")]
    // Use this attribute to specify the property whose value is displayed in Detail View captions, the leftmost column of a List View, and in Lookup List Views.
    [DefaultProperty(nameof(Name))]
    public class Project : BaseObject
    {
        public Project(Session session) : base(session) { }

        private string fName;
        public string Name
        {
            get { return fName; }
            set { SetPropertyValue(nameof(Name), ref fName, value); }
        }

        private Employee fManager;
        public Employee Manager
        {
            get { return fManager; }
            set { SetPropertyValue(nameof(Manager), ref fManager, value); }
        }

        private string fDescription;

        [StringLength(4096)]
        public string Description
        {
            get { return fDescription; }
            set { SetPropertyValue(nameof(Description), ref fDescription, value); }
        }

        [DevExpress.Xpo.Association("Project-ProjectTasks")]
        public XPCollection<ProjectTask> ProjectTasks
        {
            get { return GetCollection<ProjectTask>(nameof(ProjectTasks)); }
        }
    }
}