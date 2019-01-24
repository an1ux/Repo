namespace ProjectControl
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    [Table("UserProject")]
    public class UserProject
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProjectId { get; set; }

        [Key]
        [Column(Order = 2)]
        public bool IsActive { get; set; }

        [Key]
        [Column(Order = 3)]
        public DateTime AssignedDate { get; set; }

        public EndUser EndUser { get; set; }

        public Project Project { get; set; }

        public IEnumerable<SelectListItem> ListUsers { get; set; } 
    }
}
