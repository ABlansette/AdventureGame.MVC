using AdventureGame.Data;
using AdventureGame.Models.Planet;
using AdventureGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Services
{
    public class PlanetService
    {
        public PlanetService()
        {
        }

        public bool PlanetCreate(PlanetCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {

                var entity =
                    ctx
                        .Planets
                        .Single(u => u.PlanetId == model.PlanetId);


                var newPlanet = new Planet()
                {
                    PlanetaryName = model.PlanetaryName,

                };

                ctx.Planets.Add(newPlanet);
                return ctx.SaveChanges() == 1;
            }
        }

        public List<PlanetListItems> GetPlanets()
        {
            using (var ctx = new ApplicationDbContext())
            {

                var planetentity = ctx.Planets;

                var planetListItems = new List<PlanetListItems>();

                foreach (var item in planetentity)
                {
                    var projectListItem = new PlanetListItems()
                    {
                        PlanetId = item.PlanetId,
                        PlanetaryName = item.PlanetaryName,
                        NumOfBadGuys = item.NumOfBadGuys
                    };

                    planetListItems.Add(projectListItem);
                }

                return planetListItems;

            }
        }

        public PlanetDetails GetPlanetById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                // Title, PlanetId, Description, CreatorName, CreatorUserName
                var projectEntity =
                    ctx
                        .Planets
                        .Single(e => e.PlanetId == id);

                return new PlanetDetails
                {
                    PlanetaryName = projectEntity.PlanetaryName,
                    PlanetId = projectEntity.PlanetId,
                    NumOfBadGuys = projectEntity.NumOfBadGuys,

                };
            }
        }

        public bool UpdatePlanet(PlanetEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Planets
                        .Single(e => e.PlanetId == model.PlanetId);
                entity.PlanetaryName = model.PlanetaryName;
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletePlanet(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Planets
                        .Single(e => e.PlanetId == id);
                ctx.Planets.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }

    }
}
