using Microsoft.EntityFrameworkCore;

namespace Crud_Operation_MVC.Models
{
    [PrimaryKey(nameof(Id))]
    public class DataEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
