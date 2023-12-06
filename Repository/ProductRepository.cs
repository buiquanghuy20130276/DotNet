using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using ShoeShop.Dao;
using ShoeShop.Interfaces;
using ShoeShop.Models;
using ShoeShop.Models.Enum;
using ShoeShop.Models.ViewModel;
using System.Collections.Generic;
using System.Drawing.Printing;
using static System.Formats.Asn1.AsnWriter;

namespace ShoeShop.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext context;

        public ProductRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
       
        public async Task<ProductListViewModel> GetAllProduct(string sort, int pageProduct, int pageSize)
        {
            IQueryable<Product> products = productListSort(sort,context.Products.Include(a => a.Image));

            // Lấy dữ liệu sản phẩm và trả về view
            List<Product> productList = await products
                .Skip((pageProduct - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            int totalItems = await context.Products.CountAsync();

            ProductListViewModel viewModel = new ProductListViewModel
            {
                Products = productList,
                PagingInfo = new PagingInfo
                {
                    TotalItems = totalItems,
                    ItemPerPage = pageSize,
                    CurrentPage = pageProduct
                }
            };

            return viewModel;
        }


        public async Task<IEnumerable<Product>> GetProductByBrand(Brand brand)
        {
            return await context.Products.Include(a => a.Image).Where(x => x.Brand.Equals(brand)).ToListAsync();
        }
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await context.Products.Include(a => a.Image).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByCategory(Category Category)
        {
              return await context.Products.Include(a => a.Image).Where(x => x.Category.Equals(Category)).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByGender(Gender gender)
        {
            return await context.Products.Include(a => a.Image).Where(x => x.Gender.Equals(gender)).ToListAsync();

        }
        public async Task<IEnumerable<Product>> GetProductByName(string name)
        {
            return await context.Products.Include(a => a.Image).Where(x => x.Title.Equals(name)).ToListAsync();
        }

        public async Task<Product> getProductByIdAsNoTracking(int id)
        {
            return await context.Products.Include(a => a.Image).FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Product> getProductByIdAsyn(int id)
        {
            return await context.Products.Include(a => a.Image).AsNoTracking().FirstOrDefaultAsync(a => a.Id == id);

        }


        public bool Add(Product product)
        {
            context.Add(product);
            return Save();
        }
        public bool Delete(int id)
        {
            var product = context.Products.Find(id);
            if (product == null)
            {
                return false; // Không tìm thấy sản phẩm để xóa
            }

            context.Products.Remove(product);
            return Save();
        }
        public bool Save()
        {
            var save = context.SaveChanges();
            return save > 0 ? true : false;
        }

        public async Task<ProductListViewModel> Search(string keyword, int page, int pageSize)
        {
            return new ProductListViewModel
            {
                Products = await context.Products.Include(a => a.Image).Where(p => p.Title.Contains(keyword)).Skip((page - 1) * pageSize).Take(pageSize).ToListAsync(),
                PagingInfo = new PagingInfo
                {
                    TotalItems = await context.Products.CountAsync(p => p.Title.Contains(keyword)),
                    ItemPerPage = pageSize,
                    CurrentPage = page,
                }
            };
        }
        public bool Update(Product product)
        {
            context.Update(product);
            return Save();
        }



        public async Task<IEnumerable<Product>> GetProductsDeal()
        {
            return await context.Products.Include(a => a.Image).Where(p => p.Sale != 0).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsHint()
        {
            return await context.Products.Include(a => a.Image).Take(10).ToListAsync();
        }


        public async Task<ProductListViewModel> GetProductsByCategory(Category category, Gender gender, string sort , int pageProduct, int pageSize)

        {
            IQueryable<Product> products;
            if (gender == Gender.All)
            {
                products = productListSort(sort, context.Products.Include(a => a.Image).Where(x => x.Category == category));
            }
            else
            {
                products = productListSort(sort, context.Products.Include(a => a.Image).Where(x => x.Category == category && x.Gender == gender));
            }
            List<Product> productList = await products
              .Skip((pageProduct - 1) * pageSize)
              .Take(pageSize)
              .ToListAsync();

            int totalItems = await context.Products.CountAsync();

            ProductListViewModel viewModel = new ProductListViewModel
            {
                Products = productList,
                PagingInfo = new PagingInfo
                {
                    TotalItems = totalItems,
                    ItemPerPage = pageSize,
                    CurrentPage = pageProduct
                }
            };

            return viewModel;
        }

        public IQueryable<Product> productListSort(string sort, IQueryable<Product> lsProduct)
        {
            IQueryable<Product> products = lsProduct;
            if (sort == "price_lowest")
            {
                products = products.OrderBy(p => p.Price);
            }
            else if (sort == "price_highest")
            {
                products = products.OrderByDescending(p => p.Price);
            }
            // Sắp xếp theo tên
            else if (sort == "name_asc")
            {
                products = products.OrderBy(p => p.Title);
            }
            else if (sort == "name_desc")
            {
                products = products.OrderByDescending(p => p.Title);
            }

            return products;
        }
    }
    }
