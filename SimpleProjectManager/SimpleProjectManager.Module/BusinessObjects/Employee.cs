using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace SimpleProjectManager.Module.BusinessObjects
{
    [NavigationItem("Resources")]
    public class Employee : BaseObject
    {
        public Employee(Session session) : base(session) { }

        private string fFirstName;
        public string FirstName
        {
            get { return fFirstName; }
            set { SetPropertyValue(nameof(FirstName), ref fFirstName, value); }
        }

        private string fLastName;
        public string LastName
        {
            get { return fLastName; }
            set { SetPropertyValue(nameof(LastName), ref fLastName, value); }
        }

        private string fPassportNumber;
        [RuleUniqueValue("", DefaultContexts.Save,
        CriteriaEvaluationBehavior = CriteriaEvaluationBehavior.BeforeTransaction, 
        CustomMessageTemplate="Passport number must be unique"),
        RuleRequiredField("", DefaultContexts.Save,
        "Passport number must be specified"),
        RuleRegularExpression("", DefaultContexts.Save,
        @"^(AB|BM|HB|KH|MP|MC|KB|PP|SP|DP)[0-9]{7}$", CustomMessageTemplate="Incorrect passport number")]
        public string PassportNumber
        {
            get { return fPassportNumber; }
            set { SetPropertyValue(nameof(PassportNumber), ref fPassportNumber, value); }
        }
        public String FullName
        {
            get
            {
                return ObjectFormatter.Format("{FirstName} {LastName}",
            this, EmptyEntriesMode.RemoveDelimiterWhenEntryIsEmpty);
            }
        }

        [Association("Employees-Specializations")]
        public XPCollection<Specialization> Specializations
        {
            get { return GetCollection<Specialization>(nameof(Specializations)); }
        }
    }
}