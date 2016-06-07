namespace Myapp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EmployeeTerritories
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int 代理Id { get; set; }

        [Required]
        [StringLength(8)]
        public string 代理名稱 { get; set; }

        public int OrderID { get; set; }

        public virtual Main_Employees Main_Employees { get; set; }

        public virtual Order_Details Order_Details { get; set; }
    }
}
