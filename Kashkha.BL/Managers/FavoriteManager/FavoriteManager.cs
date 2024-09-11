using AutoMapper;
using Kashkha.BL.DTOs;
using Kashkha.DAL;

public class FavoriteManager : IFavoriteManager
{
    private readonly IFavoriteRepository _favoriteRepository;
    private readonly IMapper _mapper;

    public FavoriteManager(IFavoriteRepository favoriteRepository, IMapper mapper)
    {
        _favoriteRepository = favoriteRepository;
        _mapper = mapper;
    }

    public async Task<FavoriteDTO> AddFavoriteAsync(string userId, int productId)
    {
        if (await _favoriteRepository.ExistsAsync(userId, productId))
            throw new InvalidOperationException("Favorite already exists");

        var favorite = new Favorite { UserId = userId, ProductId = productId };
        var result = await _favoriteRepository.AddAsync(favorite);
        return _mapper.Map<FavoriteDTO>(result);
    }

    public async Task<bool> RemoveFavoriteAsync(int favoriteId)
    {
        return await _favoriteRepository.RemoveAsync(favoriteId);
    }

    public async Task<IEnumerable<FavoriteDTO>> GetUserFavoritesAsync(string userId)
    {
        var favorites = await _favoriteRepository.GetByUserIdAsync(userId);
        return _mapper.Map<IEnumerable<FavoriteDTO>>(favorites);
    }

    public async Task<bool> IsFavoriteAsync(string userId, int productId)
    {
        return await _favoriteRepository.ExistsAsync(userId, productId);
    }
}