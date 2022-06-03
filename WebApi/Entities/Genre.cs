using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class Genre
    {  
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//Otomatik Artan yapar.
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
