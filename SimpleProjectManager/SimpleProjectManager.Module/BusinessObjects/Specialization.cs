using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using System.Collections.ObjectModel;
using System.ComponentModel;


namespace SimpleProjectManager.Module.BusinessObjects
{
    [NavigationItem("Resources")]
    public class Specialization : BaseObject
    {
        public Specialization(Session session) : base(session) { }

        private string fName;
        public string Name
        {
            get { return fName; }
            set { SetPropertyValue(nameof(Name), ref fName, value); }
        }

        [Association("Employees-Specializations")]
        public XPCollection<Employee> Employees
        {
            get { return GetCollection<Employee>(nameof(Employees)); }
        }
    }
}
