using System;

namespace AwePay_DataAccess
{
	public class UserData
	{
		public int ID { get; set; }
		public string FullName { get; set; }
		public string Email { get; set; }
		public string PhoneNo { get; set; }
		public int Age { get; set; }
		public DateTime CreatedTimestamp { get; set; }
	}
}
