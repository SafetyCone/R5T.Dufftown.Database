using System;
using System.ComponentModel.DataAnnotations;


namespace R5T.Dufftown.Database.Entities
{
    public class OriginalFileNameMapping
    {
        public int ID { get; set; }

        [StringLength(256)]
        public string UniqueFileName { get; set; }

        [StringLength(512)]
        public string OriginalFileName { get; set; }
    }
}
