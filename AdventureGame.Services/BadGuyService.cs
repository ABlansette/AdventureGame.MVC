using AdventureGame.Data;
using AdventureGame.Models.BadGuy;
using AdventureGame.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Services
{
    public class BadGuyService
    {
        public BadGuyService()
        {
        }
        public bool BadGuyCreate(BadGuyCreate model)
        {
            var newBadGuy = new BadGuy()
            {
                Name = model.Name,
                Level = model.Level,
                XpDropped = model.XpDropped,
                PlanetId = model.PlanetId
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.BadGuys.Add(newBadGuy);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<BadGuyListItems> GetBadGuy()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var collection = new List<BadGuyListItems>();
                foreach (var item in ctx.BadGuys)
                {
                    var newBadGuyListItems = new BadGuyListItems
                    {
                        BadGuyId = item.BadGuyId,
                        Name = item.Name,

                    };
                    collection.Add(newBadGuyListItems);
                }
                return collection;
            }
        }

        public BadGuyDetails GetBadGuyById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .BadGuys
                        .Single(e => e.BadGuyId == id);
                return
                    new BadGuyDetails
                    {
                        Name = entity.Name,
                        Level = entity.Level,
                        Health = entity.Health,
                        Damage = entity.Damage,
                        XpDropped = entity.XpDropped,

                    };
            }
        }

        public bool UpdateBadGuy(BadGuyEdit model)
        {

            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .BadGuys
                        .Single(e => e.BadGuyId == model.BadGuyId);
                entity.Name = model.Name;
                entity.Level = model.Level;
                entity.XpDropped = model.XpDropped;
                entity.PlanetId = model.PlanetId;
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteBadGuy(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .BadGuys
                        .Single(e => e.BadGuyId == id);
                ctx.BadGuys.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
