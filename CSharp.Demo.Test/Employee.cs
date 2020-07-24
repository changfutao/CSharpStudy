using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp.Demo.Test
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string JobNum { get; set; }
        public string Name { get; set; }
        public string Remark { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int? Sex { get; set; }
        public int Status { get; set; }
        public string Email { get; set; }
        public Guid? OrgId { get; set; }
        public Guid? CreatedId { get; set; }
        public DateTime? CreatedTime { get; set; }
        public Guid? UpdatedId { get; set; }
        public DateTime? UpdatedTime { get; set; }
        public bool IsDeleted { get; set; }
        public string IdentityCode { get; set; }
    }
}
