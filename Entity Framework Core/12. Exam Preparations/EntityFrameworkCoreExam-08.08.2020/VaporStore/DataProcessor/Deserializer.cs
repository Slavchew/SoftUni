namespace VaporStore.DataProcessor
{
	using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Data;

	public static class Deserializer
	{
		public static string ImportGames(VaporStoreDbContext context, string jsonString)
		{
			return "TODO";
		}

		public static string ImportUsers(VaporStoreDbContext context, string jsonString)
		{
			return "TODO";
		}

		public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
		{
			return "TODO";
		}

		private static bool IsValid(object dto)
		{
			var validationContext = new ValidationContext(dto);
			var validationResult = new List<ValidationResult>();

			return Validator.TryValidateObject(dto, validationContext, validationResult, true);
		}
	}
}