using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace MyAspDemos.Models
{
    [Table("Books")]
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }

        [Display(Name = "Book Title")]
        [Required]
        [StringLength(100)]
        public string BookTitle { get; set; }


        [Required]
        [DefaultValue(1)]
        public int NumberOfCopies { get; set; } = 1;


        [Required]
        [DefaultValue(true)]
        public bool IsEnabled { get; set; }



        #region Navigation Properties to the Master Model - Category


        [Required]
        public int CategoryId { get; set; }

        //NOTE: To ensure that all nested objects are not serialized, add the JsonIgnore Attribute
        [System.Text.Json.Serialization.JsonIgnore]         // DO NOT USE:  [Newtonsoft.Json.JsonIgnore]
        [ForeignKey(nameof(Book.CategoryId))]
        public Category Category { get; set; }


        #endregion


        #region Navigation Properties to Author Model

        [JsonIgnore]
        public ICollection<Author> Authors { get; set; }

        #endregion
    }
}
/*********************************************
        CREATE TABLE [Categories]
        (
	        [CategoryId] int NOT NULL IDENTITY(1,1)
	        , [CategoryName] varchar(60) NOT NULL
	        , CONSTRAINT [PK_Categoryies] PRIMARY KEY ( [CategoryId] ASC )
        )
        GO
**********/
