﻿using SmartPhoneShop.Data.Infrastructure;
using SmartPhoneShop.Data.Repositories;
using SmartPhoneShop.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPhoneShop.Service
{
    public interface IProductService
    {
        Product Add(Product product);

        void Update(Product product);

        void Delete(int id);

        IEnumerable<Product> GetAll();

        IEnumerable<Product> GetAll(string keyword);

        IEnumerable<Product> GetAllPaging(int page, int pageSize, out int totalRow);

        IEnumerable<Product> GetAllByCategory(int CategoryID, int page, int pageSize, out int totalRow);

        Product GetByID(int id);

        IEnumerable<Product> GetAllTagPaging(string tag, int page, int pageSize, out int totalRow);

        void SaveChanges();
    }

    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;

        private IUnitOfWork _unitOfWork;

        public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            this._productRepository = productRepository;
            this._unitOfWork = unitOfWork;
        }

        public Product Add(Product product)
        {
            return _productRepository.Add(product);
        }

        public void Delete(int id)
        {
            _productRepository.Delete(id);
        }

        public IEnumerable<Product> GetAll()
        {
            return _productRepository.GetAll(new string[] { "ProductCategory" });
        }

        public IEnumerable<Product> GetAll(string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
                return _productRepository.GetAll();
            else
            {
                return _productRepository.GetMulti(
                    x => x.Name.Contains(keyword)
                    || x.Description.Contains(keyword)
                    || x.ID.ToString().Contains(keyword));
            }
        }

        public IEnumerable<Product> GetAllByCategory(int CategoryID, int page, int pageSize, out int totalRow)
        {
            return _productRepository.GetMultiPaging(x => x.ProductCategoryID == CategoryID
            , out totalRow, page, pageSize, new string[] { "Product" });
        }

        public IEnumerable<Product> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            return _productRepository.GetMultiPaging(null, out totalRow, page, pageSize);
        }

        public IEnumerable<Product> GetAllTagPaging(string tag, int page, int pageSize, out int totalRow)
        {
            return _productRepository.GetAllByTagPaging(tag, pageSize, pageSize, out totalRow);
        }

        public Product GetByID(int id)
        {
            return _productRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Product product)
        {
            _productRepository.Update(product);
        }
    }
}