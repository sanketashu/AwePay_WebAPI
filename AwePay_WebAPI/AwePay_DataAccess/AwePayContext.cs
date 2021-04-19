using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AwePay_DataAccess
{
	public class AwePayContext:DbContext
	{
        public AwePayContext()
        {
        }

        public AwePayContext(DbContextOptions<AwePayContext> options)
            : base(options)
        {
        }

        public virtual DbSet<UserData> UserData { get; set; }
    }
}
