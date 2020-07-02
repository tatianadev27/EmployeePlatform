using AutoMapper;
using EmployeePlatform.Database.Models;
using EmployeePlatform.Entities;
using System;
using System.Collections;
using System.Collections.Generic;

namespace EmployeePlatform.DataAccess.Mappers
{
    /// <summary>
    /// Mapper data
    /// </summary>
    /// <typeparam name="Entity">Entity initial</typeparam>
    /// <typeparam name="EntityResult">Entity Result</typeparam>
    public class GenericMapper<Entity, EntityResult>
        where Entity : class
    {
        /// <summary>
        /// Simple Mapper Data
        /// </summary>
        /// <param name="data">Data for mapper</param>
        /// <returns></returns>
        public EntityResult Map(Entity data)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Entity, EntityResult>());
            return config.CreateMapper().Map<EntityResult>(data);
        }

        /// <summary>
        /// Mapper List
        /// </summary>
        /// <param name="list">List for mapper</param>
        /// <returns></returns>
        public IEnumerable<EntityResult> MapList(IEnumerable<Entity> list)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Entity, EntityResult>());
            return config.CreateMapper().Map<IEnumerable<EntityResult>>(list);
        }
    }
}
