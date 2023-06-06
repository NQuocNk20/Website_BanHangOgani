using BanHangOgani.Models;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.AspNetCore.Mvc;

namespace BanHangOgani.Repository
{
    public interface ICategoryReposistory
    {
        public bool Create(Category category);
        public bool Update(Category category);
        public bool Delete(string categoryId);
        public List<Category> GetAll();
        public Category findByID(string id);


        public bool checkName(string name);
    }
    public class CategoryReposistory : ICategoryReposistory
    {
        private QuanLiBanHangContext _ctx;
        public CategoryReposistory(QuanLiBanHangContext ctx)
        {
            _ctx = ctx;
        }
        public bool Create(Category category)
        {
            _ctx.Categories.Add(category);
            _ctx.SaveChanges();
            return true;
        }

        public bool Delete(string categoryId)
        {
            //find id
            Category c = _ctx.Categories.FirstOrDefault(x => x.CategoryId == categoryId);
            _ctx.Categories.Remove(c);
            _ctx.SaveChanges();
            return true;
        }

        public List<Category> GetAll()
        {
            return _ctx.Categories.ToList();
        }

        public bool Update(Category category)
        {
            Category c = _ctx.Categories.FirstOrDefault(x => x.CategoryId == category.CategoryId);
            if (c != null)
            {
                _ctx.Entry(c).CurrentValues.SetValues(category);
                _ctx.SaveChanges();

            }
            return true;
        }
        public Category findByID(string id)
        {
            Category c = _ctx.Categories.FirstOrDefault(x => x.CategoryId == id);
            return c;
        }

        public bool checkName(string name)
        {
            Category c = _ctx.Categories.Where(x => x.Ncategory.Trim() == name.Trim()).FirstOrDefault();
            if (c == null)
                return false;
            else
                return true;

        }


    }
}
