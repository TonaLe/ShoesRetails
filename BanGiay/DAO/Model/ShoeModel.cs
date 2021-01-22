using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAO.Model
{
    [Table ("BanGiay") ]
   public class ShoeModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ShoesId { get; set; }
        public string ShoeName { get; set; }
        public int ShoeSize { get; set; }
        public string ShoeCateId { get; set; }
        public string ShoeDesc { get; set; }

        public string Status { get; set; }
        public string CreateId { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdadeId { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
