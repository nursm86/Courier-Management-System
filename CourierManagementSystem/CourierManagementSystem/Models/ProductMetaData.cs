using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CourierManagementSystem.Models
{
    public class ProductMetaData
    {
        public enum ProductTypeEnum
        {
            Extra_Large,
            Large,
            Medium,
            Small
        }
        public enum ProductCategoryEnum
        {
            Document,
            Package,
            Accessories,
            Electronics,
            Groceries,
            Others
        }

        public enum PaymentMethodEnum
        {
            Bkash,
            Rocket,
            Nexus,
            Cash_on_Delivery
        }

        public enum ProductStateEnum
        {
            Not_yet_Received,
            Received,
            Shipped,
            Sent_to_destination,
            Released
        }
        public int Id { get; set; }
        [Required]
        public int ProductType { get; set; }
        public int Customer_id { get; set; }
        [Required]
        public int Receiving_B_id { get; set; }
        [Required]
        public int Sending_B_id { get; set; }
        public double Delivery_charge { get; set; }
        public int Receiving_Manager_id { get; set; }
        public System.DateTime UpdatedDate { get; set; }
        public int Sending_Manager_id { get; set; }
        [Required]
        public int ProductCategory { get; set; }
        [Required]
        public int PaymentMethod { get; set; }
        [Required]
        public string RecieverName { get; set; }
        [Required,EmailAddress]
        public string RecieverEmail { get; set; }
        [Required]
        public string RecieverContact { get; set; }
        [Required]
        public string RecieverAddress { get; set; }
        [Required]
        public string Description { get; set; }
        public int Product_State { get; set; }
        public Nullable<System.DateTime> Release_Date { get; set; }

        public virtual Branch Branch { get; set; }
        public virtual Branch Branch1 { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Employee Employee1 { get; set; }
    }
}