using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace DataAccess.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}