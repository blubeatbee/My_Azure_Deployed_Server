namespace FullSack.Extensions
{
	/// <summary>
	///	Provides custom extension methods for <see cref="IConfiguration"/>.
	/// </summary>
	public static class ConfigurationExtensions
	{
		/// <summary>
		/// Gets the specified origin from the specified configuration.
		/// Shorthand for <c>GetSection("AllowedOrigins")[<paramref name="name"/>]</c>.
		/// </summary>
		/// <param name="configuration">The configuration to enumerate.</param>
		/// <param name="name">The key of the origin.</param>
		/// <returns>The origin.</returns>
		public static string? GetAllowedOrigin(this IConfiguration configuration, string name)
		{
			return configuration?.GetSection("AllowedOrigins")[name];
		}

		/// <summary>
		/// Gets the specified role name from the specified configuration.
		/// Shorthand for <c>GetSection("Roles")[<paramref name="name"/>]</c>.
		/// </summary>
		/// <param name="configuration">The configuration to enumerate.</param>
		/// <param name="name">The key of the role name.</param>
		/// <returns>The name of the role.</returns>
		public static string? GetRoleName(this IConfiguration configuration, string name)
		{
			return configuration?.GetSection("Roles")[name];
		}

		public static IConfigurationSection GetSection(this IConfiguration configuration, string key, string subKey)
		{
			return configuration.GetSection(key).GetSection(subKey);
		}
	}
}
