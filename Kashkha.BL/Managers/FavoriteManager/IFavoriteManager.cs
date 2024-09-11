using Kashkha.BL.DTOs;

public interface IFavoriteManager
{
    Task<FavoriteDTO> AddFavoriteAsync(string userId, int productId);
    Task<bool> RemoveFavoriteAsync(int favoriteId);
    Task<IEnumerable<FavoriteDTO>> GetUserFavoritesAsync(string userId);
    Task<bool> IsFavoriteAsync(string userId, int productId);
}