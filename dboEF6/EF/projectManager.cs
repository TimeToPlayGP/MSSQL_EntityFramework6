namespace dboEF6.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("projectManager")]
    public partial class projectManager
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public projectManager()
        {
            projects = new HashSet<project>();
        }

        [Key]
        public int pmID { get; set; }

        [Required]
        [StringLength(20)]
        public string surname { get; set; }

        [Required]
        [StringLength(20)]
        public string name { get; set; }

        [Column("middlename ")]
        [Required]
        [StringLength(20)]
        public string middlename_ { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<project> projects { get; set; }
    }
}
