using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System.Collections.ObjectModel;

namespace SimpleProjectManager.Module.BusinessObjects
{
    // Use this attribute to place a navigation item that corresponds to the entity class in the specified navigation group.
    [NavigationItem("Marketing")]
    // Inherit your entity classes from the BaseObject class to support CRUD operations for the declared objects automatically.
    public class Customer : BaseObject
    {
        public Customer(Session session) : base(session) { }

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

        // Use this attribute to specify the maximum number of characters that the property's editor can contain.
        private string fEmail;
        [Size(255)]
        public string Email
        {
            get { return fLastName; }
            set { SetPropertyValue(nameof(Email), ref fEmail, value); }
        }

        private string fCompany;
        public string Company
        {
            get { return fLastName; }
            set { SetPropertyValue(nameof(Company), ref fCompany, value); }
        }

        private string fOccupation;
        public string Occupation
        {
            get { return fOccupation; }
            set { SetPropertyValue(nameof(Occupation), ref fOccupation, value); }
        }

        [Association("Testimonials-Customers")]
        public XPCollection<Testimonial> Testimonials
        {
            get { return GetCollection<Testimonial>(nameof(Testimonials)); }
        }

        public String FullName
        {
            get
            {
                return ObjectFormatter.Format("{FirstName} {LastName} ({Company})",
            this, EmptyEntriesMode.RemoveDelimiterWhenEntryIsEmpty);
            }
        }

        private MediaDataObject fPhoto;
        // Use this attribute to show or hide a column with the property's values in a List View.
        [VisibleInListView(false)]

        // Use this attribute to specify dimensions of an image property editor.
        [ImageEditor(ListViewImageEditorCustomHeight = 75, DetailViewImageEditorFixedHeight = 150)]
        public MediaDataObject Photo
        {
            get { return fPhoto; }
            set { SetPropertyValue(nameof(Photo), ref fPhoto, value); }
        }

    }
}