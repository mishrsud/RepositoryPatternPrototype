﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data
{
	public class User
	{
		/// <summary> Gets or sets the id. </summary>
		/// <value> The id. </value>
		public int Id { get; set; }

		/// <summary> Gets or sets the first name. </summary>
		/// <value> The first name. </value>
		public string FirstName { get; set; }

		/// <summary> Gets or sets the last name. </summary>
		/// <value> The last name. </value>
		public string LastName { get; set; }

		/// <summary> Gets or sets the email. </summary>
		/// <value> The email. </value>
		public string Email { get; set; }

		/// <summary> Gets or sets the date of birth. </summary>
		/// <value> The date of birth. </value>
		public DateTime DateOfBirth { get; set; }
	}
}
