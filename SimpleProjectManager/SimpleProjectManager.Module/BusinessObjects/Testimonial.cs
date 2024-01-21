using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using System.Collections.ObjectModel;

namespace SimpleProjectManager.Module.BusinessObjects
{

    [NavigationItem("Marketing")]
    public class Testimonial : BaseObject
    {
        public Testimonial(Session session) : base(session) { }

        [Size(SizeAttribute.Unlimited)]
        string fQuote;
        public string Quote
        {
            get { return fQuote; }
            set { SetPropertyValue(nameof(Quote), ref fQuote, value); }
        }

        [Size(512)]
        string fHighlights;
        public string Highlights
        {
            get { return fQuote; }
            set { SetPropertyValue(nameof(Highlights), ref fHighlights, value); }
        }

        [VisibleInListView(false)]
        private DateTime fCreatedOn;
        public DateTime CreatedOn
        {
            get { return CreatedOn; }
            set { SetPropertyValue(nameof(CreatedOn), ref fCreatedOn, value); }
        }

        string fTags;
        public string Tags
        {
            get { return fTags; }
            set { SetPropertyValue(nameof(Tags), ref fTags, value); }
        }

        [Association("Testimonials-Customers")]
        public XPCollection<Customer> Customers
        {
            get { return GetCollection<Customer>(nameof(Customers)); }
        }

    }
}