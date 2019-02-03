namespace dboEF6.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("project")]
    public partial class project
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public project()
        {
            employees = new HashSet<employee>();
        }

        [Key]
        public int projID { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        [Column(TypeName = "date")]
        public DateTime dateStart { get; set; }

        [Column(TypeName = "date")]
        public DateTime dateFinish { get; set; }

        public int priority { get; set; }

        [Column(TypeName = "text")]
        public string comment { get; set; }

        public int id_projM { get; set; }

        public int id_comP { get; set; }

        public int id_comC { get; set; }

        public virtual companyCustomer companyCustomer { get; set; }

        public virtual companyPerformer companyPerformer { get; set; }

        public virtual projectManager projectManager { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<employee> employees { get; set; }
    }
}
