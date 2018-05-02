//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DbFirst
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public partial class RestaurantInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RestaurantInfo()
        {
            this.ReviewerInfoes = new HashSet<ReviewerInfo>();
        }
    
        public int restaurantId { get; set; }
        public string RestaurantName { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }

        public double getAverageRating()
        {
            return ReviewerInfoes.Select(x => x.Rating).Average();
        }
        public override string ToString()
        {
            return $"\nId: {restaurantId}\nName: {RestaurantName} \nStreet: {Street}\nCity: {City}\nDescription: {Description}" +
                   $"\nEmail: {Email}\n";
        }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReviewerInfo> ReviewerInfoes { get; set; }
    }
}
