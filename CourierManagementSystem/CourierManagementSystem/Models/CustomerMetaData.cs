using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CourierManagementSystem.Models
{
    public class CustomerMetaData
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        [Required]
        public string Name { get; set; }
        [Required]
        public string Contact { get; set; }
        public string Address { get; set; }
        [Required]
        public string Sequrity_Que { get; set; }
        public System.DateTime UpdatedDate { get; set; }
        public int Id { get; set; }
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Products { get; set; }
    }
}