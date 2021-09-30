
using AutoMapper;
using BLL.Models;
using DAL.Models;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Services
{
    public class ImageService : IService<ImageDTO>
    {
        private readonly IMapper _mapper;
        private readonly DataManager dataManager;

        public ImageService(DataManager dataManager, IMapper _mapper)
        {
            this.dataManager = dataManager;
            this._mapper = _mapper;
        }

        public ImageDTO Add(ImageDTO item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            dataManager.RepoImage.Delete(id);
            dataManager.RepoImage.Save();
        }

        public void Delete(ImageDTO item)
        {
            throw new NotImplementedException();
        }

        public void Edit(ImageDTO item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ImageDTO> GetAll()
        {
            List<Image> image = dataManager.RepoImage.GetAll().ToList();
            List<ImageDTO> result = _mapper.Map<List<ImageDTO>>(image);

            return result;
        }

        public ImageDTO GetById(int id)
        {
            Image image = dataManager.RepoImage.Get(id);
            ImageDTO imageDTO = _mapper.Map<ImageDTO>(image);
            return imageDTO;
        }
    }
}
