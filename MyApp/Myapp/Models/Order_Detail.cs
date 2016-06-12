namespace Myapp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order Details")]
    public partial class Order_Detail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order_Detail()
        {
            EmployeeTerritories = new HashSet<EmployeeTerritory>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OrderID { get; set; }

        [Column(TypeName = "date")]
        public DateTime 訂購日期 { get; set; }

        public int 訂購代理 { get; set; }

        public int 訂購貨品 { get; set; }

        [Column(TypeName = "money")]
        public decimal UnitPrice { get; set; }

        public short Quantity { get; set; }

        public float? Discount { get; set; }

        [StringLength(50)]
        public string 支付方式 { get; set; }

        [StringLength(50)]
        public string 相關客戶 { get; set; }

        [StringLength(50)]
        public string 貨品狀況 { get; set; }

        public string More { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmployeeTerritory> EmployeeTerritories { get; set; }

        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }
    }
}
