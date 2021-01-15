using BLOG_Project.EntityLayer.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLOG_Project.MapLayer.Mapping
{
    public class CommentMap:BaseMap<Comment>
    {
        public CommentMap()
        {
            Property(x => x.Text).HasMaxLength(256).IsRequired();

            //ComposetKey
            //HasKey(x => new { x.AppUserId, x.PostId });


            HasRequired(x => x.AppUser).WithMany(x => x.Comments).HasForeignKey(x => x.AppUserId).WillCascadeOnDelete(false);
            HasRequired(x => x.Post).WithMany(x => x.Comments).HasForeignKey(x => x.PostId).WillCascadeOnDelete(false);
            
        }
    }
}
