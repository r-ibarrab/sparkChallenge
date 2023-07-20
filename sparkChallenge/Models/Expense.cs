using System;
using System.ComponentModel.DataAnnotations;

namespace sparkChallenge.Models
{
	public class Expense
	{
		[Key]
		public int id { get; set; }
		public string title { get; set; }
		public string company { get; set; }
		public int amount { get; set; }

        //[Unique]
        public string folio { get; set; }

		public DateTime date { get; set; } = new DateTime();
	}
}

