﻿using AutoMapper;
using RestAPI.FluentValidation.Interfaces.Model;
using RestAPI.FluentValidation.Interfaces.Repository;
using RestAPI.FluentValidation.Interfaces.Service;
using DB = Common.DB.Model;

namespace RestAPI.FluentValidation.Services.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;

        public ItemService( IItemRepository itemRepository , IMapper mapper )
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        public async Task CreateItemAsync( Item element )
        {
            var newItem = new DB.Item ()
            {
                Id = Guid.NewGuid () ,
                Name = element.Name ,
                Description = element.Description ,
                Type = element.Type
            };

            await _itemRepository.CreateDBItemAsync ( newItem );
        }

        public async Task DeleteItemAsync( Guid id )
        {
            await _itemRepository.DeleteDBItemAsync ( id );
        }

        public async Task<IEnumerable<Item>> GetItemsAsync( string name , int limit )
        {
            var retValue = await _itemRepository.GetDBItemListAsync ( name , limit );
            return _mapper.Map<IEnumerable<Item>> ( retValue );
        }

        public async Task<Item> ReadItemAsync( Guid id )
        {
            var retValue = await _itemRepository.ReadDBItemAsync ( id );
            return _mapper.Map<Item> ( retValue );
        }

        public async Task UpdateItemAsync( Item element )
        {
            var updatedItem = new DB.Item ()
            {
                Id = element.Id ,
                Name = element.Name ,
                Description = element.Description ,
                Type = element.Type ,
                Modified = DateTime.UtcNow
            };
            await _itemRepository.UpdateDBItemAsync ( updatedItem );
        }
    }
}
