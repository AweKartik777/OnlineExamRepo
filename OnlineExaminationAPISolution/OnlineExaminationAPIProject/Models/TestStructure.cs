//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnlineExaminationAPIProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;

    [DataContract]
    public partial class TestStructure
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TestStructure()
        {
            this.Tests = new HashSet<Test>();
        }
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Technology { get; set; }
        [DataMember]
        public int Level { get; set; }
        [DataMember]
        public int MaxMinutes { get; set; }
        [DataMember]
        public int NumberOfQuestions { get; set; }
        [DataMember]
        public int PassingScore { get; set; }
        public int LastUpdatedBy { get; set; }
        public System.DateTime UpdateDate { get; set; }
        public bool IsCurrent { get; set; }

        public virtual Admin Admin { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Test> Tests { get; set; }

        public bool SetProperties(int AdminId, bool IsCurrent = true, bool SetNumberOfQuestions = true)
        {
            try {
                if (this.Level < 1 || this.Level > 3)
                    return false;
                if (SetNumberOfQuestions)
                {
                    using (db_OnlineExaminationEntities db = new db_OnlineExaminationEntities())
                    {
                        int totalQuestions = db.Questions.Count(q => q.Technology == this.Technology &&
                                                                q.Level == this.Level &&
                                                                q.QuestionFile.IsCurrent == true);
                        this.NumberOfQuestions = this.NumberOfQuestions <= totalQuestions ? this.NumberOfQuestions : totalQuestions;
                    }
                }
                this.IsCurrent = IsCurrent;
                this.LastUpdatedBy = AdminId;
                this.UpdateDate = System.DateTime.Now;
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
