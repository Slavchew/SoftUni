using AutoMapper;
using Demo.Models;
using System.Linq;

namespace Demo
{
    public class SongsToViewModelProfile : Profile
    {
        public SongsToViewModelProfile()
        {
            this.CreateMap<Song, SongViewModel>()
                    .ForMember
                    (
                        x => x.Artists,
                        opt => opt.MapFrom(s => string.Join(", ", s.SongArtists.Select(sa => sa.Artist.Name)))
                    )
                    .ForMember
                    (
                        x => x.LastModified,
                        opt => opt.MapFrom(x => x.ModifiedOn ?? x.CreatedOn)
                    ).ReverseMap();
        }
    }
}
