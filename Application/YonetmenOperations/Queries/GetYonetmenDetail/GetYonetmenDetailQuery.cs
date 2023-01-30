using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Common;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.YonetmenOperations.Queries.GetYonetmenDetail
{
    public class GetYonetmenDetailQuery
    {
        public int YonetmenId { get; set; }
        public readonly IMovieStoreDbContext _context;
        public readonly IMapper _mapper;

        public GetYonetmenDetailQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public YonetmenDetailViewModel Handle()
        {
            var yonetmen = _context.Yonetmenler.SingleOrDefault(x=>x.Id == YonetmenId);
            if(yonetmen is null)
                throw new InvalidOperationException("Yonetmen Bulunamadi.");
            return _mapper.Map<YonetmenDetailViewModel>(yonetmen);
        }
    }

    public class YonetmenDetailViewModel
    {
        public int Id { get; set; }
        public string YonetmenAdi { get; set; }
        public string YonetmenSoyadi { get; set; }
        
        
    }
}