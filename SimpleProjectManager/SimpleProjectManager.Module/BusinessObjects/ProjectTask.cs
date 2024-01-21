using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System.ComponentModel.DataAnnotations;

namespace SimpleProjectManager.Module.BusinessObjects
{
    [NavigationItem("Planning")]
    [RuleCriteria("EndDate >= StartDate",
    CustomMessageTemplate = "Start Date must be less than End Date")]
    [Appearance("InProgress", TargetItems = "Subject",
    Criteria = "Status = 1", BackColor = "LemonChiffon")]
    public class ProjectTask : BaseObject
    {
        public ProjectTask(Session session) : base(session) { }

        private string fSubject;

        [Size(255)]
        public string Subject
        {
            get { return fSubject; }
            set { SetPropertyValue(nameof(Subject), ref fSubject, value); }
        }

        private ProjectTaskStatus fStatus;
        public ProjectTaskStatus Status
        {
            get { return fStatus; }
            set { SetPropertyValue(nameof(Status), ref fStatus, value); }
        }

        private Employee fAssignedTo;
        public Employee AssignedTo
        {
            get { return fAssignedTo; }
            set { SetPropertyValue(nameof(AssignedTo), ref fAssignedTo, value); }
        }

        private DateTime? fDueDate;
        public DateTime? DueDate
        {
            get { return fDueDate; }
            set { SetPropertyValue(nameof(DueDate), ref fDueDate, value); }
        }

        private DateTime? fStartDate;
        public DateTime? StartDate
        {
            get { return fStartDate; }
            set { SetPropertyValue(nameof(StartDate), ref fStartDate, value); }
        }

        private DateTime? fEndDate;
        public DateTime? EndDate
        {
            get { return fEndDate; }
            set { SetPropertyValue(nameof(EndDate), ref fEndDate, value); }
        }

        private string fNotes;

        [StringLength(4096)]
        public string Notes
        {
            get { return fNotes; }
            set { SetPropertyValue(nameof(Notes), ref fNotes, value); }
        }

        private Project fProject;
        [DevExpress.Xpo.Association("Project-ProjectTasks")]
        public Project Project
        {
            get { return fProject; }
            set { SetPropertyValue(nameof(Project), ref fProject, value); }
        }

    }

    public enum ProjectTaskStatus
    {
        NotStarted = 0,
        InProgress = 1,
        Completed = 2,
        Deferred = 3
    }
}