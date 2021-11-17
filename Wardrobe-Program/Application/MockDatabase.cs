﻿using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace Wardrobe_Program
{
    /// <summary>
    /// An in-memory GarmentDao that can be used for testing/mocking
    /// </summary>
    public class MockDatabase : IDao<Garment>
    {
        public Garment Retrieve(long id) {
            return _data.Find(garment => garment.Id == id);
        }

        public List<Garment> ListAll() {
            return _data;
        }

        public void Insert(Garment element) {
            element.Id = GetNextId();
            _data.Add(element);
        }

        public void Update(long id, Garment element) {
            var garmentToUpdate = Retrieve(id);
            
            garmentToUpdate.Name = element.Name;
            garmentToUpdate.Seasons = element.Seasons;
            garmentToUpdate.Materials = element.Materials;
            garmentToUpdate.Brand = element.Brand;
            garmentToUpdate.Notes = element.Notes;
            garmentToUpdate.Price = element.Price;
            garmentToUpdate.Size = element.Size;
        }

        public MockDatabase GetPopulatedTestDatabase() {
            MockDatabase data = new();
            data._data.AddRange(new List<Garment>{ new Accessory(), new Shoe(), new Outerwear(), new Top() });
            return data;
        }

        private long GetNextId() {
            return _nextId++;
        }

        private long _nextId = 0;

        private readonly List<Garment> _data = new();
    }
}
