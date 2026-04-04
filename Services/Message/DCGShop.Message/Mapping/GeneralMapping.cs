using AutoMapper;
using DCGShop.Message.DAL.Entities;
using DCGShop.Message.Dtos;

namespace DCGShop.Message.Mapping
{
	public class GeneralMapping :Profile
	{
		public GeneralMapping()
		{
			CreateMap<UserMessage, ResultMessageDto>().ReverseMap();
			CreateMap<UserMessage, CreateMessageDto>().ReverseMap();
			CreateMap<UserMessage, UpdateMessageDto>().ReverseMap();
			CreateMap<UserMessage, GetByIdMessageDto>().ReverseMap();
			CreateMap<UserMessage, ResultInboxMessageDto>().ReverseMap();
			CreateMap<UserMessage, ResultSendboxMessageDto>().ReverseMap();
		}
	}
}
