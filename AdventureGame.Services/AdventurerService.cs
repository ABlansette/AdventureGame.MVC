﻿using AdventureGame.Data;
using AdventureGame.Models.Adventurer;
using AdventureGame.MVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureIsOutThere.Data
{
    public class AdventurerService
    {
        private readonly Guid _adventurerId;
        public AdventurerService(Guid adventurerId)
        {
            _adventurerId = adventurerId;
        }
        public bool CreateAdventurer(AdventurerCreate model)
        {
            var entity =
                new Adventurer()
                {
                    //AdventurerId = _adventurerId,
                    Name = model.Name,
                    Level = 1,
                    PlanetId = 1
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Adventurers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<AdventurerListItem> GetAdventurers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Adventurers
                        .Where(e => e.ownerId == _adventurerId)
                        .Select(
                            e =>
                                new AdventurerListItem
                                {
                                    AdventurerId = e.AdventurerId,
                                    Name = e.Name,
                                    Level = e.Level,
                                    Class = e.Class
                                }
                        );

                return query.ToArray();
            }
        }
        public AdventurerDetails GetAdventurerById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Adventurers
                        .Single(e => e.AdventurerId == id);
                           return
                                new AdventurerDetails
                                {
                                    AdventurerId = entity.AdventurerId,
                                    Name = entity.Name,
                                    Health = entity.Health,
                                    Damage = entity.Damage,
                                    Level = entity.Level,
                                    PlanetId = entity.PlanetId
                                };
            }
        }
    }

    public bool UpdateAdventurer(AdventurerEdit model)
    {
        using (var ctx = new ApplicationDbContext())
        {
            var entity =
                ctx
                    .Adventurers
                    .Single(e => e.AdventurerId == model.AdventurerId);

            entity.Name = model.Name;

            return ctx.SaveChanges() == 1;
        }
    }
}