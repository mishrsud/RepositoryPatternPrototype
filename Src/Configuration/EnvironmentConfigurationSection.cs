using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace RepositoryPrototype.Configuration
{
	public class EnvironmentConfigurationSection : ConfigurationSection
	{
		/// <summary> The environment section path </summary>
		public const string EnvironmentSectionPath = "spreadDisplayApi/environment";

		/// <summary> Gets the section. </summary>
		/// <returns>The environment section</returns>
		public static EnvironmentConfigurationSection GetSection()
		{
			return GetSection(EnvironmentSectionPath);
		}

		/// <summary> Gets the section. </summary>
		/// <param name="sectionPath">The section path.</param>
		/// <returns>The environment section</returns>
		/// <exception cref="System.Configuration.ConfigurationErrorsException">Exception: System.Configuration.ConfigurationErrorsException</exception>
		internal static EnvironmentConfigurationSection GetSection(string sectionPath)
		{
			EnvironmentConfigurationSection section;

			try
			{
				section = ConfigurationManager.GetSection(sectionPath) as EnvironmentConfigurationSection;
			}
			catch (Exception exception)
			{
				throw new ConfigurationErrorsException(exception.Message, exception);
			}

			return section;
		}

		/// <summary>
		/// Gets arguments to pass into the constructor of the specified logger factory.
		/// </summary>
		/// <value>The arguments.</value>
		/// <remarks>
		/// The logger factory argument list in the configuration file allows implementation
		/// specific arguments to be specified.
		/// Arguments differ from logging implementation to logging implementation. NLog
		/// takes a specific set of arguments whereas log4net takes another.
		/// </remarks>
		[ConfigurationProperty("settings", IsRequired = false, IsDefaultCollection = false)]
		[ConfigurationCollection(typeof(NameValueConfigurationCollection), AddItemName = "add")]
		public NameValueConfigurationCollection Settings
		{
			get { return (NameValueConfigurationCollection)this["settings"]; }
			////set { this["arguments"] = value; }
		}
	}
}