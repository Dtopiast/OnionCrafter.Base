using AutoMapper;
using OnionCrafter.Base.DTOs.General;
using OnionCrafter.Base.Entities.General;

namespace OnionCrafter.Base.Utils
{
    /// <summary>
    /// Provides extension methods for AutoMapper.
    /// </summary>
    public static class AutoMapperExtensions
    {
        /// <summary>
        /// Maps an entity to a DTO using AutoMapper.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <typeparam name="TDTO">The type of the DTO.</typeparam>
        /// <param name="mapper">The AutoMapper instance.</param>
        /// <param name="entity">The entity to be mapped.</param>
        /// <returns>The mapped DTO.</returns>

        public static TDTO MapEntityToDTO<TEntity, TDTO>(this IMapper mapper, TEntity entity)
            where TEntity : class, IBaseEntity
            where TDTO : class, IBaseDTO
        {
            return mapper.Map<TEntity, TDTO>(entity).ThrowIfNull();
        }

        /// <summary>
        /// Extension method to map an entity object to a DTO object using an IMapper instance.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity object.</typeparam>
        /// <typeparam name="TDTO">The type of the DTO object.</typeparam>
        /// <param name="mapper">The IMapper instance used for mapping.</param>
        /// <param name="entity">The entity object to map.</param>
        /// <param name="options">Additional mapping options.</param>
        /// <returns>The mapped DTO object.</returns>
        public static TDTO MapEntityToDTO<TEntity, TDTO>(this IMapper mapper, TEntity entity, Action<IMappingOperationOptions<TEntity, TDTO>> options)
            where TEntity : class, IBaseEntity
            where TDTO : class, IBaseDTO
        {
            return mapper.Map(entity, options).ThrowIfNull();
        }

        /// <summary>
        /// Extension method to check if an IMapper instance is null and throw an exception if it is.
        /// </summary>
        /// <param name="mapper">The IMapper instance to check.</param>
        /// <returns>The same IMapper instance.</returns>
        public static IMapper CheckMapperIsNull(this IMapper mapper)
        {
            return mapper.ThrowIfNull();
        }
    }
}