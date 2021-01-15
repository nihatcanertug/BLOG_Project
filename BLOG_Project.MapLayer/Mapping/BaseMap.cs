using BLOG_Project.EntityLayer.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLOG_Project.MapLayer.Mapping
{
    public class BaseMap<T>: EntityTypeConfiguration<T> where T : BaseEntity
    {
        public BaseMap() //Constructor method
        {
            Property(x => x.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.CreateDate).IsRequired();
            Property(x => x.UpdateDate).IsOptional();
            Property(x => x.DeleteDate).IsOptional();
            Property(x => x.Status).IsRequired();
        }
    }
}
