namespace FullSack.Entities
{
	/// <summary>
	/// Constant values used in entity annotations.
	/// </summary>
	public static partial class Constants
	{

		public const int ByteMaxRange = 255;
		public const int ByteMinRange = 1;

		/// <summary>Sets the maximum amount of digits allowed in a decimal.</summary>
		public const int DecimalPrecision = 10;
		/// <summary>Sets the amount of digit of the total that is after the decimal point.</summary>
		public const int DecimalScale = 2;

		public const int MeasurementCategory = 25;
		public const int MeasurementSymbol = 10;

		public const int TextLengthRequired = 1;
		public const int TextLengthShort = 256;
		public const int TextLengthMedium = 450;
		public const int TextLengthLong = 1000;

		public const int Zero = 0;

		public const string SqlDateTime = "DATETIME2";
		public const string SqlDecimal = "DECIMAL(10, 2)";
		public const string SqlGuid = "NVARCHAR(450)";
		public const string SqlByte = "TINYINT";



	}
}
