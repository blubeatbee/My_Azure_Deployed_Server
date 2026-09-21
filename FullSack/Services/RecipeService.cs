using FullSack.DTO.RecipeGet;
using FullSack.DTO.RecipePut;
using FullSack.Persistent;

namespace FullSack.Services
{
	public class RecipeService : IRecipeService
	{
		public readonly IUnitOfWork workUnit;

		public RecipeService(IUnitOfWork unitOfWork)
		{
			this.workUnit = unitOfWork;
		}

		public async Task<bool> RecipeExistsAsync(string id)
		{
			try
			{
				return (await this.workUnit.RecipeRepo.GetByIdAsync(id) != null) ? true : false;
			}
			catch
			{
				return false;
			}
		}

		public async Task<IList<RecipeCatalogueDTO>> GetRecipesAsListAsync(int pageIndex, int pageSize)
		{
			var recipes = await this.workUnit.RecipeRepo.GetByFilterAsync(
				pageIndex: pageIndex,
				pageSize: pageSize,
				filter: null,
				orderBy: null);

			var catalogue = new List<RecipeCatalogueDTO>();

			foreach (var recipe in recipes)
			{
				var card = new RecipeCatalogueDTO()
				{
					RecipeId = recipe.RecipeId,
					DateCreated = recipe.DateCreated,
					Title = recipe.Title,
					Slug = recipe.Slug,
					// Thumbnail = recipe.
					// AverageReviewScore = review.
				};

				if (recipe.UserNavProp != null)
				{
					card.UserId = recipe.UserId;
					card.Name = recipe.UserNavProp.FirstName + " " + recipe.UserNavProp.Surname;
					card.ProfileImage = recipe.UserNavProp.ProfileImage;
				}
				catalogue.Add(card);
			}
			return catalogue;
		}

		public async Task<RecipePageDTO> GetRecipeByIdAsync(string id)
		{
			var recipe = await this.workUnit.RecipeRepo.GetByIdAsync(id)
				?? throw new ArgumentNullException(nameof(id));

			var page = new RecipePageDTO()
			{
				RecipeId = recipe.RecipeId,
				Title = recipe.Title,
				Slug = recipe.Slug,
				Description = recipe.Description,
				DateCreated = recipe.DateCreated,
				DateUpdated = recipe.DateUpdated,
			};

			if (recipe.UserNavProp != null)
			{
				page.UserId = recipe.UserId;
				page.Name = recipe.UserNavProp.FirstName + " " + recipe.UserNavProp.Surname;
				page.ProfileImage = recipe.UserNavProp.ProfileImage;
			}

			foreach (var keywordId in recipe.KeywordRecipeNavProp)
			{
				page.KeywordIds.Add(keywordId.KeywordId);
			}

			foreach (var ingredient in recipe.IngredientNavProp)
			{
				page.Ingredients.Add(new()
				{
					Title = ingredient.Title,
					Position = ingredient.Position,
					IngredientId = ingredient.IngredientId,
					MeasurementId = ingredient.MeasurementId,
					MeasurementValue = ingredient.MeasurementValue,
				});
			}

			foreach (var instruction in recipe.InstructionNavProp)
			{
				page.Instructions.Add(new()
				{
					InstructionId = instruction.InstructionId,
					Description = instruction.Description,
					Step = instruction.Position,
				});
			}

			return page;
		}

		public async Task<RecipePageDTO> GetRecipeBySlugAsync(string slug)
		{
			var recipe = await this.workUnit.RecipeRepo.GetByUriSlugAsync(slug)
				?? throw new ArgumentNullException(nameof(slug));

			var page = new RecipePageDTO()
			{
				RecipeId = recipe.RecipeId,
				Title = recipe.Title,
				Slug = recipe.Slug,
				Description = recipe.Description,
				DateCreated = recipe.DateCreated,
				DateUpdated = recipe.DateUpdated,
			};

			if (recipe.UserNavProp != null)
			{
				page.UserId = recipe.UserId;
				page.Name = recipe.UserNavProp.FirstName + " " + recipe.UserNavProp.Surname;
				page.ProfileImage = recipe.UserNavProp.ProfileImage;
			}

			foreach (var keywordId in recipe.KeywordRecipeNavProp)
			{
				page.KeywordIds.Add(keywordId.KeywordId);
			}

			foreach (var ingredient in recipe.IngredientNavProp)
			{
				page.Ingredients.Add(new()
				{
					Title = ingredient.Title,
					Position = ingredient.Position,
					IngredientId = ingredient.IngredientId,
					MeasurementId = ingredient.MeasurementId,
					MeasurementValue = ingredient.MeasurementValue,
				});
			}

			foreach (var instruction in recipe.InstructionNavProp)
			{
				page.Instructions.Add(new()
				{
					InstructionId = instruction.InstructionId,
					Description = instruction.Description,
					Step = instruction.Position,
				});
			}

			return page;
		}

		public async Task<RecipePageDTO> AddRecipeAsync(RecipePutDTO newRecipe)
		{
			var newRecipeId = Guid.NewGuid().ToString();
			this.workUnit.RecipeRepo.Add(new()
			{
				RecipeId = newRecipeId,
				UserId = newRecipe.UserId,
				Title = newRecipe.Title,
				Slug = newRecipe.Title,
				Description = newRecipe.Description,
				DateCreated = DateTime.UtcNow,
				DateUpdated = DateTime.UtcNow,
			});
			foreach(var i in newRecipe.Ingredients)
			{
				this.workUnit.IngredientRepo.Add(new()
				{
					IngredientId = Guid.NewGuid().ToString(),
					RecipeId = newRecipeId,
					Title = i.Title,
					MeasurementId = i.MeasurementId,
					MeasurementValue = i.MeasurementValue,
					Position = i.Position,
				});
			}
			foreach (var i in newRecipe.Instructions)
			{
				this.workUnit.InstructionRepo.Add(new()
				{
					InstructionId = Guid.NewGuid().ToString(),
					RecipeId = newRecipeId,
					Description = i.Description,
					Position = i.Position,
				});
			}
			foreach (var k in newRecipe.KeywordIds)
			{
				this.workUnit.KeywordRecipeRepo.Add(new()
				{
					KeywordId = k,
					RecipeId = newRecipeId,
				});
			}
			_ = await this.workUnit.SaveAsync();
			return await this.GetRecipeByIdAsync(newRecipeId);
		}

		public async Task<RecipePageDTO> UpdateRecipeByIdAsync(string id, RecipePutDTO updatedRecipe)
		{
			var recipe = await this.workUnit.RecipeRepo.GetByIdAsync(id);
			if (recipe == null)
			{
				// return await this.workUnit.RecipeRepo.Add(updatedRecipe);
				recipe = new();
			}

			recipe.RecipeId = id;
			recipe.UserId = updatedRecipe.UserId;
			recipe.Title = updatedRecipe.Title;
			recipe.Slug = updatedRecipe.Title;
			recipe.Description = updatedRecipe.Description;
			recipe.DateCreated = updatedRecipe.DateCreated;
			recipe.DateUpdated = DateTime.UtcNow;
			recipe.ConcurrencyStamp = Guid.NewGuid().ToString();

			this.workUnit.RecipeRepo.Update(recipe);

			foreach (var updatedIngredient in updatedRecipe.Ingredients)
			{
				var ingredient = recipe.IngredientNavProp.First(i => i.IngredientId == updatedIngredient.IngredientId);

				ingredient.IngredientId = updatedIngredient.IngredientId!;
				ingredient.RecipeId = id;
				ingredient.Title = updatedIngredient.Title;
				ingredient.Position = updatedIngredient.Position;
				ingredient.MeasurementId = updatedIngredient.MeasurementId;
				ingredient.MeasurementValue = updatedIngredient.MeasurementValue;
				ingredient.ConcurrencyStamp = Guid.NewGuid().ToString();

				this.workUnit.IngredientRepo.Update(ingredient);
			}
			foreach (var updatedInstruction in updatedRecipe.Instructions)
			{
				var instruction = recipe.InstructionNavProp.First(i => i.InstructionId == updatedInstruction.InstructionId);

				instruction.InstructionId = updatedInstruction.InstructionId!;
				instruction.RecipeId = id;
				instruction.Description = updatedInstruction.Description;
				instruction.Position = updatedInstruction.Position;
				instruction.ConcurrencyStamp = Guid.NewGuid().ToString();

				this.workUnit.InstructionRepo.Update(instruction);
			}
			foreach (var updatedKeywordId in updatedRecipe.KeywordIds)
			{
				var keywordRecipe = recipe.KeywordRecipeNavProp.First(k => (k.RecipeId + k.KeywordId) == (id + updatedKeywordId));

				keywordRecipe.RecipeId = id;
				keywordRecipe.KeywordId = updatedKeywordId;

				this.workUnit.KeywordRecipeRepo.Update(keywordRecipe);
			}
			_ = await this.workUnit.SaveAsync();
			return await this.GetRecipeByIdAsync(id);
		}

		public async Task RemoveRecipeByIdAsync(string id)
		{
			var recipe = await this.workUnit.RecipeRepo.GetByIdAsync(id)
				?? throw new ArgumentNullException(id);
			recipe.ConcurrencyStamp = Guid.NewGuid().ToString();
			this.workUnit.RecipeRepo.Remove(recipe);
			_ = await this.workUnit.SaveAsync();
		}
	}
}
