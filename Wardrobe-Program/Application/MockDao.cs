﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Wardrobe_Program
{
    /// <summary>
    /// An in-memory GarmentDao that can be used for testing/mocking
    /// </summary>
    public class MockDao : IDao<IGarment>
    {
        public IGarment Retrieve(long id) {
            var retrievedElement = _data.Find(garment => garment.Id == id);
            return retrievedElement ?? new NullGarment();
        }

        public List<IGarment> ListAll() {
            return _data;
        }

        public List<IGarment> ListSome(params Predicate<IGarment>[] matchers) {
            List<IGarment> filteredData = new();
            foreach (var garment in _data) {
                bool shouldAdd = true;
                foreach (var predicate in matchers) {
                    if (predicate(garment)) continue;
                    shouldAdd = false;
                    break;
                }
                if (shouldAdd) {
                    filteredData.Add(garment);
                }
            }
            return filteredData;
        }

        public void Insert(IGarment element) {
            element.Id = GetNextId();
            _data.Add(element);
        }

        public void Update(long id, IGarment element) {
            var garmentToUpdate = Retrieve(id);
            
            garmentToUpdate.Subtype = element.Subtype;
            garmentToUpdate.Seasons = element.Seasons;
            garmentToUpdate.Materials = element.Materials;
            garmentToUpdate.Brand = element.Brand;
            garmentToUpdate.Note = element.Note;
            garmentToUpdate.Price = element.Price;
            garmentToUpdate.Size = element.Size;
        }

        public void Delete(long id) {
            var idToRemove = _data.FindIndex(garment => garment.Id == id);
            if (idToRemove != -1) {
                _data.Remove(_data[idToRemove]);
            }
        }

        public static MockDao GetPopulatedTestDatabase() {
            MockDao data = new();
            for (int i = 0; i < 15; i++) {
                var seasons = new List<List<string>>
                {
                    new() { "Winter", "Spring" },
                    new() { "Summer", "Autumn" },
                    new() { "Summer" }
                };
                Accessory garment = new()
                {
                    Subtype = Utils.PickOne(new Collection<string> { "Necklace", "Belt", "Watch", "Scarf" }),
                    Brand = Utils.PickOne(new Collection<string> { "Gucci", "D&G", "YSL", "Hugo Boss" }),
                    Price = Utils.PickOne(new Collection<float> { 99, 249, 899, 499 }),
                    Seasons = Utils.PickOne<List<string>>(new Collection<List<string>>(seasons))
                };
                data.Insert(garment);
            }
            return data;
        }

        private long GetNextId() {
            return _nextId++;
        }

        private long _nextId = 0;

        private readonly List<IGarment> _data = new();
    }
}
